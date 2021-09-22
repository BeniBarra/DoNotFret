using DoNotFret.Data;
using DoNotFret.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public class CategoryService : ICategory
    {

        private readonly DoNotFretDbContext _context;

        public CategoryService(DoNotFretDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return category;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }

        public Task<Category> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
