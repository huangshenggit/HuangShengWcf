using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Entity;
using Contracts;

namespace Service
{
  public  class CalculatorService:ICalculator
    {
        //例子
        public int ADD(int x, int y)
        {
            return x + y;
        }
        //获取所有用户
        public DataSet GetUsers()
        {
            string sql = "select * from Admin";
            var _result = SQLHelper.GetAdmin(sql);
            return _result;
        }
        //通过Id获取用户
        public DataSet GetUserInfoById(EntityAdmin entity)
        {
            string sql = "select * from Admin where Id=" + entity.id;
            var _result = SQLHelper.GetAdmin(sql);
            return _result;
        }
        //新增
        public bool SaveUser(EntityAdmin entity)
        {
            string sql = "Insert Admin(UserName,UserPwd,Name,Sex,Tel)" + "values('" + entity.username + "','" + entity.userpwd + "','User','男','12345678900')";
            return SQLHelper.ExcuteSql(sql);
           
        }
        //删除
        public bool DeleteUser(EntityAdmin entity)
        {
            string sql = "delete from Admin where Id="+entity.id;
            return SQLHelper.ExcuteSql(sql);

        }
        //修改保存
        public bool UpdateUser(EntityAdmin entity)
        {
            string sql = "Update Admin Set UserName="+entity.username+",UserPwd="+entity.userpwd+"where Id="+entity.id+"";
            return SQLHelper.ExcuteSql(sql);

        }
       public DataSet ByUserNameUser(EntityAdmin entity)
        {
            string sql = "select * from Admin where UserName="+entity.username;
            return SQLHelper.GetAdmin(sql);
        }

        //模糊查询
        public DataSet ByUserPwdAndUserName(EntityAdmin entity)
        {
            
            string sql = "select * from Admin where UserName Like '%"+entity.username+"%' and  UserPwd Like '%" + entity.userpwd + "%'";
            return SQLHelper.GetAdmin(sql);
        }
        //多行删除
        public bool mutiDel(string id)
        {
            string sql = "delete from Admin where Id in("+id+")";
            return SQLHelper.ExcuteSql(sql);
        }
    }
}
