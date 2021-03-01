using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.DAL
{
    class RandomDataContext:DbContext
    {
        public RandomDataContext() : base("RandomDataContext")
        {
        }

        public DbSet<RandomData> RandomDataList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
