namespace Processing_Large_Files
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mdForm1 = new MDForm();
            this.mdButton3 = new MDButton();
            this.mdButton2 = new MDButton();
            this.mdButton1 = new MDButton();
            this.mdcOntrolButton1 = new MDCOntrolButton();
            this.mdForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mdForm1
            // 
            this.mdForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mdForm1.Controls.Add(this.mdButton3);
            this.mdForm1.Controls.Add(this.mdButton2);
            this.mdForm1.Controls.Add(this.mdButton1);
            this.mdForm1.Controls.Add(this.mdcOntrolButton1);
            this.mdForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdForm1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.mdForm1.ForeColor = System.Drawing.Color.White;
            this.mdForm1.Location = new System.Drawing.Point(0, 0);
            this.mdForm1.Name = "mdForm1";
            this.mdForm1.Size = new System.Drawing.Size(350, 122);
            this.mdForm1.Splitter = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.mdForm1.TabIndex = 0;
            this.mdForm1.Text = "PROCESSING LARGE FILES";
            this.mdForm1.ThemeType = MDForm.ThemeTypes.Dark;
            this.mdForm1.Click += new System.EventHandler(this.mdForm1_Click);
            // 
            // mdButton3
            // 
            this.mdButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mdButton3.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.mdButton3.ForeColor = System.Drawing.Color.White;
            this.mdButton3.Location = new System.Drawing.Point(3, 94);
            this.mdButton3.MDColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.mdButton3.Name = "mdButton3";
            this.mdButton3.Size = new System.Drawing.Size(344, 24);
            this.mdButton3.TabIndex = 3;
            this.mdButton3.Text = "Merge / Объединить";
            this.mdButton3.ThemeType = MDButton.ThemeTypes.Dark;
            this.mdButton3.UseVisualStyleBackColor = false;
            this.mdButton3.Click += new System.EventHandler(this.mdButton3_Click);
            // 
            // mdButton2
            // 
            this.mdButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mdButton2.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.mdButton2.ForeColor = System.Drawing.Color.White;
            this.mdButton2.Location = new System.Drawing.Point(3, 64);
            this.mdButton2.MDColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.mdButton2.Name = "mdButton2";
            this.mdButton2.Size = new System.Drawing.Size(344, 24);
            this.mdButton2.TabIndex = 2;
            this.mdButton2.Text = "Dispense / Отсеять";
            this.mdButton2.ThemeType = MDButton.ThemeTypes.Dark;
            this.mdButton2.UseVisualStyleBackColor = false;
            this.mdButton2.Click += new System.EventHandler(this.mdButton2_Click);
            // 
            // mdButton1
            // 
            this.mdButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.mdButton1.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F);
            this.mdButton1.ForeColor = System.Drawing.Color.White;
            this.mdButton1.Location = new System.Drawing.Point(3, 34);
            this.mdButton1.MDColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.mdButton1.Name = "mdButton1";
            this.mdButton1.Size = new System.Drawing.Size(344, 24);
            this.mdButton1.TabIndex = 1;
            this.mdButton1.Text = "Load / Загрузить";
            this.mdButton1.ThemeType = MDButton.ThemeTypes.Dark;
            this.mdButton1.UseVisualStyleBackColor = false;
            this.mdButton1.Click += new System.EventHandler(this.mdButton1_Click);
            // 
            // mdcOntrolButton1
            // 
            this.mdcOntrolButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mdcOntrolButton1.BackColor = System.Drawing.Color.Transparent;
            this.mdcOntrolButton1.ControlStyle = MDCOntrolButton.Style.Close;
            this.mdcOntrolButton1.Location = new System.Drawing.Point(326, 6);
            this.mdcOntrolButton1.Name = "mdcOntrolButton1";
            this.mdcOntrolButton1.Size = new System.Drawing.Size(18, 18);
            this.mdcOntrolButton1.TabIndex = 0;
            this.mdcOntrolButton1.Text = "mdcOntrolButton1";
            this.mdcOntrolButton1.Click += new System.EventHandler(this.mdcOntrolButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 122);
            this.Controls.Add(this.mdForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "PROCESSING LARGE FILES BY MATHIAN DEVELOPER";
            this.mdForm1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MDForm mdForm1;
        private MDCOntrolButton mdcOntrolButton1;
        private MDButton mdButton2;
        private MDButton mdButton1;
        private MDButton mdButton3;
    }
}

