using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class BankAccount
    {
        static Random rng = new Random();
        public double Balance
        {
            get; set;
        }
        [Required(ErrorMessage = "The card number is required")]
        public int CardNr
        {
            get; set;
        }
        [Required(ErrorMessage = "The registration number is required")]
        public int RegNr
        {
            get; set;
        }
        [Required(ErrorMessage = "The expiration date is required")]
        public DateTime ExprDate
        {
            get; set;
        }
        [Required(ErrorMessage = "The PIN is required")]
        [Range(1000, 9999)]
        public int PIN
        {
            get; set;
        }
        [Required(ErrorMessage = "The bank name is required")]
        [MaxLength(30)]
        public string BankName
        {
            get; set;
        }

        public static void Add(BankAccount account, int[] user)
        {
            account.Balance = rng.Next(1000, 3000);  
            if (user[1] == 1)
            {
                Admin.AdminCatalog[user[0]].Account = account;
                Helpers.JsonFileHelper<Admin>.WriteToJson(Admin.AdminCatalog, Admin.JsonAdmins);
            }
            else
            {
                Customer.Catalog[user[0]].Account = account;
                Helpers.JsonFileHelper<Customer>.WriteToJson(Customer.Catalog, Customer.JsonCustomers);
            }
        }
        public static void Remove(int[] user)
        {
            if (user[1] == 1)
            {
                Admin.AdminCatalog[user[0]].Account = null;
                Helpers.JsonFileHelper<Admin>.WriteToJson(Admin.AdminCatalog, Admin.JsonAdmins);
            }
            else
            {
                Customer.Catalog[user[0]].Account = null;
                Helpers.JsonFileHelper<Customer>.WriteToJson(Customer.Catalog, Customer.JsonCustomers);
            }
        }
        public void Pay(double amount)
        {
            if (CanPay(amount))
                Balance -= amount;
            else return;
        }
        public bool CanPay(double amount)
        {
            if (Balance >= amount) return true;
            else return false;
        }
    }
}
