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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

public partial class _564_Assigments_assigment2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //creating a table manually 
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("BlogID", Type.GetType("System.String")));
        dt.Columns.Add(new DataColumn("BlogText", Type.GetType("System.String")));
        dt.Columns.Add(new DataColumn("Mood", Type.GetType("System.String")));
        dt.Rows.Add(dt.NewRow());
        dt.Rows.Add(dt.NewRow());
        dt.Rows.Add(dt.NewRow());
        dt.Rows[0]["BlogID"] = "FirstID";
        dt.Rows[0]["BlogText"] = "Awesome!";
        dt.Rows[0]["Mood"] = "This is for awesome people";
        dt.Rows[1]["BlogID"] = "SecondID";
        dt.Rows[1]["BlogText"] = "Take it easy...";
        dt.Rows[1]["Mood"] = "Stop messing";
        dt.Rows[2]["BlogID"] = "ThirdID";
        dt.Rows[2]["BlogText"] = "Great!";
        dt.Rows[2]["Mood"] = "Well done";

        dt.PrimaryKey = new DataColumn[] { dt.Columns["BlogID"] };
        GV3.DataSource = dt;
        GV3.DataBind();

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        GV4.DataSource = ds.Tables[0];
        GV4.DataBind();


        DALBlog blogDAL = new DALBlog("cheeseConnectionString");
        GV1.DataSource = blogDAL.GetDataTable("SELECT * FROM Blogs", "Blog");
        GV1.DataBind();

        Database db = DatabaseFactory.CreateDatabase("cheeseConnectionString");
        GV2.DataSource = db.ExecuteDataSet(db.GetSqlStringCommand("SELECT * FROM Blogs"));
        GV2.DataBind();

    }
}