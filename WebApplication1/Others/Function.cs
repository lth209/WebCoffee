using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Others
{
    public static class Function
    {
        public static Cart GetCartOfCurrentUser(String userid1)
        {
            using (Context context = new Context())
            {
                Cart res = new Cart();
                String useridstring = userid1;
                if (useridstring != null)
                {
                    int userid = int.Parse(useridstring);
                    var cart = context.Cart.Where(p => p.Matk == userid).FirstOrDefault() as Cart;
                    if (cart != null)
                    {
                        res = cart;
                    }
                }
                else
                {
                    res.Amount = 0;
                    res.Total = 0;
                }
                return res;
            }
        }

        public static Khachhang getCurrentUser(String uid)
        {
            if (String.IsNullOrEmpty(uid)) return null;
            int userid = int.Parse(uid);
            using(Context context = new Context())
            {
                var user = context.Khachhang.Where(p => p.Matk == userid).Single();
                return user;
            }
        }

        public static Boolean CheckRole(int id)
        {
            //int id = int.Parse(uid);
            using (Context context = new Context())
            {
                Users currentuser = context.Users.Where(p => p.Id == id).Single();
                if (currentuser.Maquyen == 2)   //Admin
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
