namespace SBRPWinUtility
{
    partial class PasswordCrypto
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
            btnEncrypt = new Button();
            txtDecrypt = new TextBox();
            label1 = new Label();
            txtEncrypt = new TextBox();
            btnDecrypt = new Button();
            label2 = new Label();
            radioButton1 = new RadioButton();
            SuspendLayout();
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(180, 82);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(160, 65);
            btnEncrypt.TabIndex = 0;
            btnEncrypt.Text = "&Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // txtDecrypt
            // 
            txtDecrypt.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            txtDecrypt.Location = new Point(180, 43);
            txtDecrypt.Name = "txtDecrypt";
            txtDecrypt.Size = new Size(274, 33);
            txtDecrypt.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(24, 46);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 2;
            label1.Text = "Plain Text";
            // 
            // txtEncrypt
            // 
            txtEncrypt.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            txtEncrypt.Location = new Point(180, 228);
            txtEncrypt.Name = "txtEncrypt";
            txtEncrypt.Size = new Size(520, 33);
            txtEncrypt.TabIndex = 3;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(180, 277);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(160, 61);
            btnDecrypt.TabIndex = 4;
            btnDecrypt.Text = "&Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(24, 236);
            label2.Name = "label2";
            label2.Size = new Size(150, 25);
            label2.TabIndex = 5;
            label2.Text = "Encrypted Text";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            radioButton1.Location = new Point(24, 12);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(69, 29);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "AES";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // PasswordCrypto
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 657);
            Controls.Add(radioButton1);
            Controls.Add(label2);
            Controls.Add(btnDecrypt);
            Controls.Add(txtEncrypt);
            Controls.Add(label1);
            Controls.Add(txtDecrypt);
            Controls.Add(btnEncrypt);
            Name = "PasswordCrypto";
            Text = "PasswordCrypto";
            Load += PasswordCrypto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEncrypt;
        private TextBox txtDecrypt;
        private Label label1;
        private TextBox txtEncrypt;
        private Button btnDecrypt;
        private Label label2;
        private RadioButton radioButton1;
    }
}