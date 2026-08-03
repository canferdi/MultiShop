using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController(IProductDetailService productDetailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await productDetailService.GetAllProductDetailsAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var value = await productDetailService.GetByIdProductDetailAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await productDetailService.CreateProductDetailAsync(createProductDetailDto);
        return Ok("Ürün detayı başarıyla oluşturuldu.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return Ok("Ürün detayı başarıyla güncellendi.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await productDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı başarıyla silindi.");
    }
}