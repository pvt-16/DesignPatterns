using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Clicked(object sender, EventArgs e)
        {
            // Generate Authentication Token and send it to the browser with the response
            // as part of the Session Cookie
            FormsAuthentication.SetAuthCookie(Username.Text, false);
        }

    }
}