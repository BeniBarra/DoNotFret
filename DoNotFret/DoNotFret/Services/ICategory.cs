using DoNotFret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public interface ICategory
    {
        Task<Category> Create(Category category);

        Task<List<Category>> GetAll();

        Task<Category> GetOne(int id);

        Task<Category> Update(Category category);

        Task Delete(int id);
    }
}
