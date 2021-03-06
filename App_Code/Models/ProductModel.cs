﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return product.Name + " was succesfully inserted to db";
        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }
    }

    public string UpdateProduct(int id, Product product)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            Product p = db.Products.Find(id);
            p.Name = product.Name;
            p.Price = product.Price;
            p.TypeId = product.TypeId;
            p.Description = product.Description;
            p.Image = product.Image;

            db.SaveChanges();
            return product.Name + " was succesfully updated";

        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }


    }

    public string DeleteProduct(int id)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            Product p = db.Products.Find(id);

            db.Products.Attach(p);
            db.Products.Remove(p);
            db.SaveChanges();

            return p.Name + " was succesfully deleted from db";

        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }

    }


    public Product GetProduct(int id)
    {
        try
        {
            using (OnlineShopDBEntities db = new OnlineShopDBEntities())
            {
                Product product = db.Products.Find(id);
                return product;
            }
        }
        catch (Exception)
        {

            return null;
        }
    }


    public List<Product> GetAllProducts()
    {
        try
        {
            using (OnlineShopDBEntities db = new OnlineShopDBEntities())
            {
                List<Product> products = (from x in db.Products
                                          select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {

            return null;
        }
    }

    public List<Product>GetProductsByType(int typeID)
    {
        try
        {
            using (OnlineShopDBEntities db = new OnlineShopDBEntities())
            {
                List<Product> products = (from x in db.Products
                                          where x.TypeId == typeID
                                          select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }


    }
}