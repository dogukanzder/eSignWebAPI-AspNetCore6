//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eSignAPI.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("surname")]
        public string Surname { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = String.Empty;

        [BsonElement("contacts")]
        public string[]? Contacts { get; set; }

        [BsonElement("package")]
        public string Package { get; set; } = String.Empty;

        [BsonElement("signatures")]
        public string[]? Signatures { get; set; }

    }
}
