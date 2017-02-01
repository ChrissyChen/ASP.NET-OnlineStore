using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_StartPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //Get a list of all products from db
        ProductModel productModel = new ProductModel();
        List<Product> products = productModel.GetAllProducts();

        //check if products exists in db 
        if (products != null)
        {
            //create a new Panel with ImageButton and 2 labels for products
            foreach(Product product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //set controls 
                imageButton.ImageUrl ="~/StarterPack/Images/Products/"+ product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.ID;

                lblPrice.Text = "$ " + product.Price;
                lblPrice.CssClass = "productPrice";

                lblName.Text = product.Name;
                lblName.CssClass = "productName";

                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal { Text = "<br />" });
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal { Text = "<br /" });
                productPanel.Controls.Add(lblPrice);

                pnlProducts.Controls.Add(productPanel);

            }
        }
        else
        {
            pnlProducts.Controls.Add(new Literal { Text = "No products found!" });
        }
    }
}