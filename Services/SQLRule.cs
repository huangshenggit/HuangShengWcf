
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace sql
{
  public  class SQLRule
    {
       
        public int ADD(int x, int y)
        {
            return x + y;
        }
        //获取所有用户
        public static string GetUsers()
        {
            string sql = "";
             sql = string.Format("select * from Admin");
            return sql;
        }
        //通过Id获取用户
        public static string GetUserInfoById(EntityAdmin entity)
        {
            string sql =string.Format("select * from Admin where Id=") + entity.id;
        
            return sql;
        }
        //新增
        public static string SaveUser(EntityAdmin entity)
        {
            string sql = string.Format("Insert Admin(UserName,UserPwd,Name,Sex,Tel)" + "values('" + entity.username + "','" + entity.userpwd + "','User','男','12345678900')");
            return sql;

        }
        //删除
        public static string DeleteUser(EntityAdmin entity)
        {
            string sql = string.Format("delete from Admin where Id=") + entity.id;
            return sql;

        }
        //修改保存
        public static string UpdateUser(EntityAdmin entity)
        {
            string sql =string.Format("Update Admin Set UserName=" + entity.username + ",UserPwd=" + entity.userpwd + "where Id=" + entity.id + "");
            return sql;

        }
        public static string ByUserNameUser(EntityAdmin entity)
        {
            string sql =string.Format("select * from Admin where UserName=" + entity.username);
            return sql;
        }

        //模糊查询
        public static string ByUserPwdAndUserName(EntityAdmin entity)
        {

            string sql = string.Format("select * from Admin where UserName Like '%" + entity.username + "%' and  UserPwd Like '%" + entity.userpwd + "%'");
            return sql;
        }
        //多行删除
        public static string mutiDel(string id)
        {
            string sql = string.Format("delete from Admin where Id in(" + id + ")");
            return sql;
        }
        //多行数组删除
        public static string mtDel(List<int> num)
        {
            string sql = string.Format("delete from Admin where Id in(" + num + ")");
            return sql;
        }
    }
}
