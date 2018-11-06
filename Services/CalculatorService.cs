
using System.Data;
using Entity;
using Contracts;
using sql;
using System.Collections.Generic;

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
            string sql = SQLRule.GetUsers();
            var _result = SQLHelper.GetAdmin(sql);
            return _result;
        }
        //通过Id获取用户
        public DataSet GetUserInfoById(EntityAdmin entity)
        {
            // string sql = "select * from Admin where Id=" + entity.id;
            string sql = SQLRule.GetUserInfoById(entity);
            var _result = SQLHelper.GetAdmin(sql);
            return _result;
        }
        //新增
        public bool SaveUser(EntityAdmin entity)
        {
           // string sql = "Insert Admin(UserName,UserPwd,Name,Sex,Tel)" + "values('" + entity.username + "','" + entity.userpwd + "','User','男','12345678900')";
            return SQLHelper.ExcuteSql(SQLRule.SaveUser(entity));
           
        }
        //删除
        public bool DeleteUser(EntityAdmin entity)
        {
            //string sql = "delete from Admin where Id="+entity.id;
            return SQLHelper.ExcuteSql(SQLRule.DeleteUser(entity));

        }
        //修改保存
        public bool UpdateUser(EntityAdmin entity)
        {
            // string sql = "Update Admin Set UserName="+entity.username+",UserPwd="+entity.userpwd+"where Id="+entity.id+"";
            return SQLHelper.ExcuteSql(SQLRule.UpdateUser(entity));

        }
       public DataSet ByUserNameUser(EntityAdmin entity)
        {
            //string sql = "select * from Admin where UserName="+entity.username;
            return SQLHelper.GetAdmin(SQLRule.ByUserNameUser(entity));
        }

        //模糊查询
        public DataSet ByUserPwdAndUserName(EntityAdmin entity)
        {
            
            //string sql = "select * from Admin where UserName Like '%"+entity.username+"%' and  UserPwd Like '%" + entity.userpwd + "%'";
            return SQLHelper.GetAdmin(SQLRule.ByUserPwdAndUserName(entity));
        }
        //多行删除
        public bool mutiDel(string id)
        {
            //string sql = "delete from Admin where Id in("+id+")";
            return SQLHelper.ExcuteSql(SQLRule.mutiDel(id));
        }
        public bool mtDel(List<int> num)
        {
            return SQLHelper.ExcuteSql(SQLRule.mtDel(num));
        }
    }
}
