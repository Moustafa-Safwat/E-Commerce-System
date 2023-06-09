﻿using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        EcommerceDbContext context;

        public ProductCategoryRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            ProductCategory productCategory = GetById(id);
            context.ProductCategory.Remove(productCategory);
            context.SaveChanges();
        }

        public List<ProductCategory> GetAll()
        {
            return context.ProductCategory.ToList();
        }
        public List<ProductCategory> GetByCategoryId(int catid)
        {
            return context.ProductCategory.Include(i=>i.Product).ThenInclude(i=>i.ProductReviews).Where(i => i.CategoryId == catid && i.Product.IsDeleted == false).ToList();
        }

        public ProductCategory GetById(int id)
        {
            return context.ProductCategory.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductCategory productCategory)
        {
            context.ProductCategory.Add(productCategory);
            context.SaveChanges();
        }

        public void Update(int id, ProductCategory productCategory)
        {
            context.Update(productCategory);
            context.SaveChanges();
        }
    }
}
