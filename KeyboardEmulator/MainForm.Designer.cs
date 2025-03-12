namespace KeyboardEmulator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tbTextForSend = new TextBox();
            btSend = new Button();
            label1 = new Label();
            tbTimeout = new TextBox();
            label2 = new Label();
            label3 = new Label();
            tbPostfix = new TextBox();
            label4 = new Label();
            tbInitTimeout = new TextBox();
            label5 = new Label();
            tbCharTimeout = new TextBox();
            SuspendLayout();
            // 
            // tbTextForSend
            // 
            tbTextForSend.Location = new Point(12, 32);
            tbTextForSend.Multiline = true;
            tbTextForSend.Name = "tbTextForSend";
            tbTextForSend.Size = new Size(674, 252);
            tbTextForSend.TabIndex = 0;
            tbTextForSend.Text = resources.GetString("tbTextForSend.Text");
            // 
            // btSend
            // 
            btSend.Location = new Point(719, 32);
            btSend.Name = "btSend";
            btSend.Size = new Size(100, 23);
            btSend.TabIndex = 1;
            btSend.Text = "Отправить";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += BtSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 2;
            label1.Text = "Текст для отправки";
            // 
            // tbTimeout
            // 
            tbTimeout.Location = new Point(719, 144);
            tbTimeout.Name = "tbTimeout";
            tbTimeout.Size = new Size(100, 23);
            tbTimeout.TabIndex = 3;
            tbTimeout.Text = "200";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(719, 126);
            label2.Name = "label2";
            label2.Size = new Size(173, 15);
            label2.TabIndex = 4;
            label2.Text = "Пауза между отправками (мс)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(719, 243);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 6;
            label3.Text = "Постфикс";
            // 
            // tbPostfix
            // 
            tbPostfix.Location = new Point(719, 261);
            tbPostfix.Name = "tbPostfix";
            tbPostfix.Size = new Size(100, 23);
            tbPostfix.TabIndex = 5;
            tbPostfix.Text = "\\r";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(719, 71);
            label4.Name = "label4";
            label4.Size = new Size(148, 15);
            label4.TabIndex = 4;
            label4.Text = "Пауза перед стартом (мс)";
            // 
            // tbInitTimeout
            // 
            tbInitTimeout.Location = new Point(719, 89);
            tbInitTimeout.Name = "tbInitTimeout";
            tbInitTimeout.Size = new Size(100, 23);
            tbInitTimeout.TabIndex = 2;
            tbInitTimeout.Text = "3000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(719, 185);
            label5.Name = "label5";
            label5.Size = new Size(154, 15);
            label5.TabIndex = 4;
            label5.Text = "Пауза между буквами (мс)";
            // 
            // tbCharTimeout
            // 
            tbCharTimeout.Location = new Point(719, 203);
            tbCharTimeout.Name = "tbCharTimeout";
            tbCharTimeout.Size = new Size(100, 23);
            tbCharTimeout.TabIndex = 4;
            tbCharTimeout.Text = "0";
            // 
            // MainForm
            // 
            AcceptButton = btSend;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 296);
            Controls.Add(tbCharTimeout);
            Controls.Add(tbTextForSend);
            Controls.Add(tbInitTimeout);
            Controls.Add(tbTimeout);
            Controls.Add(tbPostfix);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btSend);
            Name = "MainForm";
            Text = "KeyboardEmulator";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbTextForSend;
        private Button btSend;
        private Label label1;
        private TextBox tbTimeout;
        private Label label2;
        private Label label3;
        private TextBox tbPostfix;
        private Label label4;
        private TextBox tbInitTimeout;
        private Label label5;
        private TextBox tbCharTimeout;
    }
}