using DoNotFret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public interface ICategory
    {
        Task<Instrument> Create(Category category);

        Task<List<Instrument>> GetAll();

        Task<Instrument> GetOne(int id);

        Task<Instrument> Update(Category category);

        Task Delete(int id);
    }
}
