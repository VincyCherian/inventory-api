
using InventoryProject.Models;
using InventoryProject.Data;

using Microsoft.EntityFrameworkCore;    
using Microsoft.AspNetCore.Mvc;
using InventoryProject.Services;



namespace InventoryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IProductServices _services;
        public InventoryController(IProductServices services)
        {
            _services = services;
        }


        [HttpPost]
        public async Task<IActionResult> InsertProduct(Product pdt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
           
             var result = await _services.CreateProductAsync(pdt);


            if (result!=null)
                return CreatedAtAction(nameof(GetProductById), new { id = result.ProductId }, result);
            else
                return StatusCode(500,"Error while creating product");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            
            var pdt = await _services.GetProductByIDAsync(id);
            
            if (pdt!=null)
                return Ok(pdt);
            else
                return NotFound();

        }



        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var pdt = await _services.GetAllProductAsync();

            return Ok(pdt);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product p)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(id != p.ProductId)
            {
                return BadRequest("ID Mismatch");
            }

            var pdt = await _services.UpdateProductAsync(id, p);

            if(pdt == null)
            {
                return NotFound();
            }
            return Ok(pdt);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelProduct(int id)
        { 
            var p = await _services.DeleteProductAsync(id);

            if (!p)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
