using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using Pryanichek_version_1000.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pryanichek_version_1000.Controllers
{
    public class AdminController :Controller
    {
        public bool connToAccounts=false;
        public bool connToPryanick=false;
        public NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5434;Database=Users;Username=manager_ad;Password=julia");
        public NpgsqlConnection conn2  = new NpgsqlConnection("Host=localhost;Port=5434;Database=new_pryanick;Username=manager_ad;Password=julia");

        public AdminController()
        {
           
        }
        public IActionResult Index() 
        {
            
            return View("~/Views/Admin/Index.cshtml"); 
        }

        public IActionResult MakeAccout()
        {
          
            return View("AddAccount");
        }
        [HttpPost]
        public IActionResult Check_login(User user)
        {
            if (ModelState.IsValid)
            {
                return MakeUserAccount(user);
            }
            else
            {
                ViewBag.Message = "Введенные данные некорректны. Пожалуйста, повторите запрос.";
                return View("AddAccount",user);
            }
        }
        [HttpGet]
        public IActionResult MakeUserAccount(User user)
        {
            string new_password = MakeMd5Hash(user.Password);
            string login = user.Login;
            string roleName = user.RoleName;
            string FName = user.FirstName;
            string LName = user.LastName;
            string TelNo = user.TelNo;
            conn2.Open();
            conn.Open();

            int countUsers = 0;
            int countWorkers = 0;
            string u = String.Format(@" select count(""AccountNo"") from ""UsersAccounts2"" as s where s.""FirstName"" = '{0}' and s.""LastName"" = '{1}' and s.""RoleName""='{2}' and s.""TelNo"" ='{2}'", FName, LName, roleName,TelNo);
            NpgsqlCommand command = new NpgsqlCommand(u);
            command.Connection = conn;
            NpgsqlDataReader dataReader_1;
            dataReader_1 = command.ExecuteReader();
            while(dataReader_1.Read())
            {
                countUsers += Convert.ToInt32(string.Format("{0}", dataReader_1[0]));
            }
            conn.Close();

            string w = String.Format(@" select count(""StaffNo"") from ""Staff"" as s, ""Position"" as p1 where ""FirstName""='{0}' and ""LastName""='{1}' and
            s.""PositionNo"" = p1.""PositionNo"" and s.""TelNo""='{2}' and p1.""PositionName"" = '{3}' and s.""IsFired""='false'", FName, LName, TelNo,roleName);
            NpgsqlCommand commandW = new NpgsqlCommand(w);           
            commandW.Connection = conn2;
            NpgsqlDataReader dataReader_3;
            dataReader_3 = commandW.ExecuteReader();
            while (dataReader_3.Read())
            {
                countWorkers += Convert.ToInt32(string.Format("{0}", dataReader_3[0]));
            }
            conn2.Close();


            if (countWorkers == 0)
            {
                ViewBag.Message = "Такого работника не существует. Повторите запрос.";
                return View("AddAccount");
            }
            else if (countWorkers == 1 && countUsers == 0)
            {
                ViewBag.Message = "Работник успешно зарегистрирован";
                string add= String.Format(@"insert into ""UsersAccounts2"" (""FirstName"",""LastName"" ,""TelNo"" ,""Login"",""Password"",""RoleName"") values ('{0}','{1}','{2}','{3}','{4}','{5}')", FName, LName, TelNo, login, new_password, roleName);
                
                conn.Open();
                NpgsqlCommand commandAdd = new NpgsqlCommand(add);
                commandAdd.Connection = conn;
                NpgsqlDataReader dataReader_add;
                dataReader_add = commandAdd.ExecuteReader();
                dataReader_add.Read();
                conn.Close();
                if (roleName=="Пекарь" || roleName=="Кондитер")
                {
                   conn2.Open();
                   string role= String.Format(@"create role " + login + " in role baker login password '"+user.Password+"'");
                   NpgsqlCommand commandRole = new NpgsqlCommand(role);
                   commandRole.Connection = conn2;
                   NpgsqlDataReader dataReader_role;
                   dataReader_role = commandRole.ExecuteReader();
                   dataReader_role.Read();
                   conn2.Close();

                   conn2.Open();
                   string grant = String.Format(@"grant baker to " + login);
                   NpgsqlCommand commandGrant = new NpgsqlCommand(grant);
                   commandGrant.Connection = conn2;
                   NpgsqlDataReader dataReader_grant;
                   dataReader_grant = commandGrant.ExecuteReader();
                   dataReader_grant.Read();
                   conn2.Close();

                }
                else if(roleName=="Директор")
                {
                    conn2.Open();
                    string role = String.Format(@"create role " + login + " in role director login password '" + user.Password + "'");
                    NpgsqlCommand commandRole = new NpgsqlCommand(role);
                    commandRole.Connection = conn2;
                    NpgsqlDataReader dataReader_role;
                    dataReader_role = commandRole.ExecuteReader();
                    dataReader_role.Read();
                    conn2.Close();

                    conn2.Open();
                    string grant = String.Format(@"grant director to " + login);
                    NpgsqlCommand commandGrant = new NpgsqlCommand(grant);
                    commandGrant.Connection = conn2;
                    NpgsqlDataReader dataReader_grant;
                    dataReader_grant = commandGrant.ExecuteReader();
                    dataReader_grant.Read();
                    conn2.Close();
                }
                else if(roleName=="Продавец")
                {
                    conn2.Open();
                    string role = String.Format(@"create role " + login + " in role seller login password '" + user.Password + "'");
                    NpgsqlCommand commandRole = new NpgsqlCommand(role);
                    commandRole.Connection = conn2;
                    NpgsqlDataReader dataReader_role;
                    dataReader_role = commandRole.ExecuteReader();
                    dataReader_role.Read();
                    conn2.Close();

                    conn2.Open();
                    string grant = String.Format(@"grant seller to " + login);
                    NpgsqlCommand commandGrant = new NpgsqlCommand(grant);
                    commandGrant.Connection = conn2;
                    NpgsqlDataReader dataReader_grant;
                    dataReader_grant = commandGrant.ExecuteReader();
                    dataReader_grant.Read();
                    conn2.Close();
                }
               



            }
            else if (countWorkers == 1 && countUsers == 1)
            {
                ViewBag.Message = "Данный работник уже зарегистрирован";
            }

            return View("Index");
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
        public IActionResult SignOut()
        {
            conn.Close();
            conn2.Close();
            connToAccounts = false;
            connToPryanick = false;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
