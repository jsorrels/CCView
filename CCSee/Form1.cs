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
        InternalReference

    }


    public partial class Form1 : Form
    {
        Object oThreadLock = new Object();
      /*  string sDBConnectionString = "";    // init our connection string
        string sConnectionUser = "";        // init our connection string
        string sFullConnectionString = "";
        string sFullOdenConnectionString = "";*/
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
                lViewControllers.Add(new DatGridViewController());

            }
            //  DatGridViewController dgvc = new DatGridViewController();
            // set up tab 1
            

            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).CbReferenceNumberType = comboTab1;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).TbRefValue = textBoxTab1;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).BtFind = buttonTab1;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).DgvOut = dgvOut;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).MyName = eReferenceType.UEN_AssetEventHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).Init();
            comboTab1.Enabled = false;
            comboTab1.SelectedIndex = (int)eReferenceType.UEN_AssetEventHistory;

        //    lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).MyName = eReferenceType.OrderNumber;
      //      lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).Init();
       //     comboTab1.Enabled = false;
       //     comboTab1.SelectedIndex = (int)eReferenceType.OrderNumber;

            // set up tab 2
           
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).CbReferenceNumberType = comboBoxTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).TbRefValue = textBoxTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).BtFind = buttonTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).DgvOut = dataGridViewTab2;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).MyName = eReferenceType.UEN_AssetBillingHistory;
            lViewControllers.ElementAt((int)eReferenceType.UEN_AssetBillingHistory).Init();
            comboBoxTab2.Enabled = false;
            comboBoxTab2.SelectedIndex = (int)eReferenceType.UEN_AssetBillingHistory;

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


            // set up tab 4
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).CbReferenceNumberType = comboBoxTab4;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).TbRefValue = textBoxTab4;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).BtFind = buttonTab4;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).DgvOut = dataGridViewTab4;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).MyName = eReferenceType.OrderNumber;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).Init();
            comboBoxTab4.Enabled = false;
            comboBoxTab4.SelectedIndex = (int)eReferenceType.OrderNumber;
            lViewControllers.ElementAt((int)eReferenceType.OrderNumber).TbRefValue.Text = "C1618743676C";

           // lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).MyName = eReferenceType.UEN_AssetEventHistory;
           // lViewControllers.ElementAt((int)eReferenceType.UEN_AssetEventHistory).Init();
           // comboTab1.Enabled = false;
//comboTab1.SelectedIndex = (int)eReferenceType.UEN_AssetEventHistory;


            // set up tab 5
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).CbReferenceNumberType = comboBoxTab5;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).TbRefValue = textBoxTab5;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).BtFind = buttonTab5;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).DgvOut = dataGridViewTab5;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).LbOutput = lbOutput;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).MyName = eReferenceType.InternalReference;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).Init();
            comboBoxTab5.Enabled = false;
            comboBoxTab5.SelectedIndex = (int)eReferenceType.InternalReference;
            lViewControllers.ElementAt((int)eReferenceType.InternalReference).TbRefValue.Text = "2779052";





        }
        private void btFind_Click(object sender, EventArgs e)
        {
           // dgvc.btFind_Click(sender, e);
        }
        /*
        private void Init()
        {
            //  Lee's sample string - sConnectionString = String.Concat("Data Source=GREYJOY\\GREYJOY_SQL;INITIAL CATALOG=CC_HUB4;", "User Id=U4_ServicePortal;Password=Access#2016; Trusted_Connection=False;");

            sDBConnectionString = CCSee.Properties.Settings.Default.ConnectionString;                               // get our connection string value from our XML settings file
            sConnectionUser = CCSee.Properties.Settings.Default.ConnectionUser;                                     // get our user creds
            sFullConnectionString = sDBConnectionString + sConnectionUser + "Trusted_Connection=False;";                    // Append connection type
            sFullConnectionString = Regex.Unescape(sFullConnectionString);

            sFullOdenConnectionString = CCSee.Properties.Settings.Default.ConnectionStringLogTek;
            sFullOdenConnectionString += CCSee.Properties.Settings.Default.ConnectionUserLogTek + "Trusted_Connection=False;";
            sFullOdenConnectionString =  Regex.Unescape(sFullOdenConnectionString);// unescape
            //CCUSAA00007487
        }
        */
        /*
        private void btFind_Click(object sender, EventArgs e)
        {
            this.dgvOut.Rows.Clear();
            Thread tdRunFillGrid = null;                                 // do this oina  thread so we dont lockup the UI
           
            SqlConnection sqlConnection = new SqlConnection(sFullConnectionString);
            SqlCommand cmd = new SqlCommand();
        //    SqlDataReader reader;
            string sType = cbReferenceNumberType.SelectedItem.ToString();
            string sValue = tbRefValue.Text;

            if ((sType == null || sType.Equals(""))
                || (sType == null || sType.Equals("")))
                return;




            eReferenceType eR = (eReferenceType)Enum.Parse(typeof(eReferenceType), sType);

            switch (eR)
            {
                case eReferenceType.UEN_AssetEventHistory:
                case eReferenceType.UEN_AssetBillingHistory:
                  ;
                    UserOut("Find By UEN");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindLastLeasor));                                        // do this oina  thread so we dont lockup the UI
                    Object oRunObj = new object();
            
                    break;
                case eReferenceType.OrderNumber:
               
                    UserOut("Find By Ref");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByOrder));                                        // do this oina  thread so we dont lockup the UI
         
                    break;
                case eReferenceType.InternalReference:
                  
                    UserOut("Find By Order");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(dgvc.FindByInternalRef));                                        // do this oina  thread so we dont lockup the UI
                 
                    break;

            }
            tdRunFillGrid.Start(sValue);
        } */
        /*
        private void FindByInternalRef(object o)
        {
            string sInternalRef = (string)o;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            BindingSource bindingSource = new BindingSource();
            List<DataGridViewRow> ldr = new List<DataGridViewRow>();
            List<DataGridViewColumn> ldc = new List<DataGridViewColumn>();
            //DataGridViewColumn
            //   SqlDataAdapter dataAdapter = null;
            lock (oThreadLock)
            {
                ClearGrid();

                try
                {
                    SqlConnection sqlConnection = new SqlConnection(sFullOdenConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;



                    string sDate = DateTime.Now.Date.ToString("M/d/yyyy");

                    cmd.CommandText = @"select
	                dtl.assetbillingid,
	                dtl.assetid,
	                hdr.transactiondate,
	                hdr.transactionsetid,
	                hdr.internalreference,
	                hdr.sourcelocation,
	                hdr.destinationlocation,
	                hdr.actiontype,
	                hdr.created
	                --ash.*
                from
	                dbadmin.dbo.logtekauto_header hdr 
	                join dbadmin.dbo.logtekauto_detail dtl
		                on dtl.transactionsetid = hdr.transactionsetid and dtl.equipmentid = hdr.equipmentid
		        
                where

	                hdr.internalreference = '"
                                     + sInternalRef
                                     + @" 'and dtl.equipmentid = 150  ";



                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    reader = cmd.ExecuteReader();

                    {

                        // build the columns
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            //columns.Add(reader.GetName(i));
                            DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid
                            DataGridViewCell cell = new DataGridViewTextBoxCell();//Specify which type of cell in this column
                            newCol.CellTemplate = cell;

                            newCol.HeaderText = reader.GetName(i);
                            newCol.Name = reader.GetName(i);
                            newCol.Visible = true;
                            //   newCol.Width = 40;

                            ldc.Add(newCol);
                            // AddCol(newCol);

                        }
                        AddDGVCols(ldc);
                        // execute the reader
                        if (reader.FieldCount > 0)
                        {
                            DataGridViewRow dgvr = null;
                            while (reader.Read())
                            {
                                dgvr = new DataGridViewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                   
                                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                               

                                }
                                UserOut("Adding row: " );
                                ldr.Add(dgvr);

                                // AddRow(dgvr);
                                //   var columns = new List<string>();

                            }


                            AddDGVRows(ldr);
                        }


                        sqlConnection.Close();

                    }

                }

                catch (Exception ex)
                {
                    //
                    UserOut("TagID: " + sInternalRef + " Exception retrieving data :" + ex.Message);
                    // return null;
                }


            }

        }
        private void FindByOrder(object o)
        {

            string sInternalRef = (string)o;


            
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            BindingSource bindingSource = new BindingSource();
           
            List<DataGridViewRow> ldr = new List<DataGridViewRow>();
            List<DataGridViewColumn> ldc = new List<DataGridViewColumn>();

            lock (oThreadLock)
            {

                try
                {
                    SqlConnection sqlConnection = new SqlConnection(sFullConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader = null;



                    string sDate = DateTime.Now.Date.ToString("M/d/yyyy");


                    cmd.CommandText = @"

                SELECT
                      AssetID,
                      EventDateTime,
                      Version,
                      EventSequence,
                      BillingSequence,
                      PriorLocation,
                      Location,
                      PriorBillingResponsibility
                      BillingResponsibility,
                      PriorBillingUsage,
                      BillingUsage,
                      ActionType,
                      ActionReference
                FROM AssetBillingHistory
                WHERE
                      ActionReference = '"
                     + sInternalRef
                     + @"' ORDER BY AssetID, EventDateTime, EventSequence, BillingSequence";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    reader = cmd.ExecuteReader();

                    ClearGrid();


                    // build the columns
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //columns.Add(reader.GetName(i));
                        DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid
                        DataGridViewCell cell = new DataGridViewTextBoxCell();//Specify which type of cell in this column
                        newCol.CellTemplate = cell;

                        newCol.HeaderText = reader.GetName(i);
                        newCol.Name = reader.GetName(i);
                        newCol.Visible = true;
                        //   newCol.Width = 40;

                        ldc.Add(newCol);
                        // AddCol(newCol);

                    }
                    AddDGVCols(ldc);

                    UserOut("Done building columns");
                    // execute the reader
                    if (reader.FieldCount > 0)
                    {
                        DataGridViewRow dgvr = null;
                        while (reader.Read())
                        {
                            dgvr = new DataGridViewRow();
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                //    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                                //     sb.Append(" " + reader[i].ToString());
                                dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });



                            }
                            UserOut("Adding row: " + sb.ToString());
                            ldr.Add(dgvr);

                           // AddRow(dgvr);
                            System.Threading.Thread.Sleep(10);
                            //   var columns = new List<string>();

                        }
                        AddDGVRows(ldr);

                        UserOut("Done building rows");

                    }

                    //AddDGVRows(ldr);
                    sqlConnection.Close();

                }

                catch (Exception ex)
                {
                    UserOut("TagID: " + sInternalRef + " Exception retrieving data :" + ex.Message);
                    // return null;
                }


            }

        }
        private void FindLastLeasor(object o)
        {
            FindLastLeasor(o, eReferenceType.UEN_AssetEventHistory);
        }

        private void FindLastLeasor(object o, eReferenceType er)
        {
            string sTag = (string)o;
            //  CCLastObj oRet = new CCLastObj();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            BindingSource bindingSource = new BindingSource();
            //   SqlDataAdapter dataAdapter = null;
            ClearGrid();
            List<DataGridViewRow> ldr = new List<DataGridViewRow>();
            List<DataGridViewColumn> ldc = new List<DataGridViewColumn>();
            lock (oThreadLock)
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(sFullConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;



                    string sDate = DateTime.Now.Date.ToString("M/d/yyyy");

                    switch (er)
                    {
                        case eReferenceType.UEN_AssetBillingHistory:

                            cmd.CommandText = @"   
                       
                               SELECT
                                     AssetID,
                                     EventDateTime,
                                     Version,
                                     EventSequence,
                                     BillingSequence,
                                     PriorLocation,
                                     Location,
                                     PriorBillingResponsibility
                                     BillingResponsibility,
                                     PriorBillingUsage,
                                     BillingUsage,
                                     ActionType,
                                     ActionReference
                               FROM AssetBillingHistory
                               WHERE
                                     AssetID = '"
                                  + sTag
                                  + @"' ORDER BY AssetID, EventDateTime, EventSequence, BillingSequence";

                            break;

                        case eReferenceType.UEN_AssetEventHistory:
                            cmd.CommandText = @"

                    SELECT
                          EventHistoryID
                            ,[AssetID]
                            ,[InternalOrderNumber]
                            ,[CustomerReference]
                          ,[QueueID]
                          ,[QueueSequence]
                          ,[RecognizedDateTime]
                          ,[EventDateTime]
                          ,[EventType]
                          ,[ScanType]
                          ,[EventLocationID]
                          ,[OtherLocationID]
                     
                          ,[EventSuppressed]
                          ,[ProcessingResult]
                          ,[ProcessingError]
                          ,[Created]
                          ,[Version]
                    FROM AssetEventHistory
                     WHERE
                                 AssetID = '"
                                   + sTag
                                   + @" '
                    ORDER BY AssetID, EventDateTime";
                            break;

                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    reader = cmd.ExecuteReader();

                    // build the columns
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        //columns.Add(reader.GetName(i));
                        DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid
                        DataGridViewCell cell = new DataGridViewTextBoxCell();//Specify which type of cell in this column
                        newCol.CellTemplate = cell;

                        newCol.HeaderText = reader.GetName(i);
                        newCol.Name = reader.GetName(i);
                        newCol.Visible = true;
                        //   newCol.Width = 40;
                        ldc.Add(newCol);
                       // AddCol(newCol);

                    }
                    AddDGVCols(ldc);



                    // execute the reader
                    if (reader.FieldCount > 0)
                    {
                        DataGridViewRow dgvr = null;
                        while (reader.Read())
                        {
                            dgvr = new DataGridViewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                //columns.Add(reader.GetName(i));

                                //    DataGridViewCell cell = new DataGridViewTextBoxCell();//Specify which type of cell in this column
                                dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                                //   newCol.Width = 40;

                            }
                            ldr.Add(dgvr);
                            
                          //  AddRow(dgvr);
                            //   var columns = new List<string>();

                        }
                        AddDGVRows(ldr);



                    }

                    // AddDGVRows(ldr);
                    sqlConnection.Close();

                }

                catch (Exception ex)
                {
                    UserOut("TagID: " + sTag + " Exception retrieving data :" + ex.Message);
                    // return null;
                }

            }


        }
        private void AddCol(DataGridViewColumn c)
        {
            if (dgvOut.InvokeRequired)
            {
                dgvOut.Invoke((MethodInvoker)delegate ()
                {
                    dgvOut.Columns.Add(c);

                });
            }
            else
                dgvOut.Columns.Add(c);

        }
        private void AddRow(DataGridViewRow r)
        {
            if (dgvOut.InvokeRequired)
            {
                dgvOut.Invoke((MethodInvoker)delegate ()
             
                {
                    dgvOut.Rows.Add(r);

                });
            }
            else
                dgvOut.Rows.Add(r);



        }
        private void AddDGVRows(List <DataGridViewRow> dgvr)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    foreach (DataGridViewRow r in dgvr)
                    {
                        dgvOut.Rows.Add(r);
                    }

                });
            }
            else
                foreach (DataGridViewRow r in dgvr)
                {
                    dgvOut.Rows.Add(r);
                }


        }
        private void AddDGVCols(List<DataGridViewColumn> dgvc)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    foreach (DataGridViewColumn r in dgvc)
                    {
                        dgvOut.Columns.Add(r);
                    }

                });
            }
            else
                foreach (DataGridViewColumn c in dgvc)
                {
                    dgvOut.Columns.Add(c);
                }


        }
        private void ClearGrid()
        {
            if (dgvOut.InvokeRequired)
            {
                dgvOut.Invoke((MethodInvoker)delegate ()
                {
                    dgvOut.Rows.Clear();
                    dgvOut.Columns.Clear();

                });
            }
            else
            {
                dgvOut.Rows.Clear();
                dgvOut.Columns.Clear();
            }


        }
        private void UserOut(string s)
        {
            Console.WriteLine(s);

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate () { UserOut(s); }));                                            // if we are on a different thread
            else

            {

                lbOutput.Items.Insert(0, s);
                if (lbOutput.Items.Count > MAX_LB_SIZE)
                {
                    lbOutput.Items.RemoveAt(lbOutput.Items.Count - 1);                                                  // lets not explode
                }
            }

        }
        */
        private void dgvOut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
        /*
              private void dgvOut_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
              {
                  DataGridView dgv = (DataGridView)sender;
                  string s = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                  DataGridViewColumn newCol = dgv.Columns[e.ColumnIndex];
                  string sColName = newCol.Name;

                  Thread tdRunFillGrid = null;                                 // do this oina  thread so we dont lockup the UI

                  UserOut("Column clicked " + sColName);



                  //dgv.Rows.Clear();


                  switch (sColName)
                  {



                      case ("ActionReference"):
                      case ("InternalOrderNumber"):

                          if (IsOrder(s))
                          {
                               UserOut("Find By Order: " + s);
                               tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByOrder));                                        // do this oina  thread so we dont lockup the UI
                           //    tdRunFillGrid.Start(s);
                            //  FindByOrder(s);
                              cbReferenceNumberType.Text = eReferenceType.OrderNumber.ToString();
                              tbRefValue.Text = s;
                          }
                          else
                          {
                              UserOut("Find By Ref: " + s);
                               tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByInternalRef));                                        // do this oina  thread so we dont lockup the UI
                         //      tdRunFillGrid.Start(s);
                            //  FindByInternalRef(s);
                              cbReferenceNumberType.Text = eReferenceType.InternalReference.ToString();
                              tbRefValue.Text = s;

                          }

                          break;
                      case ("AssetID"):
                      case ("assetID"):
                      case ("assetid"):
                          UserOut("Find By UEN: " + s);
                          tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindLastLeasor));                                        // do this oina  thread so we dont lockup the UI

                         // FindLastLeasor(s, eReferenceType.UEN_AssetEventHistory);
                          cbReferenceNumberType.Text = eReferenceType.UEN_AssetEventHistory.ToString();
                          tbRefValue.Text = s;
                          break;
                      case ("BillingResponsibility"):
                          break;

                      default:
                          break;

                  }
                  tdRunFillGrid.Start(s);
              }
              */
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

                if (d.MyName == eReferenceType.UEN_AssetEventHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, d.MyName);
                    d.TbRefValue.Text= sp.SRef = sUEN;
                    d.btFind_Click(sender, e, sp);
                }
                if (d.MyName == eReferenceType.UEN_AssetBillingHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, d.MyName);
                    d.TbRefValue.Text=sp.SRef = sUEN;
                    d.btFind_Click(sender, e, sp);
                }
                if (d.MyName == eReferenceType.UEN_AssetStateHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, d.MyName);
                    d.TbRefValue.Text= sp.SRef = sUEN;
                    d.btFind_Click(sender, e, sp);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // billing history
           // string sUEN = null;
            foreach (DatGridViewController d in lViewControllers)
            {

                if (d.MyName == eReferenceType.UEN_AssetEventHistory)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetEventHistory);
                    sp.SRef = d.TbRefValue.Text;
                  //  sUEN = d.TbRefValue.Text;
                    //d.btFind_Click(sender, e, sp);
                    fillAllUENTabs(sender, e, d.TbRefValue.Text);
                }
            }
         //   fillAllUENTabs(sender, e,sUEN);
            // dgvc.btFind_Click(sender, e);
        }

        private void buttonTab5_Click(object sender, EventArgs e)
        {
            foreach(DatGridViewController d in  lViewControllers)
            {
                if (d.MyName == eReferenceType.InternalReference)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.InternalReference);
                    sp.SRef = d.TbRefValue.Text;
                    d.btFind_Click(sender, e, sp);
                   // d.btFind_Click(sender, e);
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
                    //d.btFind_Click(sender, e, sp);
                    fillAllUENTabs(sender, e, d.TbRefValue.Text);
                }
            }
        }

        private void buttonTab3_Click(object sender, EventArgs e)
        {
            foreach(DatGridViewController d in lViewControllers)
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
                // order
                if (d.MyName == eReferenceType.OrderNumber)
                {
                    UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.OrderNumber);
                    sp.SRef = d.TbRefValue.Text;
                    d.btFind_Click(sender, e, sp);
                    // d.btFind_Click(sender, e);
                }
            }

        }

        private void dataGridViewTab4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            anyDridClicked( sender,  e);
        }
        private void anyDridClicked(object sender, DataGridViewCellEventArgs e)
        { 
            // order grid

            DataGridView dgv = (DataGridView)sender;
            string s = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            DataGridViewColumn newCol = dgv.Columns[e.ColumnIndex];
            string sColName = newCol.Name;

            Thread tdRunFillGrid = null;                                 // do this oina  thread so we dont lockup the UI

          //  UserOut("Column clicked " + sColName);



            //dgv.Rows.Clear();


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

                    //    UserOut("Find By Order: " + s);
                      //  tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByOrder));                                        // do this oina  thread so we dont lockup the UI
                                                                                                                                      //    tdRunFillGrid.Start(s);
                                                                                                                                      //  FindByOrder(s);
                     //   cbReferenceNumberType.Text = eReferenceType.OrderNumber.ToString();
                      //  tbRefValue.Text = s;
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

                        if (d.MyName == eReferenceType.UEN_AssetBillingHistory)
                        {
                            UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetBillingHistory);
                            sp.SRef = s;
                            d.TbRefValue.Text = s;
                            d.btFind_Click(sender, e, sp);
                        }
                    }//    
                     //    UserOut("Find By UEN: " + s);
                    foreach (DatGridViewController d in lViewControllers)
                    {

                        if (d.MyName == eReferenceType.UEN_AssetEventHistory)
                        {
                            UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetEventHistory);
                            sp.SRef = s;
                            d.TbRefValue.Text = s;
                            d.btFind_Click(sender, e, sp);
                        }
                    }//    
                    foreach (DatGridViewController d in lViewControllers)
                    {

                        if (d.MyName == eReferenceType.UEN_AssetStateHistory)
                        {
                            UENSerchParams sp = new UENSerchParams(sender, e, eReferenceType.UEN_AssetStateHistory);
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
           // tdRunFillGrid.Start(s);
        }

        private void dataGridViewTab5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            anyDridClicked(sender, e);
        }

        private void dataGridViewTab2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            anyDridClicked(sender, e);
        }

        private void dataGridViewTab3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            anyDridClicked(sender, e);
        }
    }
}