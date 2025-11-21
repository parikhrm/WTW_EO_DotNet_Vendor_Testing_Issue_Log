using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Vendor_Testing_Issue_Log
{
    public partial class Issue_Log : Form
    {
        public string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
        //public string connectionstringtxt = ConfigurationManager.ConnectionStrings["KYC_RDC_Workflow.Properties.Settings.DRDConnectionString"].ConnectionString;
        //string connectionstringtxt = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        public Issue_Log()
        {
            InitializeComponent();
        }

        private void Issue_Log_Load(object sender, EventArgs e)
        {
            vendor_list();
            platform_list();
            associate_name_list();
            risk_category_list();
            priority_level_list();
            reset_overall();

        }

        public void reset_overall()
        {
            current_datetime.Visible = false;
            current_datetime.Text = DateTime.Now.ToLongDateString();
            requestid.Text = string.Empty;
            requestid.Enabled = false;
            vendor.SelectedIndex = -1;
            platform.SelectedIndex = -1;
            entity_individual_name.Text = string.Empty;
            wft_batch_requestid.Text = string.Empty;
            issue_raised_date.CustomFormat = " ";
            checkBox1.Checked = false;
            issue_resolved_date.CustomFormat = " ";
            associate_name.SelectedIndex = -1;
            ops_comments.Text = string.Empty;
            moodys_dnb_comments.Text = string.Empty;
            risk_category.SelectedIndex = -1;
            priority_level.SelectedIndex = -1;
            insert.Enabled = true;
            update.Enabled = false;
            datagridview_display_overall();
        }

        private void issue_raised_date_ValueChanged(object sender, EventArgs e)
        {
            issue_raised_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void issue_raised_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                issue_raised_date.CustomFormat = " ";
            }
        }

        private void issue_resolved_date_ValueChanged(object sender, EventArgs e)
        {
            issue_resolved_date.CustomFormat = "dd-MMMM-yyyy";
        }

        private void issue_resolved_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                issue_resolved_date.CustomFormat = " ";
            }
        }

        public void vendor_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_vendor = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_vendor.vendor_list(dtaa);
                vendor.DataSource = dtaa;
                vendor.DisplayMember = "Vendor";
                conn.Close();
                vendor.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void platform_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_platform = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_platform.platform_list(dtaa);
                platform.DataSource = dtaa;
                platform.DisplayMember = "Platform";
                conn.Close();
                platform.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void associate_name_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_associate_name = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_associate_name.associatename_list(dtaa);
                associate_name.DataSource = dtaa;
                associate_name.DisplayMember = "EmpName";
                conn.Close();
                associate_name.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void risk_category_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_risk_category = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_risk_category.risk_category_list(dtaa);
                risk_category.DataSource = dtaa;
                risk_category.DisplayMember = "Risk_Category";
                conn.Close();
                risk_category.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        public void priority_level_list()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                DropDown_References obj_priority_level = new DropDown_References();
                DataTable dtaa = new DataTable();
                obj_priority_level.priority_level_list(dtaa);
                priority_level.DataSource = dtaa;
                priority_level.DisplayMember = "Priority_Level";
                conn.Close();
                priority_level.SelectedIndex = -1;
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details: " + ab.ToString());
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_vendor_testing_issuelog_insert_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                if(string.IsNullOrEmpty(vendor.Text))
                {
                    cmd.Parameters.AddWithValue("@Vendor", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Vendor", vendor.Text);
                }
                if(string.IsNullOrEmpty(platform.Text))
                {
                    cmd.Parameters.AddWithValue("@Platform", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Platform", platform.Text);
                }
                if (string.IsNullOrEmpty(entity_individual_name.Text))
                {
                    cmd.Parameters.AddWithValue("@Entity_Individual_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Entity_Individual_Name", entity_individual_name.Text);
                }
                if(string.IsNullOrEmpty(wft_batch_requestid.Text))
                {
                    cmd.Parameters.AddWithValue("@WFT_Batch_RequestID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@WFT_Batch_RequestID", wft_batch_requestid.Text);
                }
                if (issue_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Issue_Raised_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Issue_Raised_Date", issue_raised_date.Value.Date);
                }
                if (chaser_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser_Date", chaser_date.Value.Date);
                }
                if(checkBox1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Chaser_Sent",1);
                }
                else 
                {
                    cmd.Parameters.AddWithValue("@Chaser_Sent", 0);
                }
                if (issue_resolved_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Issue_Resolved_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Issue_Resolved_Date", issue_resolved_date.Value.Date);
                }
                if (string.IsNullOrEmpty(associate_name.Text))
                {
                    cmd.Parameters.AddWithValue("@Associate_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Associate_Name", associate_name.Text);
                }
                if (string.IsNullOrEmpty(ops_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Ops_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Ops_Comments", ops_comments.Text);
                }
                if (string.IsNullOrEmpty(moodys_dnb_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Moodys_DNB_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Moodys_DNB_Comments", moodys_dnb_comments.Text);
                }
                if (string.IsNullOrEmpty(risk_category.Text))
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", risk_category.Text);
                }
                if (string.IsNullOrEmpty(priority_level.Text))
                {
                    cmd.Parameters.AddWithValue("@Priority_Level", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Priority_Level", priority_level.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy",Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName",Environment.MachineName.ToString());

                
                //if conditions
                if(issue_resolved_date.Text.Trim() != string.Empty && string.IsNullOrEmpty(moodys_dnb_comments.Text))
                {
                    MessageBox.Show("Please update Moodys DNB Comments");
                }
                else if(vendor.Text == "Moodys" && string.IsNullOrEmpty(platform.Text))
                {
                    MessageBox.Show("Please update Platform");
                }
                else if(issue_raised_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Issue Raised Date");
                }
                else if (string.IsNullOrEmpty(vendor.Text))
                {
                    MessageBox.Show("Please update Vendor");
                }
                else if (string.IsNullOrEmpty(platform.Text))
                {
                    MessageBox.Show("Please update Platform");
                }
                else if (string.IsNullOrEmpty(associate_name.Text))
                {
                    MessageBox.Show("Please update Associate Name");
                }
                else if (string.IsNullOrEmpty(ops_comments.Text))
                {
                    MessageBox.Show("Please update Ops Comments");
                }
                else if (string.IsNullOrEmpty(risk_category.Text))
                {
                    MessageBox.Show("Please update Risk Category");
                }
                else if (string.IsNullOrEmpty(priority_level.Text))
                {
                    MessageBox.Show("Please update Priority Level");
                }
                else if(issue_raised_date.Text.Trim() != string.Empty && issue_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Issue Raised Date cannot be more than Today's date");
                }
                else if (issue_resolved_date.Text.Trim() != string.Empty && issue_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Issue Resolved Date cannot be more than Today's date");
                }
                else
                {

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                cmd.Parameters.Clear();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.usp_vendor_testing_issuelog_update_dotnet";
                cmd.Parameters.Add("@Message", SqlDbType.NVarChar, 1000);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@RequestID",requestid.Text);
                if (string.IsNullOrEmpty(vendor.Text))
                {
                    cmd.Parameters.AddWithValue("@Vendor", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Vendor", vendor.Text);
                }
                if (string.IsNullOrEmpty(platform.Text))
                {
                    cmd.Parameters.AddWithValue("@Platform", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Platform", platform.Text);
                }
                if (string.IsNullOrEmpty(entity_individual_name.Text))
                {
                    cmd.Parameters.AddWithValue("@Entity_Individual_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Entity_Individual_Name", entity_individual_name.Text);
                }
                if (string.IsNullOrEmpty(wft_batch_requestid.Text))
                {
                    cmd.Parameters.AddWithValue("@WFT_Batch_RequestID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@WFT_Batch_RequestID", wft_batch_requestid.Text);
                }
                if (issue_raised_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Issue_Raised_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Issue_Raised_Date", issue_raised_date.Value.Date);
                }
                if (chaser_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Chaser_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser_Date", chaser_date.Value.Date);
                }
                if (checkBox1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Chaser_Sent", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Chaser_Sent", 0);
                }
                if (issue_resolved_date.Text.Trim() == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Issue_Resolved_Date", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Issue_Resolved_Date", issue_resolved_date.Value.Date);
                }
                if (string.IsNullOrEmpty(associate_name.Text))
                {
                    cmd.Parameters.AddWithValue("@Associate_Name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Associate_Name", associate_name.Text);
                }
                if (string.IsNullOrEmpty(ops_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Ops_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Ops_Comments", ops_comments.Text);
                }
                if (string.IsNullOrEmpty(moodys_dnb_comments.Text))
                {
                    cmd.Parameters.AddWithValue("@Moodys_DNB_Comments", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Moodys_DNB_Comments", moodys_dnb_comments.Text);
                }
                if (string.IsNullOrEmpty(risk_category.Text))
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Risk_Catetory", risk_category.Text);
                }
                if (string.IsNullOrEmpty(priority_level.Text))
                {
                    cmd.Parameters.AddWithValue("@Priority_Level", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Priority_Level", priority_level.Text);
                }
                cmd.Parameters.AddWithValue("@LastUpdatedBy", Environment.UserName.ToString());
                cmd.Parameters.AddWithValue("@MachineName", Environment.MachineName.ToString());


                //if conditions
                if (issue_resolved_date.Text.Trim() != string.Empty && string.IsNullOrEmpty(moodys_dnb_comments.Text))
                {
                    MessageBox.Show("Please update Moodys DNB Comments");
                }
                else if (vendor.Text == "Moodys" && string.IsNullOrEmpty(platform.Text))
                {
                    MessageBox.Show("Please update Platform");
                }
                else if (issue_raised_date.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please update Issue Raised Date");
                }
                else if (string.IsNullOrEmpty(vendor.Text))
                {
                    MessageBox.Show("Please update Vendor");
                }
                else if (string.IsNullOrEmpty(platform.Text))
                {
                    MessageBox.Show("Please update Platform");
                }
                else if (string.IsNullOrEmpty(associate_name.Text))
                {
                    MessageBox.Show("Please update Associate Name");
                }
                else if (string.IsNullOrEmpty(ops_comments.Text))
                {
                    MessageBox.Show("Please update Ops Comments");
                }
                else if (string.IsNullOrEmpty(risk_category.Text))
                {
                    MessageBox.Show("Please update Risk Category");
                }
                else if (string.IsNullOrEmpty(priority_level.Text))
                {
                    MessageBox.Show("Please update Priority Level");
                }
                else if (issue_raised_date.Text.Trim() != string.Empty && issue_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Issue Raised Date cannot be more than Today's date");
                }
                else if (issue_resolved_date.Text.Trim() != string.Empty && issue_raised_date.Value.Date > current_datetime.Value.Date)
                {
                    MessageBox.Show("Issue Resolved Date cannot be more than Today's date");
                }
                else
                {

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    string uploadmessage = cmd.Parameters["@Message"].Value.ToString();
                    MessageBox.Show("" + uploadmessage.ToString());
                    cmd.Parameters.Clear();
                    reset_overall();
                    conn.Close();
                }
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details :" + ab.ToString());
            }
        }

        public void datagridview_display_overall()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();
                conn.ConnectionString = connectionstringtxt;
                cmd.Connection = conn;
                conn.Open();
                cmd.Parameters.Clear();

                if (string.IsNullOrEmpty(searchby_requestid.Text) && string.IsNullOrEmpty(searchby_entityname.Text) && string.IsNullOrEmpty(searchby_associatename.Text))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select top 100 RequestID,Vendor,Platform,Entity_Individual_Name,WFT_Batch_RequestID,Issue_Raised_Date,Chaser_Date,case when Chaser_Sent = 0 then null else Chaser_Sent end as Chaser_Sent ,Issue_Resolved_Date,Associate_Name,Ops_Comments,Moodys_DNB_Comments,Risk_Catetory,Priority_Level,LastUpdatedBy from dbo.tbl_vendor_testing_issuelog_dotnet with(nolock) where IsDeleted = 0";
                    cmd.Parameters.AddWithValue("@lastupdatedby", Environment.UserName.ToString());
                }
                else
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.usp_vendor_testing_issuelog_datagridview_search_dotnet";
                    if (string.IsNullOrEmpty(searchby_requestid.Text))
                    {
                        cmd.Parameters.AddWithValue("@requestid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@requestid", searchby_requestid.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_entityname.Text))
                    {
                        cmd.Parameters.AddWithValue("@entityname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@entityname", searchby_entityname.Text);
                    }
                    if (string.IsNullOrEmpty(searchby_associatename.Text))
                    {
                        cmd.Parameters.AddWithValue("@associatename", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@associatename", searchby_associatename.Text);
                    }

                }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string messsage = "Do you want to update the record?";
            string title = "Message Box";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(messsage, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    requestid.Text = row.Cells["txt_RequestID"].Value.ToString();
                    if (string.IsNullOrEmpty(row.Cells["txt_Vendor"].Value.ToString()))
                    {
                        vendor.SelectedIndex = -1;
                    }
                    else
                    {
                        vendor.Text = row.Cells["txt_Vendor"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Platform"].Value.ToString()))
                    {
                        platform.SelectedIndex = -1;
                    }
                    else
                    {
                        platform.Text = row.Cells["txt_Platform"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Entity_Individual_Name"].Value.ToString()))
                    {
                        entity_individual_name.Text = string.Empty;
                    }
                    else
                    {
                        entity_individual_name.Text = row.Cells["txt_Entity_Individual_Name"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_WFT_Batch_RequestID"].Value.ToString()))
                    {
                        wft_batch_requestid.Text = string.Empty;
                    }
                    else
                    {
                        wft_batch_requestid.Text = row.Cells["txt_WFT_Batch_RequestID"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Issue_Raised_Date"].Value.ToString()))
                    {
                        issue_raised_date.CustomFormat = " ";
                    }
                    else
                    {
                        issue_raised_date.Text = row.Cells["txt_Issue_Raised_Date"].Value.ToString();
                        issue_raised_date.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Chaser_Date"].Value.ToString()))
                    {
                        chaser_date.CustomFormat = " ";
                    }
                    else
                    {
                        chaser_date.Text = row.Cells["txt_Chaser_Date"].Value.ToString();
                        chaser_date.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_ChaserSent"].Value.ToString()))
                    {
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = true;
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Issue_Resolved_Date"].Value.ToString()))
                    {
                        issue_resolved_date.CustomFormat = " ";
                    }
                    else
                    {
                        issue_resolved_date.Text = row.Cells["txt_Issue_Resolved_Date"].Value.ToString();
                        issue_resolved_date.CustomFormat = "dd-MMMM-yyyy";
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Associate_Name"].Value.ToString()))
                    {
                        associate_name.SelectedIndex = -1;
                    }
                    else
                    {
                        associate_name.Text = row.Cells["txt_Associate_Name"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Ops_Comments"].Value.ToString()))
                    {
                        ops_comments.Text = string.Empty;
                    }
                    else
                    {
                        ops_comments.Text = row.Cells["txt_Ops_Comments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Moodys_DNB_Comments"].Value.ToString()))
                    {
                        moodys_dnb_comments.Text = string.Empty;
                    }
                    else
                    {
                        moodys_dnb_comments.Text = row.Cells["txt_Moodys_DNB_Comments"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Risk_Catetory"].Value.ToString()))
                    {
                        risk_category.SelectedIndex = -1;
                    }
                    else
                    {
                        risk_category.Text = row.Cells["txt_Risk_Catetory"].Value.ToString();
                    }
                    if (string.IsNullOrEmpty(row.Cells["txt_Priority_Level"].Value.ToString()))
                    {
                        priority_level.SelectedIndex = -1;
                    }
                    else
                    {
                        priority_level.Text = row.Cells["txt_Priority_Level"].Value.ToString();
                    }
                }
                insert.Enabled = false;
                update.Enabled = true;
            }
            else
            {
                requestid.Focus();
                insert.Enabled = true;
                update.Enabled = false;
            }
        }

        private void searchby_requestid_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_entityname_TextChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void searchby_associatename_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridview_display_overall();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset_overall();
        }

        private void raw_data_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://a20-cb-dbse01p/Reports/report/DRD%20MI%20Mumbai/DRD%20Reports/rpt_SSRS_Vendor_Testing_IssueLog_DotNet");
            }
            catch (Exception ab)
            {
                MessageBox.Show("Unable to open link that was clicked. Following are the error generated details" + ab.ToString());
            }
        }
    }
}
