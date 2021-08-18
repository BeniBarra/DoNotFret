using DoNotFret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public interface I_Instruments
    {
        Task<Instruments> Create(Instruments instrument);

        Task<List<Instruments>> GetAll();

        Task<Instruments> GetOne(int id);

        Task<Instruments> Update(Instruments instruments);

        Task Delete(int id);
    }
}
