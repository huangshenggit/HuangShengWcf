using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGridConrtl();
        }
       /// <summary>
       /// gridConrtl绑定数据
       /// </summary>
        public void BindGridConrtl()
        {
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
                //int x = 9;
                //int y = 10;
                //this.txtUserName.Text = client.ADD(x, y).ToString();

                var _result = client.GetUsers();
                GetList(_result);

                this.gridControl1.DataSource = GetList(_result);

            }
        }

        /// <summary>
        /// 将DataSet转换为泛型
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public List<EntityAdmin> GetList(DataSet ds)
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
        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private string GetSelectID(string FileName)//FileName 控件绑定的FileName的属性
        {
            int[] pRows = this.gridView1.GetSelectedRows();//传递实体类过去 获取选中的行
            if (pRows.GetLength(0) > 0)
                return gridView1.GetRowCellValue(pRows[0], FileName).ToString();
            else
                return null;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        /// <summary>
        /// 新增数据
        /// </summary>
        public void Save()
        {
            var username = this.txtUserName.Text;
            var userpwd = this.txtUserPwd.Text;
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
              //判断用户名密码是否为空
                if ((username != "") && (userpwd != ""))
                {
                    //判断用户名是否存在
                    DataSet ds = client.ByUserNameUser(username);
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                         //添加用户
                        if (client.SaveUser(username, userpwd) == true)
                        {
                            BindGridConrtl();
                            MessageBox.Show("添加成功");
                        }
                        else
                        {
                            MessageBox.Show("添加失败");
                        }
                    }
                    else { MessageBox.Show("用户已存在，请重新输入"); }
                }

                else { MessageBox.Show("请输入用户名或密码"); }

            }
        }
       
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.CalculatorServiceClient client=new ServiceReference1.CalculatorServiceClient ())
            {
                DialogResult dr = MessageBox.Show("是否删除！", "提示！", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    var GetId = GetSelectID("id");
                    int Id = int.Parse(GetId);
                    client.DeleteUser(Id);
                    BindGridConrtl();
                    MessageBox.Show("删除成功");
                    this.txtUserName.Text = "";
                    this.txtUserPwd.Text = "";
                }
                else if (dr == DialogResult.Cancel)
                {
                  
                }
               
            }
        }
        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
           
        //}
        /// <summary>
        /// 选中每行时文本框显示当前行的数据
        /// </summary>
        public void ShowNamePwd()
        {
            //int id=Convert.ToInt32(GetSelectID("id"));
            int id = int.Parse(GetSelectID("id"));//获取选中Id
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
                DataSet _result = client.GetUserInfoById(id);
                //List<EntityAdmin> list= GetList(_result);
                //this.txtUserName.Text=_result.Tables[0].Rows[i]["UserName"].ToString();
                this.txtUserName.Text = _result.Tables[0].Rows[0]["UserName"].ToString();
                this.txtUserPwd.Text = _result.Tables[0].Rows[0]["UserPwd"].ToString();

            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            ShowNamePwd();
           
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            var username = this.txtUserName.Text;
            var userpwd = this.txtUserPwd.Text;
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
               DataSet _result =client.ByUserPwdAndUserName(username,userpwd);
            List<EntityAdmin> list=  GetList(_result);
                this.gridControl1.DataSource = list;
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var username = this.txtUserName.Text;
            var userpwd = this.txtUserPwd.Text;
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
                int[] a = gridView1.GetSelectedRows();//获取选中行的序列号
                //this.m_View.FocusedRowChanged += new
                // DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(m_View_FocusedRowChanged);
                //var a=this.gridControl1.Focused;
                int id = int.Parse(GetSelectID("id"));
                //判断用户名密码是否为空
                if ((username != "") && (userpwd != ""))
                {
                    //判断用户名或密码是否存在
                   // DataSet ds = client.ByUserNameUser(username);
                   // if (ds.Tables[0].Rows.Count <= 0)
                  //  {  
                      //int id=int.Parse(GetSelectID("id"));
                        //保存用户
                        if (client.UpdateUser(username,userpwd,id) == true)
                        {
                            BindGridConrtl();
                            MessageBox.Show("成功");
                        }
                        else
                        {
                            MessageBox.Show("失败");
                        }
                 // }
                   // else { MessageBox.Show("用户已存在，请重新输入"); }
                }

                else { MessageBox.Show("请输入用户名或密码"); }

            }

        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGridConrtl();
            empty();
        }
        /// <summary>
        /// 清空
        /// </summary>
        public void empty()
        {
            txtUserName.Text = "";
            txtUserPwd.Text = "";
        }
        //dfdfhgh
    }
}
