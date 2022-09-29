using System.Collections.Generic;
using System.Linq;

namespace ValidarEfos
{
    public class Validacion
    {
        public static void Iniciar()
        {
            State.GlobalState.FacturaEnEfos = new List<Models.Factura>();
            foreach(var xml in State.GlobalState.Xmls)
            {
                var factura = new Read.XML(xml).Factura;

                if(EstaEnEfos(factura.RFC))
                    State.GlobalState.FacturaEnEfos.Add(factura);
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
