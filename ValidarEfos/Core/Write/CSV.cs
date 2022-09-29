using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Models;

namespace Write
{
    public class CSV
    {
        public static string basicPath = "c:\\efosValidation";
        public string resultsFile { get; set; }
        public CSV(List<Factura> facturasEnEfos)
        {
            using (var writer = new StreamWriter(getFileName()))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(facturasEnEfos);
            }
        }

        string getFileName()
        {
            Directory.CreateDirectory(basicPath);

            return $"{basicPath}\\resultados{DateTime.Now.ToString("dd-MM-yy-HH-mm-ss")}.csv";
        }
    }
}
