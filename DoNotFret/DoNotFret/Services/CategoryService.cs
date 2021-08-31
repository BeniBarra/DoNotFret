using DoNotFret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public class CategoryService : ICategory
    {
        public Task<Instrument> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Instrument>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Instrument> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Instrument> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
