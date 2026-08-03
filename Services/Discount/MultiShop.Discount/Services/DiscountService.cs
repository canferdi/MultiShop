using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService(DapperContext context) : IDiscountService
{
    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
    {
        const string query = "SELECT * FROM Coupons";
        using var connection = context.CreateConnection();
        var coupons = await connection.QueryAsync<ResultDiscountCouponDto>(query);
        return coupons.ToList();
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
    {
        const string query =
            "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@code, @rate, @isActive, @validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
    {
        const string query =
            "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);
        parameters.Add("@couponId", updateCouponDto.CouponId);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteDiscountCouponAsync(int couponId)
    {
        const string query = "DELETE FROM Coupons WHERE CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);
        using var connection = context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<GetByIdDiscountCouponDto> GetDiscountCouponByIdAsync(int couponId)
    {
        const string query = "SELECT * FROM Coupons WHERE CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", couponId);
        using var connection = context.CreateConnection();
        var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
        return coupon ?? throw new Exception($"Coupon with ID {couponId} not found.");
    }
}