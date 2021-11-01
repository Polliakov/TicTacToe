namespace UI.Forms
{
    partial class SettingsForm
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
            this.tbFieldHeight = new System.Windows.Forms.TextBox();
            this.tbFieldWidth = new System.Windows.Forms.TextBox();
            this.tbWinningScore = new System.Windows.Forms.TextBox();
            this.tbPlayer1Name = new System.Windows.Forms.TextBox();
            this.tbPlayer2Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFieldHeight
            // 
            this.tbFieldHeight.Location = new System.Drawing.Point(89, 45);
            this.tbFieldHeight.MaxLength = 20;
            this.tbFieldHeight.Name = "tbFieldHeight";
            this.tbFieldHeight.Size = new System.Drawing.Size(100, 20);
            this.tbFieldHeight.TabIndex = 0;
            this.tbFieldHeight.Leave += new System.EventHandler(this.TbFieldHeight_Leave);
            // 
            // tbFieldWidth
            // 
            this.tbFieldWidth.Location = new System.Drawing.Point(268, 45);
            this.tbFieldWidth.MaxLength = 20;
            this.tbFieldWidth.Name = "tbFieldWidth";
            this.tbFieldWidth.Size = new System.Drawing.Size(100, 20);
            this.tbFieldWidth.TabIndex = 1;
            this.tbFieldWidth.Leave += new System.EventHandler(this.TbFieldWidth_Leave);
            // 
            // tbWinningScore
            // 
            this.tbWinningScore.Location = new System.Drawing.Point(142, 76);
            this.tbWinningScore.MaxLength = 20;
            this.tbWinningScore.Name = "tbWinningScore";
            this.tbWinningScore.Size = new System.Drawing.Size(47, 20);
            this.tbWinningScore.TabIndex = 2;
            this.tbWinningScore.Leave += new System.EventHandler(this.TbWinningScore_Leave);
            // 
            // tbPlayer1Name
            // 
            this.tbPlayer1Name.Location = new System.Drawing.Point(89, 12);
            this.tbPlayer1Name.MaxLength = 20;
            this.tbPlayer1Name.Name = "tbPlayer1Name";
            this.tbPlayer1Name.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer1Name.TabIndex = 3;
            this.tbPlayer1Name.Leave += new System.EventHandler(this.TbPlayer1Name_Leave);
            // 
            // tbPlayer2Name
            // 
            this.tbPlayer2Name.Location = new System.Drawing.Point(268, 12);
            this.tbPlayer2Name.MaxLength = 20;
            this.tbPlayer2Name.Name = "tbPlayer2Name";
            this.tbPlayer2Name.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer2Name.TabIndex = 4;
            this.tbPlayer2Name.Leave += new System.EventHandler(this.TbPlayer2Name_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Игрок 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Игрок 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Высота поля";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Шириа поля";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Размер победного ряда";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(220)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(63, 111);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(175, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Применить настройки";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(244, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 146);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPlayer2Name);
            this.Controls.Add(this.tbPlayer1Name);
            this.Controls.Add(this.tbWinningScore);
            this.Controls.Add(this.tbFieldWidth);
            this.Controls.Add(this.tbFieldHeight);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFieldHeight;
        private System.Windows.Forms.TextBox tbFieldWidth;
        private System.Windows.Forms.TextBox tbWinningScore;
        private System.Windows.Forms.TextBox tbPlayer1Name;
        private System.Windows.Forms.TextBox tbPlayer2Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}