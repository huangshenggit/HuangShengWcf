using cBusiness;
using Entity;
using System;
using System.Collections;
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
                var _result = client.GetUsers();
               user.GetList(_result);
                this.gridControl1.DataSource = user.GetList(_result);
            }
        }
        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        //private string GetSelectID(string FileName)//FileName 控件绑定的FileName的属性
        //{
        //    int[] pRows = this.gridView1.GetSelectedRows();//传递实体类过去 获取选中的行
        //    if (pRows.GetLength(0) > 0)
        //        return gridView1.GetRowCellValue(pRows[0], FileName).ToString();
        //    else
        //        return null;       
        //}
        
           
            
          
        private EntityAdmin getEntity(EntityAdmin entity)
        {
            var tt = gridView1.GetRow(gridView1.FocusedRowHandle) as EntityAdmin;
            return tt;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        public void Save()
        {
            EntityAdmin entity = new EntityAdmin();
            var username = this.txtUserName.Text;
            var userpwd = this.txtUserPwd.Text;
            entity.username = username;
            entity.userpwd = userpwd;
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
              //判断用户名密码是否为空
                if ((username != "") && (userpwd != ""))
                {
                    //判断用户名是否存在
                    DataSet ds = client.ByUserNameUser(entity);
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                         //添加用户
                        if (client.SaveUser(entity) == true)
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
          
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {

                DialogResult dr = MessageBox.Show("是否删除！", "提示！", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    // var id = getId();
                    //EntityAdmin entity = new EntityAdmin();

                    //  client.mutiDel(id);

                    List<EntityAdmin> list = new List<EntityAdmin>();

                    list = getId();
                    for (int i = 0; i <list.Count; i++)
                    {
                        client.DeleteUser(list[i]);
                    }
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

     
        /// <summary>
        /// 选中每行时文本框显示当前行的数据
        /// </summary>
        public void ShowNamePwd()
        {
            //int id=Convert.ToInt32(GetSelectID("id"));
            //int id = int.Parse(GetSelectID("id"));//获取选中Id
            EntityAdmin entity = new EntityAdmin();
            var tt = getEntity(entity);
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
              
                this.txtUserName.Text = tt.username;
                this.txtUserPwd.Text = tt.userpwd;

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
            EntityAdmin entity = new EntityAdmin();
            entity.username = this.txtUserName.Text;
            entity.userpwd = this.txtUserPwd.Text;
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
               
                DataSet _result =client.ByUserPwdAndUserName(entity);
                List<EntityAdmin> list= user.GetList(_result);
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
            EntityAdmin entity = new EntityAdmin();
            var tt = getEntity(entity);
             entity.username = this.txtUserName.Text;
             entity.userpwd = this.txtUserPwd.Text;
            entity.id = tt.id;
         
            using (ServiceReference1.CalculatorServiceClient client = new ServiceReference1.CalculatorServiceClient())
            {
              
                //判断用户名密码是否为空
                if ((entity.username != "") && (entity.userpwd != ""))
                {
                        if (client.UpdateUser(entity) == true)
                        {
                            BindGridConrtl();
                        empty();
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

        /// <summary>
        /// 获取删除的ID
        /// </summary>
        /// <returns></returns>
        //public string getId()
        //{
        //    string id = null;
        //    List<EntityAdmin> list = new List<EntityAdmin>();
        //    int index;
        //    List<int> num = new List<int>();
        //    list = this.gridView1.DataSource as List<EntityAdmin>;
        //    for (int i = 0; i < list.Count; i++)
        //    {

        //        if (list[i].check == true)
        //        {
        //            index = list[i].id;
        //            num.Add(list[i].id);
        //        }

        //    }

        //    for (int i = 0; i < num.Count; i++)
        //    {

        //        id = id + "," + num[i];

        //    }
        //    int length = id.Length;
        //    id = id.Substring(1, length - 1);
        //    return id;
        //}
        public List<EntityAdmin> getId()
        {
           
            List<EntityAdmin> list = new List<EntityAdmin>();
          
            //  List<int> num = new List<int>();
            List<EntityAdmin> lists = new List<EntityAdmin>();
            list = this.gridView1.DataSource as List<EntityAdmin>;
            for (int i=0;i<list.Count;i++)
            {
                if (list[i].check==true)
                {
                    lists.Add(list[i]);
                }
            }
            return lists;
        }
    }
}
