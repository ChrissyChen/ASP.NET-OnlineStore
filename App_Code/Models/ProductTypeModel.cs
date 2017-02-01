using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeModel
/// </summary>
public class ProductTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();
            return productType.Name + " was succesfully inserted to db";
        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }
    }

    public string UpdateProductTypes(int id, ProductType productType)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            ProductType p = db.ProductTypes.Find(id);
            p.Name = productType.Name;

            db.SaveChanges();
            return productType.Name + " was succesfully updated";

        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }


    }

    public string DeleteProductTypes(int id)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            ProductType p = db.ProductTypes.Find(id);

            db.ProductTypes.Attach(p);
            db.ProductTypes.Remove(p);
            db.SaveChanges();

            return p.Name + " was succesfully deleted from db";

        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }

    }
}