using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController(IProductImageService productImageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var values = await productImageService.GetAllProductImageAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var value = await productImageService.GetByIdProductImageAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await productImageService.CreateProductImageAsync(createProductImageDto);
        return Ok("Ürün resmi başarıyla oluşturuldu.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await productImageService.UpdateProductImageAsync(updateProductImageDto);
        return Ok("Ürün resmi başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await productImageService.DeleteProductImageAsync(id);
        return Ok("Ürün resmi başarıyla silindi.");
    }
}