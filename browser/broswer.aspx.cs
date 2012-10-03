//browser
//Version 2.0
//A simple recursive directory browser
//Presists folder open and close infomation in a session string not too painfull

using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class fileBrowser : System.Web.UI.Page {
		
		protected System.Web.UI.WebControls.Label Top;
        protected System.Web.UI.WebControls.Label lblDirectories, lblFiles;
		protected System.Web.UI.WebControls.Label msg;
		protected System.Web.UI.WebControls.Button Reset;
		public HtmlGenericControl   Files;
		
		public static string strAppPath = System.Web.HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"].ToString();
        public static string strVirtDir = System.Web.HttpContext.Current.Request.ServerVariables["PATH_INFO"].ToString();
        string strScriptName = System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
        string strVirtDirNoFileName = System.Web.HttpContext.Current.Request.ServerVariables["PATH_INFO"].ToString().Replace(strVirtDir,"");
        
        
        //const string basePath = @"g:";
        
        public static string [] arySplit = strAppPath.Split(new Char [] {':'});
        string basePath = arySplit[0] + ":";
		string startPath = arySplit[1];
		string currentDir;
		
		void Page_Load(object sender, System.EventArgs e)
		{
            //new
            //msg.Text = "new:<br>";
            String strBaseFolder = "/";

            //Get current path from url
            string strCurrentPath = "";
            if (!(Request["f"]==null))
                strCurrentPath = Request["f"].Replace("..", "");

            //Split the currentpath
            string[] PathArray = strCurrentPath.Split('/');
            //msg.Text += "PathArray:" + PathArray.Length;

            string strCurrentFolder = strBaseFolder;

            string strNextFolder = "";
            int Indent = 0;

            //add a slash to path but only after zero index
            if (Indent > 1)
                strCurrentFolder += "/";

            strCurrentFolder += PathArray[Indent];
            if (Indent + 1 < PathArray.Length)
                strNextFolder += PathArray[Indent + 1];

            ArrayList FullDirectoryList = new ArrayList();
            for (int i = 0; i < PathArray.Length; i++)
            {
                Indent = i;

                strCurrentFolder += PathArray[i] + "/";
                strCurrentFolder = strCurrentFolder.Replace("//", "/");

                ArrayList al = GetDirListArrayList(MakeRealPathFromfandBase(strAppPath, strCurrentFolder), strScriptName, strCurrentFolder, Indent);
            
                if (al == null)
                {
                    Response.Write("Sorry");
                    Response.End(); 
                }
                foreach (string strDir in al)
                {
                    //msg.Text += "<br />" + strDir.ToString();
                    FullDirectoryList.Add(strDir.ToString());
                }

            }

            FullDirectoryList.Sort();
            foreach (string strDir in FullDirectoryList)
            {
                string currentDir = strDir.ToString();
                
                string[] slashCount = currentDir.Split('/');
                int intSlashes = slashCount.Length;

                //Make indent
                
                string strIndent = MakeIndentString(intSlashes-2);

                //Make link
                string strLink = "<img src=\"images\\dir_dir.gif\">&nbsp;" ;
                if (strCurrentPath == currentDir)
                {
                    strLink = "<img src=\"images\\OF.gif\">&nbsp;" ;
                }
                strLink += "<a href=\"" + strScriptName + "?f=" + currentDir + "\">" + currentDir + "</a>";
                    
                //Display Link
                lblDirectories.Text += "<br />" + strIndent + strLink; 

                
            }
            //Display Files
            string realPath = MakeRealPathFromfandBase(strAppPath,strCurrentFolder);
            ArrayList fl = GetFiles(realPath);
            //lblFiles.Text += realPath;
            foreach (string fileName in fl)
            {
                lblFiles.Text += "<br />" + MakeLink(fileName, strCurrentFolder);
            }

        
		}

    private ArrayList GetFiles(string openPath)
    {
        ArrayList fl = new ArrayList();
        
        string FileNames = "";

        FileInfo fiParent = new FileInfo(openPath);
        FileInfo fi;

        string[] files = Directory.GetFiles(openPath);
        FileAttributes faParent = fiParent.Attributes;

        for (int i = 0; i < files.GetUpperBound(0) + 1; i++)
        {
            fi = new FileInfo(files[i]);
            fl.Add(fi.Name);
        }
        
        return fl;
    }

    private string MakeLink(string strFileName, string virtPath)
    {
        string newLink = "";
        string extension = "";
        string csPath;
        string icon = "images/dir_misc.gif";

        //Split at all . to find last extension
        string[] ExtensionArray = strFileName.Split('.');
        extension = ExtensionArray[ExtensionArray.GetUpperBound(0)];
        switch (extension)
        {

            case "il":
            case "c":
            case "cpp":
            case "java":
            case "pl":
            case "asax":
            case "ascx":
            case "vb":
            case "cs":
            case "bat":
            case "sql":
            case "inc":
            case "txt":
            case "xml":
                icon = "images/dir_txt.gif";
                newLink = "<img src=\"" + icon + "\" border = \"0\">&nbsp;";
                newLink += "<a href='../gbrowser.php?file=" + virtPath + strFileName + "'>" + strFileName + " - source</a>";
                break;

            
            case "asp":
            case "htm":
            case "html":
            case "aspx":
            case "css":
            case "php":
                icon = "images/dir_htm.gif";
                newLink = "<img src=\"" + icon + "\" border = \"0\">&nbsp;";
                newLink += "<a href='.." + virtPath + strFileName + "'>" + strFileName + "</a>&nbsp;";
                newLink += "<a href='../gbrowser.php?file=" + virtPath + strFileName + "'>- source</a>";
                break;

            case "jpeg":
            case "png":
            case "gif":
                icon = "images/dir_img.gif";
                newLink = "<img src=\"" + icon + "\" border = \"0\">&nbsp;";
                newLink += "<a href='.." + virtPath + strFileName + "'>" + strFileName + "</a>&nbsp;";
                
                break;
            
            case "zip":
            case "gz":
            case "z":
                icon = "images/dir_zip.gif";
                newLink = "<img src=\"" + icon + "\" border = \"0\">&nbsp;";
                newLink += "<a href='.." + virtPath + strFileName + "'>" + strFileName + "</a>&nbsp;";
                
                break;
            case "pdf":
                icon = "images/dir_pdf.gif";
                newLink = "<img src=\"" + icon + "\" border = \"0\">&nbsp;";
                newLink += "<a href='.." + virtPath + strFileName + "'>" + strFileName + "</a>&nbsp;";
                
                break;
                
            
            default:
                newLink = strFileName;
                break;
        }
        return newLink;
    }
    
    
    string MakeIndentString(int NumberOfIndents)
    {
        string strReturn = "";
        string strIndent = "|&nbsp;&nbsp;";
        //string strIndent = "bahh";
        for (int i = 0; i < NumberOfIndents; i++)
        {
            strReturn += strIndent;
        }
        return strReturn;
    }
    
    string MakeRealPathFromfandBase(string strAppPath, string strCurrentFolder)
    {
        string realPath;
        
        realPath = strAppPath + strCurrentFolder.Replace("/", "\\");
        realPath = realPath.Replace("\\\\", "\\");

        return realPath;
    }

    public ArrayList GetDirListArrayList(string strAppPath, string strScriptName, string strBaseFolder, int Indent)
    {

        Array aryCurentFolders = GetDirectoryInfoArray(strAppPath);
        ArrayList aryCurrentFolderNames = GetDirectoryNamesArray((DirectoryInfo[])aryCurentFolders, strBaseFolder);
        return aryCurrentFolderNames;
    }

    public ArrayList GetDirectoryNamesArray(DirectoryInfo[] di, string strBaseFolder)
    {
        if (di == null)
            return null;
        
        ArrayList aryDirNames = new ArrayList();
        string strFolderName;
        
        foreach (DirectoryInfo dri in di)
        {
            if (dri.Name.IndexOf("private") != -1)
                continue;

            strFolderName = strBaseFolder + Server.UrlEncode(dri.Name);
            aryDirNames.Add(strFolderName);
        }
        return aryDirNames;
    }


        public Array GetDirectoryInfoArray(string strPath)
        {
            // make a reference to a directory
            try
            {
                DirectoryInfo di = new DirectoryInfo(strPath);
                // get a reference to each directory in that directory
                DirectoryInfo[] diArr = di.GetDirectories();
                return diArr;
            }
            catch
            {
                
                return null;
            }

            
        }

    
        public void reset(object sender, System.EventArgs e)
		{
			Session.Clear();
			Response.Redirect("browser.aspx");
		}
		
		
}