using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace plants_for_cats.model
{
    public class PlantsCompedium
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string ScientificName { get; set; }
    }
}
