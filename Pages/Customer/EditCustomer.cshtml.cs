using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Customer
{
    public class EditCustomerModel : PageModel
    {
        string _firstname;
        string _lastname;
        Models.Customer.Gender _gender;
        static public string ReturnPage;
        public static Models.Customer Customer
        {
            get; set;
        }
        [BindProperty, Required(ErrorMessage = "The first name is required"), MaxLength(20, ErrorMessage = "The first name cannot be this long")]
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        [BindProperty, Required(ErrorMessage = "The first name is required"), MaxLength(20, ErrorMessage = "The last name cannot be this long")]
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        [BindProperty, Required(ErrorMessage = "The gender is required")]
        public Models.Customer.Gender CustomerGender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public IActionResult OnGet(int id, string returnpage)
        {
            if (returnpage != null) ReturnPage = returnpage;
            Customer = Models.Customer.Search(id);
            FirstName = Customer.FirstName;
            LastName = Customer.LastName;
            CustomerGender = Customer.CustomerGender;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ReturnPage == null) ReturnPage = "/LoggedInUser/UserProfile";
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer.FirstName = FirstName;
            Customer.LastName = LastName;
            Customer.CustomerGender = CustomerGender;
            Models.Customer.Update(Customer);
            return RedirectToPage(ReturnPage);
        }
    }
}
