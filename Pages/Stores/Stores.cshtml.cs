using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS10_Project_Fisketorvet_V1.Interfaces;
using CS10_Project_Fisketorvet_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS10_Project_Fisketorvet_V1.Pages.Stores
{
    public class StoresModel : PageModel
    {
        public Dictionary<int,Store> Stores { get; private set; }
        IStores repo;
        [BindProperty(SupportsGet =true)]
        public string FilterCriteria { get; set; }
        public StoresModel(IStores repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            Stores = repo.AllStores();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Stores = repo.FilterStores(FilterCriteria);
            }
            return Page();
        }
    }
}
