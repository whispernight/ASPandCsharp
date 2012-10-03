using System;
using System.Data;
using System.Collections.Generic;
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
/// Summary description for ITM564ProxyRoleProvider
/// </summary>
/// 

namespace IITCourse.Security
{
    public class ITM564ProxyRoleProvider : System.Web.Security.RoleProvider
    {
        private List<string> m_ProviderList = new List<string>();
        private RoleProvider currentProvider;

        public ITM564ProxyRoleProvider()
        {
            
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config["ProviderList"] != null)
            {
                char[] cSplitchars = { ',' };
                string[] providers = config["ProviderList"].ToString().Split(cSplitchars);
                foreach (string providerName in providers)
                    m_ProviderList.Add(providerName);
                config.Remove("ProviderList");
            }
            //Set current provider
            if (m_ProviderList.Count > 0)
            {
                //this.currentProvider = Roles.Providers[m_ProviderList[0]]; 
            }
            base.Initialize(name, config);
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            RoleProvider rp = Roles.Providers["SqlRoleProvider"];
            rp.AddUsersToRoles(usernames, roleNames);
        }

        public override string ApplicationName
        {
            get
            {throw new NotImplementedException();}
            set
            {throw new NotImplementedException();}
        }

        public override void CreateRole(string roleName)
        {throw new NotImplementedException();}

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {throw new NotImplementedException();}

        public bool DeleteRoleITM564RoleProvider(string roleName, bool throwOnPopulatedRole)
        {throw new NotImplementedException();}

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {throw new NotImplementedException();}

        public override string[] GetAllRoles()
        {
            List<string> allRoles = new List<string>();
            foreach (string providerName in m_ProviderList)
            {
             RoleProvider rp = Roles.Providers[providerName];
             string[] roles = rp.GetAllRoles();
             foreach (string role in roles)
             {allRoles.Add(role);}
            }
            return allRoles.ToArray();
        }


        public override string[] GetRolesForUser(string username)
        {
            List<string> userRoles = new List<string>();
            foreach (string providerName in m_ProviderList)
            {
             RoleProvider rp = Roles.Providers[providerName];
             string[] roles = rp.GetRolesForUser(username);
             foreach (string role in roles)
             {
              if (!userRoles.Contains(role))
               userRoles.Add(role);
             }
            }
            return userRoles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {throw new NotImplementedException();}

        public override bool IsUserInRole(string username, string roleName)
        {throw new NotImplementedException();}

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {throw new NotImplementedException();}

        public override bool RoleExists(string roleName)
        {throw new NotImplementedException();}
    }
}
