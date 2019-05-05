namespace Planowanie_Zlecen_LED
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bpSplashScreen = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSaveAndSendChanges = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvOrdersStatus = new Planowanie_Zlecen_LED.CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bpSplashScreen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // bpSplashScreen
            // 
            this.bpSplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bpSplashScreen.Location = new System.Drawing.Point(0, 0);
            this.bpSplashScreen.Margin = new System.Windows.Forms.Padding(0);
            this.bpSplashScreen.Name = "bpSplashScreen";
            this.bpSplashScreen.Size = new System.Drawing.Size(1223, 639);
            this.bpSplashScreen.TabIndex = 0;
            this.bpSplashScreen.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvOrdersStatus, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1209, 607);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bSaveAndSendChanges);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1203, 54);
            this.panel2.TabIndex = 2;
            // 
            // bSaveAndSendChanges
            // 
            this.bSaveAndSendChanges.Dock = System.Windows.Forms.DockStyle.Right;
            this.bSaveAndSendChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveAndSendChanges.Location = new System.Drawing.Point(1031, 0);
            this.bSaveAndSendChanges.Name = "bSaveAndSendChanges";
            this.bSaveAndSendChanges.Size = new System.Drawing.Size(172, 54);
            this.bSaveAndSendChanges.TabIndex = 2;
            this.bSaveAndSendChanges.Text = "Zatwierdź zmiany";
            this.bSaveAndSendChanges.UseVisualStyleBackColor = true;
            this.bSaveAndSendChanges.Visible = false;
            this.bSaveAndSendChanges.Click += new System.EventHandler(this.bSaveAndSendChanges_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 54);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1223, 639);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1215, 613);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Podgląd zleceń";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1215, 613);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dodaj zlecenie";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvOrdersStatus
            // 
            this.dgvOrdersStatus.AllowUserToAddRows = false;
            this.dgvOrdersStatus.AllowUserToDeleteRows = false;
            this.dgvOrdersStatus.AllowUserToResizeColumns = false;
            this.dgvOrdersStatus.AllowUserToResizeRows = false;
            this.dgvOrdersStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdersStatus.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdersStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdersStatus.Location = new System.Drawing.Point(3, 63);
            this.dgvOrdersStatus.Name = "dgvOrdersStatus";
            this.dgvOrdersStatus.ReadOnly = true;
            this.dgvOrdersStatus.RowHeadersVisible = false;
            this.dgvOrdersStatus.Size = new System.Drawing.Size(1203, 481);
            this.dgvOrdersStatus.TabIndex = 1;
            this.dgvOrdersStatus.userEnteredData = false;
            this.dgvOrdersStatus.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersStatus_CellDoubleClick);
            this.dgvOrdersStatus.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersStatus_CellValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 639);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bpSplashScreen);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bpSplashScreen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bpSplashScreen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CustomDataGridView dgvOrdersStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bSaveAndSendChanges;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

