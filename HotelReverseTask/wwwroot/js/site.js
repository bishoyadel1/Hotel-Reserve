$(document).ready(function () {
    // AJAX Room Search
    $("#bookingForm").submit(function (event) {
        event.preventDefault();

        let form = $(this);
        let url = form.attr("action");

        $.ajax({
            type: "GET",
            url: url,
            data: form.serialize(),
            beforeSend: function () {
                $("#roomResults").html("<p>Loading rooms...</p>");
            },
            success: function (response) {
                $("#roomResults").html(response);
            },
            error: function () {
                $("#roomResults").html("<p class='text-danger'>Error fetching available rooms.</p>");
            }
        });
    });

    // AJAX Pagination
    $(document).on("click", ".pagination-list a", function (event) {
        event.preventDefault();
        var url = $(this).attr("href");

        $.ajax({
            url: url,
            type: "GET",
            success: function (response) {
                $("#roomResults").html(response);
            },
            error: function () {
                $("#roomResults").html("<p class='text-danger'>Error loading rooms.</p>");
            }
        });
    });
});


 
$(document).ready(function () {
 
    $("#addToBasket").click(function () {
        let bookingData = {
            RoomId: $("#RoomId").val(),
            CheckInDate: $("#CheckInDate").val(),
            CheckOutDate: $("#CheckOutDate").val(),
            Adults: parseInt($("#Adults").val()),
            Children: parseInt($("#Children").val()),
            TotalRooms: parseInt($("#TotalRooms").val())
        };

        $.ajax({
            url: "/Hotel/AddToBasket",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(bookingData),
            success: function (response) {
                if (response.success) {
                    alert("Room added to basket!");
                } else {
                    alert("Error: " + response.message);
                }
            },
            error: function () {
                alert("Error adding room to basket.");
            }
        });
    });

 
    $("#bookingForm").submit(function (event) {
        event.preventDefault();  

        let bookingData = {
            RoomId: $("#RoomId").val(),
            CheckInDate: $("#CheckInDate").val(),
            CheckOutDate: $("#CheckOutDate").val(),
            Adults: parseInt($("#Adults").val()),
            Children: parseInt($("#Children").val()),
            TotalRooms: parseInt($("#TotalRooms").val())
        };

        $.ajax({
            url: "/Hotel/BookRoom",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(bookingData),
            success: function (response) {
                if (response.success) {
                    $("#bookingMessage").html(
                        "<p class='text-success'>" + response.message + "</p>"
                    );
                    $("#bookingForm")[0].reset();  
                } else {
                    $("#bookingMessage").html(
                        "<p class='text-danger'>" + response.message + "</p>"
                    );
                }
            },
            error: function () {
                $("#bookingMessage").html(
                    "<p class='text-danger'>Error submitting booking.</p>"
                );
            }
        });
    });
});