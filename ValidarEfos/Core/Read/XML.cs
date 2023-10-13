using System.IO;
using System.Xml;
using Models;

namespace Read
{
    public class XML
    {
        public Factura Factura { get; set; }
        public XML(string pathFile)
        {
            Factura = new Factura();

            using(var reader = new StreamReader(pathFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);//Leer el XML

                XmlNamespaceManager nsm = new XmlNamespaceManager(doc.NameTable);

                LeerXML("http://www.sat.gob.mx/cfd/3", doc, nsm, Factura);
                LeerXML("http://www.sat.gob.mx/cfd/4", doc, nsm, Factura);
            }
        }

        void LeerXML(string cfdiNamespace, XmlDocument doc, XmlNamespaceManager nsm, Factura Factura)
        {
            nsm.AddNamespace("cfdi", cfdiNamespace);

            //Accedemos a nodo "Comprobante"
            XmlNode nodeComprobante = doc.SelectSingleNode("//cfdi:Comprobante", nsm);

            if(nodeComprobante != null)
            {
                //Obtener Folio, Serie, SubTotal y Total
                Factura.Folio = nodeComprobante.Attributes["Folio"]?.Value;
                Factura.Serie = nodeComprobante.Attributes["Serie"]?.Value;
                Factura.SubTotal = nodeComprobante.Attributes["SubTotal"]?.Value;
                Factura.Total = nodeComprobante.Attributes["Total"]?.Value;

                //Obtener a nodo emisor
                XmlNode nodeEmisor = nodeComprobante.SelectSingleNode("cfdi:Emisor", nsm);

                //Obtener Nombre y RFC
                Factura.Nombre = nodeEmisor.Attributes["Nombre"]?.Value;
                Factura.RFC = nodeEmisor.Attributes["Rfc"]?.Value;
            }
        }
    }
}
