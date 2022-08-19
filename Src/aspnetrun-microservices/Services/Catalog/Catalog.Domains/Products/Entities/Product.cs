using System;
using aspnetrun_microservice.Frameworks.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domains.Products.Entities
{
    public class Product:BaseMongoEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }

    }
}

