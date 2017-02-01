﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            GetImages();
    }
    private void GetImages()
    {
        try
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/StarterPack/Images/Products/"));
            ArrayList imageList = new ArrayList();
            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }
            ddlImage.DataSource = imageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();
        }
        catch(Exception ex)
        {
            lblResult.Text = ex.ToString();
        }
    }

    private Product CreateProduct()
    {
        Product p = new Product();
        p.Name = txtName.Text;
        p.Price = Convert.ToInt32(txtPrice.Text);
        p.TypeId = Convert.ToInt32(ddlType.SelectedValue);
        p.Description = txtDescription.Text;
        p.Image = ddlImage.SelectedValue;

        return p;

    }

    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        ProductModel model = new ProductModel();
        Product product = CreateProduct();
        lblResult.Text = model.InsertProduct(product);
    }
}