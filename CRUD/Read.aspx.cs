using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace CRUD
{
    public partial class Read : System.Web.UI.Page
    {
        string connectionString = "";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader dataReader;

        public string sqlQuery = "";
        
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dtAll = new DataTable();
                dtAll = getAllAuthors();
                grdAuthors.DataSource = dtAll;
                grdAuthors.DataBind();
                ViewState["_Authors"] = dtAll;
                hideControllers(0);
            }
        }

        public DataTable getAllAuthors()
        {
            DataTable dt = new DataTable();
            loadConnection();
            sqlQuery = "SELECT * FROM author";
            command = new SqlCommand(sqlQuery, connection);
            dataReader = command.ExecuteReader();
            dt.Load(dataReader);
            CloseConnection();
            return dt;
        }            

        protected int getNextAuthorId()
        {
            int maxUserId = 0;
            DataTable dt = new DataTable();
            loadConnection();
            sqlQuery = "select MAX(a_id) from author";
            command = new SqlCommand(sqlQuery, connection);
            dataReader = command.ExecuteReader();
            dt.Load(dataReader);
            CloseConnection();
            if (dt.Rows.Count > 0)
            {
                maxUserId = string.IsNullOrEmpty(dt.Rows[0][0].ToString()) ? 0 : Convert.ToInt32(dt.Rows[0][0]);
            }             
            return maxUserId;
        }

        protected void insertAuthors(Hashtable ht)
        {            
            Hashtable htable = ht;
            int author_id = Convert.ToInt32(htable["author_id"].ToString());
            string author_name = (string)htable["author_name"];
            string author_address = (string)htable["author_address"];
            int author_age = Convert.ToInt32(htable["author_age"].ToString());
            loadConnection();
            sqlQuery = "INSERT into author(a_id,a_name,a_address,age) values (@ID,@NAME,@ADDRESS,@AGE)";
            command = new SqlCommand(sqlQuery, connection);
            command.Parameters.Add("@ID", SqlDbType.Int, 5);
            command.Parameters["@ID"].Value = author_id;
            command.Parameters.Add("@NAME", SqlDbType.VarChar, 50);
            command.Parameters["@NAME"].Value = author_name;
            command.Parameters.Add("@ADDRESS", SqlDbType.VarChar, 50);
            command.Parameters["@ADDRESS"].Value = author_address;
            command.Parameters.Add("@AGE", SqlDbType.Int, 5);
            command.Parameters["@AGE"].Value = author_age;
            dataReader = command.ExecuteReader();
            CloseConnection();            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int nextId = getNextAuthorId() + 1;
            string author_name = txtName.Text;
            string author_address = txtAddress.Text;
            string author_age = txtAge.Text;
            Hashtable htble = new Hashtable();
            htble.Add("author_id", nextId);
            htble.Add("author_name", author_name);
            htble.Add("author_address", author_address);
            htble.Add("author_age", author_age);
            insertAuthors(htble);

            DataTable dt = new DataTable();
            DataRow dr; 
            dt = (DataTable)ViewState["_Authors"];
            dr = dt.NewRow();
            dr["a_id"] = nextId;
            dr["a_name"] = author_name;
            dr["a_address"] = author_address;
            dr["age"] = author_age;
            dt.Rows.Add(dr);

            ViewState["_Authors"] = dt;
            grdAuthors.DataSource = ViewState["_Authors"];
            grdAuthors.DataBind();

            hideControllers(0);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            hideControllers(1);
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            hideControllers(0);
        }

        private void hideControllers(int state)
        {
            switch (state)
            {
                case 0:
                    pnlRead.Visible = true;
                    pnlNew.Visible = false;
                    btnAll.Enabled = false;
                    btnNew.Enabled = true;
                    break;
                case 1:
                    pnlRead.Visible = false;
                    pnlNew.Visible = true;
                    btnNew.Enabled = false;
                    btnAll.Enabled = true;
                    break;
                default:
                    break;
            }
        }

    }
}