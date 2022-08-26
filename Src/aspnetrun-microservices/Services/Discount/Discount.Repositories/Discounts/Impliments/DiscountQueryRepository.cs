using System;
using Dapper;
using Discount.DataAccessLayers.Context;
using Discount.Domains.Discounts.Entities;
using Discount.Domains.Discounts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Repositories.Discounts.Impliments
{
    public class DiscountQueryRepository: IDiscountQueryRepository
    {
       private readonly IConfiguration _configuration;
        private NpgsqlConnection _connection;
        private readonly DiscountContext _db;

        public DiscountQueryRepository(IConfiguration configuration, DiscountContext db)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));

            _connection = new NpgsqlConnection(_configuration["ConnectionStrings:DiscountContext"]);
            _db = db;
        }

        public async Task<IEnumerable<Coupon>> GetAllDiscount()=>
           // await _connection.QueryAsync<Coupon>("select * from Coupons");
          await _db.Coupons.ToListAsync();

        public async Task<Coupon> GetDiscountById(Guid id) =>
       // await _connection.QueryFirstOrDefaultAsync<Coupon>
       // ("select * from Coupons where Id=@Id", new { @Id=id});
       await _db.Coupons.FirstOrDefaultAsync(c=>c.Id==id);


        public async Task<Coupon> GetDiscountByProductName(string productName) =>
            //   await _connection.QueryFirstOrDefaultAsync<Coupon>
            //    ("select * from Coupons where productName=@ProductName", new { @ProductName=productName });
            await _db.Coupons.FirstOrDefaultAsync(c=>c.ProductName==productName);
        
    }
}

