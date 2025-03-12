using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HotelReverseTask.Models;

namespace HotelReverseTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager ,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.roleManager = _roleManager;
        }
       
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null) {
                    var result = await userManager.CheckPasswordAsync(user, model.Password);
                    if (result)
                    {
                        await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                        var userNow = await userManager.GetUserAsync(User);

                        return RedirectToAction("Index", "Hotel");
                    }
                    else
                        ModelState.AddModelError(string.Empty,"Invaild Password");

                }
                ModelState.AddModelError(string.Empty, " Email OR Password Invaild  ");

            }
            
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
 
      
        public async Task<IActionResult> ShowUserProfile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            var profileViewModel = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
            return View(profileViewModel);
        }

        public async Task<IActionResult> EditUserProfile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            var profileViewModel = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
            return View(profileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.Phone;
            var updateResult = await userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return View(model);
            }
            return RedirectToAction(nameof(ShowUserProfile));
        }
 
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = new IdentityUser()
                {
                    
                    Email = model.Email,
                    UserName = model.Name,
                    

                };
        
                var result = await userManager.CreateAsync(user,model.Password);
          

                if (result.Succeeded )
                {

                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var Error in result.Errors)
                        ModelState.AddModelError(string.Empty, Error.Description);
                    
                }



            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index","Hotel");
            }
            return RedirectToAction("Login");
        }
    }
}
