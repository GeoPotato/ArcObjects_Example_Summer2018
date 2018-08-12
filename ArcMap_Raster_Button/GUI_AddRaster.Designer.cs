namespace ArcMap_Raster_Button
{
    partial class GUI_AddRaster
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
            if (disposing && (components != null))
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
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.combo_SensorType = new System.Windows.Forms.ComboBox();
            this.combo_StudyType = new System.Windows.Forms.ComboBox();
            this.textBox_PathURL = new System.Windows.Forms.TextBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.lbl_SensorType = new System.Windows.Forms.Label();
            this.lbl_StudyType = new System.Windows.Forms.Label();
            this.lbl_SelectRaster = new System.Windows.Forms.Label();
            this.label_Warning = new System.Windows.Forms.Label();
            this.lbl_SensorBandCount = new System.Windows.Forms.Label();
            this.textBox_SensorBandCount = new System.Windows.Forms.TextBox();
            this.lbl_BandCombination = new System.Windows.Forms.Label();
            this.lbl_R = new System.Windows.Forms.Label();
            this.lbl_G = new System.Windows.Forms.Label();
            this.lbl_B = new System.Windows.Forms.Label();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.textBox_G = new System.Windows.Forms.TextBox();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.textBox_ImageBandCount = new System.Windows.Forms.TextBox();
            this.lbl_ImageBandCount = new System.Windows.Forms.Label();
            this.checkBox_RasterExtent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exit.Location = new System.Drawing.Point(264, 238);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 0;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(367, 238);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // combo_SensorType
            // 
            this.combo_SensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_SensorType.FormattingEnabled = true;
            this.combo_SensorType.Location = new System.Drawing.Point(12, 46);
            this.combo_SensorType.Name = "combo_SensorType";
            this.combo_SensorType.Size = new System.Drawing.Size(174, 21);
            this.combo_SensorType.TabIndex = 2;
            this.combo_SensorType.SelectedIndexChanged += new System.EventHandler(this.combo_SensorType_SelectedIndexChanged);
            // 
            // combo_StudyType
            // 
            this.combo_StudyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_StudyType.FormattingEnabled = true;
            this.combo_StudyType.Location = new System.Drawing.Point(264, 46);
            this.combo_StudyType.Name = "combo_StudyType";
            this.combo_StudyType.Size = new System.Drawing.Size(174, 21);
            this.combo_StudyType.TabIndex = 3;
            this.combo_StudyType.SelectedIndexChanged += new System.EventHandler(this.combo_StudyType_SelectedIndexChanged);
            // 
            // textBox_PathURL
            // 
            this.textBox_PathURL.Location = new System.Drawing.Point(103, 145);
            this.textBox_PathURL.Name = "textBox_PathURL";
            this.textBox_PathURL.ReadOnly = true;
            this.textBox_PathURL.Size = new System.Drawing.Size(335, 20);
            this.textBox_PathURL.TabIndex = 4;
            // 
            // button_Browse
            // 
            this.button_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Browse.Location = new System.Drawing.Point(12, 143);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(75, 23);
            this.button_Browse.TabIndex = 5;
            this.button_Browse.Text = "Browse...";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // lbl_SensorType
            // 
            this.lbl_SensorType.AutoSize = true;
            this.lbl_SensorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SensorType.Location = new System.Drawing.Point(9, 19);
            this.lbl_SensorType.Name = "lbl_SensorType";
            this.lbl_SensorType.Size = new System.Drawing.Size(136, 17);
            this.lbl_SensorType.TabIndex = 6;
            this.lbl_SensorType.Text = "Select Sensor Type:";
            // 
            // lbl_StudyType
            // 
            this.lbl_StudyType.AutoSize = true;
            this.lbl_StudyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StudyType.Location = new System.Drawing.Point(261, 19);
            this.lbl_StudyType.Name = "lbl_StudyType";
            this.lbl_StudyType.Size = new System.Drawing.Size(127, 17);
            this.lbl_StudyType.TabIndex = 7;
            this.lbl_StudyType.Text = "Select Study Type:";
            // 
            // lbl_SelectRaster
            // 
            this.lbl_SelectRaster.AutoSize = true;
            this.lbl_SelectRaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectRaster.Location = new System.Drawing.Point(9, 123);
            this.lbl_SelectRaster.Name = "lbl_SelectRaster";
            this.lbl_SelectRaster.Size = new System.Drawing.Size(139, 17);
            this.lbl_SelectRaster.TabIndex = 8;
            this.lbl_SelectRaster.Text = "Select Raster Image:";
            // 
            // label_Warning
            // 
            this.label_Warning.AutoSize = true;
            this.label_Warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Warning.ForeColor = System.Drawing.Color.Red;
            this.label_Warning.Location = new System.Drawing.Point(9, 197);
            this.label_Warning.MaximumSize = new System.Drawing.Size(435, 0);
            this.label_Warning.Name = "label_Warning";
            this.label_Warning.Size = new System.Drawing.Size(432, 30);
            this.label_Warning.TabIndex = 9;
            this.label_Warning.Text = "WARNING: Total band count of sensor selection does not match total band count of " +
    "image selection. Band combinations may appear incorrectly matched.";
            this.label_Warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Warning.Visible = false;
            // 
            // lbl_SensorBandCount
            // 
            this.lbl_SensorBandCount.AutoSize = true;
            this.lbl_SensorBandCount.Location = new System.Drawing.Point(26, 82);
            this.lbl_SensorBandCount.Name = "lbl_SensorBandCount";
            this.lbl_SensorBandCount.Size = new System.Drawing.Size(102, 13);
            this.lbl_SensorBandCount.TabIndex = 10;
            this.lbl_SensorBandCount.Text = "Sensor Band Count:";
            // 
            // textBox_SensorBandCount
            // 
            this.textBox_SensorBandCount.Location = new System.Drawing.Point(130, 79);
            this.textBox_SensorBandCount.Name = "textBox_SensorBandCount";
            this.textBox_SensorBandCount.ReadOnly = true;
            this.textBox_SensorBandCount.Size = new System.Drawing.Size(34, 20);
            this.textBox_SensorBandCount.TabIndex = 11;
            this.textBox_SensorBandCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_BandCombination
            // 
            this.lbl_BandCombination.AutoSize = true;
            this.lbl_BandCombination.Location = new System.Drawing.Point(303, 80);
            this.lbl_BandCombination.Name = "lbl_BandCombination";
            this.lbl_BandCombination.Size = new System.Drawing.Size(96, 13);
            this.lbl_BandCombination.TabIndex = 12;
            this.lbl_BandCombination.Text = "Band Combination:";
            // 
            // lbl_R
            // 
            this.lbl_R.AutoSize = true;
            this.lbl_R.Location = new System.Drawing.Point(268, 101);
            this.lbl_R.Name = "lbl_R";
            this.lbl_R.Size = new System.Drawing.Size(15, 13);
            this.lbl_R.TabIndex = 13;
            this.lbl_R.Text = "R";
            // 
            // lbl_G
            // 
            this.lbl_G.AutoSize = true;
            this.lbl_G.Location = new System.Drawing.Point(327, 101);
            this.lbl_G.Name = "lbl_G";
            this.lbl_G.Size = new System.Drawing.Size(15, 13);
            this.lbl_G.TabIndex = 14;
            this.lbl_G.Text = "G";
            // 
            // lbl_B
            // 
            this.lbl_B.AutoSize = true;
            this.lbl_B.Location = new System.Drawing.Point(386, 101);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(14, 13);
            this.lbl_B.TabIndex = 15;
            this.lbl_B.Text = "B";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(283, 98);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.ReadOnly = true;
            this.textBox_R.Size = new System.Drawing.Size(34, 20);
            this.textBox_R.TabIndex = 16;
            this.textBox_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_G
            // 
            this.textBox_G.Location = new System.Drawing.Point(342, 98);
            this.textBox_G.Name = "textBox_G";
            this.textBox_G.ReadOnly = true;
            this.textBox_G.Size = new System.Drawing.Size(34, 20);
            this.textBox_G.TabIndex = 17;
            this.textBox_G.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(400, 98);
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.ReadOnly = true;
            this.textBox_B.Size = new System.Drawing.Size(34, 20);
            this.textBox_B.TabIndex = 18;
            this.textBox_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ImageBandCount
            // 
            this.textBox_ImageBandCount.Location = new System.Drawing.Point(268, 171);
            this.textBox_ImageBandCount.Name = "textBox_ImageBandCount";
            this.textBox_ImageBandCount.ReadOnly = true;
            this.textBox_ImageBandCount.Size = new System.Drawing.Size(34, 20);
            this.textBox_ImageBandCount.TabIndex = 20;
            this.textBox_ImageBandCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_ImageBandCount
            // 
            this.lbl_ImageBandCount.AutoSize = true;
            this.lbl_ImageBandCount.Location = new System.Drawing.Point(169, 174);
            this.lbl_ImageBandCount.Name = "lbl_ImageBandCount";
            this.lbl_ImageBandCount.Size = new System.Drawing.Size(98, 13);
            this.lbl_ImageBandCount.TabIndex = 19;
            this.lbl_ImageBandCount.Text = "Image Band Count:";
            // 
            // checkBox_RasterExtent
            // 
            this.checkBox_RasterExtent.AutoSize = true;
            this.checkBox_RasterExtent.Checked = true;
            this.checkBox_RasterExtent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RasterExtent.Location = new System.Drawing.Point(12, 243);
            this.checkBox_RasterExtent.Name = "checkBox_RasterExtent";
            this.checkBox_RasterExtent.Size = new System.Drawing.Size(132, 17);
            this.checkBox_RasterExtent.TabIndex = 21;
            this.checkBox_RasterExtent.Text = "Zoom to Raster Extent";
            this.checkBox_RasterExtent.UseVisualStyleBackColor = true;
            // 
            // GUI_AddRaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 269);
            this.Controls.Add(this.checkBox_RasterExtent);
            this.Controls.Add(this.textBox_ImageBandCount);
            this.Controls.Add(this.lbl_ImageBandCount);
            this.Controls.Add(this.textBox_B);
            this.Controls.Add(this.textBox_G);
            this.Controls.Add(this.textBox_R);
            this.Controls.Add(this.lbl_B);
            this.Controls.Add(this.lbl_G);
            this.Controls.Add(this.lbl_R);
            this.Controls.Add(this.lbl_BandCombination);
            this.Controls.Add(this.textBox_SensorBandCount);
            this.Controls.Add(this.lbl_SensorBandCount);
            this.Controls.Add(this.label_Warning);
            this.Controls.Add(this.lbl_SelectRaster);
            this.Controls.Add(this.lbl_StudyType);
            this.Controls.Add(this.lbl_SensorType);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.textBox_PathURL);
            this.Controls.Add(this.combo_StudyType);
            this.Controls.Add(this.combo_SensorType);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI_AddRaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Raster Layer";
            this.Load += new System.EventHandler(this.GUI_AddRaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.Label lbl_SensorType;
        private System.Windows.Forms.Label lbl_StudyType;
        private System.Windows.Forms.Label lbl_SelectRaster;
        public System.Windows.Forms.ComboBox combo_SensorType;
        public System.Windows.Forms.ComboBox combo_StudyType;
        public System.Windows.Forms.TextBox textBox_PathURL;
        public System.Windows.Forms.Label label_Warning;
        private System.Windows.Forms.Label lbl_SensorBandCount;
        public System.Windows.Forms.TextBox textBox_SensorBandCount;
        private System.Windows.Forms.Label lbl_BandCombination;
        private System.Windows.Forms.Label lbl_R;
        private System.Windows.Forms.Label lbl_G;
        private System.Windows.Forms.Label lbl_B;
        public System.Windows.Forms.TextBox textBox_R;
        public System.Windows.Forms.TextBox textBox_G;
        public System.Windows.Forms.TextBox textBox_B;
        public System.Windows.Forms.TextBox textBox_ImageBandCount;
        private System.Windows.Forms.Label lbl_ImageBandCount;
        public System.Windows.Forms.CheckBox checkBox_RasterExtent;
    }
}