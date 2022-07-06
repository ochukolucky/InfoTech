using Microsoft.AspNetCore.Mvc;

namespace InfoTech.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            UserAccount userAccount = new UserAccount();
            return View(userAccount);
        }

        [HttpPost]
        public IActionResult Index(UserAccount login)

        {

            InfoTechDbContext _dbContext = new InfoTechDbContext();

            var user = _dbContext.UserAccounts.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();

            if (user != null)
            {

                ViewBag.Message = "Success full login";

            }
            else
            {

                ViewBag.Message = "Invalid login detail.";

            }

            return View(login);

        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserAccount userAccount)
        {
            try
            {
                InfoTechDbContext _dbContext = new InfoTechDbContext();
                if (_dbContext.UserAccounts.Any(x => x.UserName == userAccount.UserName))
                {
                    ViewBag.Message = "This account has already existed";
                    return View();
                }
                else
                {
                    var rgisterUser = new UserAccount()
                    {
                        UserName = userAccount.UserName,
                        Password = userAccount.Password,
                    };
                    _dbContext.UserAccounts.Add(rgisterUser);
                    _dbContext.SaveChanges();
                    ViewBag.Message = "User account created successfully";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error while creating user account";
            }

            return View(userAccount);
        }


    }
}