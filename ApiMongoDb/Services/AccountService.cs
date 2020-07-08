using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace ApiMongoDb.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> _mongoCollection;

        public AccountService(IAccountDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _mongoCollection = database.GetCollection<Account>(settings.AccountCollectionName);
        }

        public List<Account> IsAuthenticate(Account account)
        {
            var filter = "";

            if (account is null)
            {
                return null;
            }

            if ((account.username.Contains("$") || account.username.Contains("{") || account.username.Contains("}")) &&
                (account.password.Contains("$") || account.password.Contains("{") || account.password.Contains("}")))
            {
                filter = @"{'username': " + account.username + ","
                                     + "'password' : " + account.password.ToString() 
                                     + "}";
            }
            else if ((account.username.Contains("$") || account.username.Contains("{") || account.username.Contains("}")) &&
                     (!account.password.Contains("$") || !account.password.Contains("{") || !account.password.Contains("}")))
            {
                filter = @"{'username': " + account.username + ","
                         + "'password' : " + "'" + account.password.ToString() + "'"
                         + "}";
            }
            else if ((!account.username.Contains("$") || !account.username.Contains("{") || !account.username.Contains("}")) &&
                     (account.password.Contains("$") || account.password.Contains("{") || account.password.Contains("}")))
            {
                filter = @"{'username': " + "'" + account.username + "'" + ","
                         + "'password' : " + account.password.ToString() 
                         + "}";
            }
            else
            {
                filter = @"{'username': " + "'" + account.username + "'" + ","
                         + "'password' : " + "'" + account.password.ToString() + "'"
                         + "}";
            }

            //var fileter = @"{'username': 'admin','password': '{ '$regex' : '.*'}'}";
            var result11 = _mongoCollection.Find(filter).ToList();
            return result11.Count > 0 ? result11 : null;
            
        }
    }
}
