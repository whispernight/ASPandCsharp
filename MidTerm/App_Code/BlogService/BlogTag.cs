using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace IITCourse.Blog
{
    public class BlogTag
    {
        public int TagID { get; set; }
        public int BlogID { get; set; }
        //public System.Guid  UserID { get; set; }
        public string UserName { get; set; }


        public BlogTag()
        {
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