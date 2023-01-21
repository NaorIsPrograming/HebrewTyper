namespace HebrewTyper
{
    partial class Typer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextToType = new System.Windows.Forms.RichTextBox();
            this.TypedText = new System.Windows.Forms.TextBox();
            this.prvWpmLabel = new System.Windows.Forms.Label();
            this.AvgWPMLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextToType
            // 
            this.TextToType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextToType.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextToType.Location = new System.Drawing.Point(12, 31);
            this.TextToType.Name = "TextToType";
            this.TextToType.ReadOnly = true;
            this.TextToType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextToType.Size = new System.Drawing.Size(776, 330);
            this.TextToType.TabIndex = 0;
            this.TextToType.Text = "oh your so kawai so super kawai 12345261234156123456123456123456123456\n";
            // 
            // TypedText
            // 
            this.TypedText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypedText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TypedText.Location = new System.Drawing.Point(12, 405);
            this.TypedText.Name = "TypedText";
            this.TypedText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TypedText.Size = new System.Drawing.Size(776, 33);
            this.TypedText.TabIndex = 1;
            this.TypedText.TextChanged += new System.EventHandler(this.TypedText_TextChanged);
            this.TypedText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TypedText_KeyDown);
            // 
            // prvWpmLabel
            // 
            this.prvWpmLabel.AutoSize = true;
            this.prvWpmLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prvWpmLabel.Location = new System.Drawing.Point(12, 8);
            this.prvWpmLabel.Name = "prvWpmLabel";
            this.prvWpmLabel.Size = new System.Drawing.Size(107, 20);
            this.prvWpmLabel.TabIndex = 2;
            this.prvWpmLabel.Text = "Previous WPM ";
            // 
            // AvgWPMLabel
            // 
            this.AvgWPMLabel.AutoSize = true;
            this.AvgWPMLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AvgWPMLabel.Location = new System.Drawing.Point(196, 8);
            this.AvgWPMLabel.Name = "AvgWPMLabel";
            this.AvgWPMLabel.Size = new System.Drawing.Size(107, 20);
            this.AvgWPMLabel.TabIndex = 3;
            this.AvgWPMLabel.Text = "Average WPM ";
            // 
            // Typer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AvgWPMLabel);
            this.Controls.Add(this.prvWpmLabel);
            this.Controls.Add(this.TypedText);
            this.Controls.Add(this.TextToType);
            this.Name = "Typer";
            this.Text = "Typer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Typer_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RichTextBox TextToType;
        private TextBox TypedText;
        private Label prvWpmLabel;
        private Label AvgWPMLabel;
    }
}