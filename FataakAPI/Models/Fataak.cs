using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace FataakAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Fataak
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string GateTitle { get; set; } = String.Empty;

        [BsonElement("status")]
        public bool GateStatus { get; set; }
    }
}
