using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly ServiceApi service;

        public EditModel(ServiceApi service)
        {
            this.service = service;
        }


      

        [BindProperty]
        public ClientesEntity Entity { get; set; } = new ClientesEntity();
     

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.ClientesGetById(id.Value);
                }

              

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }
 







    }
}
