namespace L5_2.Autobusai
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
            this.results = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formattingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findingMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // results
            // 
            this.results.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.results.Location = new System.Drawing.Point(16, 33);
            this.results.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(732, 400);
            this.results.TabIndex = 0;
            this.results.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDataToolStripMenuItem,
            this.printToolStripMenuItem,
            this.endToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // setDataToolStripMenuItem
            // 
            this.setDataToolStripMenuItem.Name = "setDataToolStripMenuItem";
            this.setDataToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.setDataToolStripMenuItem.Text = "Įvesti pradinius duomenis";
            this.setDataToolStripMenuItem.Click += new System.EventHandler(this.setDataToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.printToolStripMenuItem.Text = "Spausdinti";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.endToolStripMenuItem.Text = "Baigti";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formattingToolStripMenuItem,
            this.findingMaxToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // formattingToolStripMenuItem
            // 
            this.formattingToolStripMenuItem.Name = "formattingToolStripMenuItem";
            this.formattingToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.formattingToolStripMenuItem.Text = "Formavimas";
            this.formattingToolStripMenuItem.Click += new System.EventHandler(this.formattingToolStripMenuItem_Click);
            // 
            // findingMaxToolStripMenuItem
            // 
            this.findingMaxToolStripMenuItem.Name = "findingMaxToolStripMenuItem";
            this.findingMaxToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.findingMaxToolStripMenuItem.Text = "Pelningiausio radimas";
            this.findingMaxToolStripMenuItem.Click += new System.EventHandler(this.findingMaxToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.informationToolStripMenuItem.Text = "Informacija";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.notificationLabel.ForeColor = System.Drawing.Color.Red;
            this.notificationLabel.Location = new System.Drawing.Point(16, 484);
            this.notificationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(276, 27);
            this.notificationLabel.TabIndex = 2;
            this.notificationLabel.Text = "Čia bus rodomi pranešimai!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 563);
            this.Controls.Add(this.notificationLabel);
            this.Controls.Add(this.results);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Maršrutai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox results;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formattingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findingMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.Label notificationLabel;
    }
}

