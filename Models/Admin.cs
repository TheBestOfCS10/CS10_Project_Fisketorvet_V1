using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Admin : Customer
    {
        public const string JsonAdmins = @"Data\Admins.json";
        public static Dictionary<int, Admin> AdminCatalog = Helpers.JsonFileHelper<Admin>.ReadJson(JsonAdmins);
        public enum AccessLevel
        {
            Cashier,
            Manager,
            Owner,
            MallOwner
        }
        AccessLevel _access;

        public AccessLevel Access
        {
            get { return _access; }
            set { _access = value; }
        }

        //public void Create(Admin admin)
        //{
        //    for (int i = 1; i <= AdminCatalog.Count + 1; i++)
        //    {
        //        if (!AdminCatalog.ContainsKey(i))
        //        {
        //            admin.ID = i;
        //            AdminCatalog.Add(i, admin);
        //            Helpers.JsonFileHelper<Admin>.WriteToJson(AdminCatalog, JsonAdmins);
        //            break;
        //        }
        //    }
        //}
        public static Admin Convert(Customer c)
        {
            Admin a = new Admin();
            a.FirstName = c.FirstName;
            a.LastName = c.LastName;
            a.Password = c.Password;
            a.Email = c.Email;
            a.CustomerGender = c.CustomerGender;
            return a;
        }
        public static new void Create(Customer customer)
        {
            Admin admin = Convert(customer);
            admin.Access = AccessLevel.MallOwner;
            for (int i = 1; i <= AdminCatalog.Count + 1; i++)
            {
                if (!AdminCatalog.ContainsKey(i))
                {
                    admin.ID = i;
                    AdminCatalog.Add(i, admin);
                    Helpers.JsonFileHelper<Admin>.WriteToJson(AdminCatalog, JsonAdmins);
                    break;
                }
            }
        }
        public static new Admin Search(int id)
        {
            return AdminCatalog[id];
        }
        public static void Update(Admin admin)
        {
            foreach (Admin c in AdminCatalog.Values)
            {
                if (c.ID == admin.ID)
                {
                    c.FirstName = admin.FirstName;
                    c.LastName = admin.LastName;
                    c.Email = admin.Email;
                    c.CustomerGender = admin.CustomerGender;
                    Helpers.JsonFileHelper<Admin>.WriteToJson(AdminCatalog, JsonAdmins);
                }
            }
        }
        public static new void Delete(int id)
        {
            AdminCatalog.Remove(id);
            Helpers.JsonFileHelper<Admin>.WriteToJson(AdminCatalog, JsonAdmins);
        }
    }
}
