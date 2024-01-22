using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using Microsoft.VisualBasic.CompilerServices;

namespace Enterprise_Village_2._0
{

    public partial class Z_Test_Page : Page
    {
        private string sqlserver = ConfigurationManager.AppSettings["EV_sfp"].ToString();
        private string sqldatabase = ConfigurationManager.AppSettings["EV_DB"].ToString();
        private string sqluser = ConfigurationManager.AppSettings["db_user"].ToString();
        private string sqlpassword = ConfigurationManager.AppSettings["db_password"].ToString();
        private string connection_string;
        private _0.Class_VisitData VisitID = new _0.Class_VisitData();
        private int Visit;

        public Z_Test_Page()
        {
            connection_string = "Server=" + sqlserver + ";database=" + sqldatabase + ";uid=" + sqluser + ";pwd=" + sqlpassword + ";Connection Timeout=20;";
            Visit = VisitID.GetVisitID();
            Load += Page_Load;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            var con = new SqlConnection();
            string connection_string = "Server=" + sqlserver + ";database=" + sqldatabase + ";uid=" + sqluser + ";pwd=" + sqlpassword + ";Connection Timeout=20;";
            var cmd = new SqlCommand();
            // Dim Sr As New StreamReader("\\A6351L045-4457.pinellas.local\C:\EV\media\Badge Photos\myPhoto.png")
            string clientName = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName;
            string filePath = @"C:\EV\media\Badge Photos\";
            SqlDataReader dr;

            // If System.IO.Directory.GetFiles(filePath, "myPhoto.png", IO.SearchOption.AllDirectories).Length > 0 Then
            // error_lbl.Text = "File exists"
            // Exit Sub
            // Else
            // error_lbl.Text = filePath
            // Exit Sub
            // End If

            // 'Load timestamp data
            // Try
            // con.ConnectionString = connection_string
            // con.Open()
            // cmd.Connection = con
            // cmd.CommandText = "SELECT id, itemName, itemCategory, itemSubCat, currentLocation, source, onHand, businessUsed, comments, merchCode, usedDaily
            // FROM EV_Inventory
            // ORDER BY id ASC"

            // Dim da As New SqlDataAdapter
            // da.SelectCommand = cmd
            // Dim dt As New DataTable
            // da.Fill(dt)
            // items_dgv.DataSource = dt
            // items_dgv.DataBind()

            // cmd.Dispose()
            // con.Close()

            // Catch
            // error_lbl.Text = "Error in LoadData(). Cannot get load data."
            // Exit Sub
            // End Try

            // Populating header school and school name label


            var SchoolData = new _0.Class_SchoolData();
            this.error_lbl.Text = Conversions.ToString(SchoolData.GetSchoolsString("5/18/23"));
        }

        protected void upload_btn_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/uploads/Articles/");

            // Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                // If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            // Save the File to the Directory (Folder).
            this.fileUpload_fu.SaveAs(folderPath + Path.GetFileName(this.fileUpload_fu.FileName));

            // Display the success message.
            this.error_lbl.Text = Path.GetFileName(this.fileUpload_fu.FileName) + " has been uploaded.";

        }
    }
}