﻿using CarRental.Domain.Entities;
using CarRental.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.EntityFrameworkCore
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(EFContext context) : base(context)
        {
        }
    }
}
