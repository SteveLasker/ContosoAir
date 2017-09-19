using ContosoAir.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ContosoAir.Data.Seed
{
    public static class ContosoAirDbSeed
    {
        
        public static void Seed(Db db)
        {
            var path_sep = System.IO.Path.DirectorySeparatorChar;

            var airports = DeserializeFile<Airport>(GetFilePath($"Seed{path_sep}Data{path_sep}airports.json"));
            airports.ForEach(airport => db.Airports.Add(airport));

            var fligths = DeserializeFile<Flight>(GetFilePath($"Seed{path_sep}Data{path_sep}flights.json"));
            fligths.ForEach(flight => db.Fligths.Add(flight));

            var deals = DeserializeFile<Deal>(GetFilePath($"Seed{path_sep}Data{path_sep}deals.json"));
            deals.ForEach(deal => db.Deals.Add(deal));

            var alternatives = DeserializeFile<Alternative>(GetFilePath($"Seed{path_sep}Data{path_sep}alternatives.json"));
            alternatives.ForEach(alternative => db.Alternatives.Add(alternative));

            db.SaveChanges();
        }

        private static List<T> DeserializeFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            List<T> objects = JsonConvert.DeserializeObject<List<T>>(json);
            return objects;              
        }

        private static string GetFilePath(string relativePath)
        {
            var rootPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
            var path = Path.Combine(rootPath, relativePath);
            return path;
        }
    }
}
