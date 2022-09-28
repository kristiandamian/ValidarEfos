namespace ValidarEfos
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lnkArchivoCsv = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkCarpetaXML = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "1.- ";
            // 
            // lnkArchivoCsv
            // 
            this.lnkArchivoCsv.AutoSize = true;
            this.lnkArchivoCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkArchivoCsv.Location = new System.Drawing.Point(59, 19);
            this.lnkArchivoCsv.Name = "lnkArchivoCsv";
            this.lnkArchivoCsv.Size = new System.Drawing.Size(330, 25);
            this.lnkArchivoCsv.TabIndex = 1;
            this.lnkArchivoCsv.TabStop = true;
            this.lnkArchivoCsv.Text = "Selecciona el archivo de Efos (CSV)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "2.- ";
            // 
            // lnkCarpetaXML
            // 
            this.lnkCarpetaXML.AutoSize = true;
            this.lnkCarpetaXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCarpetaXML.Location = new System.Drawing.Point(59, 138);
            this.lnkCarpetaXML.Name = "lnkCarpetaXML";
            this.lnkCarpetaXML.Size = new System.Drawing.Size(389, 25);
            this.lnkCarpetaXML.TabIndex = 3;
            this.lnkCarpetaXML.TabStop = true;
            this.lnkCarpetaXML.Text = "Selecciona la carpeta donde estan los XML";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "No ha seleccionado el archivo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "No ha seleccionado la carpeta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "Iniciar validación";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 345);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lnkCarpetaXML);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkArchivoCsv);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.Text = "Validador de Efos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkArchivoCsv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkCarpetaXML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

