using System;
using Microsoft.EntityFrameworkCore;
using reserreadingbe.Common;

namespace reserreadingbe.Data
{
    public class ReserreadingbeContext : DbContext
    {
        public ReserreadingbeContext(DbContextOptions<ReserreadingbeContext> options) : base(options)
        {
        }

        public DbSet<Story> Stories { get; set; }

    }
}