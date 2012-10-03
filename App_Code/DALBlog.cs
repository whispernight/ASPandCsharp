using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for DALBlog
/// </summary>
public class DALBlog
{
    private string connectionString;
    private DbProviderFactory dbFactory;
    private DbConnection connection;
    private DbCommand command;
    private DbDataAdapter da;
    public DataSet ds;
    public DataTable dt;

    //Constructor: intiliazes dbfactory and its connection
    public DALBlog(string connectionString)
    {
        // set object connection string to the one provided
        this.connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;

        // create new factory based on provider
        dbFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

        // create a connection to the desired database
        connection = dbFactory.CreateConnection();
        connection.ConnectionString = this.connectionString;

        // initialize DataSet and DataAdapter objects
        ds = new DataSet();
        da = dbFactory.CreateDataAdapter();
    }

    public DataTable GetDataTable(string sql, string tableName)
    {
        //Using the global connection, gets data grom the specified table
        RefreshConnection();
        command = dbFactory.CreateCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        command.CommandText = sql;
        da.SelectCommand = command;
        da.Fill(ds, tableName);

        return ds.Tables[tableName];
    }



    private void RefreshConnection()
    {
        // not created => create a new one
        if (connection == null)
        {
            connection = dbFactory.CreateConnection();
            connection.ConnectionString = connectionString;
        }

        // already open => reset
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
            connection = dbFactory.CreateConnection();
            connection.ConnectionString = connectionString;
        }
        // created and closed => initialize it
        else
        {
            connection.ConnectionString = connectionString;
        }
    }
}