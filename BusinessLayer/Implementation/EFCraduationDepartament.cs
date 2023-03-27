﻿using BusinessLayer.Interface;
using DataLayer;
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class EFCraduationDepartament : ICraduationDepartament
    {
        DiplomContext _context;
        public EFCraduationDepartament(DiplomContext context) 
        { 
            _context = context;
        }

        public async Task<List<CraduationDepartament>> GetAllCraduationDepartament(bool include = false)
        {
            if (include)
            {
                return await _context.CraduationDepartament.Include(x => x.Groups).ToListAsync();
            }
            else
            {
                return await _context.CraduationDepartament.ToListAsync();
            }
        }

        public async Task<CraduationDepartament> GetCraduationDepartament(int id, bool include = false)
        {
            if (include)
            {
                return await _context.CraduationDepartament.Include(x => x.Groups).FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return await _context.CraduationDepartament.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
