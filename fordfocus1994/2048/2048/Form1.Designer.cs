namespace _2048
{
    partial class GameForm
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
            this.Restart = new System.Windows.Forms.Button();
            this.GameField = new System.Windows.Forms.PictureBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.ScoreTextBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(10, 10);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(90, 30);
            this.Restart.TabIndex = 0;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // GameField
            // 
            this.GameField.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GameField.Location = new System.Drawing.Point(50, 50);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(400, 400);
            this.GameField.TabIndex = 1;
            this.GameField.TabStop = false;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(329, 15);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.ScoreLabel.TabIndex = 3;
            this.ScoreLabel.Text = "Score";
            // 
            // ScoreTextBox
            // 
            this.ScoreTextBox.AutoSize = true;
            this.ScoreTextBox.Location = new System.Drawing.Point(379, 15);
            this.ScoreTextBox.Name = "ScoreTextBox";
            this.ScoreTextBox.Size = new System.Drawing.Size(13, 13);
            this.ScoreTextBox.TabIndex = 4;
            this.ScoreTextBox.Text = "0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.ScoreTextBox);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.Restart);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.ShowIcon = false;
            this.Text = "2048";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label ScoreTextBox;
    }
}

