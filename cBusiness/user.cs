using Entity;
using System.Collections.Generic;
using System.Data;

namespace cBusiness
{
    public static class user
    {
        /// <summary>
        /// 将DataSet转换为泛型
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<EntityAdmin> GetList(DataSet ds)
        {
            List<EntityAdmin> list = new List<EntityAdmin>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                EntityAdmin entity = new EntityAdmin();
                //var t = ds.Tables[0].Rows[i]["UserName"].ToString();
                entity.id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                entity.username = ds.Tables[0].Rows[i]["UserName"].ToString();
                entity.userpwd = ds.Tables[0].Rows[i]["UserPwd"].ToString();
                entity.name = ds.Tables[0].Rows[i]["Name"].ToString();
                entity.sex = ds.Tables[0].Rows[i]["Sex"].ToString();
                entity.tel = ds.Tables[0].Rows[i]["Tel"].ToString();
                list.Add(entity);
            }
            return list;
        }

    }
}
