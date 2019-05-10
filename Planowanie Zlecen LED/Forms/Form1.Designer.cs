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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bpSplashScreen = new System.Windows.Forms.PictureBox();
            this.dgvDailyOrdersSummary = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSaveAndSendChangesForUpdates = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvOrdersStatus = new Planowanie_Zlecen_LED.CustomDataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lOutputNorm = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mcShippingPlan = new System.Windows.Forms.MonthCalendar();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lModelDescribtion = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bOK = new System.Windows.Forms.Button();
            this.tbLeds = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.tb10NC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lSamePcbInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bpSplashScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyOrdersSummary)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersStatus)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // bpSplashScreen
            // 
            this.bpSplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bpSplashScreen.Location = new System.Drawing.Point(0, 0);
            this.bpSplashScreen.Margin = new System.Windows.Forms.Padding(0);
            this.bpSplashScreen.Name = "bpSplashScreen";
            this.bpSplashScreen.Size = new System.Drawing.Size(1223, 714);
            this.bpSplashScreen.TabIndex = 0;
            this.bpSplashScreen.TabStop = false;
            // 
            // dgvDailyOrdersSummary
            // 
            this.dgvDailyOrdersSummary.AllowUserToAddRows = false;
            this.dgvDailyOrdersSummary.AllowUserToDeleteRows = false;
            this.dgvDailyOrdersSummary.AllowUserToResizeColumns = false;
            this.dgvDailyOrdersSummary.AllowUserToResizeRows = false;
            this.dgvDailyOrdersSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyOrdersSummary.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDailyOrdersSummary.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDailyOrdersSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDailyOrdersSummary.Location = new System.Drawing.Point(0, 0);
            this.dgvDailyOrdersSummary.Name = "dgvDailyOrdersSummary";
            this.dgvDailyOrdersSummary.ReadOnly = true;
            this.dgvDailyOrdersSummary.RowHeadersVisible = false;
            this.dgvDailyOrdersSummary.Size = new System.Drawing.Size(1203, 195);
            this.dgvDailyOrdersSummary.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1223, 714);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1215, 688);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Podgląd zleceń";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1209, 682);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.bSaveAndSendChangesForUpdates);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 623);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1207, 58);
            this.panel2.TabIndex = 2;
            // 
            // bSaveAndSendChangesForUpdates
            // 
            this.bSaveAndSendChangesForUpdates.Dock = System.Windows.Forms.DockStyle.Right;
            this.bSaveAndSendChangesForUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSaveAndSendChangesForUpdates.Location = new System.Drawing.Point(1035, 0);
            this.bSaveAndSendChangesForUpdates.Name = "bSaveAndSendChangesForUpdates";
            this.bSaveAndSendChangesForUpdates.Size = new System.Drawing.Size(172, 58);
            this.bSaveAndSendChangesForUpdates.TabIndex = 2;
            this.bSaveAndSendChangesForUpdates.Text = "Zatwierdź zmiany";
            this.bSaveAndSendChangesForUpdates.UseVisualStyleBackColor = true;
            this.bSaveAndSendChangesForUpdates.Visible = false;
            this.bSaveAndSendChangesForUpdates.Click += new System.EventHandler(this.bSaveAndSendChangesForUpdates_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.dgvOrdersStatus);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Controls.Add(this.dgvDailyOrdersSummary);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1203, 616);
            this.panel4.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Planowanie_Zlecen_LED.Properties.Resources.spinner;
            this.pictureBox1.Location = new System.Drawing.Point(1007, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(3);
            this.pictureBox1.Size = new System.Drawing.Size(193, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dgvOrdersStatus
            // 
            this.dgvOrdersStatus.AllowUserToAddRows = false;
            this.dgvOrdersStatus.AllowUserToDeleteRows = false;
            this.dgvOrdersStatus.AllowUserToResizeColumns = false;
            this.dgvOrdersStatus.AllowUserToResizeRows = false;
            this.dgvOrdersStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvOrdersStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdersStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdersStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrdersStatus.Location = new System.Drawing.Point(0, 198);
            this.dgvOrdersStatus.Margin = new System.Windows.Forms.Padding(1);
            this.dgvOrdersStatus.Name = "dgvOrdersStatus";
            this.dgvOrdersStatus.ReadOnly = true;
            this.dgvOrdersStatus.RowHeadersVisible = false;
            this.dgvOrdersStatus.Size = new System.Drawing.Size(1203, 418);
            this.dgvOrdersStatus.TabIndex = 1;
            this.dgvOrdersStatus.userEnteredData = false;
            this.dgvOrdersStatus.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersStatus_CellDoubleClick);
            this.dgvOrdersStatus.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvOrdersStatus_CellPainting);
            this.dgvOrdersStatus.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersStatus_CellValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 195);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1203, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1215, 688);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dodaj zlecenie";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lSamePcbInfo);
            this.panel3.Controls.Add(this.lOutputNorm);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.mcShippingPlan);
            this.panel3.Controls.Add(this.tbOrderNo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lModelDescribtion);
            this.panel3.Controls.Add(this.bSend);
            this.panel3.Controls.Add(this.dgvOrders);
            this.panel3.Controls.Add(this.bOK);
            this.panel3.Controls.Add(this.tbLeds);
            this.panel3.Controls.Add(this.tbQty);
            this.panel3.Controls.Add(this.tb10NC);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1209, 682);
            this.panel3.TabIndex = 0;
            // 
            // lOutputNorm
            // 
            this.lOutputNorm.AutoSize = true;
            this.lOutputNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lOutputNorm.Location = new System.Drawing.Point(443, 138);
            this.lOutputNorm.Name = "lOutputNorm";
            this.lOutputNorm.Size = new System.Drawing.Size(21, 20);
            this.lOutputNorm.TabIndex = 14;
            this.lOutputNorm.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(19, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 40);
            this.label5.TabIndex = 13;
            this.label5.Text = "Planowana\r\nwysyłka";
            // 
            // mcShippingPlan
            // 
            this.mcShippingPlan.Location = new System.Drawing.Point(133, 215);
            this.mcShippingPlan.Name = "mcShippingPlan";
            this.mcShippingPlan.TabIndex = 5;
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbOrderNo.Location = new System.Drawing.Point(133, 21);
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.Size = new System.Drawing.Size(269, 26);
            this.tbOrderNo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(17, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nr zlecenia:";
            // 
            // lModelDescribtion
            // 
            this.lModelDescribtion.AutoSize = true;
            this.lModelDescribtion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lModelDescribtion.Location = new System.Drawing.Point(443, 24);
            this.lModelDescribtion.Name = "lModelDescribtion";
            this.lModelDescribtion.Size = new System.Drawing.Size(21, 20);
            this.lModelDescribtion.TabIndex = 9;
            this.lModelDescribtion.Text = "...";
            // 
            // bSend
            // 
            this.bSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bSend.Location = new System.Drawing.Point(12, 636);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(711, 41);
            this.bSend.TabIndex = 8;
            this.bSend.Text = "UTWÓRZ I WYŚLIJ";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column4});
            this.dgvOrders.Location = new System.Drawing.Point(12, 422);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.Size = new System.Drawing.Size(711, 208);
            this.dgvOrders.TabIndex = 7;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nr";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "10NC";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ilość";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Plan wysyłki";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column6.HeaderText = "Diody LED";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "#LED";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Usuń";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // bOK
            // 
            this.bOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bOK.Location = new System.Drawing.Point(12, 382);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(390, 34);
            this.bOK.TabIndex = 6;
            this.bOK.Text = "Dodaj";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // tbLeds
            // 
            this.tbLeds.AcceptsReturn = true;
            this.tbLeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLeds.Location = new System.Drawing.Point(133, 115);
            this.tbLeds.Multiline = true;
            this.tbLeds.Name = "tbLeds";
            this.tbLeds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLeds.Size = new System.Drawing.Size(269, 95);
            this.tbLeds.TabIndex = 4;
            this.tbLeds.TextChanged += new System.EventHandler(this.tbLeds_TextChanged);
            // 
            // tbQty
            // 
            this.tbQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbQty.Location = new System.Drawing.Point(133, 84);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(269, 26);
            this.tbQty.TabIndex = 3;
            this.tbQty.TextChanged += new System.EventHandler(this.tbQty_TextChanged);
            this.tbQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // tb10NC
            // 
            this.tb10NC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb10NC.Location = new System.Drawing.Point(133, 53);
            this.tb10NC.MaxLength = 10;
            this.tb10NC.Name = "tb10NC";
            this.tb10NC.Size = new System.Drawing.Size(269, 26);
            this.tb10NC.TabIndex = 2;
            this.tb10NC.TextChanged += new System.EventHandler(this.tb10NC_TextChanged);
            this.tb10NC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tb10NC.Leave += new System.EventHandler(this.tb10NC_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(19, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diody LED:\r\n(4010 560 ...)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(62, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ilość:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model 10NC:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "Odśwież";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lSamePcbInfo
            // 
            this.lSamePcbInfo.AutoSize = true;
            this.lSamePcbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSamePcbInfo.Location = new System.Drawing.Point(443, 215);
            this.lSamePcbInfo.Name = "lSamePcbInfo";
            this.lSamePcbInfo.Size = new System.Drawing.Size(21, 20);
            this.lSamePcbInfo.TabIndex = 15;
            this.lSamePcbInfo.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 714);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bpSplashScreen);
            this.Name = "Form1";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bpSplashScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyOrdersSummary)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersStatus)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bpSplashScreen;
        private CustomDataGridView dgvOrdersStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.TextBox tbLeds;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.TextBox tb10NC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lModelDescribtion;
        private System.Windows.Forms.TextBox tbOrderNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar mcShippingPlan;
        private System.Windows.Forms.Label lOutputNorm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridView dgvDailyOrdersSummary;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bSaveAndSendChangesForUpdates;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lSamePcbInfo;
    }
}

