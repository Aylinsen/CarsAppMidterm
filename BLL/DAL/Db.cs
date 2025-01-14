﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<TypeCar> TypeCars { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<CarOwner> CarOwners { get; set; }

        public Db(DbContextOptions options) : base (options)
        {

        }
    }
}
