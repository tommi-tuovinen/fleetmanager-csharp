using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        [BsonElement("year")]
        public int? ModelYear { get; set; }

        [BsonElement("make")]
        public string Make { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("registration")]
        public string Registration { get; set; }

        [BsonElement("inspection date")]
        public string InspectionDate { get; set; }

        [BsonElement("engine size")]
        public string EngineSize { get; set; }

        [BsonElement("engine power")]
        public string EnginePower { get; set; }
    }
}