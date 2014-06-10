namespace GameGraphics
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ExitButton = new System.Windows.Forms.Button();
            this.HeroPicture = new System.Windows.Forms.PictureBox();
            this.Creation = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.InfText = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InputStats = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ImageCreation = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CreationMap = new System.Windows.Forms.Button();
            this.MainTextBox = new System.Windows.Forms.TextBox();
            this.LoadMap = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.Button();
            this.SaveGame = new System.Windows.Forms.Button();
            this.Stats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeroPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(12, 960);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(90, 30);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HeroPicture
            // 
            this.HeroPicture.Location = new System.Drawing.Point(0, 0);
            this.HeroPicture.Name = "HeroPicture";
            this.HeroPicture.Size = new System.Drawing.Size(210, 330);
            this.HeroPicture.TabIndex = 1;
            this.HeroPicture.TabStop = false;
            this.HeroPicture.MouseEnter += new System.EventHandler(this.HeroPicture_MouseEnter);
            // 
            // Creation
            // 
            this.Creation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Creation.Location = new System.Drawing.Point(12, 608);
            this.Creation.Name = "Creation";
            this.Creation.Size = new System.Drawing.Size(150, 30);
            this.Creation.TabIndex = 3;
            this.Creation.Text = "Нарисовать персонажа";
            this.Creation.UseVisualStyleBackColor = true;
            this.Creation.Click += new System.EventHandler(this.Creation_Click);
            // 
            // InfText
            // 
            this.InfText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InfText.Location = new System.Drawing.Point(0, 336);
            this.InfText.Multiline = true;
            this.InfText.Name = "InfText";
            this.InfText.Size = new System.Drawing.Size(210, 63);
            this.InfText.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(230, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1650, 650);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // InputStats
            // 
            this.InputStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InputStats.Location = new System.Drawing.Point(12, 572);
            this.InputStats.Name = "InputStats";
            this.InputStats.Size = new System.Drawing.Size(150, 30);
            this.InputStats.TabIndex = 6;
            this.InputStats.Text = "Создать персонажа";
            this.InputStats.UseVisualStyleBackColor = true;
            this.InputStats.Click += new System.EventHandler(this.InputStats_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NameTextBox.Location = new System.Drawing.Point(1636, 696);
            this.NameTextBox.Multiline = true;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 7;
            // 
            // ImageCreation
            // 
            this.ImageCreation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageCreation.Location = new System.Drawing.Point(12, 888);
            this.ImageCreation.Name = "ImageCreation";
            this.ImageCreation.Size = new System.Drawing.Size(120, 30);
            this.ImageCreation.TabIndex = 8;
            this.ImageCreation.Text = "Выбрать портрет";
            this.ImageCreation.UseVisualStyleBackColor = true;
            this.ImageCreation.Click += new System.EventHandler(this.ImageCreation_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CreationMap
            // 
            this.CreationMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CreationMap.Location = new System.Drawing.Point(12, 644);
            this.CreationMap.Name = "CreationMap";
            this.CreationMap.Size = new System.Drawing.Size(150, 30);
            this.CreationMap.TabIndex = 9;
            this.CreationMap.Text = "Сгенерировать карту";
            this.CreationMap.UseVisualStyleBackColor = true;
            this.CreationMap.Click += new System.EventHandler(this.CreationMap_Click);
            // 
            // MainTextBox
            // 
            this.MainTextBox.Location = new System.Drawing.Point(230, 690);
            this.MainTextBox.Multiline = true;
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.Size = new System.Drawing.Size(1400, 300);
            this.MainTextBox.TabIndex = 10;
            // 
            // LoadMap
            // 
            this.LoadMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadMap.Location = new System.Drawing.Point(12, 680);
            this.LoadMap.Name = "LoadMap";
            this.LoadMap.Size = new System.Drawing.Size(150, 30);
            this.LoadMap.TabIndex = 11;
            this.LoadMap.Text = "Загрузить карту";
            this.LoadMap.UseVisualStyleBackColor = true;
            this.LoadMap.Click += new System.EventHandler(this.LoadMap_Click);
            // 
            // inventory
            // 
            this.inventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inventory.Location = new System.Drawing.Point(93, 716);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(75, 30);
            this.inventory.TabIndex = 12;
            this.inventory.Text = "Инвентарь";
            this.inventory.UseVisualStyleBackColor = true;
            this.inventory.Click += new System.EventHandler(this.inventory_Click);
            // 
            // SaveGame
            // 
            this.SaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveGame.Location = new System.Drawing.Point(12, 924);
            this.SaveGame.Name = "SaveGame";
            this.SaveGame.Size = new System.Drawing.Size(75, 30);
            this.SaveGame.TabIndex = 13;
            this.SaveGame.Text = "Сохранить";
            this.SaveGame.UseVisualStyleBackColor = true;
            // 
            // Stats
            // 
            this.Stats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Stats.Location = new System.Drawing.Point(12, 716);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(75, 30);
            this.Stats.TabIndex = 14;
            this.Stats.Text = "Умения";
            this.Stats.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1904, 1002);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.SaveGame);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.LoadMap);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.CreationMap);
            this.Controls.Add(this.ImageCreation);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.InputStats);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InfText);
            this.Controls.Add(this.Creation);
            this.Controls.Add(this.HeroPicture);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Убей дракона!";
            ((System.ComponentModel.ISupportInitialize)(this.HeroPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button Creation;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox InfText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button InputStats;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button ImageCreation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.PictureBox HeroPicture;
        private System.Windows.Forms.Button CreationMap;
        private System.Windows.Forms.TextBox MainTextBox;
        private System.Windows.Forms.Button LoadMap;
        private System.Windows.Forms.Button inventory;
        private System.Windows.Forms.Button SaveGame;
        private System.Windows.Forms.Button Stats;
    }
}

