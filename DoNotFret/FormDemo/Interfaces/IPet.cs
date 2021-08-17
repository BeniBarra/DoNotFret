using FormDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormDemo.Interfaces
{
    public interface IPet
    {
        Task<Pet> Create(Pet pet);

        Task<List<Pet>> GetAll();

        Task<Pet> GetOne(int id);

        Task<Pet> Update(Pet id);

        Task Delete(int id);
    }
}
