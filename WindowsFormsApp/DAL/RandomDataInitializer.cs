using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.DAL
{
    class RandomDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RandomDataContext>
    {
        protected override void Seed(RandomDataContext context)
        {
            var data = new List<RandomData>
            {
                new RandomData{ThreadID=0,Data="TEST",Time=DateTime.Parse("2021-01-01")},
            };

            data.ForEach(s => context.RandomDataList.Add(s));
            context.SaveChanges();

        }
    }
}
