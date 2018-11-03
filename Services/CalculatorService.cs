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
        public DataSet GetUserInfoById(int id)
        {
            string sql = "select * from Admin where Id=" + id;
            var _result = SQLHelper.GetAdmin(sql);
            return _result;
        }
        //新增
        public bool SaveUser(string username,string userpwd)
        {
            string sql = "Insert Admin(UserName,UserPwd,Name,Sex,Tel)" + "values('" + username + "','" + userpwd + "','User','男','12345678900')";
            return SQLHelper.ExcuteSql(sql);
           
        }
        //删除
        public bool DeleteUser(int id)
        {
            string sql = "delete from Admin where Id="+id;
            return SQLHelper.ExcuteSql(sql);

        }
        //修改保存
        public bool UpdateUser(string username, string userpwd,int id)
        {
            string sql = "Update Admin Set UserName="+username+",UserPwd="+userpwd+"where Id="+id+"";
            return SQLHelper.ExcuteSql(sql);

        }
       public DataSet ByUserNameUser(string name)
        {
            string sql = "select * from Admin where UserName="+name;
            return SQLHelper.GetAdmin(sql);
        }

        //模糊查询
        public DataSet ByUserPwdAndUserName(string name, string pwd)
        {
            
            string sql = "select * from Admin where UserName Like '%"+name+"%' and  UserPwd Like '%" + pwd + "%'";
            return SQLHelper.GetAdmin(sql);
        }
    }
}
