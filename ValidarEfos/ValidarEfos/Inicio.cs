using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Models;

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
                        
                        xmlFolderLabel.Text = $"{folderPath} -> hay {State.GlobalState.Xmls.Count} archivos XML";
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
            var csvSelected = !string.IsNullOrEmpty(State.GlobalState.cvsFileName);
            var xmlSelected = State.GlobalState.Xmls != null && State.GlobalState.Xmls.Count > 0;
            if(csvSelected && xmlSelected)
            { 
                button1.Enabled = false;
                InicioProgressBar();

                Validacion.XmlValidado += Validacion_XmlValidado;

                Validacion.Iniciar();

                OcultoProgressBar();
                if(State.GlobalState.FacturaEnEfos.Count == 0)
                    MessageBox.Show("No se encontraron facturas en los Efos");
                else
                {
                    var resultName = new Write.CSV(State.GlobalState.FacturaEnEfos).resultsFile;
                    MessageBox.Show($"Se encontraron {State.GlobalState.FacturaEnEfos.Count} facturas en los Efos, estan en el archivo {resultName}");

                    System.Diagnostics.Process.Start (Write.CSV.basicPath);
                }

                Validacion.XmlValidado -= Validacion_XmlValidado;
                button1.Enabled = true;
            }
            else
                MessageBox.Show("Selecciona el archivo de los Efos y la carpeta donde estan los XML");


        }

        private void Validacion_XmlValidado(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value++;
        }
        void OcultoProgressBar() => progressBar1.Visible = false;

        void InicioProgressBar()
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = State.GlobalState.Xmls.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
        }
    }
}
