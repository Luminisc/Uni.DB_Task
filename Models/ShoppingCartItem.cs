using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uni.DB_Task.Models
{
    public class ShoppingCartItem
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string PathThumbnail { get; set; }
    }
}
