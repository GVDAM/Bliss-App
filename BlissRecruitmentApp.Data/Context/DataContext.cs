using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace BlissRecruitmentApp.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //DbSets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ContextMaps

            base.OnModelCreating(modelBuilder);
        }
    }
}
