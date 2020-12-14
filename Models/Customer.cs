using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Customer
    {
        public const string JsonCustomers = @"Data\Customers.json";
        int _id;
        string _firstname;
        string _lastname;
        string _password;
        string _email;
        BankAccount _account;
        int _basketid;
        public enum Gender
        {
            Male,
            Female
        }
        Gender _gender;
        public static Dictionary<int, Customer> Catalog = Helpers.JsonFileHelper<Customer>.ReadJson(JsonCustomers);
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [Required(ErrorMessage ="The first name is required")]
        [MaxLength(20, ErrorMessage ="The name cannot be this long")]
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        [Required(ErrorMessage = "The last name is required")]
        [MaxLength(20, ErrorMessage = "The name cannot be this long")]
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        //[Required(ErrorMessage = "The password is required")]
        //[MaxLength(20, ErrorMessage = "The password must be maximum 20 characters long")]
        //[MinLength(6, ErrorMessage ="The password must be at least 6 characters long")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        //[Required(ErrorMessage = "Your need to confirm your password")]
        //public string ConfirmPassword
        //{
        //    get { return _passwords[1]; }
        //    set { _passwords[1] = value; }
        //}
        //[Validators.ConfirmPassword(ErrorMessage = "The passwords do not match")]
        //public string[] Passwords
        //{
        //    get { return _passwords; }
        //    set { _passwords = value; }
        //}
        [Required(ErrorMessage = "The email is required")]
        [Validators.EmailValidation(false, ErrorMessage ="This email is already taken")]
        [EmailAddress(ErrorMessage ="This is not a valid email adress")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [Required(ErrorMessage = "You need to pick a gender")]
        public Gender CustomerGender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public BankAccount Account
        {
            get { return _account; }
            set { _account = value; }
        }
        public int BasketID
        {
            get { return _basketid; }
            set { _basketid = value; }
        }
        public static void Create(Customer customer)
        {
            for(int i = 1; i<= Catalog.Count+1; i++)
            {
                if (!Catalog.ContainsKey(i))
                {
                    customer.ID = i;
                    Catalog.Add(i, customer);
                    Helpers.JsonFileHelper<Customer>.WriteToJson(Catalog, JsonCustomers);
                    break;
                }
            }
        }
        public static Customer Search(int id)
        {
            return Catalog[id];
        }
        public static void Update(Customer customer)
        {
            foreach (Customer c in Catalog.Values)
            {
                if (c.ID == customer.ID)
                {
                    c.FirstName = customer.FirstName;
                    c.LastName = customer.LastName;
                    c.Email = customer.Email;
                    c.CustomerGender = customer.CustomerGender;
                    Helpers.JsonFileHelper<Customer>.WriteToJson(Catalog, JsonCustomers);
                    break;
                }
            }
        }
        public static void Delete(int id)
        {
            Catalog.Remove(id);
            Helpers.JsonFileHelper<Customer>.WriteToJson(Catalog, JsonCustomers);
        }
    }
}
