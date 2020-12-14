using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Administration.Order
{
    public class EditOrderModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "The Zip code is required")]
        [Range(1000, 9999)]
        public int ZIP
        {
            get; set;
        }
        [Required(ErrorMessage = "The street is required")]
        [BindProperty]
        [MaxLength(50)]
        public string Street
        {
            get; set;
        }
        [Required(ErrorMessage = "The street number is required")]
        [BindProperty]
        public string StreetNR
        {
            get; set;
        }
        [BindProperty]
        static public Models.Order Order
        {
            get;set;
        }
        public IActionResult OnGet(int id)
        {
            Order = Models.Order.Catalog[id];
            ZIP = Order.ZIP;
            Street = Order.Street;
            StreetNR = Order.StreetNR;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order.ZIP = ZIP;
            Order.Street = Street;
            Order.StreetNR = StreetNR;
            Models.Order.Update(Order);
            return RedirectToPage("/Administration/AdminOrders");
        }
    }
}
