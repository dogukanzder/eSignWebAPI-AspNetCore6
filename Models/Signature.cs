//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSignAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Signature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = String.Empty;

        [BsonElement("startDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime StartDate { get; set; }

        [BsonElement("endDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime EndDate { get; set; }

        [BsonElement("reminder")]
        public string Reminder { get; set; } = String.Empty;

        [BsonElement("files")]
        public byte[][]? Files { get; set; }

        [BsonElement("users")]
        public string[]? Users { get; set; }

        [BsonElement("nextSigner")]
        public string NextSigner { get; set; } = String.Empty;

    }
}
