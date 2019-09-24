namespace CG1
{
    partial class Form1
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
            this.Picture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Lab1 = new System.Windows.Forms.Button();
            this.Lab2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.ControlText;
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.Location = new System.Drawing.Point(0, 0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(1600, 1181);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 714);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RunButton);
            // 
            // Lab1
            // 
            this.Lab1.Location = new System.Drawing.Point(206, 714);
            this.Lab1.Name = "Lab1";
            this.Lab1.Size = new System.Drawing.Size(140, 35);
            this.Lab1.TabIndex = 2;
            this.Lab1.Text = "Lab1";
            this.Lab1.UseVisualStyleBackColor = true;
            this.Lab1.Click += new System.EventHandler(this.Lab1_Click);
            // 
            // Lab2
            // 
            this.Lab2.Location = new System.Drawing.Point(445, 714);
            this.Lab2.Name = "Lab2";
            this.Lab2.Size = new System.Drawing.Size(123, 35);
            this.Lab2.TabIndex = 3;
            this.Lab2.Text = "Lab2";
            this.Lab2.UseVisualStyleBackColor = true;
            this.Lab2.Click += new System.EventHandler(this.Lab2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 1181);
            this.Controls.Add(this.Lab2);
            this.Controls.Add(this.Lab1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Picture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Lab1;
        private System.Windows.Forms.Button Lab2;
    }
}

