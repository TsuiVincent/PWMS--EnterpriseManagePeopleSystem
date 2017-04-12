using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWMS__EnterpriseManagePeopleSystem
{
    public partial class F_Main : Form
    {
        DataClass.MyMeans MyClass = new DataClass.MyMeans();
        ModuleClass.MyModule MyMenu = new ModuleClass.MyModule();

        public F_Main()
        {
            InitializeComponent();
        }  
        

        private void F_Main_Load(object sender, EventArgs e)//在Form_Load事件之后窗体才打开
        {
            F_Login FrmLogin = new F_Login(); //首先打开登录界面
            FrmLogin.Tag = 1;//将登陆窗体的标签tag设置为1，表示调用的是登录窗体而非重新登陆窗体
            FrmLogin.ShowDialog();
            FrmLogin.Dispose();//释放
            //以下对主窗体自定义初始化，加载自定义内容
            //当判断是登录窗体时
            if(DataClass.MyMeans.Login_n==1)
            {
                Preen_Main();
                //以下两句可以不在初始化中使用
                MyMenu.PactDay(1);//询问是否打开满足生日提醒期限的表格窗体,如果没有满足的则不提醒
                MyMenu.PactDay(2);//询问是否打开满足合同提醒期限的表格窗体
            }
            //*************************//??????????????????????????????????????????????????????????????????????????????
            DataClass.MyMeans.Login_n = 3;//将公共变量设为3，便于控制登录窗体的关闭，有疑问***
            //************************/
            Tool_Help.Enabled = true;
        }
        private void  Preen_Main()//primary screen主窗体de自定义初始化，包括菜单的可用性，将菜单复制到treeview中，在statusStrip中显示当前用户名
        {
            statusStrip1.Items[2].Text = DataClass.MyMeans.Login_Name;
            treeView1.Nodes.Clear();
            MyMenu.GetMenu(treeView1, menuStrip1); //调用公共类MyModule下的GetMenu()方法，将menuStrip1控件的子菜单添加到treeView1控件中
            MyMenu.MainMenuF(menuStrip1); //将菜单栏中的各子菜单项设为不可用状态
            MyMenu.MainPope(menuStrip1, DataClass.MyMeans.Login_Name);
        }
        private void F_Main_Activated(object sender, EventArgs e)
        {
            if (DataClass.MyMeans.Login_n == 2)//调用的是重新登录窗口时，不进行提醒生日与合同了
                Preen_Main();
            DataClass.MyMeans.Login_n = 3;
        }
       

        private void Menu_9_Click(object sender, EventArgs e)   //系统退出键
        {
            Application.Exit();
        }

        private void Tool_Folk_Click(object sender, EventArgs e)//民族类别、职工类别、文化程度....设置，共有十个引用
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }
        private void Tool_Stuffbusic_Click(object sender, EventArgs e)//人事档案管理设置
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);//sender.tostring().trim()表示获取当前对象的Text属性值
        }

        private void Tool_ClewBirthday_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_ClewBargain_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Stufind_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Stusum_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_DayWordPad_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_AddressBook_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Back_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Clear_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_NewLogon_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Setup_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Counter_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_WordBook_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Tool_Help_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Text.Trim()=="系统退出")
            {
                Application.Exit();
            }
            MyMenu.TreeMenuF(menuStrip1, e);//用MyModule公共类中的TreeMenuF()方法调用各窗体
        }

        private void Button_Stuffbusic_Click(object sender, EventArgs e)
        {
            if (Tool_Stuffbusic.Enabled)
            {
                Tool_Stuffbusic_Click(sender, e);
            }
            else
                MessageBox.Show("当前用户无权调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }

        private void Button_Stufind_Click(object sender, EventArgs e)
        {
            if (Tool_Stufind.Enabled)
            {
                Tool_Stufind_Click(sender, e);
            }
            else
                MessageBox.Show("当前用户无权调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }

        private void Button_ClewBargain_Click(object sender, EventArgs e)
        {
            if (Tool_ClewBargain.Enabled)
            {
                Tool_ClewBargain_Click(sender, e);
            }
            else
                MessageBox.Show("当前用户无权调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }

        private void Buuton_AddressBook_Click(object sender, EventArgs e)
        {
            if (Tool_AddressBook.Enabled)
            {
                Tool_AddressBook_Click(sender, e);
            }
            else
                MessageBox.Show("当前用户无权调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }

        private void Buuton_DayWordPad_Click(object sender, EventArgs e)
        {
            if (Tool_DayWordPad.Enabled)
            {
                Tool_DayWordPad_Click(sender, e);
            }
            else
                MessageBox.Show("当前用户无权调用" + "\"" + ((ToolStripButton)sender).Text + "\"" + "窗体");
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();//appliction.exit();???
        }
    }
}
