namespace Aurora_Stock
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.button_Query = new System.Windows.Forms.Button();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.listView_Stock = new System.Windows.Forms.ListView();
            this.columnHeader_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_StockCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_StockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_TodayOpen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_YesterdayClose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_CurrentPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_UpDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_UpDownPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_TodayHighest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_TodayLowest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DealAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DealMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button_Refresh = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_ManualRefresh = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox_ColorText = new System.Windows.Forms.CheckBox();
            this.listView_ToBeSelected = new System.Windows.Forms.ListView();
            this.columnHeader_No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_About = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Code
            // 
            this.textBox_Code.Location = new System.Drawing.Point(13, 14);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(141, 21);
            this.textBox_Code.TabIndex = 2;
            this.textBox_Code.Click += new System.EventHandler(this.textBox_Code_Click);
            this.textBox_Code.TextChanged += new System.EventHandler(this.textBox_Code_TextChanged);
            this.textBox_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Code_KeyDown);
            this.textBox_Code.Leave += new System.EventHandler(this.textBox_Code_Leave);
            // 
            // button_Query
            // 
            this.button_Query.Location = new System.Drawing.Point(178, 14);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(100, 21);
            this.button_Query.TabIndex = 10;
            this.button_Query.Text = "查询";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // textBox_Result
            // 
            this.textBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Result.Location = new System.Drawing.Point(303, 51);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Result.Size = new System.Drawing.Size(552, 76);
            this.textBox_Result.TabIndex = 1;
            // 
            // listView_Stock
            // 
            this.listView_Stock.AllowDrop = true;
            this.listView_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Stock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ID,
            this.columnHeader_StockCode,
            this.columnHeader_StockName,
            this.columnHeader_TodayOpen,
            this.columnHeader_YesterdayClose,
            this.columnHeader_CurrentPrice,
            this.columnHeader_UpDown,
            this.columnHeader_UpDownPercent,
            this.columnHeader_TodayHighest,
            this.columnHeader_TodayLowest,
            this.columnHeader_DealAmount,
            this.columnHeader_DealMoney});
            this.listView_Stock.FullRowSelect = true;
            this.listView_Stock.GridLines = true;
            this.listView_Stock.Location = new System.Drawing.Point(12, 133);
            this.listView_Stock.Name = "listView_Stock";
            this.listView_Stock.Size = new System.Drawing.Size(843, 378);
            this.listView_Stock.SmallImageList = this.imageList1;
            this.listView_Stock.TabIndex = 3;
            this.listView_Stock.UseCompatibleStateImageBehavior = false;
            this.listView_Stock.View = System.Windows.Forms.View.Details;
            this.listView_Stock.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_Stock_ItemDrag);
            this.listView_Stock.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_Stock_DragDrop);
            this.listView_Stock.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_Stock_DragEnter);
            this.listView_Stock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_Stock_KeyDown);
            // 
            // columnHeader_ID
            // 
            this.columnHeader_ID.Text = "序号";
            this.columnHeader_ID.Width = 40;
            // 
            // columnHeader_StockCode
            // 
            this.columnHeader_StockCode.Text = "代码";
            this.columnHeader_StockCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_StockName
            // 
            this.columnHeader_StockName.Text = "名称";
            this.columnHeader_StockName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_TodayOpen
            // 
            this.columnHeader_TodayOpen.Text = "今开";
            this.columnHeader_TodayOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_TodayOpen.Width = 70;
            // 
            // columnHeader_YesterdayClose
            // 
            this.columnHeader_YesterdayClose.Text = "昨收";
            this.columnHeader_YesterdayClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_YesterdayClose.Width = 70;
            // 
            // columnHeader_CurrentPrice
            // 
            this.columnHeader_CurrentPrice.Text = "现价";
            this.columnHeader_CurrentPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_CurrentPrice.Width = 70;
            // 
            // columnHeader_UpDown
            // 
            this.columnHeader_UpDown.Text = "涨跌";
            this.columnHeader_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_UpDownPercent
            // 
            this.columnHeader_UpDownPercent.Text = "涨幅";
            this.columnHeader_UpDownPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_TodayHighest
            // 
            this.columnHeader_TodayHighest.Text = "最高";
            this.columnHeader_TodayHighest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_TodayHighest.Width = 70;
            // 
            // columnHeader_TodayLowest
            // 
            this.columnHeader_TodayLowest.Text = "最低";
            this.columnHeader_TodayLowest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_TodayLowest.Width = 70;
            // 
            // columnHeader_DealAmount
            // 
            this.columnHeader_DealAmount.Text = "成交量(手)";
            this.columnHeader_DealAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_DealAmount.Width = 80;
            // 
            // columnHeader_DealMoney
            // 
            this.columnHeader_DealMoney.Text = "成交额(万元)";
            this.columnHeader_DealMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_DealMoney.Width = 100;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(2, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(496, 14);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(80, 21);
            this.button_Refresh.TabIndex = 4;
            this.button_Refresh.Text = "自动刷新";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 8000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_ManualRefresh
            // 
            this.button_ManualRefresh.Location = new System.Drawing.Point(393, 14);
            this.button_ManualRefresh.Name = "button_ManualRefresh";
            this.button_ManualRefresh.Size = new System.Drawing.Size(80, 21);
            this.button_ManualRefresh.TabIndex = 5;
            this.button_ManualRefresh.Text = "手动刷新";
            this.button_ManualRefresh.UseVisualStyleBackColor = true;
            this.button_ManualRefresh.Click += new System.EventHandler(this.button_ManualRefresh_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(677, 14);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(80, 21);
            this.button_Delete.TabIndex = 6;
            this.button_Delete.Text = "删除";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(646, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "秒";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Aurora_Stock.Properties.Settings.Default, "Refresh_Interval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50",
            "60"});
            this.comboBox1.Location = new System.Drawing.Point(599, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(45, 20);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = global::Aurora_Stock.Properties.Settings.Default.Refresh_Interval;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox_ColorText
            // 
            this.checkBox_ColorText.AutoSize = true;
            this.checkBox_ColorText.Checked = global::Aurora_Stock.Properties.Settings.Default.ColorText;
            this.checkBox_ColorText.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Aurora_Stock.Properties.Settings.Default, "ColorText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_ColorText.Location = new System.Drawing.Point(303, 16);
            this.checkBox_ColorText.Name = "checkBox_ColorText";
            this.checkBox_ColorText.Size = new System.Drawing.Size(72, 16);
            this.checkBox_ColorText.TabIndex = 7;
            this.checkBox_ColorText.Text = "文本着色";
            this.checkBox_ColorText.UseVisualStyleBackColor = true;
            // 
            // listView_ToBeSelected
            // 
            this.listView_ToBeSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_No,
            this.columnHeader_Code,
            this.columnHeader_Name});
            this.listView_ToBeSelected.FullRowSelect = true;
            this.listView_ToBeSelected.GridLines = true;
            this.listView_ToBeSelected.Location = new System.Drawing.Point(13, 51);
            this.listView_ToBeSelected.MultiSelect = false;
            this.listView_ToBeSelected.Name = "listView_ToBeSelected";
            this.listView_ToBeSelected.Size = new System.Drawing.Size(265, 76);
            this.listView_ToBeSelected.TabIndex = 0;
            this.listView_ToBeSelected.UseCompatibleStateImageBehavior = false;
            this.listView_ToBeSelected.View = System.Windows.Forms.View.Details;
            this.listView_ToBeSelected.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_ToBeSelected_MouseDoubleClick);
            // 
            // columnHeader_No
            // 
            this.columnHeader_No.Text = "序号";
            this.columnHeader_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader_Code
            // 
            this.columnHeader_Code.Text = "代码";
            this.columnHeader_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_Code.Width = 88;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "名称";
            this.columnHeader_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_Name.Width = 88;
            // 
            // button_About
            // 
            this.button_About.Location = new System.Drawing.Point(775, 14);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(80, 21);
            this.button_About.TabIndex = 11;
            this.button_About.Text = "关于";
            this.button_About.UseVisualStyleBackColor = true;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 523);
            this.Controls.Add(this.button_About);
            this.Controls.Add(this.listView_ToBeSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox_ColorText);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_ManualRefresh);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.listView_Stock);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.button_Query);
            this.Controls.Add(this.textBox_Code);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aurora 股市";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.ListView listView_Stock;
        private System.Windows.Forms.ColumnHeader columnHeader_ID;
        private System.Windows.Forms.ColumnHeader columnHeader_StockName;
        private System.Windows.Forms.ColumnHeader columnHeader_TodayOpen;
        private System.Windows.Forms.ColumnHeader columnHeader_YesterdayClose;
        private System.Windows.Forms.ColumnHeader columnHeader_CurrentPrice;
        private System.Windows.Forms.ColumnHeader columnHeader_TodayHighest;
        private System.Windows.Forms.ColumnHeader columnHeader_TodayLowest;
        private System.Windows.Forms.ColumnHeader columnHeader_DealAmount;
        private System.Windows.Forms.ColumnHeader columnHeader_DealMoney;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader_StockCode;
        private System.Windows.Forms.Button button_ManualRefresh;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.ColumnHeader columnHeader_UpDown;
        private System.Windows.Forms.ColumnHeader columnHeader_UpDownPercent;
        private System.Windows.Forms.CheckBox checkBox_ColorText;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_ToBeSelected;
        private System.Windows.Forms.ColumnHeader columnHeader_Code;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_No;
        private System.Windows.Forms.Button button_About;
    }
}

