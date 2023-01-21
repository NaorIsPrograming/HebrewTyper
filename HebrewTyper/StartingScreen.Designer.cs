namespace HebrewTyper
{
    partial class StartingScreen
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
            this.GenerateButton = new System.Windows.Forms.Button();
            this.SelectTextsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Enabled = false;
            this.GenerateButton.Location = new System.Drawing.Point(121, 341);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Generate!";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // SelectTextsButton
            // 
            this.SelectTextsButton.Location = new System.Drawing.Point(121, 219);
            this.SelectTextsButton.Name = "SelectTextsButton";
            this.SelectTextsButton.Size = new System.Drawing.Size(75, 23);
            this.SelectTextsButton.TabIndex = 1;
            this.SelectTextsButton.Text = "Select texts";
            this.SelectTextsButton.UseVisualStyleBackColor = true;
            this.SelectTextsButton.Click += new System.EventHandler(this.SelectTextsButton_Click);
            // 
            // StartingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 450);
            this.Controls.Add(this.SelectTextsButton);
            this.Controls.Add(this.GenerateButton);
            this.Name = "StartingScreen";
            this.Text = "Starting Screen";
            this.ResumeLayout(false);

        }

        #endregion
        private Button GenerateButton;
        private Button SelectTextsButton;
    }
}