using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Authorization;

namespace IdentityApp.Pages.Invoices
{
    public class DetailsModel : DI_BasePageModel
    {
        public DetailsModel(ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        { 
        }

      public Invoice Invoice { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || Context.Invoice == null)
            {
                return NotFound();
            }

            Invoice = await Context.Invoice.FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (Invoice == null)
            {
                return NotFound();
            }

            var isAuthorizated = await AuthorizationService.AuthorizeAsync(
                User, Invoice, InvoiceOperations.Read);

            if(isAuthorizated.Succeeded == false)
            {
                return Forbid();
            }
            
            return Page();
        }
    }
}
