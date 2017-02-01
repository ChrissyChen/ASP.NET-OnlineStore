using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //get selected row
        GridViewRow row = grdProducts.Rows[e.NewEditIndex];

        //get ID of selected row
        int rowID = Convert.ToInt32(row.Cells[1].Text);

        //redirect user to ManageProducts with the selected rowID
        Response.Redirect("~/Pages/Management/ManageProducts.aspx?id=" + rowID);
    }
}