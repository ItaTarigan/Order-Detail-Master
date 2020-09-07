using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BalitTanahPelayanan.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using BalitTanahPelayanan.Services;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        AccountService service { set; get; }
        public string ReturnUrl { get; set; }
        public async Task<IActionResult>
            OnGetAsync(string paramUsername, string paramPassword)
        {
            if (service == null) service  = new  AccountService();
            string returnUrl = Url.Content("~/");
            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            var message = "";
            // *** !!! This is where you would validate the user !!! ***
            bool isAuthenticate = true;
            isAuthenticate = service.IsValid(paramUsername,paramPassword);
            if (isAuthenticate)
            {
                var db = new smlpobDB();
                var data = (from x in db.Accounttbl
                            where x.Username == paramUsername
                            select x).FirstOrDefault();

                if (data != null && !string.IsNullOrEmpty(data.IsEmailVerified) && data.IsEmailVerified == "0")
                {

                    message = "User Anda belum di aktivasi, silahkan Cek E-mail atau sms inbox Anda untuk melakukan aktivasi.";
                    isAuthenticate = false;
                }
            }
            else
            {
                message = "Login gagal, silakan ketik username dan password yang benar.";
            }
            // In this example we just log the user in
            // (Always log the user in for this demo)
            if (isAuthenticate)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, paramUsername),
                    new Claim(ClaimTypes.Role, "Administrator"),
                    new Claim(ClaimTypes.Role, "Viewer")
                };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                try
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }

            if (!isAuthenticate) returnUrl = "/pages/public/login?result=false&message="+message;
            return LocalRedirect(returnUrl);
        }
    }
}
