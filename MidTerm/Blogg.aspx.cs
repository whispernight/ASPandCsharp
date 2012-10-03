using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using IITCourse.Blog;


public partial class MidTerm_Blogg : System.Web.UI.Page
{
    MembershipUser _muc;
    List<IITCourse.Blog.Blog> _blogs;
    Label _labelNoOfResponses;
    protected void Page_Load(object sender, EventArgs e)
    {
        _muc = Membership.GetUser();
        _blogs = new List<IITCourse.Blog.Blog>();
        _labelNoOfResponses = (Label)ListViewBlogs.FindControl("labelNoOfResponses");
        if (!(IsPostBack))
        {
            _blogs = BlogService.GetBlogs();
            ListViewBlogs.DataSource = _blogs;
            ListViewBlogs.DataBind();
            List<string> dropDownItemToAdd = BlogService.GetNamesOfAllUser();

            dropDownItemToAdd.Insert(0, "All Users");
            ddUsers.DataSource = dropDownItemToAdd;
            ddUsers.DataBind();
        }
    }

    protected void ButtonPostBlog_Click(object sender, EventArgs e)
    {
        IITCourse.Blog.Blog blog = new Blog();
        TextBox Mood = ((TextBox)LoginViewPostBlog.FindControl("TextBoxMood"));

        TextBox Description = ((TextBox)LoginViewPostBlog.FindControl("TextBoxDescription"));
        blog.Mood = Mood.Text;
        blog.Description = Description.Text;
        BlogService.AddBlog(blog);
        _blogs.Clear();
        _blogs = BlogService.GetBlogs();
        ListViewBlogs.DataSource = _blogs;
        ListViewBlogs.DataBind();
        Mood.Text = string.Empty;
        Description.Text = string.Empty;

    }

    protected void ddUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        HyperLink hyperLinkEditBlog = (HyperLink)ListViewBlogs.FindControl("HyperLinkEditBlog");
        List<IITCourse.Blog.Blog> blogs = new List<IITCourse.Blog.Blog>();
        if (ddUsers.SelectedValue == "All Users")
        {blogs = BlogService.GetBlogs();}
        else
        {
            if (Roles.GetRolesForUser(ddUsers.SelectedValue).Contains("Admin"))
            {hyperLinkEditBlog.Visible = true;}
            else
                blogs = BlogService.GetUserSpecificBlogs(ddUsers.SelectedValue);
        }

        ListViewBlogs.DataSource = blogs;
        ListViewBlogs.DataBind();
    }

    protected void ListViewBlogs_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        HyperLink hyperLinkEditBlog = (HyperLink)e.Item.FindControl("HyperLinkEditBlog");
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label bogID = (Label)e.Item.FindControl("labelBlogID");
            if (Roles.GetRolesForUser().Contains("admin"))
            {hyperLinkEditBlog.Visible = true;}
            if (_muc != null)
            {
                Label author = (Label)e.Item.FindControl("labelAuthor");
                if (Membership.GetUser().UserName == author.Text)
                {hyperLinkEditBlog.Visible = true;}
            }
            else
            {hyperLinkEditBlog.Visible = false;}

            List<BlogResponse> blogResponses = BlogService.GetBlogResponses(Int32.Parse(bogID.Text));
            Label labelNoOfResponses = (Label)e.Item.FindControl("labelNoOfResponses");
            labelNoOfResponses.Text = blogResponses.Count.ToString();
            LinkButton linkButtonToggleListViewResponse = (LinkButton)e.Item.FindControl("LinkButtonToggleListViewResponse");
            if (blogResponses.Count > 0)
            {linkButtonToggleListViewResponse.Visible = true;}
            else
            {linkButtonToggleListViewResponse.Visible = false;}
            ListView listViewRespones = (ListView)e.Item.FindControl("ListViewResponses");
            listViewRespones.DataSource = blogResponses;
            listViewRespones.DataBind();

        }
    }

    protected void ListViewBlogs_ItemCommand(object sender, ListViewCommandEventArgs e)
    {

        if (e.CommandName == "PostResponse")
        {
            TextBox response = (TextBox)e.Item.FindControl("TextBoxResponse");
            Label labelResponseErr = (Label)e.Item.FindControl("labelResponseErr");
            if (!(response.Text == string.Empty))
            {
                BlogResponse newResponse = new BlogResponse();
                newResponse.ResponseText = response.Text;
                newResponse.BlogID = Int32.Parse(e.CommandArgument.ToString());
                BlogService.PostBlogResponse(newResponse);
                List<BlogResponse> blogResponses = new List<BlogResponse>();
                blogResponses = BlogService.GetBlogResponses(newResponse.BlogID);
                Label labelNoOfResponses = (Label)e.Item.FindControl("labelNoOfResponses");
                labelNoOfResponses.Text = blogResponses.Count.ToString();
                LinkButton linkButtonToggleListViewResponse = (LinkButton)e.Item.FindControl("LinkButtonToggleListViewResponse");
                ListView listViewRespones = (ListView)e.Item.FindControl("ListViewResponses");
                if (blogResponses.Count > 0)
                {
                    linkButtonToggleListViewResponse.Visible = true;
                    listViewRespones.Visible = true;
                }
                listViewRespones.DataSource = blogResponses;
                listViewRespones.DataBind();
                response.Text = string.Empty;
                labelResponseErr.Visible = false;
            }
            else
                labelResponseErr.Visible = true;
        }
        else if (e.CommandName == "ToggleListViewResponse")
        {
            ListView listViewResponses = (ListView)e.Item.FindControl("ListViewResponses");
            if (listViewResponses.Visible == true)
            {listViewResponses.Visible = false;}
            else
            {listViewResponses.Visible = true;}
        }
 
    }

    protected void ListViewResponses_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        LinkButton hyperLinkDeleteBlogResponse = (LinkButton)e.Item.FindControl("LinkButtonDeleteResponse");
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label bogResponseID = (Label)e.Item.FindControl("labelResponseID");//check usage
            if (Roles.GetRolesForUser().Contains("admin"))
            {
                hyperLinkDeleteBlogResponse.Visible = true;
            }
            if (_muc != null)
            {
                Label author = (Label)e.Item.FindControl("labelAuthor");
                if (Membership.GetUser().UserName == author.Text)
                {
                    hyperLinkDeleteBlogResponse.Visible = true;
                }
            }
            else
            {
                hyperLinkDeleteBlogResponse.Visible = false;
            }
        }
    }

    protected void ListViewResponses_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteResponse")
        {
            BlogResponse newResponse = new BlogResponse();
            Label blogResponseID = (Label)e.Item.FindControl("labelResponseID");
            var blogResponseToDelete = BlogService.GetBlogResponse(Int32.Parse(blogResponseID.Text));
            var blogId = blogResponseToDelete.BlogID;
            var result = BlogService.DeleteBlogResponse(blogResponseToDelete);
            if (result == true)
            {
                List<BlogResponse> blogResponses = BlogService.GetBlogResponses(blogId);
                ListView listViewRespones = (ListView)sender;
                listViewRespones.DataSource = blogResponses;
                listViewRespones.DataBind();
                string index = listViewRespones.ClientID.Split('_').Last();
                Label labelNoOfResponses = (Label)ListViewBlogs.Items[Int32.Parse(index)].FindControl("labelNoOfResponses");
                labelNoOfResponses.Text = blogResponses.Count.ToString();
                LinkButton linkButtonToggleListViewResponse = (LinkButton)ListViewBlogs.Items[Int32.Parse(index)].FindControl("LinkButtonToggleListViewResponse");
                if (blogResponses.Count > 0)
                    linkButtonToggleListViewResponse.Visible = true;
                else
                    linkButtonToggleListViewResponse.Visible = false;
            }
            else
            {
            };
        }
    }

    bool DoSelectDataItem(ListViewDataItem item)
    {
        return item.DisplayIndex == 0; // selects the first item in the list (this is just an example after all; keeping it simple :D )
    }


}