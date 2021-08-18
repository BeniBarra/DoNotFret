using DoNotFret.Data;
using DoNotFret.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Services
{
    public class InstrumentService : I_Instruments
    {
        private DoNotFretDbContext _context;

        public InstrumentService(DoNotFretDbContext context)
        {
            _context = context;
        }

        public async Task<Instruments> Create(Instruments instrument)
        {
            _context.Entry(instrument).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return instrument;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Instruments>> GetAll()
        {
            return await _context.Instrument.ToListAsync();
        }

        public async Task<Instruments> GetOne(int id)
        {
            Instruments instruments = await _context.Instrument.FindAsync(id);
            return instruments;
        }

        public async Task<Instruments> Update(Instruments instruments)
        {
            _context.Entry(instruments).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return instruments;
        }
    }
}
