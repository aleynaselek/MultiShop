using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult> ProductList() 
        {
            var values = await _ProductService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(string id)
        {
            var values = await _ProductService.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _ProductService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi");
        }


        [HttpPut]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");
        }
    }
}
