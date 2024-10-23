using MongoDB.Driver;
using YourAppNamespace.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace YourAppNamespace.Services
{
    public class MongoUserService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoUserService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:Database"]);
            _usersCollection = database.GetCollection<User>(configuration["MongoDB:Collection"]);
        }

        // Insert a new user into MongoDB
        public async Task InsertUserAsync(User user)
        {
            try
            {
                await _usersCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while inserting the user.", ex);
            }
        }

        // Get a user by email from MongoDB for sign-in
        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(u => u.Email, email);
                return await _usersCollection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while fetching the user.", ex);
            }
        }
    }
}
