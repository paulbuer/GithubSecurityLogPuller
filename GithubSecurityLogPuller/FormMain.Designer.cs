
namespace GithubSecurityLogPuller
{
    partial class FormMain
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
            this.TablePanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.TxtBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.TxtBoxEmail = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.TxtBoxResult = new System.Windows.Forms.TextBox();
            this.TablePanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TablePanelMain
            // 
            this.TablePanelMain.AutoSize = true;
            this.TablePanelMain.ColumnCount = 9;
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.5F));
            this.TablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.5F));
            this.TablePanelMain.Controls.Add(this.TxtBoxPassword, 4, 1);
            this.TablePanelMain.Controls.Add(this.LabelEmail, 1, 1);
            this.TablePanelMain.Controls.Add(this.TxtBoxEmail, 2, 1);
            this.TablePanelMain.Controls.Add(this.LabelPassword, 4, 1);
            this.TablePanelMain.Controls.Add(this.ButtonLogin, 7, 1);
            this.TablePanelMain.Controls.Add(this.TxtBoxResult, 1, 3);
            this.TablePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePanelMain.Location = new System.Drawing.Point(0, 0);
            this.TablePanelMain.Name = "TablePanelMain";
            this.TablePanelMain.RowCount = 5;
            this.TablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.TablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.TablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.TablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.TablePanelMain.Size = new System.Drawing.Size(684, 295);
            this.TablePanelMain.TabIndex = 0;
            // 
            // TxtBoxPassword
            // 
            this.TxtBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBoxPassword.Location = new System.Drawing.Point(369, 15);
            this.TxtBoxPassword.Name = "TxtBoxPassword";
            this.TxtBoxPassword.PasswordChar = '*';
            this.TxtBoxPassword.Size = new System.Drawing.Size(212, 21);
            this.TxtBoxPassword.TabIndex = 3;
            // 
            // LabelEmail
            // 
            this.LabelEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Location = new System.Drawing.Point(9, 18);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(41, 15);
            this.LabelEmail.TabIndex = 0;
            this.LabelEmail.Text = "Email";
            // 
            // TxtBoxEmail
            // 
            this.TxtBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBoxEmail.Location = new System.Drawing.Point(56, 15);
            this.TxtBoxEmail.Name = "TxtBoxEmail";
            this.TxtBoxEmail.Size = new System.Drawing.Size(212, 21);
            this.TxtBoxEmail.TabIndex = 1;
            // 
            // LabelPassword
            // 
            this.LabelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(301, 18);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(62, 15);
            this.LabelPassword.TabIndex = 2;
            this.LabelPassword.Text = "Password";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLogin.Location = new System.Drawing.Point(614, 13);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(58, 24);
            this.ButtonLogin.TabIndex = 4;
            this.ButtonLogin.Text = "Login";
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_ClickAsync);
            // 
            // TxtBoxResult
            // 
            this.TablePanelMain.SetColumnSpan(this.TxtBoxResult, 7);
            this.TxtBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtBoxResult.Location = new System.Drawing.Point(9, 57);
            this.TxtBoxResult.MaxLength = 0;
            this.TxtBoxResult.Multiline = true;
            this.TxtBoxResult.Name = "TxtBoxResult";
            this.TxtBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtBoxResult.Size = new System.Drawing.Size(663, 230);
            this.TxtBoxResult.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 295);
            this.Controls.Add(this.TablePanelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FormMain";
            this.Text = "Github Security Log Puller";
            this.TablePanelMain.ResumeLayout(false);
            this.TablePanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TablePanelMain;
        private System.Windows.Forms.TextBox TxtBoxPassword;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.TextBox TxtBoxEmail;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TxtBoxResult;
        internal System.Windows.Forms.Button ButtonLogin;
    }
}

