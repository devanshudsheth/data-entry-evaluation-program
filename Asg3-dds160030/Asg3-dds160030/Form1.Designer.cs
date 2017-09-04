namespace Asg3_dds160030
{
    partial class EvaluationForm
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
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ctlFilePath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listValues = new System.Windows.Forms.ListView();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.lblstatusbar = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Location = new System.Drawing.Point(46, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowse.Location = new System.Drawing.Point(456, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(132, 39);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "BROWSE";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ctlFilePath
            // 
            this.ctlFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlFilePath.Location = new System.Drawing.Point(45, 51);
            this.ctlFilePath.Name = "ctlFilePath";
            this.ctlFilePath.Size = new System.Drawing.Size(416, 22);
            this.ctlFilePath.TabIndex = 0;
            this.ctlFilePath.TextChanged += new System.EventHandler(this.ctlFilePath_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.listValues);
            this.panel2.Location = new System.Drawing.Point(45, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 459);
            this.panel2.TabIndex = 1;
            // 
            // listValues
            // 
            this.listValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listValues.HideSelection = false;
            this.listValues.Location = new System.Drawing.Point(0, 0);
            this.listValues.MultiSelect = false;
            this.listValues.Name = "listValues";
            this.listValues.Size = new System.Drawing.Size(588, 459);
            this.listValues.TabIndex = 3;
            this.listValues.UseCompatibleStateImageBehavior = false;
            this.listValues.View = System.Windows.Forms.View.List;
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatusbar});
            this.StatusBar.Location = new System.Drawing.Point(0, 710);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(682, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // lblstatusbar
            // 
            this.lblstatusbar.Name = "lblstatusbar";
            this.lblstatusbar.Size = new System.Drawing.Size(0, 17);
            // 
            // btnAccept
            // 
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAccept.Location = new System.Drawing.Point(0, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(200, 75);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "ACCEPT";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.btnAccept);
            this.panel3.Location = new System.Drawing.Point(237, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 75);
            this.panel3.TabIndex = 4;
            // 
            // EvaluationForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 732);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ctlFilePath);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EvaluationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluation Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ctlFilePath_TextChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ctlFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listValues;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblstatusbar;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Panel panel3;
    }
}

