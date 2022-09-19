using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=192.168.16.28;Initial Catalog=COSTING_NS;Persist Security Info=True;User ID=ictacca;Password=acca123!;Enlist=true; Max Pool Size=400000;Connect Timeout=200000;");
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                dropdownSet(dt);
                disp_data(con);
            }
        }

        public void dropdownSet(DataTable data)
        {
            string query = "SELECT * FROM Table_Kanchai ORDER BY Id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter das = new SqlDataAdapter(cmd);
            das.Fill(dt);
            con.Close();
            das.Dispose();

            listid.Items.Clear();
            listid.DataTextField = "Id";
            listid.DataValueField = "Id";
            listid.DataSource = data;
            listid.DataBind();
            listid.Items.Insert(0, new ListItem("--ไม่ระบุ---", ""));
            listid.SelectedIndex = 0;
        }

        public void disp_data(SqlConnection connection)
        {
            string queryDisplayData = "SELECT * FROM Table_Kanchai";;
            SqlCommand cmdDisplayData = new SqlCommand(queryDisplayData, connection);
            connection.Open();
            cmdDisplayData.ExecuteNonQuery();

            DataTable dtGridView = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmdDisplayData);
            da.Fill(dtGridView);
            GridView1.DataSource = dtGridView;
            GridView1.DataBind();

            con.Close();
            da.Dispose();
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            string queryInsert = "INSERT INTO Table_Kanchai (Description, CreateDate, CreateBy) VALUES ('"+description.Text+"', '"+ DateTime.Now + "' ,'"+createby.Text+"')";
            //System.Diagnostics.Debug.WriteLine(queryInsert);
            SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
            con.Open();
            int result = cmdInsert.ExecuteNonQuery();
            con.Close();

            description.Text = "";
            createby.Text = "";
            dropdownSet(dt);
            disp_data(con);
        }

        protected void delete_Click(object sender, EventArgs e) 
        {
            if(listid.SelectedIndex == 0)
            {
                WorningNotInputId.Visible = true;
            }
            else
            {
                string queryDelete = "DELETE FROM Table_Kanchai WHERE Id = " + listid.SelectedItem.Text;
                System.Diagnostics.Debug.WriteLine(queryDelete);
                SqlCommand cmdInsert = new SqlCommand(queryDelete, con);
                con.Open();

                
                int result = cmdInsert.ExecuteNonQuery();
                con.Close();

                listid.SelectedItem.Text = "";

                WorningNotInputId.Visible = false;
                dropdownSet(dt);
                listid.SelectedIndex = 0;
                disp_data(con);
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if(listid.SelectedIndex == 0)
            {
                WorningNotInputId.Visible = true;
            }
            else{ 
                string queryUpdate = "UPDATE Table_Kanchai SET Description = '"+description.Text+"', CreateBy = '"+createby.Text+"'  WHERE Id = "+listid.SelectedItem.Text;
                System.Diagnostics.Debug.WriteLine(queryUpdate);
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
                con.Open();

                int result = cmdUpdate.ExecuteNonQuery();
                con.Close();

                listid.SelectedItem.Text = "";
                description.Text = "";
                createby.Text = "";

                WorningNotInputId.Visible = false;
                dropdownSet(dt);
                listid.SelectedIndex = 0;
                disp_data(con);
            }
        }
    }
}