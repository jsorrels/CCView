using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CCSee
{

    public enum eReferenceType
    {
        UEN_AssetEventHistory,
        UEN_AssetBillingHistory,
        UEN_AssetStateHistory,
        OrderNumber,
        InternalReference,
        Account

    }



    public partial class Form1 : Form
    {
        Object oThreadLock = new Object();

        Queue<DataGridViewRow> qRowQ = new Queue<DataGridViewRow>();
        const int MAX_LB_SIZE = 1500;
        bool _bRun = true;                  // True to keep our thread running. 
        List<DatGridViewController> lViewControllers = new List<DatGridViewController>();

      


        public Form1()
        {
            InitializeComponent();
            foreach (string s in Enum.GetNames(typeof(eReferenceType)))
            {
                cbReferenceNumberType.Items.Add(s);
                cbReferenceNumberType.SelectedIndex = 0;
              


            }

            foreach (eReferenceType val in Enum.GetValues(typeof(eReferenceType)))
            {
                lViewControllers.Add(new DatGridViewController(this));

            }
            // bind all the tabs

            lViewControllers.ElementAt((int)eReferenceType.InternalReference).CbReferenceNumberType = comboTab1;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).TbRefValue = textBoxTab1;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).BtFind = buttonTab1;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).DgvOut = dgvOut;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).MyName = eReferenceType.InternalReference;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).Init();

            comboTab1.Enabled = false;
            comboTab1.SelectedIndex = (int)eReferenceType.InternalReference;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).TbRefValue.Text = "2779052";
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).DgvOut.ClearSelection();
            //2779052
            // Set up tab 2

            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).CbReferenceNumberType = comboBoxTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).TbRefValue = textBoxTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).BtFind = button4;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).DgvOut = dataGridViewTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).MyName = eReferenceType.UEN_AssetBillingHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).Init();
            comboBoxTab2.Enabled = false;
            comboBoxTab2.SelectedIndex = (int)eReferenceType.UEN_AssetBillingHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).DgvOut.ClearSelection();

            // set up tab 3

            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).CbReferenceNumberType = comboBoxTab3;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).TbRefValue = textBoxTab3;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).BtFind = buttonTab3;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).DgvOut = dataGridViewTab3;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).MyName = eReferenceType.UEN_AssetStateHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).Init();
            comboBoxTab3.Enabled = false;
            comboBoxTab3.SelectedIndex = (int)eReferenceType.UEN_AssetStateHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetStateHistory).DgvOut.ClearSelection();




            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).CbReferenceNumberType = comboBoxTab4;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).TbRefValue = textBoxTab4;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).BtFind = buttonTab4;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).DgvOut = dataGridViewTab4;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).LbOutput = lbOutput;

            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).MyName = eReferenceType.UEN_AssetEventHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).Init();
            comboBoxTab4.Enabled = false;
            comboBoxTab4.SelectedIndex = (int)eReferenceType.UEN_AssetEventHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).DgvOut.ClearSelection();



            // set up tab 5
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).CbReferenceNumberType = comboBoxTab5;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).TbRefValue = textBoxTab5;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).BtFind = buttonTab5;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).DgvOut = dataGridViewTab5;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).MyName = eReferenceType.OrderNumber;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).Init();
            comboBoxTab5.Enabled = false;
            comboBoxTab5.SelectedIndex = (int)eReferenceType.OrderNumber;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).TbRefValue.Text = "C1618743676C";
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).DgvOut.ClearSelection();


            // set up tab 6
            lViewControllers.ElementAt((int)eReferenceType.Account).CbReferenceNumberType = comboBoxTab6;
            lViewControllers.ElementAt((int)eReferenceType.Account).TbRefValue = textBoxTab6;
            lViewControllers.ElementAt((int)eReferenceType.Account).BtFind = buttonTab6;
            lViewControllers.ElementAt((int)eReferenceType.Account).DgvOut = dataGridViewTab6;
            lViewControllers.ElementAt((int)eReferenceType.Account).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.Account).MyName = eReferenceType.Account;
            lViewControllers.ElementAt((int)eReferenceType.Account).Init();
            comboBoxTab6.Enabled = false;
            comboBoxTab6.SelectedIndex = (int)eReferenceType.Account;
            lViewControllers.ElementAt((int)eReferenceType.Account).TbRefValue.Text = "0158";
            lViewControllers.ElementAt((int)eReferenceType.Account).DgvOut.ClearSelection();


        }
        private void btFind_Click(object sender, EventArgs e)
        {
            // dgvc.btFind_Click(sender, e);
        }
        private bool IsOrder(string s)
        {
            if (s.Any(x => !char.IsLetter(x)))
                return true;
            return false;
        }
        private void dgvOut_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { // here
            anyDridClicked(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void fillAllUENTabs(object sender, EventArgs e, string sUEN)
        {
            foreach (DatGridViewController d in lViewControllers)
            {

                if ((d.MyName == eReferenceType.UEN_AssetEventHistory)
                    || (d.MyName == eReferenceType.UEN_AssetBillingHistory)
                    || (d.MyName == eReferenceType.UEN_AssetStateHistory))
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, d.MyName);
                    d.TbRefValue.Text = sp.SRef = sUEN;
                    d.btFind_Click(sender, e, sp);
                }
                
                
            }
         //   this.TabController.SelectTab("AssetBillingHistoryTab");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DatGridViewController d in lViewControllers)
            {
                if (d.MyName == eReferenceType.InternalReference)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.InternalReference);
                    sp.SRef = d.TbRefValue.Text;
                    d.btFind_Click(sender, e, sp);

                }
            }

        }

        private void buttonTab5_Click(object sender, EventArgs e)
        {

            foreach (DatGridViewController d in lViewControllers)
            {
                // order
                if (d.MyName == eReferenceType.OrderNumber)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.OrderNumber);
                    sp.SRef = d.TbRefValue.Text;
                    d.btFind_Click(sender, e, sp);

                }
            }
        }

        private void buttonTab2_Click(object sender, EventArgs e)
        {
            foreach (DatGridViewController d in lViewControllers)
            {
                if (d.MyName == eReferenceType.UEN_AssetBillingHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetBillingHistory);
                    sp.SRef = d.TbRefValue.Text;

                    fillAllUENTabs(sender, e, d.TbRefValue.Text);
                }
            }
        }

        private void buttonTab3_Click(object sender, EventArgs e)
        {
            foreach (DatGridViewController d in lViewControllers)
            {
                if (d.MyName == eReferenceType.UEN_AssetStateHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetStateHistory);
                    sp.SRef = d.TbRefValue.Text;
                    //d.btFind_Click(sender, e, sp);
                    fillAllUENTabs(sender, e, d.TbRefValue.Text);
                }
            }
        }

        private void buttonTab4_Click(object sender, EventArgs e)
        {

            foreach (DatGridViewController d in lViewControllers)
            {

                if (d.MyName == eReferenceType.UEN_AssetEventHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetEventHistory);
                    sp.SRef = d.TbRefValue.Text;

                    fillAllUENTabs(sender, e, d.TbRefValue.Text);
                }
            }
        }

        private void dataGridViewTab4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            anyDridClicked(sender, e);
        }
        private void anyDridClicked(object sender, DataGridViewCellEventArgs e)
        {
            // order grid

            DataGridView dgv = (DataGridView)sender;
            string s = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            DataGridViewColumn newCol = dgv.Columns[e.ColumnIndex];
            string sColName = newCol.Name;

            Thread tdRunFillGrid = null;                                 // do this oina  thread so we dont lockup the UI


            switch (sColName)
            {



                case ("ActionReference"):
                case ("InternalOrderNumber"):

                    if (IsOrder(s))
                    {
                        foreach (DatGridViewController d in lViewControllers)
                        {

                            if (d.MyName == eReferenceType.OrderNumber)
                            {
                                UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.OrderNumber);
                                sp.SRef = s;
                                d.TbRefValue.Text = s;
                                d.btFind_Click(sender, e, sp);
                            }
                        }//       

                        this.TabController.SelectTab("Orders");
                    }
                    else
                    {
                        foreach (DatGridViewController d in lViewControllers)
                        {

                            if (d.MyName == eReferenceType.InternalReference)
                            {
                                UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.InternalReference);
                                sp.SRef = s;
                                d.TbRefValue.Text = s;
                                d.btFind_Click(sender, e, sp);
                            }
                        }//    

                    }

                    break;
                case ("AssetID"):
                case ("assetID"):
                case ("assetid"):
                    foreach (DatGridViewController d in lViewControllers)
                    {

                        if ((d.MyName == eReferenceType.UEN_AssetBillingHistory)
                            || (d.MyName == eReferenceType.UEN_AssetEventHistory)
                            || (d.MyName == eReferenceType.UEN_AssetStateHistory))
                        {
                            UENSerchParams sp = new UENSerchParams(sender, e, d.MyName);
                            sp.SRef = s;
                            d.TbRefValue.Text = s;
                            d.btFind_Click(sender, e, sp);
                        }


                        this.TabController.SelectTab("AssetBillingHistoryTab");
                    }//    
                    break;
                
                case ("Account"):
                    foreach (DatGridViewController d in lViewControllers)
                    {

                        if (d.MyName == eReferenceType.Account)
                           
                        {
                            UENSerchParams sp = new UENSerchParams(sender, e, d.MyName);
                            sp.SRef = s;
                            d.TbRefValue.Text = s;
                            d.btFind_Click(sender, e, sp);
                        }



                    }//    
                 

                    break;
                case ("BillingResponsibility"):
                    break;

                default:
                    break;

            }

        }

      
        private void OrderTab_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Console.WriteLine("Row selection changed");
            }
        }

        private void dgvOut_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Row selection changed");
        }

        private void btSupress_Click(object sender, EventArgs e)
        {
            // send a messag to Lee here
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DatGridViewController d in lViewControllers)
            {
                if (d.MyName == eReferenceType.UEN_AssetBillingHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetBillingHistory);
                    sp.SRef = d.TbRefValue.Text;

                    fillAllUENTabs(sender, e, d.TbRefValue.Text);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DatGridViewController d in lViewControllers)
            {
                // order
                if (d.MyName == eReferenceType.Account)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.Account);
                    sp.SRef = d.TbRefValue.Text;
                    d.btFind_Click(sender, e, sp);

                }
            }
        }
    }
}