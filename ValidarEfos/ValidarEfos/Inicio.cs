using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace ValidarEfos
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
           InitializeComponent();

           InitEfoDialog();
           InitXmlDialog();
        }

        void InitEfoDialog()
        {
            openEfoFileDialog = new OpenFileDialog()
            {
                FileName = "Selecciona el archivo CSV de los efos",
                Filter = "Text files (*.csv)|*.csv",
                Title = "Selecciona el archivo CSV de los efos"
            };
        }

        void InitXmlDialog()
        {
            openXmlFolderDialog = new OpenFileDialog()
            {
                FileName = "Selecciona el archivo XML de las facturas",
                Filter = "Text files (*.xml)|*.xml",
                Title = "Selecciona el archivo XML de las facturas"
            };
            openXmlFolderDialog.ValidateNames = false;
            openXmlFolderDialog.CheckFileExists = false;
            openXmlFolderDialog.CheckPathExists = true;
            // Always default to Folder Selection.
            openXmlFolderDialog.FileName = "Selecciona la carpeta.";
        }

        private void lnkArchivoCsv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openEfoFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openEfoFileDialog.FileName;
                    using (Stream str = openEfoFileDialog.OpenFile())
                    {
                        State.GlobalState.cvsFileName = filePath;
                        State.GlobalState.Efos = new Read.CSV("c:\\definitivos.csv").Records;
                        efoFile.Text = filePath + $" -> Hay {State.GlobalState.Efos.Count} Efos";
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void lnkCarpetaXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(!string.IsNullOrEmpty(State.GlobalState.cvsFileName))
            { 
                if(openXmlFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string folderPath = Path.GetDirectoryName(openXmlFolderDialog.FileName);
                        
                        State.GlobalState.folderXml = folderPath;
                        State.GlobalState.Xmls = GetXmls(folderPath);
                        
                        xmlFolderLabel.Text = $"{folderPath} -> hay {State.GlobalState.Xmls} archivos XML";
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
            else
                MessageBox.Show("Selecciona el archivo CSV primero");
        }

        List<string> GetXmls(string folderPath)
        {
            var ext = new List<string> { "xml" };
            var myFiles = Directory
                .EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                .ToList();

            return myFiles;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
