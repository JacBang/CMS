using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 商品消费查询.Model;
using System.Data.SqlClient;
using CMS.DAL;


namespace CMS.DAL
{
   public static  class CDDAL
    {
       /// <summary>
       /// 查询全部
       /// </summary>
       /// <returns></returns>
       public static List<ConsumerDetails> Select(string sj,string sji)
       {
           List<ConsumerDetails> list = new List<ConsumerDetails>();
           string sql = string.Format(@"select  d.TableName,b.ProductName ,a.CDPrice,a.CDAmount,a.CDDate from ConsumerDetail
           a inner join Products b on a.ProdcutID=b.ProductID inner join ConsumerBill c on  a.CBID=c.CBID
           inner join Tables d on c.TableID=d.TableID  where CDDate  between cast(@sj as datetime) and cast(@sji as datetime)
              order by a.CDDate desc
            ");
           SqlParameter[] sps = new SqlParameter[]
           {
               new SqlParameter ("@sj",sj ),
               new SqlParameter ("@sji",sji )
           };
           SqlDataReader sdr = CMS.DAL.DBHelper.ExecuteReader(sql,sps );
           while (sdr.Read ())
           {
               ConsumerDetails cd = new ConsumerDetails();
               //cd.CDID = Convert.ToInt32(sdr["CDID"]);
               //cd.CBID = sdr["CBID"].ToString();
               //cd.ProdcutID = Convert.ToInt32(sdr["ProdcutID"]);
               cd.CDPrice = Convert.ToInt32(sdr["CDPrice"]);
               cd.CDAmount = Convert.ToInt32(sdr["CDAmount"]);
               //cd.CDSale = Convert.ToInt32(sdr["CDSale"]);
               //cd.CDMoney = Convert.ToInt32(sdr["CDMoney"]);
               //cd.CDType = Convert.ToInt32(sdr["CDType"]);
               cd.CDDate = sdr["CDDate"].ToString ();
               cd.Tname = sdr["TableName"].ToString();
               cd.Pname = sdr["ProductName"].ToString();
               list.Add(cd );
           }
           sdr.Close();
           return list;
       }

       /// <summary>
       /// 根据餐台号查询
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       public static List<ConsumerDetails> SelectbyTname(string sj,string sji,string name)
       {
           List<ConsumerDetails> list = new List<ConsumerDetails>();
           string sql = string .Format (@"select  d.TableName   ,b.ProductName ,a.CDPrice,a.CDAmount,a.CDDate   from    
ConsumerDetail   a  inner join Products b   on a.ProdcutID=b.ProductID   
inner join ConsumerBill c on  a.CBID=c.CBID inner join Tables d on  
c.TableID=d.TableID where CDDate  between cast(@sj as datetime) and cast(@sji as datetime)
and  d.TableName like  '%'+@TableName+'%'   order by a.CDDate desc");
           SqlParameter[] sps = new SqlParameter[]
           {
               new SqlParameter ("@sj",sj ),
               new SqlParameter ("@sji",sji ),
             new SqlParameter ("@TableName",name)
           };
           SqlDataReader sdr = DBHelper.ExecuteReader(sql,sps );
           while (sdr.Read()) 
           {
               ConsumerDetails cd = new ConsumerDetails();
               cd.CDPrice = Convert.ToInt32(sdr["CDPrice"]);
               cd.CDAmount = Convert.ToInt32(sdr["CDAmount"]);
               cd.CDDate = sdr["CDDate"].ToString();
               cd.Tname = sdr["TableName"].ToString();
               cd.Pname = sdr["ProductName"].ToString();
               list.Add(cd);
           }
           sdr.Close();
           return list;
       }

       /// <summary>
       /// 根据消费项目查询
       /// </summary>
       /// <param name="names"></param>
       /// <returns></returns>
       public static List<ConsumerDetails> SelectbyPname(string sj,string sji,string names)
       {
           List<ConsumerDetails> list = new List<ConsumerDetails>();
           string sql = string.Format (@"select  d.TableName   ,b.ProductName ,a.CDPrice,a.CDAmount,a.CDDate   from  
           ConsumerDetail   a  inner join Products b   on a.ProdcutID=b.ProductID   inner join ConsumerBill c on 
               a.CBID=c.CBID inner join Tables d on  c.TableID=d.TableID where  CDDate  between cast(@sj as datetime) and cast(@sji as datetime)  
      and ProductName  like  '%'+@Pname+'%'  order by a.CDDate desc");
           SqlParameter[] sps = new SqlParameter[]
           {
               new SqlParameter ("@sj",sj ),
               new SqlParameter ("@sji",sji ),
             new SqlParameter ("@Pname",names)
           };
           SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
           while (sdr.Read())
           {
               ConsumerDetails cd = new ConsumerDetails();
               cd.CDPrice = Convert.ToInt32(sdr["CDPrice"]);
               cd.CDAmount = Convert.ToInt32(sdr["CDAmount"]);
               cd.CDDate = sdr["CDDate"].ToString();
               cd.Tname = sdr["TableName"].ToString();
               cd.Pname = sdr["ProductName"].ToString();
               list.Add(cd);
           }
           sdr.Close();
           return list;
       }
       /// <summary>
       /// 查询指定账单的消费信息
       /// </summary>
       /// <returns></returns>
       public static List<ConsumerDetails> SelectX(String cbid)
       {
           String Sql=@"select a.CDID,b.ProductName,b.ProductPrice,a.CDAmount,a.CDMoney,a.CDDate
 from ConsumerDetail a inner join Products b 
on a.ProdcutID=b.ProductID where CDType=0 and CBID=@cbid";
           SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@cbid",cbid)};
           SqlDataReader sdr = DBHelper.ExecuteReader(Sql, Sps);
           List<ConsumerDetails> list=new List<ConsumerDetails>();
           while (sdr.Read())
           {
               ConsumerDetails c = new ConsumerDetails();
               c.CDID=int.Parse(sdr["CDID"].ToString());
               c.ProName = sdr["ProductName"].ToString();
               c.CDPrice = int.Parse(sdr["ProductPrice"].ToString());
               c.CDAmount = int.Parse(sdr["CDAmount"].ToString());
               c.CDMoney = int.Parse(sdr["CDMoney"].ToString());
               c.CDDate=sdr["CDDate"].ToString();

               list.Add(c);
           }
           sdr.Close();
           return list;
       }
       /// <summary>
       /// 添加消费详单
       /// </summary>
       /// <param name="c"></param>
       /// <returns></returns>
       public static int Insert(ConsumerDetails c)
       {
           String Sql = "insert into ConsumerDetail values(@cbid,@proid,@price,@amount,@sale,@money,@type,@date)";
           SqlParameter[] Sps = new SqlParameter[]
           {
               new SqlParameter("@cbid",c.CBID),
               new SqlParameter("@proid",c.ProdcutID),
               new SqlParameter("@price",c.CDPrice),
               new SqlParameter("@amount",c.CDAmount),
               new SqlParameter("@sale",c.CDSale),
               new SqlParameter("@money",c.CDMoney),
               new SqlParameter("@type",c.CDType),
               new SqlParameter("@date",c.CDDate)
           };
           return DBHelper.ExecuteNonQuery(Sql, Sps);
       }

       /// <summary>
       /// 修改消费类型
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static int Update(String id)
       {
           String Sql = "update ConsumerDetail set CDType=1 where CDID=@id";
           SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@id",id)};
           return DBHelper.ExecuteNonQuery(Sql,Sps);
       }
    }
}
