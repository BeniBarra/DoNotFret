using DoNotFret.Data;
using DoNotFret.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Pages;
using Microsoft.AspNetCore.Mvc;

namespace DoNotFret.Services
{
    public class InstrumentService : I_Instrument
    {
        private DoNotFretDbContext _context;

        public InstrumentService(DoNotFretDbContext context)
        {
            _context = context;
        }

        public async Task<Instrument> Create(Instrument instrument)
        {
            _context.Entry(instrument).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return instrument;
        }

        public async Task Delete(int id)
        {
            Instrument instrument = await _context.Instrument.FindAsync(id);
            _context.Entry(instrument).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Instrument>> GetAll()
        {
            return await _context.Instrument.ToListAsync();
        }

        public async Task<Instrument> GetOne(int id)
        {
            Instrument instruments = await _context.Instrument.FindAsync(id);
            return instruments;
        }

        public async Task<Instrument> Update(Instrument instruments)
        {
            _context.Entry(instruments).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return instruments;
        }

    }
}
