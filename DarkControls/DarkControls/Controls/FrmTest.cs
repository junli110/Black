using Lordeo.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public partial class FrmTest : BForm
    {
        private DataGridViewTextBoxColumn RowNum = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Symbol = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Name1 = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Close = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn HighLow = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Mixed = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn PreClose = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Open = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn High = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Low = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn TurnoverRate = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Volume = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn TradedMoney = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Circulation = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn CirculationValue = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Total = new DataGridViewTextBoxColumn();

        private DataGridViewTextBoxColumn MarketValue = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn Empty = new DataGridViewTextBoxColumn();
       
        public FrmTest()
            : base()
        {
            InitializeComponent();
            
            //bGridView1.ParentChanged();
            // 
            // RowNum
            // 
            this.RowNum.DataPropertyName = "RowNum";
            this.RowNum.HeaderText = "序号";
            this.RowNum.Name = "RowNum";
            this.RowNum.ReadOnly = true;
            this.RowNum.Width = 40;
            this.RowNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowNum.Frozen = true;
            this.RowNum.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "代码";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.Symbol.Width = 90;
            this.Symbol.Frozen = true;
            this.Symbol.DefaultCellStyle.ForeColor = Color.FromArgb(180, 174, 81);
            // 
            // Name
            // 
            this.Name1.DataPropertyName = "Name";
            this.Name1.HeaderText = "藏品名称";
            this.Name1.Name = "Name";
            this.Name1.ReadOnly = true;
            this.Name1.Width = 120;
            this.Name1.Frozen = true;
            this.Name1.DefaultCellStyle.ForeColor = Color.FromArgb(180, 174, 81);
            // 
            // Close
            // 
            this.Close.DataPropertyName = "Close";
            this.Close.HeaderText = "最新价";
            this.Close.Name = "Close";
            this.Close.ReadOnly = true;
            this.Close.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Close.Width = 80;
            this.Close.DefaultCellStyle.Format = "f2";
            this.Close.Frozen = true;
            this.Close.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // HighLow
            // 
            this.HighLow.DataPropertyName = "HighLow";
            this.HighLow.HeaderText = "涨跌幅";
            this.HighLow.Name = "HighLow";
            this.HighLow.ReadOnly = true;
            this.HighLow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.HighLow.Width = 80;
            this.HighLow.Frozen = true;
            this.HighLow.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            this.HighLow.DefaultCellStyle.Format = "P";

            // 
            // Mixed
            // 
            this.Mixed.DataPropertyName = "Mixed";
            this.Mixed.HeaderText = "涨跌";
            this.Mixed.Name = "Mixed";
            this.Mixed.ReadOnly = true;
            this.Mixed.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Mixed.Width = 80;
            this.Mixed.DefaultCellStyle.Format = "f2";
            this.Mixed.Frozen = true;
            this.Mixed.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // PreClose
            // 
            this.PreClose.DataPropertyName = "PreClose";
            this.PreClose.HeaderText = "昨收";
            this.PreClose.Name = "PreClose";
            this.PreClose.ReadOnly = true;
            this.PreClose.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.PreClose.Width = 80;
            this.PreClose.DefaultCellStyle.Format = "f2";
            this.PreClose.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // Open
            // 
            this.Open.DataPropertyName = "Open";
            this.Open.HeaderText = "开盘价";
            this.Open.Name = "Open";
            this.Open.ReadOnly = true;
            this.Open.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Open.Width = 80;
            this.Open.DefaultCellStyle.Format = "f2";
            this.Open.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // High
            // 
            this.High.DataPropertyName = "High";
            this.High.HeaderText = "最高价";
            this.High.Name = "High";
            this.High.ReadOnly = true;
            this.High.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.High.Width = 80;
            this.High.DefaultCellStyle.Format = "f2";
            this.High.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // Low
            // 
            this.Low.DataPropertyName = "Low";
            this.Low.HeaderText = "最低价";
            this.Low.Name = "Low";
            this.Low.ReadOnly = true;
            this.Low.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Low.Width = 80;
            this.Low.DefaultCellStyle.Format = "f2";
            this.Low.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            // 
            // TurnoverRate
            // 
            this.TurnoverRate.DataPropertyName = "TurnoverRate";
            this.TurnoverRate.HeaderText = "换手率";
            this.TurnoverRate.Name = "TurnoverRate";
            this.TurnoverRate.ReadOnly = true;
            this.TurnoverRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.TurnoverRate.Width = 80;
            this.TurnoverRate.DefaultCellStyle.ForeColor = Color.FromArgb(205, 205, 205);
            this.TurnoverRate.DefaultCellStyle.Format = "P";
            // 
            // Volume
            // 
            this.Volume.DataPropertyName = "Volume";
            this.Volume.HeaderText = "成交量";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            this.Volume.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Volume.Width = 100;
            this.Volume.DefaultCellStyle.Format = "f0";
            this.Volume.DefaultCellStyle.ForeColor = Color.FromArgb(73, 134, 183);
            // 
            // TradedMoney
            // 
            this.TradedMoney.DataPropertyName = "TradedMoney";
            this.TradedMoney.HeaderText = "交易额(万)";
            this.TradedMoney.Name = "TradedMoney";
            this.TradedMoney.ReadOnly = true;
            this.TradedMoney.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.TradedMoney.Width = 120;
            this.TradedMoney.DefaultCellStyle.Format = "N2";
            this.TradedMoney.DefaultCellStyle.ForeColor = Color.FromArgb(73, 134, 183);

            this.Circulation.DataPropertyName = "Circulation";
            this.Circulation.HeaderText = "流通量";
            this.Circulation.Name = "Circulation";
            this.Circulation.ReadOnly = true;
            this.Circulation.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Circulation.Width = 100;
            this.Circulation.DefaultCellStyle.Format = "N0";
            this.Circulation.DefaultCellStyle.ForeColor = Color.FromArgb(73, 134, 183);

            this.CirculationValue.DataPropertyName = "CirculationValue";
            this.CirculationValue.HeaderText = "流通额(万)";
            this.CirculationValue.Name = "CirculationValue";
            this.CirculationValue.ReadOnly = true;
            this.CirculationValue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.CirculationValue.Width = 100;
            this.CirculationValue.DefaultCellStyle.Format = "N2";
            this.CirculationValue.DefaultCellStyle.ForeColor = Color.FromArgb(73, 134, 183);
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "总量";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Total.Width = 90;
            this.Total.DefaultCellStyle.Format = "N0";
            this.Total.DefaultCellStyle.ForeColor = Color.FromArgb(73, 134, 183);
            
            // 
            // MarketValue
            // 
            this.MarketValue.DataPropertyName = "MarketValue";
            this.MarketValue.HeaderText = "市值(万)";
            this.MarketValue.Name = "MarketValue";
            this.MarketValue.ReadOnly = true;
            this.MarketValue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.MarketValue.Width = 120;
            this.MarketValue.DefaultCellStyle.Format = "N2";
            this.MarketValue.DefaultCellStyle.ForeColor = Color.FromArgb(73, 134, 183);
            Empty.Width = 20;

            System.Drawing.Size mSize = SystemInformation.WorkingArea.Size;

            int j = mSize.Width;

            if (j > 1600)
            {
                int width = (j - 1600) / 15;

                bGridView1.Columns["RowNum"].Width += width;
                bGridView1.Columns["Symbol"].Width += width;
                bGridView1.Columns["Name"].Width += width;
                bGridView1.Columns["Close"].Width += width;
                bGridView1.Columns["HighLow"].Width += width;
                bGridView1.Columns["Mixed"].Width += width;

                bGridView1.Columns["PreClose"].Width += width;
                bGridView1.Columns["Open"].Width += width;
                bGridView1.Columns["High"].Width += width;
                bGridView1.Columns["Low"].Width += width;
                bGridView1.Columns["TurnoverRate"].Width += width;
                bGridView1.Columns["Volume"].Width += width;
                bGridView1.Columns["TradedMoney"].Width += width;
                bGridView1.Columns["Total"].Width += width;
                bGridView1.Columns["MarketValue"].Width += width;
            }
            Total.MinimumWidth = 88;
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            
            bGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNum,
            this.Symbol,
            this.Name1,
            this.Close,
            this.HighLow,
            this.Mixed,
            this.PreClose,
            this.Open,
            this.High,
            this.Low,
            this.TurnoverRate,
            this.Volume,
            this.TradedMoney,
            Circulation,
            CirculationValue,
            this.Total,
            this.MarketValue});

            var dt = new DataTable();
            
            
             bGridView1.DataSource = null;// new BindingCollection<Entity.EntityCollection>(dt);
            


        }
        public delegate void OneStrParam(string a);
        public void RefeshList(string symbol)
        {
            if (bGridView1.InvokeRequired)
            {
                bGridView1.Invoke(new OneStrParam(RefeshList), symbol);
            }
            foreach (DataGridViewRow r in bGridView1.Rows)
            {
                if (r.Cells["Symbol"].Value.ToString() == symbol)
                {
                    bGridView1.InvalidateRow(r.Index);
                }
            }

        }
        private string[] selfComparePreClose = { "High", "Low", "Close", "Open" };
        private string[] closeComparePreClose = { "HighLow", "Mixed" };

        private string[] convertTenThsend = { "MarketValue", "CirculationValue", "TradedMoney" };
        private void bGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var name = bGridView1.Columns[e.ColumnIndex].Name;
            if (selfComparePreClose.Contains(name))
            {
                var preClose = Convert.ToDouble(bGridView1.Rows[e.RowIndex].Cells["PreClose"].Value.ToString());
                if (preClose > Convert.ToDouble(e.Value))
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (preClose < Convert.ToDouble(e.Value))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            else if (closeComparePreClose.Contains(name))
            {
                var preClose = Convert.ToDouble(bGridView1.Rows[e.RowIndex].Cells["PreClose"].Value.ToString());
                var Close = Convert.ToDouble(bGridView1.Rows[e.RowIndex].Cells["Close"].Value.ToString());
                if (preClose > Close)
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (preClose < Close)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }


            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

        private void bGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in ((DataGridView)sender).Columns)
            {
                //column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

        }
        
       
      
    }
}
