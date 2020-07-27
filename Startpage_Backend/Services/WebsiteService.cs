using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Startpage_Backend.Models;

namespace Startpage_Backend.Services
{
    public class WebsiteService
    {
        // Get access to appsettings.json
        private readonly IMongoCollection<Website> _websites;

        public WebsiteService(IStartpageDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _websites = database.GetCollection<Website>(settings.StartpageCollectionName);
        }

        // CRUD operations
        // Get all websites
        public List<Website> Get() =>
            _websites.Find(Website => true).ToList();
        // Get a single website by id
        public Website Get(string id) =>
            _websites.Find<Website>(website => website.Id == id).FirstOrDefault();
        // Create a new website object
        public Website Create(Website website)
        {
            _websites.InsertOne(website);
            return website;
        }
        // Update a website
        public void Update(string id, Website websiteIn) =>
            _websites.ReplaceOne(website => website.Id == id, websiteIn);
        // Remove by using website object
        public void Remove(Website websiteIn) =>
            _websites.DeleteOne(website => website.Id == websiteIn.Id);
        // Remove by using id only
        public void Remove(string id) =>
            _websites.DeleteOne(website => website.Id == id);
    }
}
