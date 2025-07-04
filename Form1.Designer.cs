namespace WordGenerator
{
    partial class Form1
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
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(54, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 24);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 1;
            label1.Text = "Letters";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(237, 67);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 24);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 3;
            label2.Text = "Required Letters";
            label2.Click += label2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(437, 67);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(440, 27);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 5;
            label3.Text = "Min Letters";
            // 
            // button1
            // 
            button1.Location = new Point(56, 137);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(57, 236);
            listView1.Name = "listView1";
            listView1.Size = new Size(453, 185);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private Button button1;
        private ListView listView1;
    }
}
