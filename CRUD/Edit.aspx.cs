using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CRUD
{
    public partial class Edit : System.Web.UI.Page
    {
        string connectionString = "";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dataReader;

        public string sqlQuery = "";
        public string queryString = "";

        public void loadConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ToString();
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
            sqlQuery = "";
            queryString = "";
        }

        protected static int author_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                author_id = Convert.ToInt32(Request.QueryString["Id"].ToString());

                DataTable dtAll = new DataTable();
                dtAll = getAuthor(author_id);
                txtName.Text = dtAll.Rows[0][1].ToString();
                txtAddress.Text = dtAll.Rows[0][2].ToString();
                txtAge.Text = dtAll.Rows[0][3].ToString();
            }
        }

        protected DataTable getAuthor(int id)
        {
            DataTable dt = new DataTable();
            loadConnection();
            sqlQuery = "SELECT * FROM author WHERE a_id = @ID";
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ID", SqlDbType.Int, 5);
            command.Parameters["@ID"].Value = id;            
            dataReader = command.ExecuteReader();
            dt.Load(dataReader);
            CloseConnection();
            return dt;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteAuthor(author_id);
            Response.Redirect("~/Read.aspx");
        }

        protected void deleteAuthor(int id)
        {
            DataTable dt = new DataTable();
            loadConnection();
            sqlQuery = "DELETE FROM author WHERE a_id = @ID";
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ID", SqlDbType.Int, 5);
            command.Parameters["@ID"].Value = id;
            dataReader = command.ExecuteReader();
            CloseConnection();            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtAge.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            updateAuthor(author_id);
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
        }

        protected void updateAuthor(int id)
        {
            string author_name = txtName.Text;
            string author_address = txtAddress.Text;
            int author_age = Convert.ToInt32(txtAge.Text);
            loadConnection();
            sqlQuery = "UPDATE author SET a_name = @NAME,a_address= @ADDRESS, age= @AGE WHERE a_id =@ID";
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ID", SqlDbType.Int, 5);
            command.Parameters["@ID"].Value = id;
            command.Parameters.Add("@NAME", SqlDbType.VarChar, 50);
            command.Parameters["@NAME"].Value = author_name;
            command.Parameters.Add("@ADDRESS", SqlDbType.VarChar, 50);
            command.Parameters["@ADDRESS"].Value = author_address;
            command.Parameters.Add("@AGE", SqlDbType.Int, 5);
            command.Parameters["@AGE"].Value = author_age;
            dataReader = command.ExecuteReader();
            CloseConnection();
        }
    }
}