//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace AutoRecon.WebUI.Pages
//{
//    public class LoginModel : PageModel
//    {
//        private readonly SignInManager<IdentityUser> _signInManager;

//        [BindProperty]
//        public string Username { get; set; }
//        [BindProperty]
//        public string Password { get; set; }
//        public LoginModel(SignInManager<IdentityUser> signInManager)
//        {
//            _signInManager = signInManager;
//        }

//        public IActionResult OnGet()
//        {
//            if (_signInManager.IsSignedIn(User))
//            {
//                return LocalRedirect("~/Dashboard");
//            }
//            return Page();
//        }

//        public IActionResult OnPost()
//        {
//            if (_signInManager.IsSignedIn(User))
//            {
//                return LocalRedirect("~/Dashboard");
//            }
//            return Page();
//        }
//    }
//}