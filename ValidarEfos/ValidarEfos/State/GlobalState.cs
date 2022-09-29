using Models;
using System.Collections.Generic;

namespace ValidarEfos.State
{
    static internal class GlobalState
    {
        public static string cvsFileName { get; set; }
        public static List<Efo> Efos { get; set; }
        public static string folderXml { get; set; }
        public static List<string> Xmls { get; set; }

    }
}
