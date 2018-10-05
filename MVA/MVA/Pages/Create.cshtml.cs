using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVA.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        public ILogger<CreateModel> Logger;

        public CreateModel(AppDbContext db, ILogger<CreateModel> logger)
        {
            _db = db;
            Logger = logger;                          
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            var msg = $"Customer {Customer.Name} added!";
            Message = msg;
            Logger.LogCritical(msg);
            return RedirectToPage("/Index");
        }
    }
}