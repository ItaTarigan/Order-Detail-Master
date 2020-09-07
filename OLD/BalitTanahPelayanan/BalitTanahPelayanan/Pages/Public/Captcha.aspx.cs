using SRVTextToImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Public
{
    public partial class Captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CaptchaRandomImage CI = new CaptchaRandomImage();
            string captchatext = CI.GetRandomString(5);

            Session["CaptchaText"] = captchatext;
            CI.GenerateImage(captchatext, 200, 50, Color.DarkGray, Color.White);

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";
            CI.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            CI.Dispose();
        }
    }
}