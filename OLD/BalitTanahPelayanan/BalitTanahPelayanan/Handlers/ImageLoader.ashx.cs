using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BalitTanahPelayanan.Handlers
{
    /// <summary>
    /// Summary description for ImageLoader
    /// </summary>
    public class ImageLoader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var pathStr = context.Request.QueryString["ImgPath"];
            if (!string.IsNullOrEmpty(pathStr) && File.Exists(pathStr))
            {
                var bytesData = File.ReadAllBytes(pathStr);
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(bytesData);

            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Image not found");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}