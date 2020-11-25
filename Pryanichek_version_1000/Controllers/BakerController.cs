using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Pryanichek_version_1000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Controllers
{
    public class BakerController: Controller
    {
        static string Login;
        static string Password;
        static bool OpenConnection = false;
        static string TelNo;
        static int StaffNo;
        static string BakerFullName = "";
        static int BakerNo = 0;
        static string connection;
        static decimal EndSummary = 0;
        static NpgsqlConnection conn2;
        static int ProductNo=0;
        static int ClientNo;
        //public new_pryanickContext pryanickContext = new new_pryanickContext();
        public static List<Product> products = new List<Product>();
        
        public static List<Item> card = new List<Item>();
        public static IEnumerable<Product> MakeList() => products;

       /* public IActionResult Price()
        {
            IEnumerable<Product> products3 = ShowAllProducts();
            return View("Price", products3);
        }*/

        public IActionResult SetLogin(string l, string p, string t, string n)
        {
            Loginn user = new Loginn();
            user.Login = l;
            user.Password = p;
            Login = l;
            Password = p;
            connection = String.Format("Host=localhost;Port=5434;Database=new_pryanick;Username={0};Password={1}", Login, Password);
            conn2 = new NpgsqlConnection(connection);
            TelNo = t;
            BakerFullName = n;
            StaffNo = FindStaffNo();
            return View("Index", user);
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        public int FindStaffNo()
        {
            int StaffNo = 0;
            conn2.Open();
            OpenConnection = true;
            string S = String.Format(@"select ""StaffNo"",""StaffBakeryNo"" from ""Staff"" where ""TelNo""='{0}'", TelNo);
            NpgsqlCommand command2 = new NpgsqlCommand(S);
            command2.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = command2.ExecuteReader();
            while (dataReader_3.Read())
            {
                StaffNo = Convert.ToInt32(dataReader_3[0].ToString().Trim());
                BakerNo = Convert.ToInt32(dataReader_3[1].ToString().Trim());
            }
            conn2.Close();
            OpenConnection = false;
            return StaffNo;
        }

        public IActionResult SignOut()
        {
            if (OpenConnection == true) conn2.Close();

            return View("~/Views/Home/Index.cshtml");
        }
        
        public  IActionResult Products()
        {
            TempData["Products"] = ShowAllProducts();
            return View("Products");
        }

        [HttpPost]
        public IActionResult Details(Product p)
        {
            NewProduct pr = new NewProduct();
            ProductNo = p.ProductNo;
            pr = AboutProduct(p.ProductNo);
            return View("Details",pr);
        }
        
        public NewProduct AboutProduct(int ProductNo)
        {
            NewProduct pr = new NewProduct();
            string main_information = String.Format(@"   select pr.""ProductName"",s.""SortName"", pr.""PreparingTime"", pr.""Recipe"" from
            ""Product"" pr, ""Sort"" s where pr.""ProductSort"" = s.""SortNo"" and pr.""ProductNo""={0}", ProductNo);
            NpgsqlCommand command2 = new NpgsqlCommand(main_information);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;

            dataReader_2 = command2.ExecuteReader();
            while (dataReader_2.Read())
            {
                pr.ProductName=dataReader_2[0].ToString().Trim();   //Название
                pr.SortName=dataReader_2[1].ToString().Trim(); //Тип изделия               
                pr.PreparingTime = Convert.ToInt32(dataReader_2[2]); //время приготовления 
                pr.Recipe=dataReader_2[3].ToString().Trim(); //Рецепт
            }
            conn2.Close();
            OpenConnection = false;
            pr.ProductNo = ProductNo;
            
            string added_information = String.Format(@" select i.""IngredientName"", pi.""Measure"" from ""ProductInclude"" pi, ""Ingredient"" i
                where pi.""ProductNo"" = {0} and pi.""IngredientNo"" = i.""IngredientNo""", ProductNo);
            NpgsqlCommand command1 = new NpgsqlCommand(added_information);
            command1.Connection = conn2;
            conn2.Open();

            OpenConnection = true;
            NpgsqlDataReader dataReader_1;

            dataReader_1 = command1.ExecuteReader();
            List<string> ingredients = new List<string>();
            while (dataReader_1.Read())
            {
                ingredients.Add(dataReader_1[0].ToString().Trim() + ": \n"+ dataReader_1[1].ToString().Trim());
            }
            conn2.Close();
            OpenConnection = false;
           TempData["Ingredients"] = ingredients;
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

                products.Add(new Product(Convert.ToInt32(dataReader_2[0]), dataReader_2[1].ToString().Trim(), Convert.ToDecimal(dataReader_2[2])));
            }
            conn2.Close();
            OpenConnection = false;
            products2 = MakeList();
            return products2;
        }
        [HttpPost]
        public IActionResult ChangeProduct(NewProduct pr)
        {
            NewProduct pr2 = new NewProduct();
            pr2 = AboutProduct(pr.ProductNo);
            return View("Change",pr2);
        }
        [HttpPost]
        public IActionResult ProductUpdate(NewProduct p)
        {
            products.Clear();
            if (ModelState.IsValid)
            {
                string g = String.Format(@"update ""Product"" set ""Recipe""='{0}',""PreparingTime""={1}  where ""ProductNo""={2}", p.Recipe, p.PreparingTime, p.ProductNo);
                NpgsqlCommand command2 = new NpgsqlCommand(g);
                command2.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_2;
                dataReader_2 = command2.ExecuteReader();
                dataReader_2.Read();
                conn2.Close();
                OpenConnection = false;
                return RedirectToAction("Details2",new { p = p.ProductNo });
            }
            else
                return View("Change");
        }

        public IActionResult Details2(int p)
        {
            NewProduct pr = new NewProduct();
            ProductNo = p;
            pr = AboutProduct(p);
            return View("Details", pr);
        }
        public IActionResult CurrentList()
        {
                BakerNo = FindStaffNo();

                string date = Convert.ToString(DateTime.Now);
                string n = date.Substring(0, 10);
                string day = date.Substring(0, 2);
                string month = date.Substring(3, 2);
                string year = date.Substring(6, 4);
                string Date = month + "." + day + "." + year;

                string order = String.Format(@"select o.""OrderNo"", cl.""FirstName"" || ' ' || cl.""LastName"", cl.""TelNo"", pr.""ProductName"",d.""CountProducts""*pr.""Price"", d.""CountProducts"", o.""Status"",
                                            o.""Deadline"", s.""FirstName""  || ' ' || s.""LastName""
                                            from ""Order"" o, ""Client"" cl, ""Product"" pr, ""Details"" d, ""Staff"" s
                                            where cl.""ClientNo"" = o.""ClientNo"" and  d.""OrderNo"" = o.""OrderNo"" and d.""CookNo""={0} and s.""StaffNo""=o.""CashierNo"" and
                                            pr.""ProductNo"" = d.""ProductNo"" and o.""Deadline"" >= '{1}'  and o.""Status""='заказ обрабатывается'", BakerNo, Date);


                List<NewOrder> orders = new List<NewOrder>();

                string orderNo = "";
                string From = BakerFullName;
                string To = "";
                string telno = "";
                string status = "";
                string deadline = "";
                string Cashier = "";
                List<string> products = new List<string>();
                List<string> counts = new List<string>();
                List<double> prices = new List<double>();

                NpgsqlCommand command1 = new NpgsqlCommand(order);
                command1.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_1;
                dataReader_1 = command1.ExecuteReader();
                while (dataReader_1.Read())
                {
                    orderNo = "";
                    To = "";
                    telno = "";
                    deadline = "";
                    products.Clear();
                    prices.Clear();
                    counts.Clear();

                    orderNo = string.Format("{0}", dataReader_1[0].ToString().Trim());
                    To = string.Format("{0}", dataReader_1[1].ToString().Trim());
                    telno = string.Format("{0}", dataReader_1[2].ToString().Trim());
                    products.Add(string.Format("{0}", dataReader_1[3].ToString().Trim()));
                    prices.Add(Convert.ToDouble(dataReader_1[4]));
                    counts.Add(string.Format("{0}", dataReader_1[5].ToString().Trim()));
                    status = string.Format("{0}", dataReader_1[6].ToString().Trim());
                    deadline = string.Format("{0}", dataReader_1[7].ToString().Trim());
                    Cashier = string.Format("{0}", dataReader_1[8].ToString().Trim());
                    bool find = false;
                    int index = 0;
                    foreach (var r in orders)
                    {
                        if (r.OrderNo == orderNo) { find = true; break; }
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
                        orders[index].ProductNameWithCount += s;

                        double r2 = summ;
                        orders[index].Sum += r2;
                    }
                    else
                    {
                        string s1 = orderNo;
                        string s2 = From;
                        string s3 = To + ", " + telno;
                        string cashier = Cashier;
                        string statuss = status;
                        string s5 = "";
                        double sum = 1;
                        for (int i = 0; i < products.Count; i++)
                        {
                            s5 += "\'" + products[i] + "\', " + counts[i] + "шт. \n";
                            sum *= prices[i];
                        }
                        double s7 = sum;
                        orders.Add(new NewOrder { OrderNo = s1, FromPerson = s2, ToPerson = s3, Cashier = cashier, StartDate ="", EndDate = deadline.Substring(0, 10), ProductNameWithCount = s5, Sum = s7, Status = statuss });
                    }

                }
                conn2.Close();
                OpenConnection = false;
                TempData["Orders2"] = orders;
                return View("CurrentOrder");
        }

        [HttpPost]
        public IActionResult ChangeOrder(NewOrder n)
        {
            string s = String.Format(@"select o.""Status"",o.""Deadline"" from ""Order"" o where o.""OrderNo""={0}", n.OrderNo);
            NpgsqlCommand command2 = new NpgsqlCommand(s);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            while (dataReader_2.Read())
            {
                n.Status= string.Format("{0}", dataReader_2[0].ToString().Trim());    
                n.EndDate= (string.Format("{0}", dataReader_2[1].ToString().Trim())).Substring(0,10);
            }
            n.FromPerson = BakerFullName;
            conn2.Close();
            OpenConnection = false;
            return View("ChangeOrder",n);
        }
        public IActionResult ChangeOrderr(NewOrder n)
        {
            string s = String.Format(@"select o.""Status"",o.""Deadline"" from ""Order"" o where o.""OrderNo""={0}", n.OrderNo);
            NpgsqlCommand command2 = new NpgsqlCommand(s);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            while (dataReader_2.Read())
            {
                n.Status = string.Format("{0}", dataReader_2[0].ToString().Trim());
                n.EndDate = (string.Format("{0}", dataReader_2[1].ToString().Trim())).Substring(0, 10);
            }
            n.FromPerson = BakerFullName;
            conn2.Close();
            OpenConnection = false;
            ViewBag.Message = "* Это поле является обязательным";
            return View("ChangeOrder", n);
        }
        [HttpPost]
        public IActionResult OrderUpdate(NewOrder n)
        {
            if (n.Status=="1")
            {
                string d = n.EndDate;
                string dayd = d.Substring(0, 2);
                string monthd = d.Substring(3, 2);
                string yeard = d.Substring(6, 4);
                string deadline = yeard + '-' + monthd + '-' + dayd;


                string date = Convert.ToString(DateTime.Now);
                string ds = date.Substring(0, 10);
                string days = ds.Substring(0, 2);
                string months = ds.Substring(3, 2);
                string years = ds.Substring(6, 4);
                string now = years + '-' + months + '-' + days;


                string s = String.Format(@"select date '{0}'-date '{1}' from ""Order"" o where o.""OrderNo""={2}", deadline, now, n.OrderNo);
                NpgsqlCommand command2 = new NpgsqlCommand(s);
                command2.Connection = conn2;
                conn2.Open();
                OpenConnection = true;
                NpgsqlDataReader dataReader_2;
                dataReader_2 = command2.ExecuteReader();
                int result = 0;
                while (dataReader_2.Read())
                {
                    result = Convert.ToInt32(dataReader_2[0]);
                }
                conn2.Close();
                OpenConnection = false;
                if (result > 1)
                {
                    ViewBag.Message = "Заказ сдавать рано! Предполагаемая дата сдачи: " + deadline;
                    return View("Early");
                }
                else
                {
                    
                        string s2 = String.Format(@"update ""Order"" set ""Status""='заказ готов' where ""OrderNo""={0}", n.OrderNo);
                        NpgsqlCommand command1 = new NpgsqlCommand(s2);
                        command1.Connection = conn2;
                        conn2.Open();
                        OpenConnection = true;
                        NpgsqlDataReader dataReader_1;
                        dataReader_1 = command1.ExecuteReader();                      
                        dataReader_1.Read();
                        conn2.Close();
                    OpenConnection = false;
                    return RedirectToAction("CurrentList");
                }
            }

            return RedirectToAction("ChangeOrderr", new NewOrder {OrderNo=n.OrderNo });

        }




        public IActionResult Orders()
        {
            return View("Orders");
        }
        [HttpPost]
        public IActionResult FindOrderByPeriod(ClassPeriodReceipt cl)
        {
            if (ModelState.IsValid)
            {
                
                BakerNo = FindStaffNo();
                string start = MakeDate(cl.StartDate);
                string end = MakeDate(cl.EndDate);
                if (start == end) { return RedirectToAction("CurrentList"); }
                else
                {
                    string order = String.Format(@"select o.""OrderNo"", cl.""FirstName"" || ' ' || cl.""LastName"", cl.""TelNo"", pr.""ProductName"",d.""CountProducts""*pr.""Price"", d.""CountProducts"", o.""Status"",
                                            o.""DateOfReceipt"",o.""Deadline"", s.""FirstName""  || ' ' || s.""LastName""
                                            from ""Order"" o, ""Client"" cl, ""Product"" pr, ""Details"" d, ""Staff"" s
                                            where cl.""ClientNo"" = o.""ClientNo"" and  d.""OrderNo"" = o.""OrderNo"" and d.""CookNo""={0} and s.""StaffNo""=o.""CashierNo"" and
                                            pr.""ProductNo"" = d.""ProductNo"" and o.""DateOfReceipt"" >= '{1}' and o.""DateOfReceipt""<='{2}' and o.""Status""='заказ готов'", BakerNo, start, end);


                    List<NewOrder> orders = new List<NewOrder>();

                    string orderNo = "";
                    string From = BakerFullName;
                    string To = "";
                    string telno = "";
                    string status = "";
                    string receiptdate = "";
                    string deadline = "";
                    string Cashier = "";
                    List<string> products = new List<string>();
                    List<string> counts = new List<string>();
                    List<double> prices = new List<double>();

                    NpgsqlCommand command1 = new NpgsqlCommand(order);
                    command1.Connection = conn2;
                    conn2.Open();
                    OpenConnection = true;
                    NpgsqlDataReader dataReader_1;
                    dataReader_1 = command1.ExecuteReader();
                    while (dataReader_1.Read())
                    {
                        orderNo = "";
                        To = "";
                        telno = "";
                        receiptdate = "";
                        deadline = "";
                        products.Clear();
                        prices.Clear();
                        counts.Clear();

                        orderNo = string.Format("{0}", dataReader_1[0].ToString().Trim());
                        To = string.Format("{0}", dataReader_1[1].ToString().Trim());
                        telno = string.Format("{0}", dataReader_1[2].ToString().Trim());
                        products.Add(string.Format("{0}", dataReader_1[3].ToString().Trim()));
                        prices.Add(Convert.ToDouble(dataReader_1[4]));
                        counts.Add(string.Format("{0}", dataReader_1[5].ToString().Trim()));
                        status = string.Format("{0}", dataReader_1[6].ToString().Trim());
                        receiptdate = string.Format("{0}", dataReader_1[7].ToString().Trim());
                        deadline = string.Format("{0}", dataReader_1[8].ToString().Trim());
                        Cashier = string.Format("{0}", dataReader_1[9].ToString().Trim());
                        bool find = false;
                        int index = 0;
                        foreach (var r in orders)
                        {
                            if (r.OrderNo == orderNo) { find = true; break; }
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
                            orders[index].ProductNameWithCount += s;

                            double r2 = summ;
                            orders[index].Sum += r2;
                        }
                        else
                        {
                            string s1 = orderNo;
                            string s2 = From;
                            string s3 = To + ", " + telno;
                            string cashier = Cashier;
                            string statuss = status;
                            string s5 = "";
                            double sum = 1;
                            for (int i = 0; i < products.Count; i++)
                            {
                                s5 += "\'" + products[i] + "\', " + counts[i] + "шт. \n";
                                sum *= prices[i];
                            }
                            double s7 = sum;
                            orders.Add(new NewOrder { OrderNo = s1, FromPerson = s2, ToPerson = s3, Cashier = cashier, StartDate = receiptdate.Substring(0, 10), EndDate = deadline.Substring(0, 10), ProductNameWithCount = s5, Sum = s7, Status = statuss });
                        }

                    }
                    conn2.Close();
                    OpenConnection = false;
                    TempData["Orders"] = orders;
                    return View("ShowOrders");
                }

            }
            else return View("Orders");
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

        public IActionResult AddProducts()
        {
            string need = String.Format(@"select r.""SortRack"",sr.""SortName"",r.""CountProducts"",r.""CountProducts""-r.""CurrentProductsCount"" from 
                                        ""Rack"" r, ""Bakery"" b, ""Staff"" s, ""Sort"" sr
                                        where r.""SortRack"" = sr.""SortNo"" and r.""RackBakeryNo"" = b.""BakeryNo"" and b.""BakeryNo"" = s.""StaffBakeryNo""
                                        and s.""StaffNo"" = {0} and r.""CurrentProductsCount""<=r.""CountProducts""/2 ", BakerNo);
            NpgsqlCommand command2 = new NpgsqlCommand(need);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            int result = 0;
            List<Need> needs = new List<Need>();
            while (dataReader_2.Read())
            {
                needs.Add(new Need
                {
                    SortNo = Convert.ToInt32(dataReader_2[0]),
                    SortName = string.Format("{0}", dataReader_2[1].ToString().Trim()),
                    MaxCount = Convert.ToInt32(dataReader_2[2]),
                    NeedCount = Convert.ToInt32(dataReader_2[3])
                });
            }
            conn2.Close();

            OpenConnection = false;
            TempData["Needs"] = needs;
            return View("Needs");
        }


        [HttpPost]
        public IActionResult UpdateNeeds(Need n)
        {
            int sortno = n.SortNo;
            int need = 0;
            int max = 0;
            string find = String.Format(@"select r.""CountProducts"",r.""CountProducts""-r.""CurrentProductsCount"" from 
                                        ""Rack"" r,""Staff"" s, ""Bakery"" b   where r.""SortRack"" = {0} and r.""RackBakeryNo""=b.""BakeryNo"" and s.""StaffBakeryNo""=b.""BakeryNo"" and s.""StaffNo""= {1}", sortno, BakerNo);

            NpgsqlCommand command = new NpgsqlCommand(find);
            command.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_0;
            dataReader_0 = command.ExecuteReader();
            while(dataReader_0.Read())
            {
                max = Convert.ToInt32(dataReader_0[0]);
                need= Convert.ToInt32(dataReader_0[1]);
            }
            conn2.Close();
            OpenConnection = false;



            string update = String.Format(@"update ""Rack"" set ""CurrentProductsCount""=""CurrentProductsCount""+{0} where ""RackBakeryNo""={1} and ""SortRack""={2}", need,BakerNo,n.SortNo);
            NpgsqlCommand command2 = new NpgsqlCommand(update);
            command2.Connection = conn2;
            conn2.Open();
            OpenConnection = true;
            NpgsqlDataReader dataReader_2;
            dataReader_2 = command2.ExecuteReader();
            dataReader_2.Read();
            
            conn2.Close();
            OpenConnection =false;
            return RedirectToAction("AddProducts");
        }
    }
}
