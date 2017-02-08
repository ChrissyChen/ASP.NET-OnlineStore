using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            db.Carts.Add(cart);
            db.SaveChanges();
            return "Order was succesfully inserted";
        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            Cart p = db.Carts.Find(id);
            p.DatePurchased = cart.DatePurchased;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;
            p.ClientID = cart.ClientID;
            p.ProductID = cart.ProductID;

            db.SaveChanges();
            return cart.DatePurchased + " was succesfully updated";

        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }


    }

    public string DeleteCart(int id)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            Cart cart = db.Carts.Find(id);

            db.Carts.Attach(cart);
            db.Carts.Remove(cart);
            db.SaveChanges();

            return cart.DatePurchased + " was succesfully deleted from db";

        }
        catch (Exception ex)
        {
            return "Error: " + ex;
        }

    }
}