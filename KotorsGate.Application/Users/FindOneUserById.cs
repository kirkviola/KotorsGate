﻿using KotorsGate.Application.Interfaces;
using KotorsGate.Application.Users.Interfaces;
using KotorsGate.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotorsGate.Application.Users
{
    public class FindOneUserById : IFindOneUserById
    {
        private readonly IKotorsGateDbContext _context;

        public FindOneUserById(IKotorsGateDbContext context) {
            _context = context;
        }
        public async Task<User?> GetAsync(int id) {
            return await _context.Users.FindAsync(id);
        }
    }
}
