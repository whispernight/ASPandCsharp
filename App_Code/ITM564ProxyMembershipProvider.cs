using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


/// <summary>
/// Summary description for ITM564PoxyMembershipProvider
/// </summary>
public class ITM564ProxyMembershipProvider : MembershipProvider
{
    private List<string> m_ProviderList = new List<string>();
    private MembershipProvider currentProvider;

    public ITM564ProxyMembershipProvider()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
        if (config["providerList"] != null)
        {
            char[] cSplitchars = { ',' };
            string[] providers = config["providerList"].ToString().Split(cSplitchars);
            foreach (string providerName in providers)
                m_ProviderList.Add(providerName);
            config.Remove("providerList");
        }
        base.Initialize(name, config);
    }

    public override string ApplicationName
    {
        get
        {
            return "ITM564";
        }
        set
        {throw new NotImplementedException();}
    }

    public override bool ChangePassword(string username, string oldPassword, string newPassword)
    {throw new NotImplementedException();}

    public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
    {throw new NotImplementedException();}

    public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {throw new NotImplementedException();}

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {throw new NotImplementedException();}

    public override bool EnablePasswordReset
    {get {throw new NotImplementedException();}}

    public override bool EnablePasswordRetrieval
    {get {throw new NotImplementedException();}}

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {throw new NotImplementedException();}

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {throw new NotImplementedException();}

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
        List<MembershipUserCollection> mucs = new List<MembershipUserCollection>();
        foreach (string providerName in m_ProviderList)
        {
            MembershipProvider mp = Membership.Providers[providerName];
            mucs.Add(mp.GetAllUsers(pageIndex, pageSize, out totalRecords));
        }
        MembershipUserCollection allUsers = new MembershipUserCollection();
        totalRecords = 0;

        List<string> userNames = new List<string>();

        foreach (MembershipUserCollection muc in mucs)
        {
            foreach (MembershipUser mu in muc)
            {
                if (!(userNames.Contains(mu.UserName)))
                {
                    userNames.Add(mu.UserName);
                    allUsers.Add(mu);
                    totalRecords++;
                }
            }
        }
        return allUsers;
    }

    public override int GetNumberOfUsersOnline()
    {throw new NotImplementedException();}

    public override string GetPassword(string username, string answer)
    {throw new NotImplementedException();}

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {throw new NotImplementedException();}

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {throw new NotImplementedException();}

    public override string GetUserNameByEmail(string email)
    {throw new NotImplementedException();}

    public override int MaxInvalidPasswordAttempts
    {get { throw new NotImplementedException(); }}

    public override int MinRequiredNonAlphanumericCharacters
    {get { throw new NotImplementedException(); }}

    public override int MinRequiredPasswordLength
    {get { throw new NotImplementedException(); }}

    public override int PasswordAttemptWindow
    {get { throw new NotImplementedException(); }}

    public override MembershipPasswordFormat PasswordFormat
    { get { throw new NotImplementedException(); }}

    public override string PasswordStrengthRegularExpression
    {get { throw new NotImplementedException(); }}

    public override bool RequiresQuestionAndAnswer
    {get { throw new NotImplementedException(); }}

    public override bool RequiresUniqueEmail
    {get { throw new NotImplementedException(); }}

    public override string ResetPassword(string username, string answer)
    {throw new NotImplementedException();}

    public override bool UnlockUser(string userName)
    {throw new NotImplementedException();}

    public override void UpdateUser(MembershipUser user)
    {throw new NotImplementedException();}

    public override bool ValidateUser(string username, string password)
    {
        foreach (string providerName in m_ProviderList)
        {
            MembershipProvider mp = Membership.Providers[providerName];
            if (mp.ValidateUser(username, password))
            {return true;}
        }
        return false;
    }
}