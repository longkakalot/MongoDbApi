using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDb.Models
{
    public class SinhVienDatabaseSettings : ISinhVienDatabaseSettings
    {
        public string SinhVienCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISinhVienDatabaseSettings
    {
        string SinhVienCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
