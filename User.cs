using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YourAppNamespace.Models
{
    public class User
    {
        // This will map the _id field in MongoDB to the Id property in C#
        [BsonId]  // Indicates that this property is the MongoDB _id field
        [BsonRepresentation(BsonType.ObjectId)]  // Converts ObjectId to string for ease of use
        public string Id { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
