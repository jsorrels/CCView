using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace CCSee


{
    class DatGridViewController 
    {
        Object oThreadLock = new Object();
        string sDBConnectionString = "";    // init our connection string
        string sConnectionUser = "";        // init our connection string
        string sFullConnectionString = "";
        string sFullOdenConnectionString = "";
        Queue<DataGridViewRow> qRowQ = new Queue<DataGridViewRow>();
        const int MAX_LB_SIZE = 1500;
        bool _bRun = true;                  // True to keep our thread running. 
        private eReferenceType myName ;
        private Form1 _parent = null;
        BindingSource bindingsource = new BindingSource();
        private System.Windows.Forms.ComboBox cbReferenceNumberType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.TextBox tbRefValue;
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.ListBox lbOutput;
        private System.Windows.Forms.TabControl tabControl1;
       // private System.Windows.Forms.TabPage tabPage1;
     //   private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;


        public eReferenceType MyName
        {
            get
            {
                return myName;
            }

            set
            {
                myName = value;
            }
        }
        public ComboBox CbReferenceNumberType
        {
            get
            {
                return cbReferenceNumberType;
            }

            set
            {
                cbReferenceNumberType = value;
            }
        }

        public Label Label1
        {
            get
            {
                return label1;
            }

            set
            {
                label1 = value;
            }
        }

        public Button BtFind
        {
            get
            {
                return btFind;
            }

            set
            {
                btFind = value;
            }
        }

        public TextBox TbRefValue
        {
            get
            {
                return tbRefValue;
            }

            set
            {
                tbRefValue = value;
            }
        }

        public DataGridView DgvOut
        {
            get
            {
                return dgvOut;
            }

            set
            {
                dgvOut = value;
            }
        }

        public ListBox LbOutput
        {
            get
            {
                return lbOutput;
            }

            set
            {
                lbOutput = value;
            }
        }

        public TabControl TabControl1
        {
            get
            {
                return tabControl1;
            }

            set
            {
                tabControl1 = value;
            }
        }

        

        public DataGridView DataGridView1
        {
            get
            {
                return dataGridView1;
            }

            set
            {
                dataGridView1 = value;
            }
        }

        public Form1 Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value;
            }
        }

        public DatGridViewController(Form1 parent)
        {

            Parent = _parent;
          //  Init();

        }

        public void Init()
        {
            //  Lee's sample string - sConnectionString = String.Concat("Data Source=GREYJOY\\GREYJOY_SQL;INITIAL CATALOG=CC_HUB4;", "User Id=U4_ServicePortal;Password=Access#2016; Trusted_Connection=False;");

            sDBConnectionString = CCSee.Properties.Settings.Default.ConnectionString;                               // get our connection string value from our XML settings file
            sConnectionUser = CCSee.Properties.Settings.Default.ConnectionUser;                                     // get our user creds
            sFullConnectionString = sDBConnectionString + sConnectionUser + "Trusted_Connection=False;";                    // Append connection type
            sFullConnectionString = Regex.Unescape(sFullConnectionString);

            sFullOdenConnectionString = CCSee.Properties.Settings.Default.ConnectionStringLogTek;
            sFullOdenConnectionString += CCSee.Properties.Settings.Default.ConnectionUserLogTek + "Trusted_Connection=False;";
            sFullOdenConnectionString = Regex.Unescape(sFullOdenConnectionString);// unescape
            foreach (string s in Enum.GetNames(typeof(eReferenceType)))
            {
                CbReferenceNumberType.Items.Add(s);
                CbReferenceNumberType.SelectedIndex = 0;
            }
            dgvOut.DataSource = bindingsource;
            dgvOut.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen;
            //CCUSAA00007487
        }


        public void btFind_Click(object sender, EventArgs e, UENSerchParams sp)
        {
            ClearGrid();
            Thread tdRunFillGrid = null;                                 // do this oina  thread so we dont lockup the UI

            SqlConnection sqlConnection = new SqlConnection(sFullConnectionString);
            SqlCommand cmd = new SqlCommand();
          
            string sType = CbReferenceNumberType.SelectedItem.ToString();
           string sValue = sp.SRef;
  
            if ((sType == null || sType.Equals(""))
                || (sType == null || sType.Equals("")))
                return;




            eReferenceType eR = (eReferenceType)Enum.Parse(typeof(eReferenceType), sType);

            switch (eR)
            {
                case eReferenceType.UEN_AssetEventHistory:
                case eReferenceType.UEN_AssetBillingHistory:
                case eReferenceType.UEN_AssetStateHistory:

                    UserOut("Find By UEN");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindLastLeasor));                                        // do this oina  thread so we dont lockup the UI
                  //  Object oRunObj = new object();
                    tdRunFillGrid.Start(sp);
                    break;
                case eReferenceType.OrderNumber:

                    UserOut("Find By Order");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByOrder));                                        // do this oina  thread so we dont lockup the UI
                    tdRunFillGrid.Start(sValue);
                    break;
                case eReferenceType.InternalReference:

                    UserOut("Find By InternlRef");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByInternalRef));                                        // do this oina  thread so we dont lockup the UI
                    tdRunFillGrid.Start(sValue);
                    break;
                case eReferenceType.Account:

                    UserOut("Find By Account");
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByAccount));                                        // do this oina  thread so we dont lockup the UI
                    tdRunFillGrid.Start(sValue);
                    break;

            }
           
        }
        public void FindByInternalRef(object o)
        {
            string sInternalRef = (string)o;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
          //  BindingSource bindingSource = new BindingSource();
            List<DataGridViewRow> ldr = new List<DataGridViewRow>();
            List<DataGridViewColumn> ldc = new List<DataGridViewColumn>();
          
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
                    ClearGrid();
                    reader = cmd.ExecuteReader();
                    AddReaderRows(reader);
                    reader = cmd.ExecuteReader();
                    
                    {
                    /*
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
                                //    UserOut("Adding row: " + reader[i].ToString());

                                }
                              //  UserOut("Adding row: ");
                                ldr.Add(dgvr);

                                // AddRow(dgvr);
                                //   var columns = new List<string>();

                            }


                            AddDGVRows(ldr);
                        }

                        */
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
        public void FindByAccount(object o)
        {
            string sAccount = (string)o;



            SqlDataAdapter dataAdapter = new SqlDataAdapter();
     

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

              
 
                    SELECT *
                    FROM
                      
                         CC_HUB4.dbo.ufn_GetPreviousReferenceRecognized(GETDATE(),DateAdd(d, 1, GETDATE()),'N') U4
                     WHERE
                              U4.BillingID  =  '"
                     + sAccount
                     + @" ' ORDER BY BillingID, Usage, LegacyAccount ";                   
                      

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    ClearGrid();
                    reader = cmd.ExecuteReader();
                    AddReaderRows(reader);
                   // ClearGrid();
                    /*

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
                        UserOut("building rows.....\n\n");
                        DataGridViewRow dgvr = null;
                        while (reader.Read())
                        {
                            dgvr = new DataGridViewRow();
                            //   StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                //    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                                //     sb.Append(" " + reader[i].ToString());
                                dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                                //     UserOut("Adding row: " + reader[i].ToString());



                            }

                            ldr.Add(dgvr);

                            // AddRow(dgvr);
                            System.Threading.Thread.Sleep(10);
                            //   var columns = new List<string>();

                        }
                        AddDGVRows(ldr);

                        UserOut("Done building rows");

                    }
                    */
                    //AddDGVRows(ldr);
                    sqlConnection.Close();

                }

                catch (Exception ex)
                {
                    UserOut("TagID: " + sAccount + " Exception retrieving data :" + ex.Message);
                    // return null;
                }


            }


        }
        public void FindByOrder(object o)
        {

            string sInternalRef = (string)o;



            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            //BindingSource bindingSource = new BindingSource();

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
                  
                    ClearGrid();
                    reader = cmd.ExecuteReader();
                    AddReaderRows(reader);

                    /*

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
                        UserOut("building rows.....\n\n");
                        DataGridViewRow dgvr = null;
                        while (reader.Read())
                        {
                            dgvr = new DataGridViewRow();
                         //   StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                //    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                                //     sb.Append(" " + reader[i].ToString());
                                dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = reader[i] });
                           //     UserOut("Adding row: " + reader[i].ToString());



                            }
                           
                            ldr.Add(dgvr);

                            // AddRow(dgvr);
                            System.Threading.Thread.Sleep(10);
                            //   var columns = new List<string>();

                        }
                        AddDGVRows(ldr);

                        UserOut("Done building rows");

                    }
                    */
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
        public void FindLastLeasor(object o)
        {
            UENSerchParams sp = (UENSerchParams)o;
           
       
            string sTag = sp.SRef;
            //  CCLastObj oRet = new CCLastObj();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            
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

                    switch (sp.ETypeOfSearch)
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
                            UserOut("Billing History");
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
                            UserOut("Event History");
                            break;

                    

                     case eReferenceType.UEN_AssetStateHistory:
                            cmd.CommandText = @"

                                          SELECT
                              [AssetID]
                              ,[EventDateTime]
                              ,[Version]
                              ,[EventSequence]
                              ,[LocationID]
                              ,[BillingID]
                              ,[Usage]
                              ,[ActionType]
                              ,[ActionReference]
                        FROM AssetStateHistory
                        WHERE
                                 AssetID = '"
                                   + sTag
                                   + @" '
                        ORDER BY
                              AssetID, EventDateTime, EventSequence";
                            UserOut("State History");
                            break;

                }
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    reader = cmd.ExecuteReader();
                    AddReaderRows(reader);
                   
                    /*
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
                       


                    } */

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
        public void AddCol(DataGridViewColumn c)
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()
                {
                    DgvOut.Columns.Add(c);

                });
            }
            else
                DgvOut.Columns.Add(c);

        }
        public void AddRow(DataGridViewRow r)
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()

                {
                    DgvOut.Rows.Add(r);

                });
            }
            else
                DgvOut.Rows.Add(r);



        }
        public void AddReaderRows(SqlDataReader r)
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()
                {

                    bindingsource.DataSource = r ;
                    DgvOut.Refresh();
                });
            }
        }

        public void AddDGVRows(List<DataGridViewRow> dgvr)
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()
                {

                    foreach (DataGridViewRow r in dgvr)
                    {
                        DgvOut.Rows.Add(r);
                        if ((dgvr.IndexOf(r)) %2 == 0)
                        {
                            r.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                    }

                });
            }
            else
                foreach (DataGridViewRow r in dgvr)
                {
                    DgvOut.Rows.Add(r);
                }


        }
        public void AddDGVCols(List<DataGridViewColumn> dgvc)
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()
                {

                    foreach (DataGridViewColumn r in dgvc)
                    {
                        DgvOut.Columns.Add(r);
                    }

                });
            }
            else
                foreach (DataGridViewColumn c in dgvc)
                {
                    DgvOut.Columns.Add(c);

                }


        }
        public void ClearGrid()
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()
                {
                    DgvOut.Rows.Clear();
                    DgvOut.Columns.Clear();

                });
            }
            else
            {
                DgvOut.Rows.Clear();
                DgvOut.Columns.Clear();
            }


        }
        public void UserOut(string s)
        {
            Console.WriteLine(s);

            if (DgvOut.InvokeRequired)
                DgvOut.Invoke(new MethodInvoker(delegate () { UserOut(s); }));                                            // if we are on a different thread
            else

            {

                LbOutput.Items.Insert(0, s);
                if (LbOutput.Items.Count > MAX_LB_SIZE)
                {
                    LbOutput.Items.RemoveAt(LbOutput.Items.Count - 1);                                                  // lets not explode
                }
            }

        }

        public void dgvOut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public bool IsOrder(string s)
        {
            if (s.Any(x => !char.IsLetter(x)))
                return true;
            return false;
        }


        public void dgvOut_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                        CbReferenceNumberType.Text = eReferenceType.OrderNumber.ToString();
                        TbRefValue.Text = s;
                    }
                    else
                    {
                        UserOut("Find By Ref: " + s);
                        tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindByInternalRef));                                        // do this oina  thread so we dont lockup the UI
                                                                                                                                            //      tdRunFillGrid.Start(s);
                                                                                                                                            //  FindByInternalRef(s);
                        CbReferenceNumberType.Text = eReferenceType.InternalReference.ToString();
                        TbRefValue.Text = s;

                    }

                    break;
                case ("AssetID"):
                case ("assetID"):
                case ("assetid"):
                    UserOut("Find By UEN: " + s);
                    tdRunFillGrid = new Thread(new ParameterizedThreadStart(FindLastLeasor));                                        // do this oina  thread so we dont lockup the UI

                    // FindLastLeasor(s, eReferenceType.UEN_AssetEventHistory);
                    CbReferenceNumberType.Text = eReferenceType.UEN_AssetEventHistory.ToString();
                    TbRefValue.Text = s;
                    
                    break;
                case ("BillingResponsibility"):
                    break;

                default:
                    break;

            }
            tdRunFillGrid.Start(s);
        }

        public void dgvOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { // here

        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
