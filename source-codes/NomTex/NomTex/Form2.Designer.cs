namespace NomTex
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(118, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(122, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyUp += textBox1_KeyUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 15);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 1;
            label1.Text = "Bulunacak Kelime: ";
            // 
            // button1
            // 
            button1.Location = new Point(84, 55);
            button1.Name = "button1";
            button1.Size = new Size(102, 44);
            button1.TabIndex = 2;
            button1.Text = "Ara";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 111);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(500, 500);
            Name = "Form2";
            Text = "Bul ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
    }
}