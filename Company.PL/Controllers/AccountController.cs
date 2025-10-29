using Company.DAL.Models;
using Company.PL.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<ApplicatiionUser> userManager;
        private readonly SignInManager<ApplicatiionUser> signInManager;

        public AccountController(UserManager<ApplicatiionUser> userManager, SignInManager<ApplicatiionUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicatiionUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName
            };

            // إنشاء المستخدم باستخدام كلمة المرور
            var result = userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                // يمكنك تسجيل الدخول تلقائيًا أو إعادة التوجيه
              //  signInManager.SignInAsync(user, isPersistent: false).Wait();
                return RedirectToAction("Login");
            }

            // إذا فشل التسجيل، عرض الأخطاء
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
   
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var User = userManager.FindByEmailAsync(model.Email).Result;
            if(User is not null)
            {
                bool flag = userManager.CheckPasswordAsync(User, model.Password).Result;
                if(flag)
                {
                    // محاولة تسجيل الدخول
                    var result = signInManager.PasswordSignInAsync(User, model.Password, model.RememberMe, false).Result;

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home"); // نجاح الدخول
                    }
                }

            }
           

            ModelState.AddModelError("", "Invalid login attempt. Please check your email or password.");
            return View(model);
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction("Login");
        }
    }
}
