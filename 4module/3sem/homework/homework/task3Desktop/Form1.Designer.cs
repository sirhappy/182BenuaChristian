namespace task3Desktop
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
            this.lhsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rhsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.incrementButton = new System.Windows.Forms.Button();
            this.decrementButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lhsTextBox
            // 
            this.lhsTextBox.Location = new System.Drawing.Point(12, 51);
            this.lhsTextBox.Name = "lhsTextBox";
            this.lhsTextBox.Size = new System.Drawing.Size(100, 31);
            this.lhsTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "LHS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "RHS";
            // 
            // rhsTextBox
            // 
            this.rhsTextBox.Location = new System.Drawing.Point(17, 188);
            this.rhsTextBox.Name = "rhsTextBox";
            this.rhsTextBox.Size = new System.Drawing.Size(100, 31);
            this.rhsTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Result";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(17, 364);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(771, 31);
            this.resultTextBox.TabIndex = 5;
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(342, 40);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(99, 42);
            this.plusButton.TabIndex = 6;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(575, 40);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(107, 42);
            this.minusButton.TabIndex = 7;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(342, 142);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(99, 35);
            this.multiplyButton.TabIndex = 8;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = true;
            // 
            // divideButton
            // 
            this.divideButton.Location = new System.Drawing.Point(575, 142);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(107, 35);
            this.divideButton.TabIndex = 9;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = true;
            // 
            // incrementButton
            // 
            this.incrementButton.Location = new System.Drawing.Point(342, 258);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(99, 29);
            this.incrementButton.TabIndex = 10;
            this.incrementButton.Text = "++";
            this.incrementButton.UseVisualStyleBackColor = true;
            // 
            // decrementButton
            // 
            this.decrementButton.Location = new System.Drawing.Point(575, 258);
            this.decrementButton.Name = "decrementButton";
            this.decrementButton.Size = new System.Drawing.Size(107, 29);
            this.decrementButton.TabIndex = 11;
            this.decrementButton.Text = "--";
            this.decrementButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.decrementButton);
            this.Controls.Add(this.incrementButton);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rhsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lhsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lhsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rhsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button incrementButton;
        private System.Windows.Forms.Button decrementButton;
    }
}

