using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfoModel
/// </summary>
public class UserInfoModel
{
    public UserInformation GetUserInformation(string guID)
    {
        OnlineShopDBEntities db = new OnlineShopDBEntities();
        UserInformation info = (from x in db.UserInformations
                                where x.GUID == guID
                                select x).FirstOrDefault();
        return info;
    }

    public void InsertUserInformation(UserInformation info)
    {
        OnlineShopDBEntities db = new OnlineShopDBEntities();
        db.UserInformations.Add(info);
        db.SaveChanges();
    }
}