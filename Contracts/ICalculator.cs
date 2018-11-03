using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Entity;
using System.Data;

namespace Contracts
{
      [ServiceContract(Name="CalculatorService", Namespace="http://www.artech.com/")]
       public interface ICalculator
       {
        /// <summary>
        /// 实验
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [OperationContract]
        int ADD(int a, int b);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUsers();

        /// <summary>
        /// 通过Id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserInfoById(int id);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpwd"></param>
        /// <returns></returns>
        [OperationContract]
        bool SaveUser(string username, string userpwd);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteUser(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpwd"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateUser(string username, string userpwd,int id);

        /// <summary>
        /// 通过用户名和密码进行模糊查询
        /// </summary>
        [OperationContract]
        DataSet ByUserPwdAndUserName(string name,string pwd);
            
        /// <summary>
        /// 通过用户名获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet ByUserNameUser(string name);

    }
}
