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
    public class SellerController : Controller
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

        public IActionResult Price()
        {
            IEnumerable<Product> products3 = ShowAllProducts();
            return View("Price", products3);
        }
        
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
        [HttpGet]
        public IActionResult ProductList()
        {
            TempData["Sort"] = ShowAllProducts(0);
            return View("SortList");
        }

        public IActionResult Allergic()
        {
            IEnumerable<Product> products3 = ShowAllProducts();
            return View("Allergic", products3);
        }

        [HttpGet]
        public IActionResult FindAllergicIngredient(Product product)
        {
            string name = product.ProductName;
            string name2 = Char.ToUpper(name[0]) + name.Substring(1);
            List<string> ingredients = new List<string>();
            string k = String.Format(@" select i.""IngredientName"" from ""Ingredient"" as i, ""Product"" as pr, ""ProductInclude"" as pi
                where pr.""ProductName""='{0}' and pi.""ProductNo"" = pr.""ProductNo"" and pi.""IngredientNo"" = i.""IngredientNo"" and i.""Allergic"" = 'true'",name2);
            NpgsqlCommand command1 = new NpgsqlCommand(k);
            command1.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_1;
            dataReader_1 = command1.ExecuteReader();            
            while (dataReader_1.Read())
            {                
                ingredients.Add(string.Format("{0}", dataReader_1[0].ToString().Trim()));
            }
            if (ingredients.Count == 0) { ingredients.Add("Не содержит аллергенных ингредиентов!"); }
            TempData["Ingredients"] = ingredients;
            OpenConnection = false;
            conn2.Close();
            IEnumerable<Product> products3 = ShowAllProducts();
            return View("FindAllergic", products3);
        }

        public IActionResult Receipts()
        {
            return View("Receipt");
        }

        public IActionResult ReceiptPeriod()
        {
            return View("ReceiptPeriod");
        }

        public IActionResult CreateCheck()
        {
            ViewBag.Message = "";
            EndSummary = 0;
            IEnumerable<ClassClient> Clints = ShowAllClients();
            return View("CreateReceipt", Clints);
        }
 

        [HttpPost]
        public IActionResult Create(ClassClient client)
        {
            card.Clear();
            ViewBag.Message = "";
            EndSummary = 0;
            ClientNo =client.Identifyier;
            IEnumerable<Product> pr= ShowAllProducts();
            return View("NewReceipt",pr);

        }
        [HttpPost]
        public IActionResult FindReceipt(ClasssReceipt receipt)
        {
            if (ModelState.IsValid)
            {
                string date = receipt.Date;
                string FindDate=MakeDate(date);

                List<TakeReceipt> receipts = new List<TakeReceipt>();

                string receiptNo = "";
                string From = SellerFullName;
                string To = "";
                int discount = 0;
                string telno = "";
                List<string> products = new List<string>();
                List<string> counts = new List<string>();
                List<double> prices = new List<double>();
                StaffNo = FindStaffNo();

                string cmd = String.Format(@"select r.""ReceiptNo"",cl.""FirstName"" || ' ' || cl.""LastName"",pr.""ProductName"",r.""AmountOfDiscount"",sl.""CountProducts"" , 
                    cl.""TelNo"",sl.""CountProducts""*pr.""Price"" from ""Client"" as cl, ""Product"" as pr, ""Sale"" as sl, ""Receipt"" as r
                    where  r.""CashierNo""={0} and r.""TheDate"" = '{1}' and pr.""ProductNo"" = sl.""ProductNo""
                            and r.""ReceiptNo"" = sl.""ReceiptNo"" and r.""ClientNo"" = cl.""ClientNo""", StaffNo, FindDate);
                NpgsqlCommand command1 = new NpgsqlCommand(cmd);
                command1.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_1;
                dataReader_1 = command1.ExecuteReader();


                while (dataReader_1.Read())
                {
                    receiptNo = "";
                    To = "";
                    discount = 0;
                    telno = "";
                    products.Clear();
                    prices.Clear();
                    counts.Clear();

                    receiptNo = string.Format("{0}", dataReader_1[0].ToString().Trim());
                    To = string.Format("{0}", dataReader_1[1].ToString().Trim());
                    products.Add(string.Format("{0}", dataReader_1[2].ToString().Trim()));
                    discount = Convert.ToInt32(dataReader_1[3]);
                    counts.Add(string.Format("{0}", dataReader_1[4].ToString().Trim()));
                    telno = string.Format("{0}", dataReader_1[5].ToString().Trim());
                    prices.Add(Convert.ToDouble(dataReader_1[6]));

                    bool find = false;
                    int index = 0;
                    foreach (var r in receipts)
                    {
                        if (r.ReceiptNo == receiptNo) { find = true; break; }
                        index += 1;
                    }
                    if (find == true)
                    {

                        double summ = 1;
                        string s = "";
                        for (int i = 0; i < products.Count; i++)
                        {
                            s += "\'" + products[i] + "\', " + counts[i] + "шт. \n";
                            summ *= prices[i];
                        }
                        receipts[index].ProductNameWithCount += s;

                        double r2 = summ;
                        double r3 = Math.Round(summ - (discount * summ / 100), 2);
                        receipts[index].Sum += r2;
                        double e = Math.Round(receipts[index].SumWithDiscount + r3, 2);
                        receipts[index].SumWithDiscount =e;
                    }
                    else
                    {
                        string s1 = receiptNo;
                        string s2 = From;
                        string s3 = To + ", " + telno;
                        string s4 = date;
                        string s5 = "";
                        double sum = 1;
                        for (int i = 0; i < products.Count; i++)
                        {
                            s5 += "\'" + products[i] + "\', " + counts[i] + "шт. \n";
                            sum *= prices[i];
                        }
                        string s6 = discount + "% ";
                        double s7 = sum;
                        double s8 = Math.Round(sum - (discount * sum / 100), 2);
                        receipts.Add(new TakeReceipt { ReceiptNo = s1, FromPerson = s2, ToPerson = s3, Date = s4, ProductNameWithCount = s5, AmountOfDiscount = s6, Sum = s7, SumWithDiscount = s8 });
                    }
                }
                conn2.Close();
                OpenConnection = false;


                TempData["Receipts"] = receipts;

                return View("ShowReceipt");
            }
            else return View("Receipt");
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
                BakeryNo= Convert.ToInt32(dataReader_3[1].ToString().Trim());
            }
            conn2.Close();
            OpenConnection = false;
            return StaffNo;
        }

        [HttpPost]
        public IActionResult FindReceiptByPeriod(ClassPeriodReceipt receipt)
        {
            if (ModelState.IsValid)
            {
                string start = receipt.StartDate;
                string finish = receipt.EndDate;
                if (start == finish)
                {
                    ClasssReceipt r = new ClasssReceipt();
                    r.Date = start;
                    return FindReceipt(r);
                }
                else
                {
                    string SFindDate = MakeDate(start);                    
                    string FFindDate = MakeDate(finish);
                    List<TakeReceipt> receipts = new List<TakeReceipt>();

                    string receiptNo = "";
                    string From = SellerFullName;
                    string To = "";
                    int discount = 0;
                    string telno = "";
                    string date = "";
                    List<string> products = new List<string>();
                    List<string> counts = new List<string>();
                    List<double> prices = new List<double>();
                    int StaffNo = FindStaffNo();

                    string cmd = String.Format(@"select r.""ReceiptNo"",cl.""FirstName"" || ' ' || cl.""LastName"" ,pr.""ProductName"",r.""AmountOfDiscount"",sl.""CountProducts"" , 
                    cl.""TelNo"",sl.""CountProducts""*pr.""Price"",r.""TheDate"" from ""Client"" as cl, ""Product"" as pr, ""Sale"" as sl, ""Receipt"" as r 
                    where  r.""CashierNo""={0} and r.""TheDate"" >= '{1}' and r.""TheDate""<='{2}'  and pr.""ProductNo"" = sl.""ProductNo""
                            and r.""ReceiptNo"" = sl.""ReceiptNo"" and r.""ClientNo"" = cl.""ClientNo"" order by r.""TheDate"" asc", StaffNo, SFindDate,FFindDate);
                    NpgsqlCommand command1 = new NpgsqlCommand(cmd);
                    command1.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_1;
                    dataReader_1 = command1.ExecuteReader();


                    while (dataReader_1.Read())
                    {
                        receiptNo = "";
                        To = "";
                        discount = 0;
                        telno = "";
                        date = "";
                        products.Clear();
                        prices.Clear();
                        counts.Clear();

                        receiptNo = string.Format("{0}", dataReader_1[0].ToString().Trim());
                        To = string.Format("{0}", dataReader_1[1].ToString().Trim());
                        products.Add(string.Format("{0}", dataReader_1[2].ToString().Trim()));
                        discount = Convert.ToInt32(dataReader_1[3]);
                        counts.Add(string.Format("{0}", dataReader_1[4].ToString().Trim()));
                        telno = string.Format("{0}", dataReader_1[5].ToString().Trim());
                        prices.Add(Convert.ToDouble(dataReader_1[6]));
                        date= string.Format("{0}", dataReader_1[7].ToString().Trim());
                        bool find = false;
                        int index = 0;
                        foreach (var r in receipts)
                        {
                            if (r.ReceiptNo == receiptNo) { find = true; break; }
                            index += 1;
                        }
                        
                        if (find == true)
                        {

                            double summ = 1;
                            string s = "";
                            for (int i = 0; i < products.Count; i++)
                            {
                                s += "\'" + products[i] + "\', " + counts[i] + "шт. \n";
                                summ *= prices[i];
                            }
                            receipts[index].ProductNameWithCount += s;

                            double r2 = summ;
                            double r3 = Math.Round((summ - (discount * summ / 100)), 2);
                            receipts[index].Sum += r2;
                            double e = Math.Round(receipts[index].SumWithDiscount + r3, 2);
                            receipts[index].SumWithDiscount = e;

                        }
                        else
                        {
                            string s1 = receiptNo;
                            string s2 = From;
                            string s3 = To + ", " + telno;

                            string s4 = date.Substring(0, 10);
                            string year = s4.Substring(6, 4);
                            string day = s4.Substring(3, 2);
                            string month = s4.Substring(0, 2);
                            string FindDate = year + "-" + month + "-" + day;
                            string s5 = "";
                            double sum = 1;
                            for (int i = 0; i < products.Count; i++)
                            {
                                s5 += "\'" + products[i] + "\', " + counts[i] + "шт. \n";
                                sum *= prices[i];
                            }
                            string s6 = discount + "% ";
                            double s7 = sum;
                            double s8 = Math.Round((sum - (discount * sum / 100)), 2);
                            receipts.Add(new TakeReceipt { ReceiptNo = s1, FromPerson = s2, ToPerson = s3, Date =FindDate, ProductNameWithCount = s5, AmountOfDiscount = s6, Sum = s7, SumWithDiscount = s8 });
                        }
                    }
               
                conn2.Close();
                OpenConnection = false;
                TempData["Receipts"] = receipts;
                return View("ShowReceipt"); 
                }
            }

            return View("ReceiptPeriod");
        }

        public string MakeDate(string date)
        {
            date = date.Substring(0, 10);
            string day = date.Substring(8, 2);
            string month = date.Substring(5, 2);
            string year = date.Substring(0, 4);
            string FindDate = month + "." + day + "." + year;
            return FindDate;
        }
        [HttpGet]
        public IActionResult SortList(ClassSort sort)
        {
          
                string Sort = sort.NameSort;
                if (Sort == "1")
                {
                    TempData["Sort"] = ShowAllProducts(1);
                }
                else if (Sort == "2")
                {
                    TempData["Sort"] = ShowAllProducts(2);
                }
                else if (Sort == "3")
                {
                    TempData["Sort"] = ShowAllProducts(3);
                }            
                else
                {
                    TempData["Sort"] = ShowAllProducts(0);
                    ViewBag.Error = "* Данное поле является обязательным";
                }
                
                return View("SortList");
        }


        [HttpGet]
        public IActionResult FindProductPrice(Product product)
        {
          
            string name = product.ProductName;
            string name2 = Char.ToUpper(name[0]) + name.Substring(1);

            List<string> prices = new List<string>();
           // string connection = String.Format("Host=localhost;Port=5434;Database=new_pryanick;Username={0};Password={1}", Login, Password);
           // conn2 = new NpgsqlConnection(connection);
            //NpgsqlCommand command1 = new NpgsqlCommand(@"select pr.""Price"" from ""Product"" as pr where pr.""ProductName""=" + "'" + name2 + "'");
            NpgsqlCommand command1 = new NpgsqlCommand(@"select pr.""ProductName"", pr.""Price"" from ""Product"" as pr where pr.""ProductName"" similar to '"+name2+"%'");

            command1.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_1;
            dataReader_1 = command1.ExecuteReader();
            while (dataReader_1.Read())
            {
                prices.Add(" Цена на изделие: " + "\"" + string.Format("{0}", dataReader_1[0].ToString().Trim()) + "\"=" + string.Format("{0}", dataReader_1[1].ToString().Trim()) + " грн ");
            }
            conn2.Close();
            OpenConnection = false;
            if (prices.Count == 0) {prices.Add("Изделие не найдено, повторите запрос!"); }
            TempData["Prices"] = prices;
            IEnumerable<Product> products3 = ShowAllProducts();
            return View("ShowPrice", products3);

        }


        public List<Product> ShowAllProducts(int sort)
        {
            List<Product> pr = new List<Product>();
           // string new_connection = String.Format("Host=localhost;Port=5434;Database=new_pryanick;Username={0};Password={1}", Login, Password);
           // conn2 = new NpgsqlConnection(new_connection);
            if (sort == 0)
            {
               
                NpgsqlCommand command2 = new NpgsqlCommand(@"select pr.""ProductNo"",pr.""ProductName"",pr.""Price"" from ""Product"" as pr");
                command2.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_2;

                dataReader_2 = command2.ExecuteReader();
                while (dataReader_2.Read())
                {

                    pr.Add(new Product(Convert.ToInt32(dataReader_2[0]), dataReader_2[1].ToString().Trim(), Convert.ToDecimal(dataReader_2[2])));
                }
                OpenConnection = false;
                conn2.Close();
            }
            else if(sort==1)
            {
                NpgsqlCommand command2 = new NpgsqlCommand(@"select pr.""ProductNo"",pr.""ProductName"",pr.""Price"" from ""Product"" as pr order by ""Price"" asc");
                command2.Connection = conn2;
                OpenConnection = true;
                conn2.Open();
                NpgsqlDataReader dataReader_2;

                dataReader_2 = command2.ExecuteReader();
                while (dataReader_2.Read())
                {

                    pr.Add(new Product(Convert.ToInt32(dataReader_2[0]), dataReader_2[1].ToString().Trim(), Convert.ToDecimal(dataReader_2[2])));
                }
                conn2.Close();
                OpenConnection = false;
            }
            else if(sort==2)
            {
                NpgsqlCommand command2 = new NpgsqlCommand(@"select pr.""ProductNo"",pr.""ProductName"",pr.""Price"" from ""Product"" as pr order by ""Price"" desc");
                command2.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_2;

                dataReader_2 = command2.ExecuteReader();
                while (dataReader_2.Read())
                {

                    pr.Add(new Product(Convert.ToInt32(dataReader_2[0]), dataReader_2[1].ToString().Trim(), Convert.ToDecimal(dataReader_2[2])));
                }
                conn2.Close();
                OpenConnection = false;
            }
            else if(sort==3)
            {
                NpgsqlCommand command2 = new NpgsqlCommand(@"select pr.""ProductNo"",pr.""ProductName"",pr.""Price"" from ""Product"" as pr order by ""ProductName"" asc");
                command2.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_2;

                dataReader_2 = command2.ExecuteReader();
                while (dataReader_2.Read())
                {

                    pr.Add(new Product(Convert.ToInt32(dataReader_2[0]), dataReader_2[1].ToString().Trim(), Convert.ToDecimal(dataReader_2[2])));
                }
                conn2.Close();
                OpenConnection = false;
            }
           
            return pr;
        }
        
        public IEnumerable<Product> ShowAllProducts()
        {
            products.Clear();
            IEnumerable<Product> products2;
            NpgsqlCommand command2 = new NpgsqlCommand(@"select pr.""ProductNo"",pr.""ProductName"",pr.""Price"" from ""Product"" as pr");
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;

                dataReader_2 = command2.ExecuteReader();
                while (dataReader_2.Read())
                {

                    products.Add(new Product(Convert.ToInt32(dataReader_2[0]),dataReader_2[1].ToString().Trim(), Convert.ToDecimal(dataReader_2[2])));
                }
                conn2.Close();
            OpenConnection = false;
            products2 = MakeList();
            return products2;
        }


        public IEnumerable<ClassClient> ShowAllClients()
        {
            IEnumerable<ClassClient> cl;
            clients.Clear();
            conn2.Open();
            OpenConnection = true;
            string S = String.Format(@"select ""FirstName"" || ' ' || ""LastName"", ""TelNo"",""VisitsNumbers"",""ClientNo"" from ""Client""");
            NpgsqlCommand commandd = new NpgsqlCommand(S);
            commandd.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = commandd.ExecuteReader();
            while (dataReader_3.Read())
            {
                ClassClient client = new ClassClient();
                client.ClientName = dataReader_3[0].ToString().Trim();
                client.TelNo = dataReader_3[1].ToString().Trim();
                client.VisitsNumbers = Convert.ToInt32(dataReader_3[2].ToString().Trim());
                client.Identifyier = Convert.ToInt32(dataReader_3[3].ToString().Trim());
                clients.Add(new ClassClient { ClientName = client.ClientName, TelNo = client.TelNo, VisitsNumbers = client.VisitsNumbers, Bonuses = client.Bonuses, Identifyier = client.Identifyier });
            }
            conn2.Close();
            OpenConnection = false;
            cl = MakeClientList();
            return cl;
        }

            public IActionResult Index()
        {
            Loginn user = new Loginn();
            user.Login = Login;
            user.Password = Password;
            return View("Index", user);
        }

        public IActionResult SignOut()
        {
            if(OpenConnection == true)conn2.Close();
            
            return View("~/Views/Home/Index.cshtml");
        }


        [HttpGet]
        public IActionResult AddToCard(Product product)
        {
            int number = product.ProductNo;
            string name = "";
            decimal price = 0;
            int sort = 0;
            string s = String.Format(@"select pr.""ProductName"",pr.""Price"",pr.""ProductSort"" from ""Product"" as pr where pr.""ProductNo""={0}",number);
            NpgsqlCommand command2 = new NpgsqlCommand(s);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            while (dataReader_2.Read())
            {
                name = dataReader_2[0].ToString().Trim();
                price= Convert.ToDecimal(dataReader_2[1]);
                sort = Convert.ToInt32(dataReader_2[2]);
            }
            conn2.Close();
            OpenConnection = false;
            int count = 1;
            int c = 0;
            
            foreach(var i in card)
            {
                    if (i.ProductNo == number) { i.Price = i.Price + price; i.count = i.count + 1;c = 1; EndSummary += price;   break;  }
            }          
            if (c==0)
            {
                EndSummary += price;
                card.Add(new Item { ProductNo = number, Price = price, ProductName = name, count = count, Message = "",ProductSort=sort }) ;
                TempData["ListInReceipt"] = card;
                ViewBag.Message = "Итоговая сумма: " + EndSummary + " грн";
                IEnumerable<Product> pr = ShowAllProducts();
                return View("R", pr);
            }
            else
            {
               
                TempData["ListInReceipt"] = card;
                ViewBag.Message = "Итоговая сумма: " + EndSummary + " грн";
                IEnumerable<Product> pr = ShowAllProducts();
                return View("R",pr);
            }
           
        }
        [HttpPost]
        public IActionResult RemoveFromCard(Product item)
        {
            foreach (var i in card)
            {
                if (i.ProductNo == item.ProductNo) 
                {
                    if (i.count >= 2) {EndSummary -= i.Price / i.count; i.Price = i.Price - i.Price / i.count;  i.count = i.count - 1; i.Message = ""; break; }
                    else { card.Remove(i); EndSummary -= i.Price; break; }
                }
            }
            TempData["ListInReceipt"] = card;
            ViewBag.Message = "Итоговая сумма: " + EndSummary + " грн";
            IEnumerable<Product> pr = ShowAllProducts();
            return View("R", pr);
        }
        [HttpGet]
        public IActionResult ClearCard()
        {
            card.Clear(); 

            TempData["ListInReceipt"] = card;
            IEnumerable<Product> pr = ShowAllProducts();
            return View("R", pr);
        }
        
        [HttpGet]
        public IActionResult ComeBack()
        {
            card.Clear();            
            newcard.Clear();
            EndSummary = 0;
            ExeptionReceipt = 0;
            exp = false;
            IEnumerable<ClassClient> Clints = ShowAllClients();
            return View("CreateReceipt", Clints);
        }
        public IActionResult R()
        {
            return View("R");
        }
        [HttpPost]
        public IActionResult Save()
        {
            if (card.Count != 0)
            {
                newcard.Clear();
                foreach (var v in card)
                {
                    newcard.Add(v);
                }

                if (exp == false)
                {
                    int skidka = 0;
                    string s1 = String.Format(@"select ""DiscountCalculationNew""({0})", ClientNo);

                    NpgsqlCommand command = new NpgsqlCommand(s1);
                    command.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_2;
                    dataReader_2 = command.ExecuteReader();

                    while (dataReader_2.Read())
                    {
                        skidka = Convert.ToInt32(dataReader_2[0].ToString().Trim());
                    }
                    conn2.Close();
                    OpenConnection = false;
                    string date = Convert.ToString(DateTime.Now);
                    string n = date.Substring(0, 10);
                    string day = date.Substring(0, 2);
                    string month = date.Substring(3, 2);
                    string year = date.Substring(6, 4);
                    string Date = month + "." + day + "." + year;


                    string s = String.Format(@"insert into ""Receipt"" (""CashierNo"",""TheDate"",""ClientNo"",""AmountOfDiscount"") values ({0},'{1}',{2},{3}) returning ""ReceiptNo""", StaffNo, Date, ClientNo, skidka);     //values ({0},'{1}',{2},{3})", StaffNo,Date,ClientNo,skidka);


                    NpgsqlCommand command2 = new NpgsqlCommand(s);
                    command2.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    int ReceiptNo = 0;
                    NpgsqlDataReader dataReader_1;
                    dataReader_1 = command2.ExecuteReader();
                    while (dataReader_1.Read())
                    {
                        ReceiptNo = Convert.ToInt32(dataReader_1[0].ToString().Trim());
                    }
                    conn2.Close();
                    OpenConnection = false;
                    string n1 = String.Format(@"update ""Client"" set ""VisitsNumbers""=""VisitsNumbers""+1 where ""ClientNo""={0} and ""TelNo""!='000-000-00-00'", ClientNo);
                    NpgsqlCommand command4 = new NpgsqlCommand(n1);
                    command4.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_4;
                    dataReader_4 = command4.ExecuteReader();
                    dataReader_4.Read();
                    conn2.Close();
                    OpenConnection = false;
                    int i = 0;
                    foreach (var item in card)
                    {

                        string m = String.Format(@"insert into ""Sale""(""ProductNo"",""ReceiptNo"",""CountProducts"") values({0},{1},{2})", item.ProductNo, ReceiptNo, item.count);

                        NpgsqlCommand command3 = new NpgsqlCommand(m);
                        command3.Connection = conn2;
                        conn2.Open();
                        OpenConnection = true;
                        NpgsqlDataReader dataReader_3;
                        try
                        {
                            dataReader_3 = command3.ExecuteReader();
                            dataReader_3.Read();
                            //card.Remove(item);

                        }
                        catch (NpgsqlException ex)
                        {
                            conn2.Close();
                            OpenConnection = false;

                            item.Message = ex.Message;
                            ExeptionReceipt = ReceiptNo;
                            exp = true;

                            card.Clear();
                            foreach (var v in newcard)
                            {
                                card.Add(v);
                            }
                            TempData["ListInReceipt"] = card;
                            IEnumerable<Product> pr = ShowAllProducts();
                            return View("R", pr);
                        }
                        newcard.Remove(item);
                        i += 1;
                        conn2.Close();
                        OpenConnection = false;

                        string update = String.Format(@"update ""Rack"" set ""CurrentProductsCount""=""CurrentProductsCount""-{0} where
                           ""RackBakeryNo""={1} and ""SortRack""={2}", item.count, BakeryNo, item.ProductSort);
                        OpenConnection = true;
                        NpgsqlCommand commandd3 = new NpgsqlCommand(update);
                        commandd3.Connection = conn2;
                        conn2.Open();
                        OpenConnection = true;
                        NpgsqlDataReader dataReader_r;
                        dataReader_r = commandd3.ExecuteReader();
                        dataReader_r.Read();
                        conn2.Close();
                        OpenConnection = false;
                    }
                    ViewBag.Message = "Чек успешно добавлен!";
                    exp = false;
                    ExeptionReceipt = 0;
                    string tel = "";
                    string n11 = String.Format(@"select ""TelNo"" from ""Client"" where ""ClientNo""='{0}'", ClientNo);
                    NpgsqlCommand command44 = new NpgsqlCommand(n11);
                    command44.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_44;
                    dataReader_44 = command44.ExecuteReader();
                    while (dataReader_44.Read())
                    {
                        tel = dataReader_44[0].ToString().Trim();
                    }
                    conn2.Close();
                    OpenConnection = false;
                    if (tel == "000-000-00-00")
                    {
                        return View("DoYouWantRegister");
                    }
                    else
                    {
                        IEnumerable<ClassClient> Clints = ShowAllClients();
                        return View("CreateReceipt", Clints);
                    }

                }
                else
                {
                    for (int i = 0; i < card.Count; i++)
                    {
                        string m = String.Format(@"insert into ""Sale""(""ProductNo"",""ReceiptNo"",""CountProducts"") values({0},{1},{2})", card[i].ProductNo, ExeptionReceipt, card[i].count);

                        NpgsqlCommand command3 = new NpgsqlCommand(m);
                        command3.Connection = conn2;
                        conn2.Open();
                        OpenConnection = true;
                        NpgsqlDataReader dataReader_3;
                        try
                        {
                            dataReader_3 = command3.ExecuteReader();
                            dataReader_3.Read();
                            //card.Remove(item);
                        }
                        catch (NpgsqlException ex)
                        {
                            conn2.Close();
                            OpenConnection = false;
                            // ViewBag.Error = ex.Message;
                            card[i].Message = ex.Message;
                            exp = true;
                            // exind = j;
                            foreach (var v in newcard)
                            {
                                card.Add(v);
                            }
                            TempData["ListInReceipt"] = card;
                            IEnumerable<Product> pr = ShowAllProducts();
                            return View("R", pr);
                        }
                        // j += 1;
                        newcard.Remove(card[i]);
                        conn2.Close(); OpenConnection = false;

                        string update = String.Format(@"update ""Rack""  set ""CurrentProductsCount""=""CurrentProductsCount""-{0} where
                           ""RackBakeryNo""={1} and ""SortRack""={2}", card[i].count, BakeryNo, card[i].ProductSort);
                        OpenConnection = true;
                        NpgsqlCommand commandd3 = new NpgsqlCommand(update);
                        commandd3.Connection = conn2;
                        conn2.Open();
                        OpenConnection = true;
                        NpgsqlDataReader dataReader_r;
                        dataReader_r = commandd3.ExecuteReader();
                        dataReader_r.Read();
                        conn2.Close();
                        OpenConnection = false;
                    }
                    ViewBag.Message = "Чек успешно добавлен!";
                    exp = false;
                    ExeptionReceipt = 0;
                    string tel = "";
                    string n11 = String.Format(@"select ""TelNo"" from ""Client"" where ""ClientNo""='{0}'", ClientNo);
                    NpgsqlCommand command44 = new NpgsqlCommand(n11);
                    command44.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_44;
                    dataReader_44 = command44.ExecuteReader();
                    while (dataReader_44.Read())
                    {
                        tel = dataReader_44[0].ToString().Trim();
                    }
                    conn2.Close();
                    OpenConnection = false;
                    if (tel == "000-000-00-00")
                    {
                        return View("DoYouWantRegister");
                    }
                    else
                    {
                        IEnumerable<ClassClient> Clints = ShowAllClients();
                        return View("CreateReceipt", Clints);
                    }
                }
            }
            else
            TempData["ListInReceipt"] = card;
            ViewBag.Err = "* Даже не пытайтесь сохранить пустой чек";
            IEnumerable<Product> pr2 = ShowAllProducts();
            return View("R", pr2);
        }
        [HttpGet]
        public IActionResult ClientRegistration()
        {
            return View("ClientRegistration");
        }

        [HttpPost]
        public IActionResult Register(ClientRegistration NewClient)
        {
            if(ModelState.IsValid)
            {
                string telno = NewClient.TelNo;
                string Search = String.Format(@"select count(""ClientNo"") from ""Client"" where ""TelNo""='{0}'", telno);
                conn2.Open();
                OpenConnection = true;
                NpgsqlCommand commandd = new NpgsqlCommand(Search);
                commandd.Connection = conn2;
                NpgsqlDataReader dataReader_3;
                dataReader_3 = commandd.ExecuteReader();
                int c = 0;
                while (dataReader_3.Read())
                {
                    c= Convert.ToInt32(dataReader_3[0].ToString().Trim());
                }
                conn2.Close();
                OpenConnection = false;
                if (c==0)
                {
                    string Add = String.Format(@"insert into ""Client""(""FirstName"",""LastName"",""TelNo"",""VisitsNumbers"") values(
	                '{0}','{1}','{2}',1)",NewClient.FirstName,NewClient.LastName,telno);
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlCommand commandd2 = new NpgsqlCommand(Add);
                    commandd2.Connection = conn2;
                    NpgsqlDataReader dataReader_2;
                    dataReader_2 = commandd2.ExecuteReader();                   
                    dataReader_2.Read();                    
                    conn2.Close();
                    OpenConnection = false;
                }
                else
                {
                    ViewBag.Message = "Такой клиет уже зарегистрирован!";
                    return View("ClientRegistration");
                }
                    return RedirectToAction("CreateCheck");
            }
            else
            {
                ViewBag.Message = "Введенные данные не корректны";
                return View("ClientRegistration");
            }
            
        }

        
        public IActionResult NewOrder()
        {
            ViewBag.Message = "";
            EndSummary = 0;
            IEnumerable<ClassClient> Clints = ShowAllClients();           
            return View("NewOrder",Clints);
        }
        public List<ClassOrder> Smth(ClassClient client)
        {
            card.Clear();
            ViewBag.Message = "";
            EndSummary = 0;
            ClientNo = client.Identifyier;
            int staffbakery = 0;
            List<ClassOrder> bakers = new List<ClassOrder>();
            string baker = String.Format(@"select ""StaffBakeryNo"" from ""Staff"" where ""StaffNo""={0}", StaffNo);
            NpgsqlCommand command1 = new NpgsqlCommand(baker);
            command1.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_1;
            dataReader_1 = command1.ExecuteReader();
            while (dataReader_1.Read())
            {
                staffbakery = Convert.ToInt32(dataReader_1[0]);
            }
            conn2.Close();


            string s = String.Format(@"select s.""StaffNo"",s.""FirstName"" || ' ' || s.""LastName"",s.""TelNo"" from ""Staff"" s,""Position"" po where s.""StaffBakeryNo""={0} 
            and s.""PositionNo""=po.""PositionNo"" and po.""PositionName""='Кондитер' and s.""IsFired""='false'", staffbakery);

            NpgsqlCommand command2 = new NpgsqlCommand(s);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            while (dataReader_2.Read())
            {
                bakers.Add(new ClassOrder { CookNo = Convert.ToInt32(dataReader_2[0]), CookName = dataReader_2[1].ToString().Trim() +", "+
                    dataReader_2[2].ToString().Trim(), Date = "" });
            }
            conn2.Close();
            OpenConnection = false;
            return bakers;
        }

        [HttpPost]
        public IActionResult CreateOrder(ClassClient client)
        {
           
            TempData["Bakers"] = Smth(client);
            return View("SelectDate");
        }
        [HttpPost]
        public IActionResult OrderWillBeForm(ClassOrder order)
        {

            if (ModelState.IsValid)
            {
                OrderDate = MakeDate(order.Date);
                BakerNo = order.CookNo;
                EndSummary = 0;
                IEnumerable<Product> pr = ShowAllProducts();
                return View("CreateNewOrder", pr);
            }
            else
            {
                ClassClient c = new ClassClient();
                c.Identifyier = ClientNo;
                ViewBag.Err = "* Это поле является обязательным";
                TempData["Bakers"] = Smth(c);
                return View("SelectDate");
            }
        }


        [HttpGet]
        public IActionResult AddToOrderCard(Product product)
        {
            int number = product.ProductNo;
            string name = "";
            decimal price = 0;
            string s = String.Format(@"select pr.""ProductName"",pr.""Price"" from ""Product"" as pr where pr.""ProductNo""={0}", number);
            NpgsqlCommand command2 = new NpgsqlCommand(s);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            while (dataReader_2.Read())
            {
                name = dataReader_2[0].ToString().Trim();
                price = Convert.ToDecimal(dataReader_2[1]);
            }
            conn2.Close();
            OpenConnection = false;
            int count = 1;
            int c = 0;

            foreach (var i in card)
            {
                if (i.ProductNo == number) { i.Price = i.Price + price; i.count = i.count + 1; c = 1; EndSummary += price; break; }
            }
            if (c == 0)
            {
                EndSummary += price;
                card.Add(new Item { ProductNo = number, Price = price, ProductName = name, count = count, Message = "" });
                TempData["ListInOrder"] = card;
                ViewBag.Message = "Итоговая сумма: " + EndSummary + " грн";
                IEnumerable<Product> pr = ShowAllProducts();
                return View("O", pr);
            }
            else
            {

                TempData["ListInOrder"] = card;
                ViewBag.Message = "Итоговая сумма: " + EndSummary + " грн";
                IEnumerable<Product> pr = ShowAllProducts();
                return View("O", pr);
            }

        }

        [HttpPost]
        public IActionResult RemoveFromOrderCard(Product item)
        {
            foreach (var i in card)
            {
                if (i.ProductNo == item.ProductNo)
                {
                    if (i.count >= 2) { EndSummary -= i.Price / i.count; i.Price = i.Price - i.Price / i.count; i.count = i.count - 1; i.Message = ""; break; }
                    else { card.Remove(i); EndSummary -= i.Price; break; }
                }
            }
            TempData["ListInOrder"] = card;
            ViewBag.Message = "Итоговая сумма: " + EndSummary + " грн";
            IEnumerable<Product> pr = ShowAllProducts();
            return View("O", pr);
        }
        [HttpGet]
        public IActionResult ClearOrderCard()
        {
            card.Clear();

            TempData["ListInOrder"] = card;
            IEnumerable<Product> pr = ShowAllProducts();
            return View("O", pr);
        }

        [HttpGet]
        public IActionResult ComeBackOrder()
        {
            card.Clear();
            newcard.Clear();
            EndSummary = 0;
            ExeptionReceipt = 0;
            exp = false;
            BakerNo = 0;
            BakerName = "";
            IEnumerable<ClassClient> Clints = ShowAllClients();
            return View("NewOrder", Clints);
        }
        public IActionResult O()
        {
            return View("O");
        }



        [HttpPost]
        public IActionResult SaveOrder(ClassPeriodReceipt cl)
        {
            if (card.Count != 0)
            {

                int skidka = 0;
                string s1 = String.Format(@"select ""DiscountCalculationNew""({0})", ClientNo);

                NpgsqlCommand command = new NpgsqlCommand(s1);
                command.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_2;
                dataReader_2 = command.ExecuteReader();

                while (dataReader_2.Read())
                {
                    skidka = Convert.ToInt32(dataReader_2[0].ToString().Trim());
                }
                conn2.Close();
                OpenConnection = false;
                string date = Convert.ToString(DateTime.Now);
                string n = date.Substring(0, 10);
                string day = date.Substring(0, 2);
                string month = date.Substring(3, 2);
                string year = date.Substring(6, 4);
                string Date = month + "." + day + "." + year;


                string s = String.Format(@"insert into ""Order"" (""DateOfReceipt"",""Deadline"",""Status"",""ClientNo"",""CashierNo"") values ('{0}','{1}','заказ обрабатывается',{2},{3}) returning ""OrderNo""", Date, OrderDate, ClientNo, StaffNo);

                NpgsqlCommand command2 = new NpgsqlCommand(s);
                command2.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                int OrderNo = 0;
                NpgsqlDataReader dataReader_1;
                dataReader_1 = command2.ExecuteReader();
                while (dataReader_1.Read())
                {
                    OrderNo = Convert.ToInt32(dataReader_1[0].ToString().Trim());
                }
                conn2.Close();
                OpenConnection = false;

                string n1 = String.Format(@"update ""Client"" set ""VisitsNumbers""=""VisitsNumbers""+1 where ""ClientNo""={0} and ""TelNo""!='000-000-00-00'", ClientNo);
                NpgsqlCommand command4 = new NpgsqlCommand(n1);
                command4.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_4;
                dataReader_4 = command4.ExecuteReader();
                dataReader_4.Read();
                conn2.Close();
                OpenConnection = false;
                int i = 0;
                foreach (var item in card)
                {

                    string m = String.Format(@"insert into ""Details""(""OrderNo"",""ProductNo"",""CountProducts"",""CookNo"") values({0},{1},{2},{3})", OrderNo, item.ProductNo, item.count, BakerNo);

                    NpgsqlCommand command3 = new NpgsqlCommand(m);
                    command3.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_3;
                    dataReader_3 = command3.ExecuteReader();
                    dataReader_3.Read();
                    newcard.Remove(item);
                    i += 1;
                    conn2.Close();
                    OpenConnection = false;
                }
                ViewBag.Message = "Заказ успешно добавлен!";
                exp = false;
                ExeptionReceipt = 0;
                string tel = "";
                string n11 = String.Format(@"select ""TelNo"" from ""Client"" where ""ClientNo""='{0}'", ClientNo);
                NpgsqlCommand command44 = new NpgsqlCommand(n11);
                command44.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_44;
                dataReader_44 = command44.ExecuteReader();
                while (dataReader_44.Read())
                {
                    tel = dataReader_44[0].ToString().Trim();
                }
                conn2.Close();
                OpenConnection = false;
                if (tel == "000-000-00-00")
                {
                    return View("DoYouWantRegister");
                }
                else
                {
                    IEnumerable<ClassClient> Clints = ShowAllClients();
                    return View("CreateReceipt", Clints);
                }
            } 
        else
        {
         TempData["ListInReceipt"] = card;
            ViewBag.Err = "* Даже не пытайтесь сохранить пустой чек";
            IEnumerable<Product> pr2 = ShowAllProducts();
            return View("R", pr2);
        }
       
    }

    }
}
