﻿namespace Tipper_Variant2
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
            this.buttonSetTruckOrTipper = new System.Windows.Forms.Button();
            this.groupBoxTakeTruck = new System.Windows.Forms.GroupBox();
            this.buttonTake = new System.Windows.Forms.Button();
            this.labelGarage = new System.Windows.Forms.Label();
            this.numberGarage = new System.Windows.Forms.MaskedTextBox();
            this.labelGarages = new System.Windows.Forms.Label();
            this.textBoxGarages = new System.Windows.Forms.TextBox();
            this.buttonAddGarage = new System.Windows.Forms.Button();
            this.listBoxGarages = new System.Windows.Forms.ListBox();
            this.buttonDeleteGarages = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarages)).BeginInit();
            this.groupBoxTakeTruck.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxGarages
            // 
            this.pictureBoxGarages.Location = new System.Drawing.Point(12, 45);
            this.pictureBoxGarages.Name = "pictureBoxGarages";
            this.pictureBoxGarages.Size = new System.Drawing.Size(646, 514);
            this.pictureBoxGarages.TabIndex = 0;
            this.pictureBoxGarages.TabStop = false;
            // 
            // buttonSetTruckOrTipper
            // 
            this.buttonSetTruckOrTipper.Location = new System.Drawing.Point(690, 370);
            this.buttonSetTruckOrTipper.Name = "buttonSetTruckOrTipper";
            this.buttonSetTruckOrTipper.Size = new System.Drawing.Size(237, 36);
            this.buttonSetTruckOrTipper.TabIndex = 2;
            this.buttonSetTruckOrTipper.Text = "Добавить грузовик/самосвал";
            this.buttonSetTruckOrTipper.UseVisualStyleBackColor = true;
            this.buttonSetTruckOrTipper.Click += new System.EventHandler(this.buttonSetTruckOrTipper_Click);
            // 
            // groupBoxTakeTruck
            // 
            this.groupBoxTakeTruck.Controls.Add(this.buttonTake);
            this.groupBoxTakeTruck.Controls.Add(this.labelGarage);
            this.groupBoxTakeTruck.Controls.Add(this.numberGarage);
            this.groupBoxTakeTruck.Location = new System.Drawing.Point(690, 425);
            this.groupBoxTakeTruck.Name = "groupBoxTakeTruck";
            this.groupBoxTakeTruck.Size = new System.Drawing.Size(237, 122);
            this.groupBoxTakeTruck.TabIndex = 3;
            this.groupBoxTakeTruck.TabStop = false;
            this.groupBoxTakeTruck.Text = "Забрать грузовик/самосвал";
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
            // labelGarage
            // 
            this.labelGarage.AutoSize = true;
            this.labelGarage.Location = new System.Drawing.Point(24, 46);
            this.labelGarage.Name = "labelGarage";
            this.labelGarage.Size = new System.Drawing.Size(53, 17);
            this.labelGarage.TabIndex = 1;
            this.labelGarage.Text = "Гараж:";
            // 
            // numberGarage
            // 
            this.numberGarage.Location = new System.Drawing.Point(94, 41);
            this.numberGarage.Name = "numberGarage";
            this.numberGarage.Size = new System.Drawing.Size(51, 22);
            this.numberGarage.TabIndex = 0;
            // 
            // labelGarages
            // 
            this.labelGarages.AutoSize = true;
            this.labelGarages.Location = new System.Drawing.Point(778, 25);
            this.labelGarages.Name = "labelGarages";
            this.labelGarages.Size = new System.Drawing.Size(57, 17);
            this.labelGarages.TabIndex = 4;
            this.labelGarages.Text = "Гаражи";
            // 
            // textBoxGarages
            // 
            this.textBoxGarages.Location = new System.Drawing.Point(691, 45);
            this.textBoxGarages.Name = "textBoxGarages";
            this.textBoxGarages.Size = new System.Drawing.Size(236, 22);
            this.textBoxGarages.TabIndex = 5;
            // 
            // buttonAddGarage
            // 
            this.buttonAddGarage.Location = new System.Drawing.Point(691, 73);
            this.buttonAddGarage.Name = "buttonAddGarage";
            this.buttonAddGarage.Size = new System.Drawing.Size(237, 36);
            this.buttonAddGarage.TabIndex = 6;
            this.buttonAddGarage.Text = "Добавить парковку (гараж)";
            this.buttonAddGarage.UseVisualStyleBackColor = true;
            this.buttonAddGarage.Click += new System.EventHandler(this.buttonAddGarage_Click);
            // 
            // listBoxGarages
            // 
            this.listBoxGarages.FormattingEnabled = true;
            this.listBoxGarages.ItemHeight = 16;
            this.listBoxGarages.Location = new System.Drawing.Point(690, 141);
            this.listBoxGarages.Name = "listBoxGarages";
            this.listBoxGarages.Size = new System.Drawing.Size(235, 116);
            this.listBoxGarages.TabIndex = 7;
            this.listBoxGarages.SelectedIndexChanged += new System.EventHandler(this.listBoxGarages_SelectedIndexChanged);
            // 
            // buttonDeleteGarages
            // 
            this.buttonDeleteGarages.Location = new System.Drawing.Point(690, 263);
            this.buttonDeleteGarages.Name = "buttonDeleteGarages";
            this.buttonDeleteGarages.Size = new System.Drawing.Size(237, 36);
            this.buttonDeleteGarages.TabIndex = 8;
            this.buttonDeleteGarages.Text = "Удалить парковку (гаражи)";
            this.buttonDeleteGarages.UseVisualStyleBackColor = true;
            this.buttonDeleteGarages.Click += new System.EventHandler(this.buttonDeleteGarages_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(946, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "txt file | *.txt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt file | *.txt";
            // 
            // FormGarages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 571);
            this.Controls.Add(this.buttonDeleteGarages);
            this.Controls.Add(this.listBoxGarages);
            this.Controls.Add(this.buttonAddGarage);
            this.Controls.Add(this.textBoxGarages);
            this.Controls.Add(this.labelGarages);
            this.Controls.Add(this.groupBoxTakeTruck);
            this.Controls.Add(this.buttonSetTruckOrTipper);
            this.Controls.Add(this.pictureBoxGarages);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGarages";
            this.Text = "Гаражи";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarages)).EndInit();
            this.groupBoxTakeTruck.ResumeLayout(false);
            this.groupBoxTakeTruck.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGarages;
        private System.Windows.Forms.Button buttonSetTruckOrTipper;
        private System.Windows.Forms.GroupBox groupBoxTakeTruck;
        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Label labelGarage;
        private System.Windows.Forms.MaskedTextBox numberGarage;
        private System.Windows.Forms.Label labelGarages;
        private System.Windows.Forms.TextBox textBoxGarages;
        private System.Windows.Forms.Button buttonAddGarage;
        private System.Windows.Forms.ListBox listBoxGarages;
        private System.Windows.Forms.Button buttonDeleteGarages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}