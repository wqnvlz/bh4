namespace BH4.WindowsFormsApp
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelStart = new System.Windows.Forms.Panel();
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblInputPrompt = new System.Windows.Forms.Label();
            this.txtCategoryInput = new System.Windows.Forms.TextBox();
            this.btnEnterCategories = new System.Windows.Forms.Button();
            this.panelStart.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(214, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 77);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cool App";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnStart.Location = new System.Drawing.Point(277, 347);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 51);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelStart
            // 
            this.panelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStart.Controls.Add(this.btnEnterCategories);
            this.panelStart.Controls.Add(this.txtCategoryInput);
            this.panelStart.Controls.Add(this.lblInputPrompt);
            this.panelStart.Location = new System.Drawing.Point(24, 18);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(753, 417);
            this.panelStart.TabIndex = 2;
            this.panelStart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStart_Paint);
            // 
            // panelInput
            // 
            this.panelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInput.Controls.Add(this.btnStart);
            this.panelInput.Controls.Add(this.lblTitle);
            this.panelInput.Location = new System.Drawing.Point(37, 13);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(740, 425);
            this.panelInput.TabIndex = 3;
            // 
            // lblInputPrompt
            // 
            this.lblInputPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputPrompt.AutoSize = true;
            this.lblInputPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputPrompt.Location = new System.Drawing.Point(57, 82);
            this.lblInputPrompt.Name = "lblInputPrompt";
            this.lblInputPrompt.Size = new System.Drawing.Size(308, 29);
            this.lblInputPrompt.TabIndex = 2;
            this.lblInputPrompt.Text = "Enter your three categories:";
            this.lblInputPrompt.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtCategoryInput
            // 
            this.txtCategoryInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryInput.Location = new System.Drawing.Point(62, 129);
            this.txtCategoryInput.Name = "txtCategoryInput";
            this.txtCategoryInput.Size = new System.Drawing.Size(305, 22);
            this.txtCategoryInput.TabIndex = 3;
            // 
            // btnEnterCategories
            // 
            this.btnEnterCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterCategories.Location = new System.Drawing.Point(242, 193);
            this.btnEnterCategories.Name = "btnEnterCategories";
            this.btnEnterCategories.Size = new System.Drawing.Size(125, 43);
            this.btnEnterCategories.TabIndex = 4;
            this.btnEnterCategories.Text = "Enter";
            this.btnEnterCategories.UseVisualStyleBackColor = true;
            this.btnEnterCategories.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this.panelInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblInputPrompt;
        private System.Windows.Forms.TextBox txtCategoryInput;
        private System.Windows.Forms.Button btnEnterCategories;
    }
}

