
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rest.Model
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

       
        public string Email { get; set; }
        public string Password { get; set; }
    }
}