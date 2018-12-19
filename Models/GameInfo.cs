using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uni.DB_Task.Models
{
    public class GameInfo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string AppId { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string LogoUrl { get; set; }

        public string GetLogoUrl => $"http://media.steampowered.com/steamcommunity/public/images/apps/{AppId}/{LogoUrl}.jpg";
        public string GetIconUrl => $"http://media.steampowered.com/steamcommunity/public/images/apps/{AppId}/{IconUrl}.jpg";
    }
}
