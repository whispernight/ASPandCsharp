using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class _564_Assigment3_part2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = string.Empty;
        Label2.Text = string.Empty;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Auth564"].ConnectionString);

        SqlCommand command = new SqlCommand();

        SqlTransaction tran = null;

        string strSQL1 = "SELECT PeopleID,firstName FROM People WHERE logonName = '" + TextBox1.Text + "'" + "AND passwd='" + TextBox2.Text + "'";

        try
        {
            conn.Open();
            tran = conn.BeginTransaction();
            command = new SqlCommand(strSQL1, conn, tran);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Label1.Text = "User not found";
            }
            else
            {

                int PeopleID = (int)ds.Tables[0].Rows[0]["PeopleID"];
                string UserName = (string)ds.Tables[0].Rows[0]["firstName"];

                string strSQL2 = "SELECT RoleTypeID FROM roles WHERE PeopleID = '" + PeopleID + "'";

                command = new SqlCommand(strSQL2, conn, tran);
                da = new SqlDataAdapter(command);
                ds = new DataSet();
                da.Fill(ds);
                int RoleTypeID = (int)ds.Tables[0].Rows[0]["RoleTypeID"];

                string strSQL3 = "SELECT RoleTypeName FROM roleTypes WHERE RoleTypeID = '" + RoleTypeID + "'";


                command = new SqlCommand(strSQL3, conn, tran);
                da = new SqlDataAdapter(command);
                ds = new DataSet();
                da.Fill(ds);
                string RoleTypeName = (string)ds.Tables[0].Rows[0]["RoleTypeName"];

                Label1.Text = "Hello " + UserName;
                Label2.Text = "You're looged as <b>" + RoleTypeName;
                tran.Commit();
            }
        }
        catch (Exception eTran)
        {
            Response.Write(eTran.ToString());
            Response.End();
            tran.Rollback();
        }
        finally
        {
            conn.Close();
        }
    }
}