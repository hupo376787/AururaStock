using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace Aurora_Stock
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public string StockCode = "";        //股票代码

        public string StockName = "";        //[0]股票名字
        public string TodayOpen = "";        //[1]今日开盘价
        public string YesterdayClose = "";   //[2]昨日收盘价
        public string CurrentPrice = "";     //[3]当前价格
        public string TodayHighest = "";     //[4]今日最高价
        public string TodayLowest = "";      //[5]今日最低价
        public string BuyPrice = "";         //[6]竞买价，即“买一”报价
        public string SellPrice = "";        //[7]竞卖价，即“卖一”报价
        public string DealAmount = "";       //[8]成交的股票数，由于股票交易以一百股为基本单位，所以在使用时，通常把该值除以一百
        public string DealMoney = "";        //[9]成交金额，单位为“元”，为了一目了然，通常以“万元”为成交金额的单位，所以通常把该值除以一万

        public string BuyOneAmount = "";     //[10]“买一”申请4695股，即47手
        public string BuyOnePrice = "";      //[11]“买一”报价；
        public string BuyTwoAmount = "";     //[12]“买二”
        public string BuyTwoPrice = "";      //[13]“买二”
        public string BuyThreeAmount = "";   //[14]“买三”
        public string BuyThreePrice = "";    //[15]“买三”
        public string BuyFourAmount = "";    //[16]“买四”
        public string BuyFourPrice = "";     //[17]“买四”
        public string BuyFiveAmount = "";    //[18]“买五”
        public string BuyFivePrice = "";     //[19]“买五”

        public string SellOneAmount = "";    //[20]“卖一”申报3100股，即31手；
        public string SellOnePrice = "";     //[21]“卖一”报价
        public string SellTwoAmount = "";    //[22]“卖二”
        public string SellTwoPrice = "";     //[23]“卖二”
        public string SellThreeAmount = "";  //[24]“卖三”
        public string SellThreePrice = "";   //[25]“卖三”
        public string SellFourAmount = "";   //[26]“卖四”
        public string SellFourPrice = "";    //[27]“卖四”
        public string SellFiveAmount = "";   //[28]“卖五”
        public string SellFivePrice = "";    //[29]“卖五”

        public string CurrentDate = "";      //[30]日期
        public string CurrentTime = "";      //[31]时间

        List<string> LDictionaryName = new List<string>();
        List<string> LDictionaryCode = new List<string>();
        List<string> LDictionaryNameInput = new List<string>();
        List<string> LDictionaryCodeInput = new List<string>();

        private void button_Query_Click(object sender, EventArgs e)
        {
            if (textBox_Code.Text == "输入股票简拼或代码")
                return;
            textBox_Result.Text = GetResponseFromSinaJS(textBox_Code.Text);
            AddToList(textBox_Code.Text);

        }

        private void button_ManualRefresh_Click(object sender, EventArgs e)
        {
            RefreshStockList();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button_Refresh.Text = "自动刷新";
            }
            else
            {
                timer1.Enabled = true;
                timer1.Interval = Convert.ToInt32(comboBox1.Text.Trim()) * 1000;
                button_Refresh.Text = "停止自动";
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (listView_Stock.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in listView_Stock.SelectedItems)  //选中项遍历   
                {
                    listView_Stock.Items.RemoveAt(lvi.Index); // 按索引移除
                    //AdjustListView.Items.Remove(lvi);   //按项移除，两种方法都可以.   
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的行[按Ctrl键可多选]。", "Aurora智能提示");
            }

            int nnCount = listView_Stock.Items.Count;
            for (int i = 0; i < nnCount; i++)
            {
                listView_Stock.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshStockList();
        }

        private string GetResponseFromSinaJS(string strStockCode)
        {
            if (strStockCode == "")
                return "";
            string strWebResponse = "";
            //指数查询规则：s_sh000001,s_sz399001,s_sz399106,s_sh000300：上证指数，深证成指，深证综指，沪深300
            //股票查询规则：sh601857,sz002230：中石油，科大讯飞（以sh开头代表沪市A股，以sz开头代表深市股票，后面是对应的股票代码）
            //自动识别规则，先用sh开头。如果有数据，就继续。如果返回var hq_str_sz600992="";，则用sz开头查询。

            string strURL = "http://hq.sinajs.cn/list=sh" + strStockCode.Trim();
            WebClient client = new WebClient();
            strWebResponse = client.DownloadString(strURL);
            if(strWebResponse.Length < 30)
            {
                strURL = "http://hq.sinajs.cn/list=sz" + strStockCode.Trim();
                client = new WebClient();
                strWebResponse = client.DownloadString(strURL);
            }
            return strWebResponse;
        }

        private void AnalyzeData(string strStockCode)
        {
            if (strStockCode == "")
                return;

            string strWebResponse = GetResponseFromSinaJS(strStockCode);

            //股票代码
            int nTemp = strWebResponse.LastIndexOf('=');
            StockCode = strWebResponse.Substring(nTemp - 6, 6);
            //StockCode = StockCode.ToUpper();

            int nStart = strWebResponse.IndexOf('"');
            int nEnd = strWebResponse.LastIndexOf('"');
            string strStockInfo = strWebResponse.Substring(nStart + 1);
            strStockInfo = strStockInfo.Replace("\";", "");

            string[] ArrayStockInfo = strStockInfo.Split(',');

            try
            {
                StockName = ArrayStockInfo[0];
                TodayOpen = ArrayStockInfo[1];
                YesterdayClose = ArrayStockInfo[2];
                CurrentPrice = ArrayStockInfo[3];
                TodayHighest = ArrayStockInfo[4];
                TodayLowest = ArrayStockInfo[5];
                //BuyPrice = ArrayStockInfo[6];
                //SellPrice = ArrayStockInfo[7];
                DealAmount = ArrayStockInfo[8];
                DealMoney = ArrayStockInfo[9];

                //BuyOneAmount = ArrayStockInfo[10];
                //BuyOnePrice = ArrayStockInfo[11];
                //BuyTwoAmount = ArrayStockInfo[12];
                //BuyTwoPrice = ArrayStockInfo[13];
                //BuyThreeAmount = ArrayStockInfo[14];
                //BuyThreePrice = ArrayStockInfo[15];
                //BuyFourAmount = ArrayStockInfo[16];
                //BuyFourPrice = ArrayStockInfo[17];
                //BuyFiveAmount = ArrayStockInfo[18];
                //BuyFivePrice = ArrayStockInfo[19];

                //SellOneAmount = ArrayStockInfo[20];
                //SellOnePrice = ArrayStockInfo[21];
                //SellTwoAmount = ArrayStockInfo[22];
                //SellTwoPrice = ArrayStockInfo[23];
                //SellThreeAmount = ArrayStockInfo[24];
                //SellThreePrice = ArrayStockInfo[25];
                //SellFourAmount = ArrayStockInfo[26];
                //SellFourPrice = ArrayStockInfo[27];
                //SellFiveAmount = ArrayStockInfo[28];
                //SellFivePrice = ArrayStockInfo[29];

                CurrentDate = ArrayStockInfo[30];
                CurrentTime = ArrayStockInfo[31];
            }
            catch
            {

            }
        }

        private void AddToList(string strStockCode)
        {
            if (strStockCode == "")
                return;

            for (int i = 0; i < listView_Stock.Items.Count; i++)
            {
                if (strStockCode == listView_Stock.Items[i].SubItems[1].Text)
                    return;
            }

            AnalyzeData(strStockCode);

            int nCount = listView_Stock.Items.Count;

            ListViewItem lv = new ListViewItem((nCount + 1).ToString());

            lv.SubItems.Add(StockCode);
            lv.SubItems.Add(StockName);
            lv.SubItems.Add(TodayOpen);
            lv.SubItems.Add(YesterdayClose);
            lv.SubItems.Add(CurrentPrice);

            double dUpDown = Convert.ToDouble(CurrentPrice) - Convert.ToDouble(YesterdayClose);
            string strUpDown = dUpDown.ToString("#0.00");
            strUpDown = dUpDown > 0 ? "+" + strUpDown : strUpDown;
            lv.SubItems.Add(strUpDown);
            double dUpDownPercent = dUpDown / Convert.ToDouble(YesterdayClose);
            string strUpDownPercent = dUpDownPercent.ToString("P");
            strUpDownPercent = dUpDown > 0 ? "+" + strUpDownPercent : strUpDownPercent;
            lv.SubItems.Add(strUpDownPercent);

            lv.SubItems.Add(TodayHighest);
            lv.SubItems.Add(TodayLowest);
            //lv.SubItems.Add(BuyPrice);
            //lv.SubItems.Add(SellPrice);
            Int64 temp = Convert.ToInt64(DealAmount) / 100;
            lv.SubItems.Add(temp.ToString());
            temp = (Int64)Convert.ToDouble(DealMoney) / 10000;
            lv.SubItems.Add(temp.ToString());

            //temp = Convert.ToInt64(BuyOneAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(BuyOnePrice);
            //temp = Convert.ToInt64(BuyTwoAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(BuyTwoPrice);
            //temp = Convert.ToInt64(BuyThreeAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(BuyThreePrice);
            //temp = Convert.ToInt64(BuyFourAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(BuyFourPrice);
            //temp = Convert.ToInt64(BuyFiveAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(BuyFivePrice);

            //temp = Convert.ToInt64(SellOneAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(SellOnePrice);
            //temp = Convert.ToInt64(SellTwoAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(SellTwoPrice);
            //temp = Convert.ToInt64(SellThreeAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(SellThreePrice);
            //temp = Convert.ToInt64(SellFourAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(SellFourPrice);
            //temp = Convert.ToInt64(SellFiveAmount) / 100;
            //lv.SubItems.Add(temp.ToString());
            //lv.SubItems.Add(SellFivePrice);

            //lv.SubItems.Add(CurrentDate);
            //lv.SubItems.Add(CurrentTime);

            listView_Stock.Items.Add(lv);
        }

        private void ResetAllFields()
        {
            StockCode = "";        //股票代码

            StockName = "";        //[0]股票名字
            TodayOpen = "";        //[1]今日开盘价
            YesterdayClose = "";   //[2]昨日收盘价
            CurrentPrice = "";     //[3]当前价格
            TodayHighest = "";     //[4]今日最高价
            TodayLowest = "";      //[5]今日最低价
            BuyPrice = "";         //[6]竞买价，即“买一”报价
            SellPrice = "";        //[7]竞卖价，即“卖一”报价
            DealAmount = "";       //[8]成交的股票数，由于股票交易以一百股为基本单位，所以在使用时，通常把该值除以一百
            DealMoney = "";        //[9]成交金额，单位为“元”，为了一目了然，通常以“万元”为成交金额的单位，所以通常把该值除以一万

            BuyOneAmount = "";     //[10]“买一”申请4695股，即47手
            BuyOnePrice = "";      //[11]“买一”报价；
            BuyTwoAmount = "";     //[12]“买二”
            BuyTwoPrice = "";      //[13]“买二”
            BuyThreeAmount = "";   //[14]“买三”
            BuyThreePrice = "";    //[15]“买三”
            BuyFourAmount = "";    //[16]“买四”
            BuyFourPrice = "";     //[17]“买四”
            BuyFiveAmount = "";    //[18]“买五”
            BuyFivePrice = "";     //[19]“买五”

            SellOneAmount = "";    //[20]“卖一”申报3100股，即31手；
            SellOnePrice = "";     //[21]“卖一”报价
            SellTwoAmount = "";    //[22]“卖二”
            SellTwoPrice = "";     //[23]“卖二”
            SellThreeAmount = "";  //[24]“卖三”
            SellThreePrice = "";   //[25]“卖三”
            SellFourAmount = "";   //[26]“卖四”
            SellFourPrice = "";    //[27]“卖四”
            SellFiveAmount = "";   //[28]“卖五”
            SellFivePrice = "";    //[29]“卖五”

            CurrentDate = "";      //[30]日期
            CurrentTime = "";      //[31]时间
        }

        private void RefreshStockList()
        {
            for (int i = 0; i < listView_Stock.Items.Count; i++)
            {
                if (checkBox_ColorText.Checked == true)
                    listView_Stock.Items[i].UseItemStyleForSubItems = false;
                else
                    listView_Stock.Items[i].UseItemStyleForSubItems = true;

                string strStockCode = listView_Stock.Items[i].SubItems[1].Text;
                ResetAllFields();
                AnalyzeData(strStockCode);
                
                listView_Stock.Items[i].SubItems[0].Text = (i + 1).ToString();
                listView_Stock.Items[i].SubItems[1].Text = StockCode;
                listView_Stock.Items[i].SubItems[2].Text = StockName;
                listView_Stock.Items[i].SubItems[3].Text = TodayOpen;
                listView_Stock.Items[i].SubItems[4].Text = YesterdayClose;
                listView_Stock.Items[i].SubItems[5].Text = CurrentPrice;

                double dUpDown = Convert.ToDouble(CurrentPrice) - Convert.ToDouble(YesterdayClose);
                string strUpDown = dUpDown.ToString("#0.00");
                strUpDown = dUpDown > 0 ? "+" + strUpDown : strUpDown;
                listView_Stock.Items[i].SubItems[6].Text = strUpDown;
                double dUpDownPercent = dUpDown / Convert.ToDouble(YesterdayClose);
                string strUpDownPercent = dUpDownPercent.ToString("P");
                strUpDownPercent = dUpDown > 0 ? "+" + strUpDownPercent : strUpDownPercent;
                listView_Stock.Items[i].SubItems[7].Text = strUpDownPercent;
                if (dUpDown > 0)
                {
                    listView_Stock.Items[i].SubItems[6].ForeColor = Color.Red;
                    listView_Stock.Items[i].SubItems[7].ForeColor = Color.Red;
                }
                else if(dUpDown < 0)
                {
                    listView_Stock.Items[i].SubItems[6].ForeColor = Color.Green;
                    listView_Stock.Items[i].SubItems[7].ForeColor = Color.Green;
                }

                listView_Stock.Items[i].SubItems[8].Text = TodayHighest;
                listView_Stock.Items[i].SubItems[9].Text = TodayLowest;
                //listView_Stock.Items[i].SubItems[10].Text = BuyPrice;
                //listView_Stock.Items[i].SubItems[11].Text = SellPrice;
                Int64 temp = Convert.ToInt64(DealAmount) / 100;
                listView_Stock.Items[i].SubItems[10].Text = temp.ToString();
                temp = (Int64)Convert.ToDouble(DealMoney) / 10000;
                listView_Stock.Items[i].SubItems[11].Text = temp.ToString();

                //temp = Convert.ToInt64(BuyOneAmount) / 100;
                //listView_Stock.Items[i].SubItems[14].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[15].Text = BuyOnePrice;
                //temp = Convert.ToInt64(BuyTwoAmount) / 100;
                //listView_Stock.Items[i].SubItems[16].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[17].Text = BuyTwoPrice;
                //temp = Convert.ToInt64(BuyThreeAmount) / 100;
                //listView_Stock.Items[i].SubItems[18].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[19].Text = BuyThreePrice;
                //temp = Convert.ToInt64(BuyFourAmount) / 100;
                //listView_Stock.Items[i].SubItems[20].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[21].Text = BuyFourPrice;
                //temp = Convert.ToInt64(BuyFiveAmount) / 100;
                //listView_Stock.Items[i].SubItems[22].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[23].Text = BuyFivePrice;

                //temp = Convert.ToInt64(SellOneAmount) / 100;
                //listView_Stock.Items[i].SubItems[24].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[25].Text = SellOnePrice;
                //temp = Convert.ToInt64(SellTwoAmount) / 100;
                //listView_Stock.Items[i].SubItems[26].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[27].Text = SellTwoPrice;
                //temp = Convert.ToInt64(SellThreeAmount) / 100;
                //listView_Stock.Items[i].SubItems[28].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[29].Text = SellThreePrice;
                //temp = Convert.ToInt64(SellFourAmount) / 100;
                //listView_Stock.Items[i].SubItems[30].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[31].Text = SellFourPrice;
                //temp = Convert.ToInt64(SellFiveAmount) / 100;
                //listView_Stock.Items[i].SubItems[32].Text = temp.ToString();
                //listView_Stock.Items[i].SubItems[33].Text = SellFivePrice;

                //listView_Stock.Items[i].SubItems[12].Text = CurrentDate;
                //listView_Stock.Items[i].SubItems[13].Text = CurrentTime;
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            SaveList();
        }

        
        private void SaveList()
        {
            if (listView_Stock.Items.Count == 0)
                return;
            FileStream fs = new FileStream(Application.StartupPath + "\\MyList.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            for(int i = 0; i < listView_Stock.Items.Count; i++)
            {
                sw.WriteLine(listView_Stock.Items[i].SubItems[1].Text);
            }
            sw.Close();
            fs.Close();
        }

        private void ReadMyList()
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\MyList.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string strCode = "";
            while ((strCode = sr.ReadLine()) != null)
            {
                textBox_Result.Text += strCode + ",";
                if (strCode == "")
                    continue;

                AddToList(strCode);
            }
            sr.Close();
            fs.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(File.Exists(Application.StartupPath + "\\Aurora Stock.ico"))
                this.Icon = new Icon(Application.StartupPath + "\\Aurora Stock.ico");

            textBox_Code.Text = "输入股票简拼或代码";
            textBox_Code.ForeColor = Color.Gray;
            textBox_Code.SelectionStart = textBox_Code.Text.Length;
            textBox_Code.SelectionLength = 0;

            ReadStockFile(Application.StartupPath + "\\上海股票.txt");
            ReadStockFile(Application.StartupPath + "\\深圳股票.txt");

            ReadMyList();
            RefreshStockList();
        }

        private void listView_Stock_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView_Stock.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listView_Stock_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            Point ptScreen = new Point(e.X, e.Y);
            Point pt = listView_Stock.PointToClient(ptScreen);
            ListViewItem TargetItem = listView_Stock.GetItemAt(pt.X, pt.Y);//拖动的项将放置于该项之前   
            if (null == TargetItem)
                return;

            listView_Stock.Items.Insert(TargetItem.Index, (ListViewItem)draggedItem.Clone());
            listView_Stock.Items.Remove(draggedItem);

            int nnCount = listView_Stock.Items.Count;
            for (int i = 0; i < nnCount; i++)
            {
                listView_Stock.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void listView_Stock_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = e.AllowedEffect;
            e.Effect = DragDropEffects.Move;
        }

        private void listView_Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                RefreshStockList();
        }

        private void textBox_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_Query_Click(sender, e);
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
            //    RefreshStockList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(comboBox1.Text.Trim()) * 1000;
        }

        //输入股票的简拼也可以查询啦！！！2016.02.25
        private void textBox_Code_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Code.Text == "")
                return;

            listView_ToBeSelected.Items.Clear();
            int n_No = 0;

            foreach (string s in LDictionaryName)
            {
                if (PinYinHelper.GetChineseSpell(s).IndexOf(textBox_Code.Text.ToUpper()) == 0)
                {
                    int nCount = listView_Stock.Items.Count;

                    ListViewItem lv = new ListViewItem((n_No + 1).ToString());

                    for(int i = 0; i < LDictionaryName.Count; i++)
                    {
                        if (LDictionaryName[i] == s)
                            lv.SubItems.Add(LDictionaryCode[i]);
                    }

                    lv.SubItems.Add(s);

                    listView_ToBeSelected.Items.Add(lv);
                    n_No++;
                }
            }
        }

        private void ReadStockFile(string str_stock_file)
        {
            string str_line = "";
            StreamReader sr = new StreamReader(str_stock_file, Encoding.Default);
            while ((str_line = sr.ReadLine()) != null)
            {
                string[] strTemp = str_line.Split(',');
                LDictionaryName.Add(strTemp[0]);
                LDictionaryCode.Add(strTemp[1]);
            }
        }

        private void listView_ToBeSelected_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewItem item = listView_ToBeSelected.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    string strCode = item.SubItems[1].Text;
                    AddToList(strCode);
                }
            }
        }

        private void textBox_Code_Click(object sender, EventArgs e)
        {
            if (textBox_Code.Text == "输入股票简拼或代码")
            {
                textBox_Code.Text = "";
                textBox_Code.ForeColor = Color.Black;
            }
        }

        private void textBox_Code_Leave(object sender, EventArgs e)
        {
            if (textBox_Code.Text == "")
            {
                textBox_Code.Text = "输入股票简拼或代码";
                textBox_Code.ForeColor = Color.Gray;
            }
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            AboutMe ab = new AboutMe();
            ab.ShowDialog();
        }
    }
}
