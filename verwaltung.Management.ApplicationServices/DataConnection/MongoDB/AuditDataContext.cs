using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opname.verwaltung.Management.ApplicationServices.DataConnection.MongoDB
{
    using Domain;
    public class DataStorage
    {
        
        
    


        public DataStorage()
        {
            
        }

        public AuditRecord Record { get; set; }
        public async void Insert()
        {
            String mongoHost = ConfigurationManager.ConnectionStrings["awsConnectionString"].ConnectionString;
            MongoClientSettings settings =
                MongoClientSettings.FromUrl(new MongoUrl(mongoHost));

             MongoClient _mongoClient = new MongoClient(settings);

            var _db = _mongoClient.GetDatabase(ConfigurationManager.AppSettings["mdatabasename"]);

            
            //get mongodb collection
            var collection = _db.GetCollection<AuditRecord>("SurveyInformation");
            await collection.InsertOneAsync(Record);

        }
       

         

    }
}
