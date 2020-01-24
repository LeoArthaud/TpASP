using App.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.Json;
using App.Data.Services;

namespace App.Data
{

    public class JsonRestaurantRepository
    {
        private RestaurantsServices _services = new RestaurantsServices();

        /// <summary>
        /// Charge un fichier json(tableau de restau)
        /// </summary>
        public List<Restaurant> LoadJson(string Path)
        {
            // ouverture et lecture du fichier
            var data = File.ReadAllText(path: Path);
            // transformation du résultat en json
            return JsonSerializer
            .Deserialize<List<Restaurant>>(data);
        }
        
        public void SaveData(List<Restaurant> data)
        {
            _services.createActionRange(data);

        }

        //public void ExportData(string Path)
        //{
        //    var listResto = _services.getAllResto();

        //    string serialized = JsonSerializer.Serialize(listResto, Formatting.Indented, new JsonSerializerSettings


        //    File.WriteAllText(jsonFilePath, serialized);
        //}
    }
}
