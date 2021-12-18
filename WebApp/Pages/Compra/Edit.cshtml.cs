using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Compra
{
    public class EditModel : PageModel
    {
        private readonly ServiceApi service;

        public EditModel(ServiceApi service)
        {
            this.service = service;
        }

        [BindProperty]
        public CompraEntity Entity { get; set; } = new CompraEntity();
        public IEnumerable<ClientesEntity> ClientesLista { get; set; } = new List<ClientesEntity>();
        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.CompraGetById(id.Value);
                }

                ClientesLista = await service.ClientesGetLista();
                ProductoLista = await service.ProductoGetLista();

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }


        }
       


    }
}
