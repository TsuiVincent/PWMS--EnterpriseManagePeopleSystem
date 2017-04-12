using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PWMS__EnterpriseManagePeopleSystem
{
    public partial class F_Login : Form
    {
        DataClass.MyMeans Myclass = new DataClass.MyMeans();
        public F_Login()
        {
            InitializeComponent();
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                textPass.Focus();
            }

        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                butLogin.Focus();
            }
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if(textName.Text!=""&textPass.Text!="")
            {
                SqlDataReader temDR = Myclass.getcom("select * from tb_Login where Name='" + textName.Text.Trim() + "' and Pass='" + textPass.Text.Trim() + "'");
                bool ifcom = temDR.Read();//记录是否有相应的账号和密码
                if(ifcom)
                {
                    DataClass.MyMeans.Login_Name = textName.Text.Trim();//=temDR[1].ToString()
                    DataClass.MyMeans.Login_ID = temDR.GetString(0);//使用temDR[0].tostring()也可以
                    DataClass.MyMeans.My_conn.Close();//在getcom中打开了数据库，现在需要关掉
                    DataClass.MyMeans.My_conn.Dispose();//释放资源
                    DataClass.MyMeans.Login_n = (int)(this.Tag);//login_n 是记录登录与重新登录的标识
                    this.Close();//此时登陆成功，因为数据已经传进去了，可以关闭登录窗口
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                }              
                
            }
            else
            {
                MessageBox.Show("请将登录信息填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
        }

        private void F_Login_Activated(object sender, EventArgs e)
        {
            textName.Focus();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if((int)(this.Tag)==1)
            {
                DataClass.MyMeans.Login_n = 3;//n=1,2,3;1为登录，2为重新登陆，3为？？关闭？？？
                Application.Exit();
            }
            else
            {
                if ((int)(this.Tag) == 2)
                    this.Close();//关闭重新登陆窗口
            }
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            try
            {
                Myclass.con_open();//一关一闭是为了试验数据库是否正常
                Myclass.conn_close();//后边使用时会重新连接
                textName.Text = "";
                textPass.Text = "";
            }
            catch
            {
                MessageBox.Show("数据库连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
