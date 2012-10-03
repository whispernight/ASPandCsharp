using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;

public partial class _564_Assigments_assigment1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //With Data Reader
        SqlConnection objConnection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["cheeseConnectionString"].ConnectionString);
        string strSQL = "SELECT * FROM cheese";
        SqlCommand objCommand = new SqlCommand();
        objCommand.CommandText = strSQL;
        objCommand.Connection = objConnection;
        SqlDataReader objDataReader = null;
        //This is dangerous
        try
        {
            // With Object Data Reader
            objConnection.Open();
            objDataReader = objCommand.ExecuteReader();
            //container.InnerHtml = strResultsHolder;
            GridView1.DataSource = objDataReader;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Div1.InnerHtml = "Connection failed to open successfully.<br/>";
            Div1.InnerHtml += ex.ToString();
        }
        finally
        {
            objDataReader.Close();
            objConnection.Close();
        }

        //With Data Adapter
        objConnection.Open();
        // With Object Data Adapter
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(objCommand);
        da.Fill(ds, "Cheeses");
        GridView2.DataSource = ds.Tables["Cheeses"].DefaultView;
        GridView2.DataBind();

        //With DBFACTORY WITH MYSQL ******************************************/

        // Data Provider Objects
        DbProviderFactory dbFactory;
        DbConnection conn;
        DbCommand dc;
        DbDataAdapter dataadapter;

        //Consumer
        DataTable dt;

        dbFactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");

        using (conn = dbFactory.CreateConnection())
        using (dc = dbFactory.CreateCommand())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["cheeseConnectionString"].ConnectionString;

            dc.CommandType = CommandType.Text;
            dc.CommandText = strSQL;
            dc.Connection = conn;
            dataadapter = dbFactory.CreateDataAdapter();     //Inialize DataAdapter with DataCommand
            dataadapter.SelectCommand = dc;

            ds = new DataSet();                     //Initialize empty DataSet
            dt = new DataTable();

            dataadapter.Fill(ds, "Region");          //Use the DataAdapter to fill the DataSet with a named Table
            dt = ds.Tables["Region"];       //Retreive the named table from the DataSet
        }

        GridView3.DataSource = dt;    //Set the DataTable as the source for the GridView note AutoGenerateColumns = true
        GridView3.DataBind();          //Bind the data form the table to the GridView


        //With DBFACTORY WITH MICROSOFT SQL

        //Connection string comes from web config
        dbFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        using (conn = dbFactory.CreateConnection())
        using (dc = dbFactory.CreateCommand())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["cheeseConnectionString"].ConnectionString;

            dc.CommandType = CommandType.Text;
            dc.CommandText = strSQL;
            dc.Connection = conn;

            dataadapter = dbFactory.CreateDataAdapter();     //Inialize DataAdapter with DataCommand
            dataadapter.SelectCommand = dc;

            ds = new DataSet();                     //Initialize empty DataSet
            dt = new DataTable();

            dataadapter.Fill(ds, "Region");          //Use the DataAdapter to fill the DataSet with a named Table
            dt = ds.Tables["Region"];       //Retreive the named table from the DataSet
        }

        GridView4.DataSource = dt;    //Set the DataTable as the source for the GridView note AutoGenerateColumns = true
        GridView4.DataBind();          //Bind the data form the table to the GridView
    }
}