using DoNotFret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public interface I_Instrument
    {
        Task<Instrument> Create(Instrument instrument);

        Task<List<Instrument>> GetAll();

        Task<Instrument> GetOne(int id);

        Task<Instrument> Update(Instrument instruments);

        Task Delete(int id);
    }
}
