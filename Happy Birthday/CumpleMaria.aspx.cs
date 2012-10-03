using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Happy_Birthday_Default : System.Web.UI.Page
{

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static AjaxControlToolkit.Slide[] GetSlides()
    {
        AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[7];

        imgSlide[0] = new AjaxControlToolkit.Slide("Images/Cumple1.JPG", "Cumple1", "Cumple1");
        imgSlide[1] = new AjaxControlToolkit.Slide("Images/Cumple2.JPG", "Cumple2", "Cumple2");
        imgSlide[2] = new AjaxControlToolkit.Slide("Images/Cumple3.JPG", "Cumple3", "Cumple3");
        imgSlide[3] = new AjaxControlToolkit.Slide("Images/Cumple4.JPG", "Cumple4", "Cumple4");
        imgSlide[4] = new AjaxControlToolkit.Slide("Images/Cumple5.JPG", "Cumple5", "Cumple5");
        imgSlide[5] = new AjaxControlToolkit.Slide("Images/Cumple6.JPG", "Cumple6", "Cumple6");
        imgSlide[6] = new AjaxControlToolkit.Slide("Images/Cumple7.JPG", "Cumple7", "Cumple7");
       
        return (imgSlide);
    }
}