using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongoDb.Models
{
    public class SinhVien
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }

        public string ID { get; set; }

        public string SoBD { get; set; }
        public string Math { get; set; }
        public string Viet { get; set; }
        public string English { get; set; }
        public string Physics { get; set; }
        public string Chemistry { get; set; }
        public string Biology { get; set; }
        public string History { get; set; }
        public string Geography { get; set; }
        public string GDCD { get; set; }
        public string KhoiA { get; set; }
        public string KhoiB { get; set; }
        public string KhoiC { get; set; }
        public string KhoiD { get; set; }
        public string KhoiA1 { get; set; }

    }
}
