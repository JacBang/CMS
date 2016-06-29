using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 商品管理.Model;
using 商品管理.DAL;
using CMS.Model;

namespace CMS.BLL
{
    public static class ProductsBLL
    {
        public static List<Products> selectAll()
        {

            return ProductsDAL.selectAll();
        }
        public static bool  insert(Products list)
        {
            int count = ProductsDAL.insert(list);
            if (count >= 1)
                return true;
            else
                return false;

        }
        public static bool update(Products list)
        {
            int count = ProductsDAL.update(list);
            if (count >= 1)
                return true;
            else
                return false;
        }
        public static bool database(string id)
        {
            int count = ProductsDAL.database(id);
            if (count >= 1)
                return true;
            else
                return false;

        }
        public static List<Products> selectname(int leiid)
        {
            return ProductsDAL.selectname(leiid);

        }
        public static List<Products> selectjp(string jp)
        {
            return ProductsDAL.selectjp(jp);

        }
        public static Products select(int id)
        {
            return ProductsDAL.select(id);
        }
      
    }
}
