using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using plants_for_cats.DataLayer;
using plants_for_cats.model;

namespace plants_for_cats.Controllers
{
    public class MongoController : ControllerBase
    {
        private readonly ILogger<MongoController> _logger;
        private readonly IMongoHelper _mongoHelper;
        public MongoController(ILogger<MongoController> logger, IMongoHelper mongo)
        {
            _logger = logger;
            _mongoHelper = mongo;
        }

        [HttpGet("Get")]
        public async Task<IEnumerable<PlantsCompedium>> GetPlants()
        {
            return await _mongoHelper.GetAllDocuments<PlantsCompedium>("plantsForCats", "plantsForCats");
        }

        [HttpGet("GetByName")]
        public async Task<IEnumerable<PlantsCompedium>> GetByName(string name)
        {
            var filter = Builders<PlantsCompedium>.Filter.Eq("Name", name);
            return await _mongoHelper.GetFilteredDocuments<PlantsCompedium>("plantsForCats", "plantsForCats", filter);
        }

        [HttpPost("Post")]
        public async Task CreateDetails(PlantsCompedium plantsCompedium)
        {
            await _mongoHelper.CreateDocument<PlantsCompedium>("plantsForCats", "plantsForCats", plantsCompedium);
        }

        [HttpDelete("Delete")]
        public async Task DeleteDetails(int id)
        {
            var filter = Builders<PlantsCompedium>.Filter.Eq("_id", id);
            await _mongoHelper.DeleteDocument<PlantsCompedium>("plantsForCats", "plantsForCats", filter);
        }

        
    }
}
