using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ITMSqlMemberShipProvider
/// </summary>
public class ITMSqlMemberShipProvider : SqlMembershipProvider
{


    public ITMSqlMemberShipProvider()
    {
        //
        // TODO: Add constructor logic here
        //

    }



    public override string GetPassword(string username, string passwordAnswer)
    {
        return base.GetPassword(username, passwordAnswer);
    }


}