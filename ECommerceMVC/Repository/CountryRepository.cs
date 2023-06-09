﻿using ECommerceMVC.Context;
using ECommerceMVC.Migrations;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly EcommerceDbContext context;

        public CountryRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Country country = GetById(id);
            country.IsDeleted = true;
            country.DeletedOnUtc = DateTime.UtcNow;
            context.SaveChanges();
        }

        public List<Country> GetAll()
        {
            return context.Country.Where(i => i.IsDeleted == false).ToList();
        }

        public Country GetById(int id)
        {
            return context.Country.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Country newcountry)
        {
            context.Country.Add(newcountry);
            context.SaveChanges();
        }

        public void Update(int id, Country country)
        {
            context.Update(country);
            context.SaveChanges();
        }
    }
}
