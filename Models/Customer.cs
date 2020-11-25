﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Models
{
    public class Customer
    {
        public const string JsonCustomers = @"C:\Users\Radu\source\repos\TheBestOfCS10\CS10_Project_Fisketorvet_V1\Data\Customers.json";
        int _id;
        string _name;
        string _password;
        string[] _passwords = new string[2];
        string _email;
        public enum Gender
        {
            Male,
            Female
        }
        Gender _gender;
        public static Dictionary<int, Customer> Catalog = Helpers.JsonFileReader<Customer>.ReadJson(JsonCustomers);
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [Required(ErrorMessage ="The name is required")]
        [MaxLength(40, ErrorMessage ="The name cannot be this long")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [Required(ErrorMessage = "The password is required")]
        [MaxLength(20, ErrorMessage = "The password must be maximum 20 characters long")]
        public string Password
        {
            get { return _passwords[0]; }
            set { _passwords[0] = value; }
        }
        [Required(ErrorMessage = "Your need to confirm your password")]
        
        public string ConfirmPassword
        {
            get { return _passwords[1]; }
            set { _passwords[1] = value; }
        }
        [Validators.ConfirmPassword(ErrorMessage = "The passwords do not match")]
        public string[] Passwords
        {
            get { return _passwords; }
            set { _passwords = value; }
        }
        [Required(ErrorMessage = "The email is required")]
        [Validators.EmailValidation(ErrorMessage ="This email is already taken")]
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
        public static void Create(Customer customer)
        {
            for(int i = 1; i<= Catalog.Count+1; i++)
            {
                if (!Catalog.ContainsKey(i))
                {
                    customer.ID = i;
                    Catalog.Add(i, customer);
                    Helpers.JsonFileWritter<Customer>.WriteToJson(Catalog, JsonCustomers);
                    break;
                }
            }
        }
        public static bool VerifyUser(Customer customer)
        {
            foreach(Customer c in Catalog.Values)
            {
                if (c.Email == customer.Email && c.Password == customer.Password) return true;
            }
            return false;
        }
    }
}
