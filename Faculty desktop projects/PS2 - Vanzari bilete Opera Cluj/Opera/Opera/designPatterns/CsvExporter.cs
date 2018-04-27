using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Opera.model;
using System.IO;

namespace Opera.designPatterns
{
    public class CsvExporter : Exporter
    {
        public CsvExporter() { }
        
        public void export(string numeSpectacol, List<Bilet> bilete)
        {
            string data = DateTime.Today.ToString("dd_MM_yyyy");
            string filename = "raport_" + numeSpectacol + ".csv";

            if(!Directory.Exists(@"../Export/csv/" + data)) Directory.CreateDirectory(@"../Export/csv/" + data);
            //File.Create(@"../Export/csv/" + data + "/" + filename);

            //StreamWriter swBilet = new StreamWriter(@"../Export/csv/" + data + "/" + filename);
            StreamWriter swBilet = File.CreateText(@"../Export/csv/" + data + "/" + filename);

            swBilet.WriteLine("idBilet;idSpectacol;rand;coloana");
            foreach (Bilet b in bilete)
            {
                swBilet.WriteLine(b.csvString());
            }

            swBilet.Close();
        }
    }
}
