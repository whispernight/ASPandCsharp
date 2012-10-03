using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFTestService" in code, svc and config file together.
public class WCFTestService : IWCFTestService
{
	public void DoWork()
	{
	}
    [WebGet]

    public string getName()
    {
        return "Angel";
    }

    [WebGet]
    public string sayHello(string name)
    {
        return "Hello "+ name;
    }
}
