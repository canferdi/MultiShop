using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController(IDiscountService discountService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCoupons() => Ok(await discountService.GetAllDiscountCouponsAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCouponById(int id) => Ok(await discountService.GetDiscountCouponByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CreateDiscountCouponDto createCouponDto)
    {
        await discountService.CreateDiscountCouponAsync(createCouponDto);
        return Ok("Coupon created successfully.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        await discountService.DeleteDiscountCouponAsync(id);
        return Ok("Coupon deleted successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
    {
        await discountService.UpdateDiscountCouponAsync(updateCouponDto);
        return Ok("Coupon updated successfully.");
    }
}