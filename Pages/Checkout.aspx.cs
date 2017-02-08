using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CompleteCheckout();
    }

    private void CompleteCheckout()
    {
        //remove bought items from cart
        List<Cart> carts = (List<Cart>)Session[User.Identity.GetUserId()];

        CartModel model = new CartModel();
        model.MarkOrderAsPaid(carts);

        Session[User.Identity.GetUserId()] = null;
    }
}