using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace sgprojectmanagement.Models
{
    public class EmployeeProfile
    {
        [BsonElement("_id")]
        public ObjectId MongoId { get; set; }
        [BsonElement("EmployeeId")]
        public string EmployeeId { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
    }
}