using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var values = await categoryService.GetAllCategoriesAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var value = await categoryService.GetByIdCategoryAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await categoryService.CreateCategoryAsync(createCategoryDto);
        return Ok("Kategori başarıyla oluşturuldu.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await categoryService.DeleteCategoryAsync(id);
        return Ok("Kategori başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await categoryService.UpdateCategoryAsync(updateCategoryDto);
        return Ok("Kategori başarıyla güncellendi.");
    }
}