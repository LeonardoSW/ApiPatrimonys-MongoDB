using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace hvn_project.Models
{
    public class PatrimonyItems
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }

        [BsonElement("createDate")]
        public DateTime CreateDate { get; set; }

        [BsonElement("updateDate")]
        public DateTime UpdateDate { get; set; }

        [BsonElement("patrimonyNumber")]
        public string PatrimonyNumber  { get; set; }
    }
}
