using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _564_Assigment3_part1: System.Web.UI.Page
{
    SqlDataAdapter sqlDataAdapter;
    DataSet dataSet = new DataSet();
    string strSQLAddNewuser, strSQLSelectUser, strSQLAddRole;

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Auth564"].ConnectionString);
    SqlCommand command = new SqlCommand();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        strSQLSelectUser = "SELECT * FROM People WHERE firstName = 'Angel' AND lastName='Alferez' AND logonName='aalferez' order by PeopleID DESC";

        command = new SqlCommand(strSQLSelectUser, connection, transaction);
        sqlDataAdapter = new SqlDataAdapter(command);
        sqlDataAdapter.Fill(dataSet);
        GridViewUsers.DataSource = dataSet;
        GridViewUsers.DataBind();
    }

    protected void ButtonAddUser_Click(object sender, EventArgs e)
    {

        try
        {
            strSQLAddNewuser = "INSERT INTO People ";
            strSQLAddNewuser += "(salutationID, firstName, lastName, logonName, passwd)";
            strSQLAddNewuser += " VALUES ";
            strSQLAddNewuser += " (1, 'Angel', 'Alferez', 'aalferez', '12345')";

            connection.Open();
            transaction = connection.BeginTransaction();
            command.Transaction = transaction;

            //Add user to table
            command = new SqlCommand(strSQLAddNewuser, connection, transaction);
            command.ExecuteNonQuery();

            //select user from table
            strSQLSelectUser = "SELECT PeopleID FROM People WHERE firstName = 'Angel' AND lastName='Alferez' AND logonName='aalferez' order by PeopleID DESC";
            command = new SqlCommand(strSQLSelectUser, connection, transaction);
            sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(dataSet);
            int PeopleID = (int)dataSet.Tables[0].Rows[0]["PeopleID"];

            //Insert role in table
            strSQLAddRole = "INSERT INTO roles ";
            strSQLAddRole += "( PeopleID, roleTypeID, RoleActive )";
            strSQLAddRole += "VALUES";
            strSQLAddRole += "( " + PeopleID + ", 1, 1)";

            command = new SqlCommand(strSQLAddRole, connection, transaction);
            command.ExecuteNonQuery();

            command = new SqlCommand("SELECT * FROM People", connection, transaction);
            sqlDataAdapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            GridViewUsers.DataSource = dataSet;
            GridViewUsers.DataBind();
            transaction.Commit();

        }
        catch { }
    }
}
