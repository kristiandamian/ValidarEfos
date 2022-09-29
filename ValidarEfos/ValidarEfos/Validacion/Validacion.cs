using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidarEfos
{
    public class Validacion
    {
        public static event Action<int>XmlValidado = delegate { };
        public static void Iniciar()
        {
            State.GlobalState.FacturaEnEfos = new List<Models.Factura>();
            var step = 0;
            foreach(var xml in State.GlobalState.Xmls)
            {
                var factura = new Read.XML(xml).Factura;

                if(EstaEnEfos(factura.RFC))
                    State.GlobalState.FacturaEnEfos.Add(factura);

                step++;

                XmlValidado(step);
            }
        }

        static bool EstaEnEfos(string RFC)
        {
            if(string.IsNullOrEmpty(RFC))
                return false;

            return State.GlobalState.Efos.Where(x => x.RFC.ToUpper() == RFC.ToUpper()).Any();
        }
    }
}
