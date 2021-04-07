namespace SiteCopy
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
            this.Link = new System.Windows.Forms.TextBox();
            this.CopyText = new System.Windows.Forms.Button();
            this.SiteBody = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Link
            // 
            this.Link.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Link.Location = new System.Drawing.Point(12, 12);
            this.Link.Multiline = true;
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(208, 41);
            this.Link.TabIndex = 0;
            this.Link.Text = "https://www.simbirsoft.com/";
            // 
            // CopyText
            // 
            this.CopyText.Location = new System.Drawing.Point(226, 12);
            this.CopyText.Name = "CopyText";
            this.CopyText.Size = new System.Drawing.Size(59, 41);
            this.CopyText.TabIndex = 2;
            this.CopyText.Text = "->";
            this.CopyText.UseVisualStyleBackColor = true;
            this.CopyText.Click += new System.EventHandler(this.CopyText_Click);
            // 
            // SiteBody
            // 
            this.SiteBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SiteBody.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SiteBody.Location = new System.Drawing.Point(291, 12);
            this.SiteBody.Name = "SiteBody";
            this.SiteBody.ReadOnly = true;
            this.SiteBody.Size = new System.Drawing.Size(454, 402);
            this.SiteBody.TabIndex = 3;
            this.SiteBody.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 419);
            this.Controls.Add(this.SiteBody);
            this.Controls.Add(this.CopyText);
            this.Controls.Add(this.Link);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Link;
        private System.Windows.Forms.Button CopyText;
        public System.Windows.Forms.RichTextBox SiteBody;
    }
}

