using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace IITCourse.Blog
{
	public class BlogResponse
	{
        public int BlogResponseID { get; set; }
        public int BlogID { get; set; }
        public string UserName { get; set; }
        public DateTime RecCreation { get; set; }
        public string IPAddress { get; set; }
        public string ResponseText { get; set; }
 
        public BlogResponse()
        {
            IPAddress = HttpContext.Current.Request.UserHostAddress;
            RecCreation = DateTime.Now;
            if (Membership.GetUser() != null)
            {
                UserName = Membership.GetUser().UserName;
            }
            else
            {
                UserName = "Anonymous";
            }
        }
    }
}