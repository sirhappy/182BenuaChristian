namespace task5
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
            this.pickColorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.circleRadiusUpDown = new System.Windows.Forms.NumericUpDown();
            this.circlePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.circleRadiusUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pickColorButton
            // 
            this.pickColorButton.Location = new System.Drawing.Point(41, 246);
            this.pickColorButton.Name = "pickColorButton";
            this.pickColorButton.Size = new System.Drawing.Size(120, 43);
            this.pickColorButton.TabIndex = 1;
            this.pickColorButton.Text = "Pick Color";
            this.pickColorButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Circle Radius";
            // 
            // circleRadiusUpDown
            // 
            this.circleRadiusUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.circleRadiusUpDown.Location = new System.Drawing.Point(41, 42);
            this.circleRadiusUpDown.Name = "circleRadiusUpDown";
            this.circleRadiusUpDown.Size = new System.Drawing.Size(120, 31);
            this.circleRadiusUpDown.TabIndex = 3;
            this.circleRadiusUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // circlePictureBox
            // 
            this.circlePictureBox.Location = new System.Drawing.Point(201, 14);
            this.circlePictureBox.Name = "circlePictureBox";
            this.circlePictureBox.Size = new System.Drawing.Size(598, 436);
            this.circlePictureBox.TabIndex = 4;
            this.circlePictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.circlePictureBox);
            this.Controls.Add(this.circleRadiusUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pickColorButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.circleRadiusUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pickColorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown circleRadiusUpDown;
        private System.Windows.Forms.PictureBox circlePictureBox;
    }
}

