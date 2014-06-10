namespace GameGraphics
{
    partial class HeroCreation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeroCreation));
            this.HeroNameText = new System.Windows.Forms.TextBox();
            this.HeroNameLabel = new System.Windows.Forms.Label();
            this.RaceSelect = new System.Windows.Forms.ComboBox();
            this.ExitButton2 = new System.Windows.Forms.Button();
            this.ConfirmCreation = new System.Windows.Forms.Button();
            this.HeroRaceLabel = new System.Windows.Forms.Label();
            this.RaceInf = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HeroNameText
            // 
            this.HeroNameText.Location = new System.Drawing.Point(171, 12);
            this.HeroNameText.Name = "HeroNameText";
            this.HeroNameText.Size = new System.Drawing.Size(100, 20);
            this.HeroNameText.TabIndex = 0;
            // 
            // HeroNameLabel
            // 
            this.HeroNameLabel.AutoSize = true;
            this.HeroNameLabel.Location = new System.Drawing.Point(12, 9);
            this.HeroNameLabel.Name = "HeroNameLabel";
            this.HeroNameLabel.Size = new System.Drawing.Size(131, 13);
            this.HeroNameLabel.TabIndex = 1;
            this.HeroNameLabel.Text = "Введите имя персонажа";
            // 
            // RaceSelect
            // 
            this.RaceSelect.FormattingEnabled = true;
            this.RaceSelect.Items.AddRange(new object[] {
            "Человек",
            "Эльф",
            "Полуэльф",
            "Дворф",
            "Гном"});
            this.RaceSelect.Location = new System.Drawing.Point(152, 52);
            this.RaceSelect.Name = "RaceSelect";
            this.RaceSelect.Size = new System.Drawing.Size(120, 21);
            this.RaceSelect.TabIndex = 2;
            this.RaceSelect.SelectedIndexChanged += new System.EventHandler(this.RaceSelect_SelectedIndexChanged);
            // 
            // ExitButton2
            // 
            this.ExitButton2.Location = new System.Drawing.Point(196, 227);
            this.ExitButton2.Name = "ExitButton2";
            this.ExitButton2.Size = new System.Drawing.Size(75, 23);
            this.ExitButton2.TabIndex = 3;
            this.ExitButton2.Text = "Отмена";
            this.ExitButton2.UseVisualStyleBackColor = true;
            this.ExitButton2.Click += new System.EventHandler(this.ExitButton2_Click);
            // 
            // ConfirmCreation
            // 
            this.ConfirmCreation.Location = new System.Drawing.Point(15, 227);
            this.ConfirmCreation.Name = "ConfirmCreation";
            this.ConfirmCreation.Size = new System.Drawing.Size(97, 23);
            this.ConfirmCreation.TabIndex = 4;
            this.ConfirmCreation.Text = "Подтвердить";
            this.ConfirmCreation.UseVisualStyleBackColor = true;
            this.ConfirmCreation.Click += new System.EventHandler(this.ConfirmCreation_Click);
            // 
            // HeroRaceLabel
            // 
            this.HeroRaceLabel.AutoSize = true;
            this.HeroRaceLabel.Location = new System.Drawing.Point(12, 52);
            this.HeroRaceLabel.Name = "HeroRaceLabel";
            this.HeroRaceLabel.Size = new System.Drawing.Size(83, 13);
            this.HeroRaceLabel.TabIndex = 5;
            this.HeroRaceLabel.Text = "Выберите расу";
            // 
            // RaceInf
            // 
            this.RaceInf.Location = new System.Drawing.Point(152, 92);
            this.RaceInf.Multiline = true;
            this.RaceInf.Name = "RaceInf";
            this.RaceInf.Size = new System.Drawing.Size(120, 80);
            this.RaceInf.TabIndex = 6;
            // 
            // HeroCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.RaceInf);
            this.Controls.Add(this.HeroRaceLabel);
            this.Controls.Add(this.ConfirmCreation);
            this.Controls.Add(this.ExitButton2);
            this.Controls.Add(this.RaceSelect);
            this.Controls.Add(this.HeroNameLabel);
            this.Controls.Add(this.HeroNameText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HeroCreation";
            this.Text = "Создание героя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeroNameLabel;
        private System.Windows.Forms.ComboBox RaceSelect;
        private System.Windows.Forms.Button ExitButton2;
        private System.Windows.Forms.Button ConfirmCreation;
        private System.Windows.Forms.Label HeroRaceLabel;
        private System.Windows.Forms.TextBox RaceInf;
        public System.Windows.Forms.TextBox HeroNameText;

    }
}