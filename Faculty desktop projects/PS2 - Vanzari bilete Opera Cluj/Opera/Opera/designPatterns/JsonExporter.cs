using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.model;
using System.IO;
using Newtonsoft.Json;

namespace Opera.designPatterns
{
    public class JsonExporter : Exporter
    {
        public void export(string numeSpectacol, List<Bilet> bilete)
        {
            string data = DateTime.Today.ToString("dd_MM_yyyy");
            string filename = "raport_" + numeSpectacol + ".json";

            if (!Directory.Exists(@"../Export/json/" + data)) Directory.CreateDirectory(@"../Export/json/" + data);
            using (StreamWriter swBilet = File.CreateText(@"../Export/json/" + data + "/" + filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(swBilet, bilete);
            }
        }
    }
}
