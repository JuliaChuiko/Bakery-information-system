using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Pryanichek_version_1000.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Controllers
{
    public class OwnerController : Controller
    {
        static string Login;
        static string Password;
        static bool OpenConnection = false;
        static string TelNo;
        static int StaffNo;
        static int BakeryNo;
        static string OrderDate = "";
        static int  BakerNo;
        public string BakerName = "";


        static string SellerFullName="";
        static string connection;
        static decimal EndSummary = 0;
        static NpgsqlConnection conn2;
        static int ExeptionReceipt = 0;
        static bool exp = false;
        static int exind = 0;
        static int ClientNo;
        //public new_pryanickContext pryanickContext = new new_pryanickContext();
        public static List<Product> products = new List<Product>();
        public static List<ClassClient> clients = new List<ClassClient>();
        public static List<Item> card = new List<Item>();
        public static List<Item> newcard = new List<Item>();
        public static IEnumerable<Product> MakeList() => products;
        public static IEnumerable<ClassClient> MakeClientList() => clients;

      
        public IActionResult SetLogin(string l, string p,string t,string n)
        {
            Loginn user = new Loginn();
            user.Login = l;
            user.Password = p;
            Login = l;
            Password = p;
            connection = String.Format("Host=localhost;Port=5434;Database=new_pryanick;Username={0};Password={1}", Login, Password);
            conn2 = new NpgsqlConnection(connection);
            TelNo = t;
            SellerFullName = n;
            StaffNo = FindStaffNo();
            return View("Index",user);
        }
        public int FindStaffNo()
        {
            int StaffNo = 0;

            OpenConnection = true;
            conn2.Open();
            string S = String.Format(@"select ""StaffNo"",""StaffBakeryNo"" from ""Staff"" where ""TelNo""='{0}'", TelNo);
            NpgsqlCommand command3 = new NpgsqlCommand(S);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                StaffNo = Convert.ToInt32(dataReader_3[0].ToString().Trim());
                BakeryNo = Convert.ToInt32(dataReader_3[1].ToString().Trim());
            }
            conn2.Close();
            OpenConnection = false;
            return StaffNo;
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult SignOut()
        {
            if (OpenConnection == true) conn2.Close();

            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult Information()
        {
            List<Bakery> baks = new List<Bakery>();
            string bakeries = String.Format(@"select ""BakeryName"", ""BakeryNo"" from ""Bakery"" where ""BakeryNo""!=25 order by ""BakeryNo"" asc");
            conn2.Open();
            OpenConnection =true;
            NpgsqlCommand command3 = new NpgsqlCommand(bakeries);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                baks.Add(new Bakery
                {
                    BakeryName = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[1])
                });
                            }
            conn2.Close();
            OpenConnection = false;
            TempData["Bakeries"] = baks;
            return View("Bakeries");
        }
        [HttpPost]
        public IActionResult Details(NewBakery bakery)
        {
            int BakeryNo = bakery.BakeryNo;
            string ThisBakery=string.Format(@"select b.""BakeryName"", b.""City"" || ','|| b.""Street"" || ',' || b.""HouseNumber"", b.""TelNo"" 
                                            from ""Bakery"" b, ""Staff"" s where ""BakeryNo"" = {0}  and s.""StaffBakeryNo"" = b.""BakeryNo"" 
                                            group by b.""BakeryName"", b.""City"" || ',' || b.""Street"" || ',' || b.""HouseNumber"", b.""TelNo"" ",BakeryNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(ThisBakery);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            NewBakery bak = new NewBakery();
            bak.BakeryNo = BakeryNo;
            while (dataReader_3.Read())
            {
                bak.BakeryName = string.Format("{0}", dataReader_3[0].ToString().Trim());
                bak.Adress = string.Format("{0}", dataReader_3[1].ToString().Trim());
                bak.TelNo = string.Format("{0}", dataReader_3[2].ToString().Trim());
                
            }
            conn2.Close();
            OpenConnection = false;
            
            string ThisBakery2 = string.Format(@"select count(""StaffNo"") from ""Staff"" where ""StaffBakeryNo""={0} and ""IsFired""='false'  ", BakeryNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command0 = new NpgsqlCommand(ThisBakery2);
            command0.Connection = conn2;
            NpgsqlDataReader dataReader_0;
            dataReader_0 = command0.ExecuteReader();
          
            while (dataReader_0.Read())
            {
                bak.CountWorkers = Convert.ToInt32(dataReader_0[0]);
            }
            conn2.Close();
            OpenConnection = false;

            
            string positions = String.Format(@"select count(s.""StaffNo""),po.""PositionName""
                    from ""Staff"" s, ""Position"" po  where s.""StaffBakeryNo"" = {0} and s.""PositionNo"" = po.""PositionNo"" and s.""IsFired""='false' and
                    po.""PositionNo"" = (select ""PositionNo"" from ""Position"" where s.""PositionNo"" = ""PositionNo"") group by po.""PositionNo""", BakeryNo);
            conn2.Open();
            OpenConnection = true;
            List<string> PositionC = new List<string>();
            NpgsqlCommand command4 = new NpgsqlCommand(positions);
            command4.Connection = conn2;
            NpgsqlDataReader dataReader_4;
            dataReader_4 = command4.ExecuteReader();
            while (dataReader_4.Read())
            {
                PositionC.Add(string.Format("{0}:", dataReader_4[1].ToString().Trim()) + string.Format("{0} чел.", dataReader_4[0].ToString().Trim()));
            }
            conn2.Close();
            OpenConnection = false;
            TempData["Positions"] = PositionC;

            return View("BakeryDetails",bak);

        }

        [HttpPost]
        public IActionResult ShowWorkers(NewBakery b)
        {
            int bakeryNo = b.BakeryNo;
            List<Person> person = new List<Person>();
            string worker = String.Format(@"select s.""StaffNo"",s.""FirstName"" ||' '|| s.""LastName"",s.""DateOfBirth"",s.""Sex"", s.""TelNo"",po.""PositionName"",s.""Salary"", s.""IsFired""
            from ""Staff"" s, ""Position"" po where s.""StaffBakeryNo""={0} and po.""PositionNo""=(select ""PositionNo"" from ""Position"" where s.""PositionNo""=""PositionNo"") and s.""PositionNo""=po.""PositionNo"" ",bakeryNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(worker);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            NewBakery bak = new NewBakery();
            bak.BakeryNo = BakeryNo;
            while (dataReader_3.Read())
            {

                Person p = new Person();
                p.StaffNo = Convert.ToInt32(dataReader_3[0]);
                p.Name = string.Format("{0}", dataReader_3[1].ToString().Trim());
                p.DateOfBirth = (string.Format("{0}", dataReader_3[2].ToString().Trim())).Substring(0,10);
                if (string.Format("{0}", dataReader_3[3].ToString().Trim()) == "M") { p.Sex = "М"; }
                else p.Sex = "Ж";
                p.TelNo = string.Format("{0}", dataReader_3[4].ToString().Trim());
                p.PositionName = string.Format("{0}", dataReader_3[5].ToString().Trim());
                p.Salary= Convert.ToInt32(dataReader_3[6]);
                if(string.Format("{0}", dataReader_3[7].ToString().Trim())=="False") { p.IsFired = "Работает"; }
                else p.IsFired = "Уволен";
                person.Add(p);

            }
            conn2.Close();
            OpenConnection = false;
            TempData["Workers"] = person;
           
            return View("AllStaff");


        }
        [HttpPost]
        public IActionResult ChangeStaff(Person person)
        {
            int stNo = person.StaffNo;
            string s = String.Format(@"select s.""StaffNo"",s.""FirstName"" ||' '|| s.""LastName"",s.""DateOfBirth"",s.""Sex"", s.""TelNo"",po.""PositionName"",s.""Salary"", s.""IsFired""
            from ""Staff"" s, ""Position"" po where s.""StaffNo""={0} and s.""PositionNo""=po.""PositionNo"" ",stNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(s);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            NewBakery bak = new NewBakery();
            bak.BakeryNo = BakeryNo;

            Person p = new Person();
            while (dataReader_3.Read())
            {
               
                p.StaffNo = Convert.ToInt32(dataReader_3[0]);
                p.Name = string.Format("{0}", dataReader_3[1].ToString().Trim());
                p.DateOfBirth = (string.Format("{0}", dataReader_3[2].ToString().Trim())).Substring(0, 10);
                if (string.Format("{0}", dataReader_3[3].ToString().Trim()) == "M") { p.Sex = "М"; }
                else p.Sex = "Ж";
                p.TelNo = string.Format("{0}", dataReader_3[4].ToString().Trim());
                p.PositionName = string.Format("{0}", dataReader_3[5].ToString().Trim());
                p.Salary = Convert.ToInt32(dataReader_3[6]);
                if (string.Format("{0}", dataReader_3[7].ToString().Trim()) == "False") { p.IsFired = "Работает"; }
                else p.IsFired = "Уволен";
            }
            conn2.Close();
            OpenConnection = false;
            return View("UpdateWorker", p);

        }
        [HttpGet]
        public IActionResult Staff(Person pq)
        {
            if (ModelState.IsValid)
            {
                string f;
                if (pq.IsFired == "Уволен") f = "true";
                else f = "false";
                string change = String.Format(@"update ""Staff"" set ""IsFired""='{0}' where ""StaffNo""={1} ", f, pq.StaffNo);
                conn2.Open();
                OpenConnection = true;
                NpgsqlCommand command3 = new NpgsqlCommand(change);
                command3.Connection = conn2;
                NpgsqlDataReader dataReader_3;
                dataReader_3 = command3.ExecuteReader();
                dataReader_3.Read();
                conn2.Close();
                OpenConnection = false;
                return RedirectToAction("Information");
            }
            else
            {
                ViewBag.Err = "* Это поле является обязательным";
                int stNo = pq.StaffNo;
                string s = String.Format(@"select s.""StaffNo"",s.""FirstName"" ||' '|| s.""LastName"",s.""DateOfBirth"",s.""Sex"", s.""TelNo"",po.""PositionName"",s.""Salary"", s.""IsFired""
                from ""Staff"" s, ""Position"" po where s.""StaffNo""={0} and s.""PositionNo""=po.""PositionNo"" ", stNo);
                conn2.Open();
                OpenConnection = true;
                NpgsqlCommand command3 = new NpgsqlCommand(s);
                command3.Connection = conn2;
                NpgsqlDataReader dataReader_3;
                dataReader_3 = command3.ExecuteReader();
                NewBakery bak = new NewBakery();
                bak.BakeryNo = BakeryNo;

                Person p = new Person();
                while (dataReader_3.Read())
                {

                    p.StaffNo = Convert.ToInt32(dataReader_3[0]);
                    p.Name = string.Format("{0}", dataReader_3[1].ToString().Trim());
                    p.DateOfBirth = (string.Format("{0}", dataReader_3[2].ToString().Trim())).Substring(0, 10);
                    if (string.Format("{0}", dataReader_3[3].ToString().Trim()) == "M") { p.Sex = "М"; }
                    else p.Sex = "Ж";
                    p.TelNo = string.Format("{0}", dataReader_3[4].ToString().Trim());
                    p.PositionName = string.Format("{0}", dataReader_3[5].ToString().Trim());
                    p.Salary = Convert.ToInt32(dataReader_3[6]);
                    if (string.Format("{0}", dataReader_3[7].ToString().Trim()) == "False") { p.IsFired = "Работает"; }
                    else p.IsFired = "Уволен";
                }
                conn2.Close();
                OpenConnection = false;
                return View("UpdateWorker", p);
            }
        }
        public IActionResult ChangeStafff(Person person)
        {
            int stNo = person.StaffNo;
            string s = String.Format(@"select s.""StaffNo"",s.""FirstName"" ||' '|| s.""LastName"",s.""DateOfBirth"",s.""Sex"", s.""TelNo"",po.""PositionName"",s.""Salary"", s.""IsFired""
            from ""Staff"" s, ""Position"" po where s.""StaffNo""={0} and s.""PositionNo""=po.""PositionNo"" ", stNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(s);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            NewBakery bak = new NewBakery();
            bak.BakeryNo = BakeryNo;

            Person p = new Person();
            while (dataReader_3.Read())
            {

                p.StaffNo = Convert.ToInt32(dataReader_3[0]);
                p.Name = string.Format("{0}", dataReader_3[1].ToString().Trim());
                p.DateOfBirth = (string.Format("{0}", dataReader_3[2].ToString().Trim())).Substring(0, 10);
                if (string.Format("{0}", dataReader_3[3].ToString().Trim()) == "M") { p.Sex = "М"; }
                else p.Sex = "Ж";
                p.TelNo = string.Format("{0}", dataReader_3[4].ToString().Trim());
                p.PositionName = string.Format("{0}", dataReader_3[5].ToString().Trim());
                p.Salary = Convert.ToInt32(dataReader_3[6]);
                if (string.Format("{0}", dataReader_3[7].ToString().Trim()) == "False") { p.IsFired = "Работает"; }
                else p.IsFired = "Уволен";
            }
            conn2.Close();
            OpenConnection = false;
            return View("UpdateWorker", p);

        }
        public IActionResult Prodazi()
        {
            return View("Prodazi");
        }
        [HttpPost]
        public IActionResult CurrentMothForAll()
        {
            List<MonthSale> m = new List<MonthSale>();
            string cur = String.Format(@"select ""Год"",""Месяц"",""Продажа за месяц"",""Название пекарни"",""Номер пекарни"" from ""ImportantMonthSales"" where ""Год""=extract(year from current_date) and ""Месяц""=extract(month from current_date)");
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(cur);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while(dataReader_3.Read())
            {
                m.Add(new MonthSale
                {
                    Year = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    Month = string.Format("{0}", dataReader_3[1].ToString().Trim()),
                    Sum = string.Format("{0}", dataReader_3[2].ToString().Trim()),
                    BakeryName = string.Format("{0}", dataReader_3[3].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[4])
                });
            }
            conn2.Close();
            OpenConnection = false;
            TempData["MonthSales"] = m;
            return View("MonthSales");
        }
        [HttpPost]
        public IActionResult YearForAll()
        {
            List<MonthSale> m = new List<MonthSale>();
            string cur = String.Format(@"select ""Год"",""Месяц"",sum(""Продажа за месяц""),""Название пекарни"",""Номер пекарни"" from ""ImportantMonthSales"" where ""Год""=extract(year from current_date) group by ""Месяц"",""Год"", ""Номер пекарни"",""Название пекарни""");
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(cur);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                m.Add(new MonthSale
                {
                    Year = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    Month = string.Format("{0}", dataReader_3[1].ToString().Trim()),
                    Sum = string.Format("{0}", dataReader_3[2].ToString().Trim()),
                    BakeryName = string.Format("{0}", dataReader_3[3].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[4])
                });
            }
            conn2.Close();
            OpenConnection = false;
            TempData["YearSales"] = m;
            return View("YearSales");
        }
        [HttpPost]
        public IActionResult AllYearForAll()
        {
            List<MonthSale> m = new List<MonthSale>();
            string cur = String.Format(@"select ""Год"",""Месяц"",sum(""Продажа за месяц""),""Название пекарни"",""Номер пекарни"" from ""ImportantMonthSales"" group by ""Месяц"",""Год"", ""Номер пекарни"",""Название пекарни"" ");
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(cur);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                m.Add(new MonthSale
                {
                    Year = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    Month = string.Format("{0}", dataReader_3[1].ToString().Trim()),
                    Sum = string.Format("{0}", dataReader_3[2].ToString().Trim()),
                    BakeryName = string.Format("{0}", dataReader_3[3].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[4])
                });
            }
            conn2.Close();
            OpenConnection = false;
            TempData["AllYearSales"] = m;
            return View("AllYearSales");
        }
        public IActionResult Prodazi2(NewBakery n)
        {

            return View("Choose", n);

        }

        [HttpPost]
        public IActionResult CurrentMothForThis(NewBakery n)
        {
            List<MonthSale> m = new List<MonthSale>();
            string cur = String.Format(@"select ""Год"",""Месяц"",sum(""Продажа за месяц""),""Название пекарни"",""Номер пекарни"" from ""ImportantMonthSales"" where ""Год""=extract(year from current_date) and ""Месяц""=extract(month from current_date) and ""Номер пекарни""={0} group by ""Месяц"",""Год"",""Номер пекарни"",""Название пекарни""", n.BakeryNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(cur);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                m.Add(new MonthSale
                {
                    Year = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    Month = string.Format("{0}", dataReader_3[1].ToString().Trim()),
                    Sum = string.Format("{0}", dataReader_3[2].ToString().Trim()),
                    BakeryName = string.Format("{0}", dataReader_3[3].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[4])
                });
            }
            conn2.Close();
            OpenConnection = false;
            TempData["MonthSales"] = m;
            return View("MonthSales");
        }
        [HttpPost]
        public IActionResult YearForThis(NewBakery n)
        {
            List<MonthSale> m = new List<MonthSale>();
            string cur = String.Format(@"select ""Год"",""Месяц"",sum(""Продажа за месяц""),""Название пекарни"",""Номер пекарни"" from ""ImportantMonthSales"" where ""Год""=extract(year from current_date) and ""Номер пекарни""={0} group by ""Месяц"",""Год"",""Номер пекарни"",""Название пекарни""", n.BakeryNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(cur);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                m.Add(new MonthSale
                {
                    Year = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    Month = string.Format("{0}", dataReader_3[1].ToString().Trim()),
                    Sum = string.Format("{0}", dataReader_3[2].ToString().Trim()),
                    BakeryName = string.Format("{0}", dataReader_3[3].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[4])
                });
            }
            conn2.Close();
            OpenConnection = false;
            TempData["YearSales"] = m;
            return View("YearSales");
        }
        [HttpPost]
        public IActionResult AllYearForThis(NewBakery n)
        {
            List<MonthSale> m = new List<MonthSale>();
            string cur = String.Format(@"select ""Год"",""Месяц"",sum(""Продажа за месяц""),""Название пекарни"",""Номер пекарни"" from ""ImportantMonthSales"" where ""Номер пекарни""={0}  group by ""Месяц"",""Год"",""Номер пекарни"",""Название пекарни""", n.BakeryNo);
            conn2.Open();
            OpenConnection = true;
            NpgsqlCommand command3 = new NpgsqlCommand(cur);
            command3.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command3.ExecuteReader();
            while (dataReader_3.Read())
            {
                m.Add(new MonthSale
                {
                    Year = string.Format("{0}", dataReader_3[0].ToString().Trim()),
                    Month = string.Format("{0}", dataReader_3[1].ToString().Trim()),
                    Sum = string.Format("{0}", dataReader_3[2].ToString().Trim()),
                    BakeryName = string.Format("{0}", dataReader_3[3].ToString().Trim()),
                    BakeryNo = Convert.ToInt32(dataReader_3[4])
                });
            }
            conn2.Close();
            OpenConnection = false;
            TempData["AllYearSales"] = m;
            return View("AllYearSales");
        }
    }
}
