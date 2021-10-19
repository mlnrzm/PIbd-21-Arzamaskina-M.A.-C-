namespace Tipper_Variant2
{
    partial class FormGarages
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
            this.pictureBoxGarages = new System.Windows.Forms.PictureBox();
            this.buttonParkingTruck = new System.Windows.Forms.Button();
            this.buttonParkingTipper = new System.Windows.Forms.Button();
            this.groupBoxTakeTruck = new System.Windows.Forms.GroupBox();
            this.numberGarage = new System.Windows.Forms.MaskedTextBox();
            this.labelGarage = new System.Windows.Forms.Label();
            this.buttonTake = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarages)).BeginInit();
            this.groupBoxTakeTruck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxGarages
            // 
            this.pictureBoxGarages.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGarages.Name = "pictureBoxGarages";
            this.pictureBoxGarages.Size = new System.Drawing.Size(646, 547);
            this.pictureBoxGarages.TabIndex = 0;
            this.pictureBoxGarages.TabStop = false;
            // 
            // buttonParkingTruck
            // 
            this.buttonParkingTruck.Location = new System.Drawing.Point(687, 27);
            this.buttonParkingTruck.Name = "buttonParkingTruck";
            this.buttonParkingTruck.Size = new System.Drawing.Size(240, 42);
            this.buttonParkingTruck.TabIndex = 1;
            this.buttonParkingTruck.Text = "Припарковать грузовик";
            this.buttonParkingTruck.UseVisualStyleBackColor = true;
            this.buttonParkingTruck.Click += new System.EventHandler(this.buttonParkingTruck_Click);
            // 
            // buttonParkingTipper
            // 
            this.buttonParkingTipper.Location = new System.Drawing.Point(687, 75);
            this.buttonParkingTipper.Name = "buttonParkingTipper";
            this.buttonParkingTipper.Size = new System.Drawing.Size(240, 36);
            this.buttonParkingTipper.TabIndex = 2;
            this.buttonParkingTipper.Text = "Припарковать самосвал";
            this.buttonParkingTipper.UseVisualStyleBackColor = true;
            this.buttonParkingTipper.Click += new System.EventHandler(this.buttonParkingTipper_Click);
            // 
            // groupBoxTakeTruck
            // 
            this.groupBoxTakeTruck.Controls.Add(this.buttonTake);
            this.groupBoxTakeTruck.Controls.Add(this.labelGarage);
            this.groupBoxTakeTruck.Controls.Add(this.numberGarage);
            this.groupBoxTakeTruck.Location = new System.Drawing.Point(689, 138);
            this.groupBoxTakeTruck.Name = "groupBoxTakeTruck";
            this.groupBoxTakeTruck.Size = new System.Drawing.Size(237, 122);
            this.groupBoxTakeTruck.TabIndex = 3;
            this.groupBoxTakeTruck.TabStop = false;
            this.groupBoxTakeTruck.Text = "Забрать грузовик/самосвал";
            // 
            // numberGarage
            // 
            this.numberGarage.Location = new System.Drawing.Point(94, 41);
            this.numberGarage.Name = "numberGarage";
            this.numberGarage.Size = new System.Drawing.Size(51, 22);
            this.numberGarage.TabIndex = 0;
            // 
            // labelGarage
            // 
            this.labelGarage.AutoSize = true;
            this.labelGarage.Location = new System.Drawing.Point(24, 46);
            this.labelGarage.Name = "labelGarage";
            this.labelGarage.Size = new System.Drawing.Size(53, 17);
            this.labelGarage.TabIndex = 1;
            this.labelGarage.Text = "Гараж:";
            // 
            // buttonTake
            // 
            this.buttonTake.Location = new System.Drawing.Point(27, 78);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(77, 26);
            this.buttonTake.TabIndex = 2;
            this.buttonTake.Text = "Забрать";
            this.buttonTake.UseVisualStyleBackColor = true;
            this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
            // 
            // FormGarages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 571);
            this.Controls.Add(this.groupBoxTakeTruck);
            this.Controls.Add(this.buttonParkingTipper);
            this.Controls.Add(this.buttonParkingTruck);
            this.Controls.Add(this.pictureBoxGarages);
            this.Name = "FormGarages";
            this.Text = "Гаражи";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarages)).EndInit();
            this.groupBoxTakeTruck.ResumeLayout(false);
            this.groupBoxTakeTruck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGarages;
        private System.Windows.Forms.Button buttonParkingTruck;
        private System.Windows.Forms.Button buttonParkingTipper;
        private System.Windows.Forms.GroupBox groupBoxTakeTruck;
        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Label labelGarage;
        private System.Windows.Forms.MaskedTextBox numberGarage;
    }
}