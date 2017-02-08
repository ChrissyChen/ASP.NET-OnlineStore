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

    public List<Cart> GetOrdersInCart(string userId)
    {
        OnlineShopDBEntities db = new OnlineShopDBEntities();
        List<Cart> orders = (from x in db.Carts
                             where x.ClientID == userId
                             && x.IsInCart
                             orderby x.DatePurchased
                             select x).ToList();

        return orders;
    }

    public int GetAmountOfOrders(string userId)
    {
        try
        {
            OnlineShopDBEntities db = new OnlineShopDBEntities();
            int amount = (from x in db.Carts
                          where x.ClientID == userId
                          && x.IsInCart
                          select x.Amount).Sum();

            return amount;
        }
        catch 
        {

            return 0;
        }
    }

    public void UpdateQuantity(int id, int quantity)
    {
        OnlineShopDBEntities db = new OnlineShopDBEntities();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;

        db.SaveChanges();
    }

    public void MarkOrderAsPaid(List<Cart> carts)
    {
        OnlineShopDBEntities db = new OnlineShopDBEntities();

        if(carts!= null)
        {
            foreach(Cart cart in carts)
            {
                Cart oldCart = db.Carts.Find(cart.ID);
                oldCart.DatePurchased = DateTime.Now;
                oldCart.IsInCart = false;
            }

            db.SaveChanges();
        }
    }
}