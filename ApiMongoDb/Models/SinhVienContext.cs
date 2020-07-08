using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiMongoDb.Models
{
    public class SinhVienContext : DbContext
    {
        public SinhVienContext(DbContextOptions<SinhVienContext> options) : base(options)
        {
        }
        public DbSet<SinhVien> SinhViens { get; set; }
    }
}
