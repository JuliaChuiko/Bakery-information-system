using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using Pryanichek_version_1000.Models;

namespace Pryanichek_version_1000.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public bool connToAccounts;
        public bool connToPryanick;
        
        //Подключаемся к базе с аккаунтами
        public NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5434;Database=Users;Username=manager_ad;Password=julia");
        public NpgsqlConnection conn2 = new NpgsqlConnection("Host=localhost;Port=5434;Database=new_pryanick;Username=manager_ad;Password=julia");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            connToAccounts = false;
            connToPryanick = false;
        }
        public string MakeMd5Hash(string password)
        {
            // step 1, calculate MD5 hash from password
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        [HttpGet]
        public IActionResult MakeUserAccount(User user)
        {
            if (string.IsNullOrEmpty(user.Login))
            {
                ModelState.AddModelError("Login", "* Обязательное поле");

            }
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", "* Обязательное поле");

            }
            /*if (string.IsNullOrEmpty(user.RoleName))
            {
                ModelState.AddModelError("RoleName", "* Обязательное поле");
            }*/
            string new_password = MakeMd5Hash(user.Password);
            string login = user.Login;
            string roleName = user.RoleName;

            //Команда добавления новой записи в таблицу аккаунтов
            string c = String.Format(@"insert into ""UsersAccounts"" (""Login"",""Password"",""RoleName"") values ('{0}','{1}','{2}')",login,new_password,roleName);
            // NpgsqlCommand command = new NpgsqlCommand(@"insert into ""UsersAccounts"" (""Login"",""Password"",""RoleName"") values ('"+login+"' , '"+new_password +"', '"+roleName+"')");
            NpgsqlCommand command = new NpgsqlCommand(c);
            command.Connection = conn;
            
            NpgsqlDataReader dataReader_1;
            dataReader_1 = command.ExecuteReader();
            dataReader_1.Read();
            
            return View("AdminIndex");
        }

   
        public IActionResult MakeAccout()
        {
            return RedirectToAction("MakeAccount", "Adnim", conn);
        }

        public bool Check_is_admin(Loginn user)
        {
            string Login = user.Login;
            string Password = user.Password;
            if (Login == "manager_ad" && Password == "julia") //проверяем является ли он админом?
            {
                conn.Open();                                   //если да, то подключаем его к базе new_pryanick
                connToAccounts = true;
                return true;
            }
            else return false;
            
        }
        public IActionResult Check_in_base(Loginn s)
        {
            bool find =false;
            NpgsqlCommand command1 = new NpgsqlCommand(@"select us.""Login"",us.""Password"", us.""RoleName"",us.""TelNo"",us.""FirstName"" || ' ' || us.""LastName""
            from ""UsersAccounts2"" as us");
            command1.Connection = conn;
            conn.Open();
            NpgsqlDataReader dataReader_1;
            string login="";
            string password="";
            string role="";
            string TelNo = "";
            string fullname = "";
            dataReader_1 = command1.ExecuteReader();
            while (dataReader_1.Read())
            {

               login = string.Format("{0}", dataReader_1[0].ToString().Trim());
               password = string.Format("{0}", dataReader_1[1].ToString().Trim());
               role= string.Format("{0}", dataReader_1[2].ToString().Trim());
               TelNo = string.Format("{0}", dataReader_1[3].ToString().Trim());
               fullname = string.Format("{0}", dataReader_1[4].ToString().Trim());
                if (password == MakeMd5Hash(s.Password) && login == s.Login ) { find = true; break; }
            }
            conn.Close();
            conn2.Open();

            string d = String.Format(@"select ""IsFired"" from ""Staff"" where ""TelNo""='{0}'",TelNo);
            NpgsqlCommand c = new NpgsqlCommand(d);
            c.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = c.ExecuteReader();
            bool find2 = true;
            while (dataReader_3.Read())
            {
                if(string.Format("{0}", dataReader_3[0].ToString().Trim()) == "False") { find2 = false; }
                
            }
            conn2.Close();

                if (find==true && find2==false)
            {
                if(role== "Пекарь" || role=="Кондитер")
                {
                    return RedirectToAction("SetLogin", "Baker", new { l = s.Login, p = s.Password, t = TelNo, n = fullname });
                    //return View("~/Views/Baker/Index.cshtml",s);
                }
                else if(role=="Владелец")
                {
                    return RedirectToAction("SetLogin", "Owner", new { l = s.Login, p = s.Password, t = TelNo, n = fullname });
                }
                else if (role == "Продавец")
                {
                    return RedirectToAction("SetLogin", "Seller", new { l = s.Login, p = s.Password, t = TelNo , n=fullname }) ;
                    //return View("~/Views/Seller/Index.cshtml", s);
                }
              
                return View("SignIn");

            }
            else
            {
                ViewBag.Message = "* Введенные данные некорректны! ";
                return View("SignIn");
            }

        }
         public IActionResult Index() {
             return View("Index"); 
             }
       /* public IActionResult Index() => RedirectToAction("Index","Product");*/
        
        public IActionResult SignOut()
        {
            conn.Close();
            connToAccounts = false;
            connToPryanick = false;
            return View("~/Home/Index");
        }

        [HttpPost]
        public IActionResult Check_login(Loginn user)
        {
            if(ModelState.IsValid)
            {

                if (Check_is_admin(user))
                {
                    conn.Close();
                    return View("~/Views/Admin/Index.cshtml");
                  
                }
                else
                {
                    return Check_in_base(user);
                }
            }
            else
            {
                return View("SignIn");
            }
        }
        public IActionResult Privacy()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }
        public IActionResult Signin()
        {
            return View("~/Views/Home/Signin.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
