using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CMS.Model;

namespace CMS.DAL
{
    public static class VipsDAL
    {
        /// <summary>
        /// 会员折扣查询
        /// </summary>
        /// <returns></returns>
        public static object SelectCBD(String id)
        {
            String Sql = "select b.VGDiscount from Vips a inner join VipGrade b on a.GradeID=b.VGID where VipID=@id";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@id",id)};
            return DBHelper.ExecuteScalar(Sql, Sps);
        }

        /// <summary>
        /// 检索会员是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SqlDataReader SelectID(String id)
        {
            String Sql = "select * from Vips where VipID=@id";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@id",id)};
            return DBHelper.ExecuteReader(Sql, Sps);
        }



        public static List<VipGrade> selectvip()
        {
            List<VipGrade> vip = new List<VipGrade>();
            string sql = "select * from VIPGrade";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, null);
            while (sdr.Read())
            {
                VipGrade v = new VipGrade();
                v.VGID = Convert.ToInt32(sdr["VGID"].ToString());
                v.VGName = sdr["VGName"].ToString();
                v.VGDiscount = Convert.ToDouble(sdr["VGDiscount"].ToString());

                vip.Add(v);
            }
            sdr.Close();
            return vip;

        }
        public static int insert(string jiname, string zhe)
        {
            string sql = "insert into  VIPGrade  values(@jiname,@zhe)";
            SqlParameter[] sps = new SqlParameter[]
            {
            new SqlParameter("@jiname", jiname),
            new SqlParameter("@zhe",zhe)
            
            };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;

        }
        public static int update(VipGrade list)
        {

            string sql = "update VIPGrade set VGName=@hui ,VGDiscount=@zhe where VGID=@id";
            SqlParameter[] sps = new SqlParameter[]
            {
            new SqlParameter ("@hui",list.VGName),
            new SqlParameter("@zhe",list.VGDiscount ),
            new SqlParameter("@id", list.VGID)
            
            };

            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;


        }
        public static int database(string id)
        {
            string sql = "delete from VIPGrade where VGID=@id ";
            SqlParameter[] sps = new SqlParameter[]
          {
              new SqlParameter("@id",id)
          };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;

        }

        /// <summary>
        /// 结账会员查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Vips Select(String id)
        {
            String Sql = @"select a.VipID,b.VipName,c.VGName,c.VGDiscount from ConsumerBill a inner 
join Vips b on a.VipID=b.VipID inner join VipGrade c on b.GradeID=c.VGID
where a.CBID=@id and a.CBClose=0";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@id",id)};
            Vips v = new Vips();
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql, Sps);
            if (sdr.Read())
            {
                v.VipID = sdr["VipID"].ToString();
                v.VipName = sdr["VipName"].ToString();
                v.VipGname = sdr["VGName"].ToString();
                v.VipGD = sdr["VGDiscount"].ToString();
            }
            sdr.Close();
            return v;
        }



        //查询全部会员信息
        public static List<Vips> select()
        {
            List<Vips> list = new List<Vips>();
            string sql = "select VipID,VipName,VipSex,VGName,VGDiscount,VipTel,VipStartDate,VipEndDate from Vips a inner join VIPGrade b on a.GradeID=b.VGID";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                Vips v = new Vips();
                v.VipID = sdr["VipID"].ToString();
                v.VipName = sdr["VipName"].ToString();
                v.VipSex = sdr["VipSex"].ToString();
                v.VGName = sdr["VGName"].ToString();
                v.VGDiscount = Convert.ToDouble(sdr["VGDiscount"]);
                v.VipTel = sdr["VipTel"].ToString();
                v.VipStartDate = sdr["VipStartDate"].ToString();
                v.VipEndDate = sdr["VipEndDate"].ToString();
                list.Add(v);
            }
            sdr.Close();
            return list;
        }

        //查询会员等级表
        public static List<VIPGrades> selVG()
        {
            List<VIPGrades> list = new List<VIPGrades>();
            string sql = "select * from VIPGrade";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql);
            while (sdr.Read())
            {
                VIPGrades vg = new VIPGrades();
                vg.VGID = Convert.ToInt32(sdr["VGID"]);
                vg.VGName = sdr["VGName"].ToString();
                vg.VGDiscount = Convert.ToDouble(sdr["VGDiscount"]);
                list.Add(vg);
            }
            sdr.Close();
            return list;
        }

        //查询最大的ID
        public static int selectID()
        {
            string sql = "select max(VipID) from Vips";
            return Convert.ToInt32(DBHelper.ExecuteScalar(sql));
        }
        //添加会员
        public static int Insert(Vips v)
        {
            string sql = "insert into Vips  values(@name,@sex,@gid,@tpl, getdate(),@sj)";
            SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@name",v.VipName ),
           new SqlParameter ("@sex",v.VipSex ),
           new SqlParameter ("@gid",v.GradeID ),
           new SqlParameter ("@tpl",v.VipTel ),
           new SqlParameter ("@sj",v.VipEndDate )
           };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;
        }

        //修改会员
        public static int upbyid(Vips v)
        {
            string sql = "update Vips set VipName=@name,VipSex=@sex,GradeID=@gid,VipTel=@tel,VipEndDate=@vdat  where VipID=@id";
            SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@name",v.VipName ),
           new SqlParameter ("@sex",v.VipSex ),
           new SqlParameter ("@gid",v.GradeID   ),
           new SqlParameter ("@tel",v.VipTel ),
           new SqlParameter ("@vdat",v.VipEndDate ),
           new SqlParameter ("@id",v.VipID )
           };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;
        }
        //根据编号删除会员
        public static int delete(int id)
        {
            string sql = "delete from Vips  where VipID=@id";
            SqlParameter[] sps = new SqlParameter[]
           { 
             new SqlParameter ("@id",id )
           };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;
        }
        //根据编号或者姓名查询会员信息
        public static List<Vips> Sel(string Sid)
        {
            List<Vips> list = new List<Vips>();
            string sql = string.Format(@"select VipID,VipName,VipSex,VGName,VGDiscount,VipTel,VipStartDate,VipEndDate 
from Vips a inner join VIPGrade b on a.GradeID=b.VGID where VipName  like '%'+@Sid+'%'");
            SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@Sid",Sid ),
           };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
            while (sdr.Read())
            {
                Vips v = new Vips();
                v.VipID = sdr["VipID"].ToString();
                v.VipName = sdr["VipName"].ToString();
                v.VipSex = sdr["VipSex"].ToString();
                v.VGName = sdr["VGName"].ToString();
                v.VGDiscount = Convert.ToDouble(sdr["VGDiscount"]);
                v.VipTel = sdr["VipTel"].ToString();
                v.VipStartDate = sdr["VipStartDate"].ToString();
                v.VipEndDate = sdr["VipEndDate"].ToString();
                list.Add(v);
            }
            sdr.Close();
            return list;
        }
        public static List<Vips> Sel(int Sidi)
        {
            List<Vips> list = new List<Vips>();
            string sql = string.Format(@"select VipID,VipName,VipSex,VGName,VGDiscount,VipTel,VipStartDate,VipEndDate 
from Vips a inner join VIPGrade b on a.GradeID=b.VGID where VipID=@Sidi");
            SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@Sidi",Sidi )
           };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
            while (sdr.Read())
            {
                Vips v = new Vips();
                v.VipID = sdr["VipID"].ToString();
                v.VipName = sdr["VipName"].ToString();
                v.VipSex = sdr["VipSex"].ToString();
                v.VGName = sdr["VGName"].ToString();
                v.VGDiscount = Convert.ToDouble(sdr["VGDiscount"]);
                v.VipTel = sdr["VipTel"].ToString();
                v.VipStartDate = sdr["VipStartDate"].ToString();
                v.VipEndDate = sdr["VipEndDate"].ToString();
                list.Add(v);
            }
            sdr.Close();
            return list;
        }

    }
}
