using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.Data;

namespace CCSee
  //  User Id=U4_ServicePortal;Password=Access#2016;

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

        public ListBox dgLbOutput
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
            dgvOut.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvOut.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvOut.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOut.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LightSalmon;
            dgvOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOut.MultiSelect = true;
            dgvOut.BorderStyle = BorderStyle.Fixed3D;

            //  dgvOut.DefaultCellStyle.SelectionBackColor = Color.Red;
            //  dgvOut.DefaultCellStyle.SelectionForeColor = Color.Black;

            //   dgvOut.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold
            //CCUSAA00007487
        }

        public void ProcessRequest(UENSerchParams sp)
        {

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

                  
/*
                    hdr.transactiondate,
	                hdr.transactionsetid,
	                hdr.internalreference,
	                hdr.sourcelocation,
	                hdr.destinationlocation,
	                hdr.actiontype,
	                hdr.created,
*/

                    string sDate = DateTime.Now.Date.ToString("M /d/yyyy");

                    cmd.CommandText = @"select
                    hdr.AutomationID,
                    hdr.transactionsetid,
                    
                 	dl.assetbillingid,
	                dl.assetid,
                    hdr.actionreference as ActionReference,
                    hdr.revision as LogTekRev,
                    dtl.revision as ArchiveRev,
                    dtl.AssetID as ArchiveAssetID,

                   -- hdr.Quantity,
                    hdr.shelfaverage,
	                hdr.transactiondate,
	                hdr.transactionsetid,
	                hdr.internalreference,
	                hdr.sourcelocation,
	                hdr.destinationlocation,
	                hdr.actiontype,
	                hdr.created 

	                
                from
	                dbadmin.dbo.logtekauto_header hdr 
             left join dbadmin.dbo.logtekauto_detail dl
		            on dl.transactionsetid = hdr.transactionsetid 
	             left join dbadmin.dbo.logtekauto_archive dtl
		               on dtl.transactionsetid = hdr.transactionsetid 
		        
                where

	                hdr.internalreference = '"
                                     + sInternalRef
                                     + @" ' AND hdr.equipmentID = 150";





                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    ClearGrid();
                    reader = cmd.ExecuteReader();
                    AddReaderRows(reader);
                
                   
                    sqlConnection.Close();

                   

                }

                catch (Exception ex)
                {
                   

                    UserOut("TagID: " + sInternalRef + " Exception retrieving data :" + ex.Message);
                   

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
                  //  startWaitingThread();
                    reader = cmd.ExecuteReader();
                    AddReaderRows(reader);
                  //  stopWaitingThread();



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
                      PriorBillingResponsibility,
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
          

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            
        

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
                                     PriorBillingResponsibility,
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
                   
                    

                    sqlConnection.Close();

                }

                catch (Exception ex)
                {
                    UserOut("TagID: " + sTag + " Exception retrieving data :" + ex.Message);
                    

                }

            }


        }


        public void AddReaderRows(SqlDataReader r)
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke((MethodInvoker)delegate ()
                {

                    bindingsource.DataSource = r;
                    DgvOut.ClearSelection();
                    DgvOut.Refresh();
                });

            }
            else
            {
                bindingsource.DataSource = r;
                DgvOut.ClearSelection();
                DgvOut.Refresh();
            }
        }
       
        public void ClearGrid()
        {
            if (DgvOut.InvokeRequired)
            {
                DgvOut.Invoke(new MethodInvoker(delegate () { ClearGrid(); }));
               
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

                dgLbOutput.Items.Insert(0, s);
                if (dgLbOutput.Items.Count > MAX_LB_SIZE)
                {
                    dgLbOutput.Items.RemoveAt(dgLbOutput.Items.Count - 1);                                                  // lets not explode
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
                case ("ArchiveAssetID"):
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

        private void startWaitingThread()
        {
            _bRun = true;
            Thread wt = new Thread(waitingThread);
            wt.Start();

        }
        private void stopWaitingThread()
        {
            _bRun = false;


        }
        private void waitingThread()
        {

            char[] caSpinner = new char[] { '-','\\','|','/'};

            while (_bRun)
            {
                if (TbRefValue.InvokeRequired)
                    TbRefValue.Invoke(new MethodInvoker(delegate () { waitingThread(); }));                                            // if we are on a different thread
                else

                {
                    for (int i = 0; i < caSpinner.Length; i++)
                    {
                        TbRefValue.BackColor = Color.Red;
                        //   DgvOut.Border    = Color.Red;
                        TbRefValue.BorderStyle = BorderStyle.FixedSingle;

                        Thread.Sleep(1000);
                        TbRefValue.BackColor = Color.Green;
                        TbRefValue.BorderStyle = BorderStyle.Fixed3D;
                        Thread.Sleep(1000);
                        //DgvOut.
                    }                                             
                   
                }
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
