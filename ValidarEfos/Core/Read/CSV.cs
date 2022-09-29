using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Models;

namespace Read
{
    public class CSV
    {
        public List<Efo> Records { get; set; }

        public CSV(string pathFile)
        {
            Records = new List<Efo>();

            using (var reader = new StreamReader(pathFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    try
                    {
                        if(!string.IsNullOrEmpty(csv.Parser.Record[1]) && csv.Parser.Record[1] != "RFC")
                        { 
                            var record = new Efo
                            {
                                RFC = csv.Parser.Record[1],
                                Nombre = csv.Parser.Record[2]
                            };
                            Records.Add(record);
                        }
                    }
                    catch(MissingFieldException)
                    {
                        //
                    }
                }
            }
        }
    }
}
