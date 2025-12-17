using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace Vendor_Testing_Issue_Log
{
    internal class DropDown_References
    {
        public void vendor_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_vendor_dotnet with(nolock) where IsDeleted = 0 order by Vendor";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void platform_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_platform_dotnet with(nolock) where IsDeleted = 0 order by Platform";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void activity_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_activity_dotnet with(nolock) where IsDeleted = 0 order by Activity";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void associatename_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_emp_details with(nolock) where IsDeleted = 0 and Process not in ('MI','Management') and empname not in ('Others','Rinkesh Parikh ADM') order by EmpName";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void risk_category_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_risk_category_dotnet with(nolock) where IsDeleted = 0 order by Risk_Category";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void priority_level_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_priority_level_dotnet with(nolock) where IsDeleted = 0 order by Priority_Level";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void event_category_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_event_category_dotnet with(nolock) where IsDeleted = 0 order by Event_Category";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void sub_category_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_sub_category_dotnet with(nolock) where IsDeleted = 0 order by Sub_Category";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }

        public void ageing_of_test_status_list(DataTable dta)
        {
            string connectionstringtxt = "Data Source=A20-CB-DBSE01P;Initial Catalog=DRD;User ID=DRDUsers;Password=24252425";
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from dbo.tbl_vendor_testing_issuelog_ageing_of_test_status_dotnet with(nolock) where IsDeleted = 0 order by Ageing_Of_Test_Status";
                sda.SelectCommand = cmd;
                dt = dta;
                sda.Fill(dta);
            }
            catch (Exception ab)
            {
                MessageBox.Show("Error Generated Details : " + ab.ToString());
            }
        }
    }
}
