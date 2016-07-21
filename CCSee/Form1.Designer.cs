namespace CCSee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbReferenceNumberType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btFind = new System.Windows.Forms.Button();
            this.tbRefValue = new System.Windows.Forms.TextBox();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.lbOutput = new System.Windows.Forms.ListBox();
            this.TabController = new System.Windows.Forms.TabControl();
            this.AssetEventHistoryTab = new System.Windows.Forms.TabPage();
            this.textBoxTab1 = new System.Windows.Forms.TextBox();
            this.buttonTab1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTab1 = new System.Windows.Forms.ComboBox();
            this.dataGridViewTab1 = new System.Windows.Forms.DataGridView();
            this.AssetBillingHistoryTab = new System.Windows.Forms.TabPage();
            this.textBoxTab2 = new System.Windows.Forms.TextBox();
            this.buttonTab2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTab2 = new System.Windows.Forms.ComboBox();
            this.dataGridViewTab2 = new System.Windows.Forms.DataGridView();
            this.AssetStateHistoryTab = new System.Windows.Forms.TabPage();
            this.textBoxTab3 = new System.Windows.Forms.TextBox();
            this.buttonTab3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTab3 = new System.Windows.Forms.ComboBox();
            this.dataGridViewTab3 = new System.Windows.Forms.DataGridView();
            this.OrderTab = new System.Windows.Forms.TabPage();
            this.textBoxTab4 = new System.Windows.Forms.TextBox();
            this.buttonTab4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTab4 = new System.Windows.Forms.ComboBox();
            this.dataGridViewTab4 = new System.Windows.Forms.DataGridView();
            this.InternalRefTab = new System.Windows.Forms.TabPage();
            this.textBoxTab5 = new System.Windows.Forms.TextBox();
            this.buttonTab5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTab5 = new System.Windows.Forms.ComboBox();
            this.dataGridViewTab5 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.TabController.SuspendLayout();
            this.AssetEventHistoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab1)).BeginInit();
            this.AssetBillingHistoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab2)).BeginInit();
            this.AssetStateHistoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab3)).BeginInit();
            this.OrderTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab4)).BeginInit();
            this.InternalRefTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab5)).BeginInit();
            this.SuspendLayout();
            // 
            // cbReferenceNumberType
            // 
            this.cbReferenceNumberType.FormattingEnabled = true;
            this.cbReferenceNumberType.Location = new System.Drawing.Point(12, 46);
            this.cbReferenceNumberType.Margin = new System.Windows.Forms.Padding(4);
            this.cbReferenceNumberType.Name = "cbReferenceNumberType";
            this.cbReferenceNumberType.Size = new System.Drawing.Size(284, 33);
            this.cbReferenceNumberType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lookup By:";
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(308, 87);
            this.btFind.Margin = new System.Windows.Forms.Padding(4);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(88, 50);
            this.btFind.TabIndex = 2;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // tbRefValue
            // 
            this.tbRefValue.Location = new System.Drawing.Point(12, 94);
            this.tbRefValue.Margin = new System.Windows.Forms.Padding(4);
            this.tbRefValue.Name = "tbRefValue";
            this.tbRefValue.Size = new System.Drawing.Size(284, 31);
            this.tbRefValue.TabIndex = 3;
            this.tbRefValue.Text = "CCUSAD00008650";
            // 
            // dgvOut
            // 
            this.dgvOut.AllowUserToOrderColumns = true;
            this.dgvOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Location = new System.Drawing.Point(3, 169);
            this.dgvOut.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.RowTemplate.Height = 33;
            this.dgvOut.Size = new System.Drawing.Size(2666, 927);
            this.dgvOut.TabIndex = 4;
            this.dgvOut.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOut_CellContentClick);
            this.dgvOut.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOut_CellContentDoubleClick);
            this.dgvOut.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOut_CellDoubleClick);
            // 
            // lbOutput
            // 
            this.lbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOutput.FormattingEnabled = true;
            this.lbOutput.ItemHeight = 25;
            this.lbOutput.Location = new System.Drawing.Point(22, 1169);
            this.lbOutput.Margin = new System.Windows.Forms.Padding(4);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(3236, 104);
            this.lbOutput.TabIndex = 5;
            // 
            // TabController
            // 
            this.TabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabController.Controls.Add(this.AssetEventHistoryTab);
            this.TabController.Controls.Add(this.AssetBillingHistoryTab);
            this.TabController.Controls.Add(this.AssetStateHistoryTab);
            this.TabController.Controls.Add(this.OrderTab);
            this.TabController.Controls.Add(this.InternalRefTab);
            this.TabController.Location = new System.Drawing.Point(12, 15);
            this.TabController.Name = "TabController";
            this.TabController.SelectedIndex = 0;
            this.TabController.Size = new System.Drawing.Size(2692, 1147);
            this.TabController.TabIndex = 6;
            // 
            // AssetEventHistoryTab
            // 
            this.AssetEventHistoryTab.Controls.Add(this.textBoxTab1);
            this.AssetEventHistoryTab.Controls.Add(this.buttonTab1);
            this.AssetEventHistoryTab.Controls.Add(this.dgvOut);
            this.AssetEventHistoryTab.Controls.Add(this.label2);
            this.AssetEventHistoryTab.Controls.Add(this.comboTab1);
            this.AssetEventHistoryTab.Controls.Add(this.dataGridViewTab1);
            this.AssetEventHistoryTab.Location = new System.Drawing.Point(8, 39);
            this.AssetEventHistoryTab.Name = "AssetEventHistoryTab";
            this.AssetEventHistoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssetEventHistoryTab.Size = new System.Drawing.Size(2676, 1100);
            this.AssetEventHistoryTab.TabIndex = 0;
            this.AssetEventHistoryTab.Text = "AssetEventHistory";
            this.AssetEventHistoryTab.UseVisualStyleBackColor = true;
            // 
            // textBoxTab1
            // 
            this.textBoxTab1.Location = new System.Drawing.Point(33, 100);
            this.textBoxTab1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTab1.Name = "textBoxTab1";
            this.textBoxTab1.Size = new System.Drawing.Size(284, 31);
            this.textBoxTab1.TabIndex = 7;
            this.textBoxTab1.Text = "CCUSAD00008650";
            // 
            // buttonTab1
            // 
            this.buttonTab1.Location = new System.Drawing.Point(340, 90);
            this.buttonTab1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTab1.Name = "buttonTab1";
            this.buttonTab1.Size = new System.Drawing.Size(88, 50);
            this.buttonTab1.TabIndex = 6;
            this.buttonTab1.Text = "Find";
            this.buttonTab1.UseVisualStyleBackColor = true;
            this.buttonTab1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lookup By:";
            // 
            // comboTab1
            // 
            this.comboTab1.FormattingEnabled = true;
            this.comboTab1.Location = new System.Drawing.Point(32, 47);
            this.comboTab1.Margin = new System.Windows.Forms.Padding(4);
            this.comboTab1.Name = "comboTab1";
            this.comboTab1.Size = new System.Drawing.Size(284, 33);
            this.comboTab1.TabIndex = 4;
            // 
            // dataGridViewTab1
            // 
            this.dataGridViewTab1.AllowUserToOrderColumns = true;
            this.dataGridViewTab1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTab1.Location = new System.Drawing.Point(3, 169);
            this.dataGridViewTab1.Name = "dataGridViewTab1";
            this.dataGridViewTab1.RowTemplate.Height = 33;
            this.dataGridViewTab1.Size = new System.Drawing.Size(1223, 674);
            this.dataGridViewTab1.TabIndex = 0;
            this.dataGridViewTab1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // AssetBillingHistoryTab
            // 
            this.AssetBillingHistoryTab.Controls.Add(this.textBoxTab2);
            this.AssetBillingHistoryTab.Controls.Add(this.buttonTab2);
            this.AssetBillingHistoryTab.Controls.Add(this.label3);
            this.AssetBillingHistoryTab.Controls.Add(this.comboBoxTab2);
            this.AssetBillingHistoryTab.Controls.Add(this.dataGridViewTab2);
            this.AssetBillingHistoryTab.Location = new System.Drawing.Point(8, 39);
            this.AssetBillingHistoryTab.Name = "AssetBillingHistoryTab";
            this.AssetBillingHistoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssetBillingHistoryTab.Size = new System.Drawing.Size(2676, 1100);
            this.AssetBillingHistoryTab.TabIndex = 1;
            this.AssetBillingHistoryTab.Text = "AssetBillingHistory";
            this.AssetBillingHistoryTab.UseVisualStyleBackColor = true;
            // 
            // textBoxTab2
            // 
            this.textBoxTab2.Location = new System.Drawing.Point(33, 100);
            this.textBoxTab2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTab2.Name = "textBoxTab2";
            this.textBoxTab2.Size = new System.Drawing.Size(284, 31);
            this.textBoxTab2.TabIndex = 7;
            this.textBoxTab2.Text = "CCUSAD00008650";
            // 
            // buttonTab2
            // 
            this.buttonTab2.Location = new System.Drawing.Point(340, 90);
            this.buttonTab2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTab2.Name = "buttonTab2";
            this.buttonTab2.Size = new System.Drawing.Size(88, 50);
            this.buttonTab2.TabIndex = 6;
            this.buttonTab2.Text = "Find";
            this.buttonTab2.UseVisualStyleBackColor = true;
            this.buttonTab2.Click += new System.EventHandler(this.buttonTab2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lookup By:";
            // 
            // comboBoxTab2
            // 
            this.comboBoxTab2.FormattingEnabled = true;
            this.comboBoxTab2.Location = new System.Drawing.Point(32, 47);
            this.comboBoxTab2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTab2.Name = "comboBoxTab2";
            this.comboBoxTab2.Size = new System.Drawing.Size(284, 33);
            this.comboBoxTab2.TabIndex = 4;
            // 
            // dataGridViewTab2
            // 
            this.dataGridViewTab2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTab2.Location = new System.Drawing.Point(3, 169);
            this.dataGridViewTab2.Name = "dataGridViewTab2";
            this.dataGridViewTab2.RowTemplate.Height = 33;
            this.dataGridViewTab2.Size = new System.Drawing.Size(2666, 927);
            this.dataGridViewTab2.TabIndex = 0;
            this.dataGridViewTab2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTab2_CellContentClick);
            // 
            // AssetStateHistoryTab
            // 
            this.AssetStateHistoryTab.Controls.Add(this.textBoxTab3);
            this.AssetStateHistoryTab.Controls.Add(this.buttonTab3);
            this.AssetStateHistoryTab.Controls.Add(this.label4);
            this.AssetStateHistoryTab.Controls.Add(this.comboBoxTab3);
            this.AssetStateHistoryTab.Controls.Add(this.dataGridViewTab3);
            this.AssetStateHistoryTab.Location = new System.Drawing.Point(8, 39);
            this.AssetStateHistoryTab.Name = "AssetStateHistoryTab";
            this.AssetStateHistoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssetStateHistoryTab.Size = new System.Drawing.Size(2676, 1100);
            this.AssetStateHistoryTab.TabIndex = 2;
            this.AssetStateHistoryTab.Text = "AssetStateHistory";
            this.AssetStateHistoryTab.UseVisualStyleBackColor = true;
            // 
            // textBoxTab3
            // 
            this.textBoxTab3.Location = new System.Drawing.Point(33, 100);
            this.textBoxTab3.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTab3.Name = "textBoxTab3";
            this.textBoxTab3.Size = new System.Drawing.Size(284, 31);
            this.textBoxTab3.TabIndex = 12;
            this.textBoxTab3.Text = "CCUSAD00008650";
            // 
            // buttonTab3
            // 
            this.buttonTab3.Location = new System.Drawing.Point(340, 90);
            this.buttonTab3.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTab3.Name = "buttonTab3";
            this.buttonTab3.Size = new System.Drawing.Size(88, 50);
            this.buttonTab3.TabIndex = 11;
            this.buttonTab3.Text = "Find";
            this.buttonTab3.UseVisualStyleBackColor = true;
            this.buttonTab3.Click += new System.EventHandler(this.buttonTab3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lookup By:";
            // 
            // comboBoxTab3
            // 
            this.comboBoxTab3.FormattingEnabled = true;
            this.comboBoxTab3.Location = new System.Drawing.Point(32, 47);
            this.comboBoxTab3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTab3.Name = "comboBoxTab3";
            this.comboBoxTab3.Size = new System.Drawing.Size(284, 33);
            this.comboBoxTab3.TabIndex = 9;
            // 
            // dataGridViewTab3
            // 
            this.dataGridViewTab3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTab3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTab3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTab3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTab3.Location = new System.Drawing.Point(3, 169);
            this.dataGridViewTab3.Name = "dataGridViewTab3";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTab3.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTab3.RowTemplate.Height = 33;
            this.dataGridViewTab3.Size = new System.Drawing.Size(2666, 927);
            this.dataGridViewTab3.TabIndex = 8;
            this.dataGridViewTab3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTab3_CellContentClick);
            // 
            // OrderTab
            // 
            this.OrderTab.Controls.Add(this.textBoxTab4);
            this.OrderTab.Controls.Add(this.buttonTab4);
            this.OrderTab.Controls.Add(this.label5);
            this.OrderTab.Controls.Add(this.comboBoxTab4);
            this.OrderTab.Controls.Add(this.dataGridViewTab4);
            this.OrderTab.Location = new System.Drawing.Point(8, 39);
            this.OrderTab.Name = "OrderTab";
            this.OrderTab.Padding = new System.Windows.Forms.Padding(3);
            this.OrderTab.Size = new System.Drawing.Size(2676, 1100);
            this.OrderTab.TabIndex = 3;
            this.OrderTab.Text = "Order";
            this.OrderTab.UseVisualStyleBackColor = true;
            // 
            // textBoxTab4
            // 
            this.textBoxTab4.Location = new System.Drawing.Point(33, 100);
            this.textBoxTab4.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTab4.Name = "textBoxTab4";
            this.textBoxTab4.Size = new System.Drawing.Size(284, 31);
            this.textBoxTab4.TabIndex = 17;
            this.textBoxTab4.Text = "CCUSAD00008650";
            // 
            // buttonTab4
            // 
            this.buttonTab4.Location = new System.Drawing.Point(340, 90);
            this.buttonTab4.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTab4.Name = "buttonTab4";
            this.buttonTab4.Size = new System.Drawing.Size(88, 50);
            this.buttonTab4.TabIndex = 16;
            this.buttonTab4.Text = "Find";
            this.buttonTab4.UseVisualStyleBackColor = true;
            this.buttonTab4.Click += new System.EventHandler(this.buttonTab4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Lookup By:";
            // 
            // comboBoxTab4
            // 
            this.comboBoxTab4.FormattingEnabled = true;
            this.comboBoxTab4.Location = new System.Drawing.Point(32, 47);
            this.comboBoxTab4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTab4.Name = "comboBoxTab4";
            this.comboBoxTab4.Size = new System.Drawing.Size(284, 33);
            this.comboBoxTab4.TabIndex = 14;
            // 
            // dataGridViewTab4
            // 
            this.dataGridViewTab4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTab4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTab4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTab4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTab4.Location = new System.Drawing.Point(3, 169);
            this.dataGridViewTab4.Name = "dataGridViewTab4";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTab4.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTab4.RowTemplate.Height = 33;
            this.dataGridViewTab4.Size = new System.Drawing.Size(2666, 927);
            this.dataGridViewTab4.TabIndex = 13;
            this.dataGridViewTab4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTab4_CellContentClick);
            // 
            // InternalRefTab
            // 
            this.InternalRefTab.Controls.Add(this.textBoxTab5);
            this.InternalRefTab.Controls.Add(this.buttonTab5);
            this.InternalRefTab.Controls.Add(this.label6);
            this.InternalRefTab.Controls.Add(this.comboBoxTab5);
            this.InternalRefTab.Controls.Add(this.dataGridViewTab5);
            this.InternalRefTab.Location = new System.Drawing.Point(8, 39);
            this.InternalRefTab.Name = "InternalRefTab";
            this.InternalRefTab.Padding = new System.Windows.Forms.Padding(3);
            this.InternalRefTab.Size = new System.Drawing.Size(2676, 1100);
            this.InternalRefTab.TabIndex = 4;
            this.InternalRefTab.Text = "LogTekInternalRef";
            this.InternalRefTab.UseVisualStyleBackColor = true;
            // 
            // textBoxTab5
            // 
            this.textBoxTab5.Location = new System.Drawing.Point(33, 100);
            this.textBoxTab5.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTab5.Name = "textBoxTab5";
            this.textBoxTab5.Size = new System.Drawing.Size(284, 31);
            this.textBoxTab5.TabIndex = 17;
            this.textBoxTab5.Text = "CCUSAD00008650";
            // 
            // buttonTab5
            // 
            this.buttonTab5.Location = new System.Drawing.Point(340, 90);
            this.buttonTab5.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTab5.Name = "buttonTab5";
            this.buttonTab5.Size = new System.Drawing.Size(88, 50);
            this.buttonTab5.TabIndex = 16;
            this.buttonTab5.Text = "Find";
            this.buttonTab5.UseVisualStyleBackColor = true;
            this.buttonTab5.Click += new System.EventHandler(this.buttonTab5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Lookup By:";
            // 
            // comboBoxTab5
            // 
            this.comboBoxTab5.FormattingEnabled = true;
            this.comboBoxTab5.Location = new System.Drawing.Point(32, 47);
            this.comboBoxTab5.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTab5.Name = "comboBoxTab5";
            this.comboBoxTab5.Size = new System.Drawing.Size(284, 33);
            this.comboBoxTab5.TabIndex = 14;
            // 
            // dataGridViewTab5
            // 
            this.dataGridViewTab5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTab5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTab5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTab5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTab5.Location = new System.Drawing.Point(3, 169);
            this.dataGridViewTab5.Name = "dataGridViewTab5";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTab5.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTab5.RowTemplate.Height = 33;
            this.dataGridViewTab5.Size = new System.Drawing.Size(2666, 927);
            this.dataGridViewTab5.TabIndex = 13;
            this.dataGridViewTab5.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTab5_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2724, 1298);
            this.Controls.Add(this.TabController);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.tbRefValue);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbReferenceNumberType);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "CCSee";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.TabController.ResumeLayout(false);
            this.AssetEventHistoryTab.ResumeLayout(false);
            this.AssetEventHistoryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab1)).EndInit();
            this.AssetBillingHistoryTab.ResumeLayout(false);
            this.AssetBillingHistoryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab2)).EndInit();
            this.AssetStateHistoryTab.ResumeLayout(false);
            this.AssetStateHistoryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab3)).EndInit();
            this.OrderTab.ResumeLayout(false);
            this.OrderTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab4)).EndInit();
            this.InternalRefTab.ResumeLayout(false);
            this.InternalRefTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTab5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbReferenceNumberType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.TextBox tbRefValue;
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.ListBox lbOutput;
        private System.Windows.Forms.TabControl TabController;
        private System.Windows.Forms.TabPage AssetEventHistoryTab;
        private System.Windows.Forms.TabPage AssetBillingHistoryTab;
        private System.Windows.Forms.DataGridView dataGridViewTab2;
        private System.Windows.Forms.DataGridView dataGridViewTab1;
        private System.Windows.Forms.TextBox textBoxTab1;
        private System.Windows.Forms.Button buttonTab1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTab1;
        private System.Windows.Forms.TextBox textBoxTab2;
        private System.Windows.Forms.Button buttonTab2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTab2;
        private System.Windows.Forms.TabPage AssetStateHistoryTab;
        private System.Windows.Forms.TabPage OrderTab;
        private System.Windows.Forms.TabPage InternalRefTab;
        private System.Windows.Forms.TextBox textBoxTab3;
        private System.Windows.Forms.Button buttonTab3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTab3;
        private System.Windows.Forms.DataGridView dataGridViewTab3;
        private System.Windows.Forms.TextBox textBoxTab4;
        private System.Windows.Forms.Button buttonTab4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTab4;
        private System.Windows.Forms.DataGridView dataGridViewTab4;
        private System.Windows.Forms.TextBox textBoxTab5;
        private System.Windows.Forms.Button buttonTab5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxTab5;
        private System.Windows.Forms.DataGridView dataGridViewTab5;
    }
}

