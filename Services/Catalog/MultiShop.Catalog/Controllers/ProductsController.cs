using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var values = await productService.GetAllProductsAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var value = await productService.GetByIdProductAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await productService.CreateProductAsync(createProductDto);
        return Ok("Ürün başarıyla oluşturuldu.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await productService.DeleteProductAsync(id);
        return Ok("Ürün başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await productService.UpdateProductAsync(updateProductDto);
        return Ok("Ürün başarıyla güncellendi.");
    }
}