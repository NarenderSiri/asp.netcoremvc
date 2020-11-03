using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleProject.Models;

namespace SampleProject.Data
{
    public class SampleProjectContext : DbContext
    {
        public SampleProjectContext (DbContextOptions<SampleProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SampleProject.Models.SampleModel> SampleModel { get; set; }
    }
}
