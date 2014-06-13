namespace GameGraphics
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.ExitButton = new System.Windows.Forms.Button();
            this.SpotsForItems = new System.Windows.Forms.PictureBox();
            this.Bag = new System.Windows.Forms.PictureBox();
            this.CreateItemButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpotsForItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bag)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(897, 430);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 30);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Назад";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SpotsForItems
            // 
            this.SpotsForItems.BackColor = System.Drawing.Color.White;
            this.SpotsForItems.Location = new System.Drawing.Point(0, 0);
            this.SpotsForItems.Name = "SpotsForItems";
            this.SpotsForItems.Size = new System.Drawing.Size(300, 460);
            this.SpotsForItems.TabIndex = 5;
            this.SpotsForItems.TabStop = false;
            this.SpotsForItems.Paint += new System.Windows.Forms.PaintEventHandler(this.SpotsForItems_Paint);
            this.SpotsForItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SpotsForItems_MouseClick);
            // 
            // Bag
            // 
            this.Bag.BackColor = System.Drawing.Color.White;
            this.Bag.Location = new System.Drawing.Point(330, 0);
            this.Bag.Name = "Bag";
            this.Bag.Size = new System.Drawing.Size(660, 420);
            this.Bag.TabIndex = 6;
            this.Bag.TabStop = false;
            this.Bag.Paint += new System.Windows.Forms.PaintEventHandler(this.Bag_Paint);
            this.Bag.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Bag_MouseClick);
            // 
            // CreateItemButton
            // 
            this.CreateItemButton.Location = new System.Drawing.Point(410, 430);
            this.CreateItemButton.Name = "CreateItemButton";
            this.CreateItemButton.Size = new System.Drawing.Size(123, 30);
            this.CreateItemButton.TabIndex = 8;
            this.CreateItemButton.Text = "Создать предмет";
            this.CreateItemButton.UseVisualStyleBackColor = true;
            this.CreateItemButton.Click += new System.EventHandler(this.CreateItemButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(329, 466);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(462, 98);
            this.textBox1.TabIndex = 9;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 712);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CreateItemButton);
            this.Controls.Add(this.Bag);
            this.Controls.Add(this.SpotsForItems);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory";
            this.Text = "Inventory";
            ((System.ComponentModel.ISupportInitialize)(this.SpotsForItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox SpotsForItems;
        private System.Windows.Forms.PictureBox Bag;
        private System.Windows.Forms.Button CreateItemButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}