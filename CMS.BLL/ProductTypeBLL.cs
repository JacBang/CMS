using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 商品管理.Model;
using 商品管理.DAL;

namespace CMS.BLL
{
  public static   class ProductTypeBLL
    {
        public static List<ProductType> selectall()
        {

            return ProductTypeDAL.selectall();
        }
        public static bool insert(string  name)
        {
            int b = ProductTypeDAL.insert(name);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;

        }
        public static bool update(string id,string name)
        {
            int b = ProductTypeDAL.update(id,name);
            if (b >= 1)
            {
                return true;

            }
            else
                return false;

        }
        public static bool database(string id)
        {
            int b = ProductTypeDAL.database(id);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        
        }
      
    }
}
