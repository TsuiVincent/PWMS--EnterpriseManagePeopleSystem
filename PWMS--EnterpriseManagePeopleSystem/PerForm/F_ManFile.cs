using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PWMS__EnterpriseManagePeopleSystem.PerForm
{
    public partial class F_ManFile : Form
    {
        public F_ManFile()
        {
            InitializeComponent();
        }
        #region 当前窗体的所有公共变量
        DataClass.MyMeans MyDataClass = new DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static string tem_Field = "";
        public static string tem_Value = "";
        public static string tem_ID = "";
        public static int hold_n = 0;//用于记录添加操作的标识
        public static byte[] imgBytesIn;//用来存储图片的二进制数
        public static int Ima_n = 0;//判断是否对图片进行了操作
        public static string Part_ID = "";//存储数据表的ID信息
        #endregion
        public void ShowData_Image(byte[] DI, PictureBox Ima)//显示图片，还没有被引用
        {
            //不需要了！！！，已经被写进去了
        }

        #region 显示“职工基本信息”表中的指定记录
        public string Grid_Inof(DataGridView DGrid)
        {
            byte[] pic;//一个字节数组
            if(DGrid.RowCount>1)//为什么不是大于0？？？？？,因为有一行空的，如果有内容至少两行
            {
                //将数据库中的数据对应填写进去
                S_0.Text = DGrid[0, DGrid.CurrentCell.RowIndex].Value.ToString();//datagridview[comlumn,row]
                S_1.Text = DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_2.Text = DGrid[2, DGrid.CurrentCell.RowIndex].Value.ToString();//
                S_3.Text = MyMC.Date_Format(Convert.ToString(DGrid[3, DGrid.CurrentCell.RowIndex].Value).Trim());//
                S_4.Text = DGrid[4, DGrid.CurrentCell.RowIndex].Value.ToString();//
                S_5.Text = DGrid[5, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_6.Text = DGrid[6, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_7.Text = DGrid[7, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_8.Text = DGrid[8, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_9.Text = DGrid[9, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_10.Text = MyMC.Date_Format(Convert.ToString(DGrid[10, DGrid.CurrentCell.RowIndex].Value).Trim());//
                S_11.Text = DGrid[11, DGrid.CurrentCell.RowIndex].Value.ToString();//
                S_12.Text = DGrid[12, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_13.Text = DGrid[13, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_14.Text = DGrid[14, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_15.Text = DGrid[15, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_16.Text = DGrid[16, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_17.Text = DGrid[17, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_18.Text = DGrid[18, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_19.Text = DGrid[19, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_20.Text = DGrid[20, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_21.Text = MyMC.Date_Format(Convert.ToString(DGrid[21, DGrid.CurrentCell.RowIndex].Value).Trim());//
                S_22.Text = DGrid[22, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_23.Text = DGrid[24, DGrid.CurrentCell.RowIndex].Value.ToString();//23列是图片数据
                S_24.Text = DGrid[25, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_25.Text = DGrid[26, DGrid.CurrentCell.RowIndex].Value.ToString();//
                S_26.Text = DGrid[27, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_27.Text = MyMC.Date_Format(Convert.ToString(DGrid[28, DGrid.CurrentCell.RowIndex].Value).Trim());//
                S_28.Text = MyMC.Date_Format(Convert.ToString(DGrid[29, DGrid.CurrentCell.RowIndex].Value).Trim());//
                S_29.Text = DGrid[30, DGrid.CurrentCell.RowIndex].Value.ToString();//

                //显示图片
                try
                {
                    pic = (byte[])(MyDS_Grid.Tables[0].Rows[DGrid.CurrentCell.RowIndex][23]);//23列是图片数据
                    MemoryStream ms = new MemoryStream(pic);//内存流
                    pictureBox1.Image = Image.FromStream(ms);
                }
                catch
                {
                    pictureBox1.Image = null;
                }
                tem_ID = S_0.Text.Trim();//获取当前编号,,,现在还不知道什么用》？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？?????????????????????????????????？？？？？？？？？？？？？？
                return DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();

            }
            else//datagridview中少于两行时
            {
                MyMC.Clear_Control(tabControl1.TabPages[0].Controls);
                tem_ID = "";
                return "";
            }
            

        }
        #endregion
       


        private void F_ManFile_Load(object sender, EventArgs e)
        {
            //dataGridView显示职工名称
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.AllSql, "tb_stuffbusic");//allsql可以是关于合同生日提醒的，也可以是基本信息的Stuffbasic
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;//能够自动创建列，什么意思
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 80;

            for(int i=2;i<dataGridView1.ColumnCount;i++)//隐藏dataGridView1控件中不需要的列字段???需要隐藏么
            {
                dataGridView1.Columns[i].Visible = false;//只显示前两列
            }

            //设定MaskedTextBox的输入格式
            MyMC.MaskedTextBox_Format(S_3);
            MyMC.MaskedTextBox_Format(S_10);
            MyMC.MaskedTextBox_Format(S_21);
            MyMC.MaskedTextBox_Format(S_27);
            MyMC.MaskedTextBox_Format(S_28);
            //向combox下拉列表框中添加数据库中的项目
            MyMC.CoPassData(S_2, "tb_Folk");
            MyMC.CoPassData(S_5, "tb_Kultur");
            MyMC.CoPassData(S_8, "tb_Visage");  //向"正治面貌”列表框中添加信息
            MyMC.CoPassData(S_12, "tb_EmployeeGenre");  //向"职工类别”列表框中添加信息
            MyMC.CoPassData(S_13, "tb_Business");  //向"职务类别”列表框中添加信息
            MyMC.CoPassData(S_14, "tb_Laborage");  //向"工资类别”列表框中添加信息
            MyMC.CoPassData(S_15, "tb_Branch");  //向"部门类别”列表框中添加信息
            MyMC.CoPassData(S_16, "tb_Duthcall");
            MyMC.CityInfo(S_23, "select distinct BeAware from tb_City", 0);//下拉列表中添加不同的省份
            ///根据省匹配市，此时不需要，在输入内容时，在省已经输入后才添加市的下拉列表！！！！！！！!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            S_23.AutoCompleteMode = AutoCompleteMode.SuggestAppend;//自动匹配下拉列表中的选项到复选框中,使用下拉选项较多时
            S_23.AutoCompleteSource = AutoCompleteSource.ListItems;

            textBox1.Text = Grid_Inof(dataGridView1);
            DataClass.MyMeans.AllSql = "select * from tb_Stuffbusic";//这一句加的很重要，因为生日合同提醒会使得AllSQL改变

        }
        //根据省匹配市
        private void S_23_TextChanged(object sender, EventArgs e)
        {
            S_24.Items.Clear();
            MyMC.CityInfo(S_24, "select City from tb_City where BeAware='"+S_23.Text.Trim()+"'",0);
        }


        #region 按条件显示“职工基本信息”表的内容
        public void Condition_Lookup(string C_Value)
        {

            MyDS_Grid = MyDataClass.getDataSet("select * from tb_Stuffbusic where " + tem_Field + "='" + tem_Value + "'","tb_Stuffbusic");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            textBox1.Text = Grid_Inof(dataGridView1);
        }
        #endregion
        #region 将图片转换成字节数组
        public void Read_Image(OpenFileDialog openF,PictureBox MyImage)
        {
            openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";
            if(openF.ShowDialog(this)==DialogResult.OK)
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);//将图片放入pictureBox中去
                    string stri = openF.FileName.ToString();//记录图片所在路径
                    FileStream fs = new FileStream(stri, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imgBytesIn = br.ReadBytes((int)fs.Length);//将流读入字节数组中
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MyImage.Image = null;
                }
            }
        }

        #endregion

        #region tabcontrol的初始化
        /// <summary>
        /// 有疑问？？？？？？？？？？？？？？？？？？？？？？？？？？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Click(object sender, EventArgs e)
        {           
            groupBox5.Enabled = true;
            Sta_Delete.Enabled = true;
            MyMC.Ena_Button(Sta_Add, Sta_Amend, Sta_Cancel, Sta_Save, 1, 1, 0, 0);
            if(tabControl1.SelectedTab.Name=="tabPage1")//选择的是“职工基本信息”选项卡
            {
                hold_n = 0;//添加操作标识恢复
                MyMC.Ena_Button(Sta_Add, Sta_Amend, Sta_Cancel, Sta_Save, 1, 1, 0, 0);
                groupBox5.Text = "";
                Ima_n = 0;//标识是否选择了职工照片
                Img_Clear.Enabled = false;
                Img_Save.Enabled = false;
                Sta_Table.Enabled = true;//word文档能够使用
            }
            if (tabControl1.SelectedTab.Name == "tabPage2"|tabControl1.SelectedTab.Name=="tabPage3"|tabControl1.SelectedTab.Name=="tabPage4" | tabControl1.SelectedTab.Name == "tabPage5")//选择的是“职工基本信息”选项卡
            {
                groupBox5.Enabled = false;//用不到了
                //Sta_Table.Enabled = false;//这一句感觉可有可无
                if(tabControl1.SelectedTab.Name=="tabPage2")//工作简历选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage2;
                    MyMC.MaskedTextBox_Format(Word_2);
                    MyMC.MaskedTextBox_Format(Word_3);
                }
                if (tabControl1.SelectedTab.Name == "tabPage3")//家庭关系选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage3;
                    MyMC.MaskedTextBox_Format(Family_4);
                    
                }
                if (tabControl1.SelectedTab.Name == "tabPage4")//培训记录选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage4;
                    MyMC.MaskedTextBox_Format(TrainNote_3);
                    MyMC.MaskedTextBox_Format(TrainNote_4);
                }
                if (tabControl1.SelectedTab.Name == "tabPage5")//奖惩记录选项卡
                {
                    groupBox6.Parent = (TabPage)tabPage5;
                    MyMC.MaskedTextBox_Format(RANDP_3);
                    MyMC.MaskedTextBox_Format(RANDP_5);
                    MyMC.CoPassData(RANDP_2, "tb_RPKind");//向“奖惩类别”列表框中添加信息
                }

            }
            if (tabControl1.SelectedTab.Name == "tabPage6")//选择的是“个人简历”选项卡
            {
                MyMC.Ena_Button(Sta_Add, Sta_Amend, Sta_Cancel, Sta_Delete, 0, 0, 0, 0);//Sta_Table还能用
                Sta_Save.Enabled = true;//保存按钮可用
            }

                
        }
        #endregion



        #region groupBox5中的按钮（修改，添加，删除，存储，取消）模块，用于tabPage1中
        private void Sta_Add_Click(object sender, EventArgs e)
        {
            MyMC.Clear_Control(tabControl1.TabPages[0].Controls);//清空职工基本信息的相应文本框
            S_0.Text = MyMC.GetAutocoding("tb_Stuffbusic", "ID");
            hold_n = 1;////用于记录添加操作的标识
            MyMC.Ena_Button(Sta_Add, Sta_Amend, Sta_Cancel, Sta_Save, 0, 0, 1, 1);
            groupBox5.Text = "当前正在添加信息";
            Img_Clear.Enabled = true;
            Img_Save.Enabled = true;
        }
        private void Sta_Amend_Click(object sender, EventArgs e)
        {

        }

        private void Sta_Delete_Click(object sender, EventArgs e)
        {

        }

        private void Sta_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Sta_Save_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region groupBox1中的combox1,comoBox2的应用
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:  //按姓名查询
                    {
                        MyMC.CityInfo(comboBox2, "select distinct StuffName from tb_StuffBusic", 0);
                        tem_Field = "StuffName";//现在还不知道有什么用
                        break;
                    }
                case 1:  //按性别查询
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("男");
                        comboBox2.Items.Add("女");
                        tem_Field = "Sex";//现在还不知道有什么用
                        break;
                    }
                case 2:  //按民族查询
                    {
                        MyMC.CityInfo(comboBox2, "select distinct Folk from tb_StuffBusic", 0);
                        //也可以用MyMC.CopassData(comoBox2,"tb_Folk");但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Folk";//现在还不知道有什么用
                        break;
                    }
                case 3:  //按文化程度查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Kultur from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2,"tb_Kultur");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Kultur";//现在还不知道有什么用
                        break;
                    }
                case 5:  //按职工类别查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Employee from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2, "tb_EmployeeGenre");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Employee";//现在还不知道有什么用
                        break;
                    }
                case 4:  //按政治面貌查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Visage from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2, "tb_Visage");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Visage";//现在还不知道有什么用
                        break;
                    }
                case 6:  //按职务类别查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Business from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2, "tb_Business");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Business";//现在还不知道有什么用
                        break;
                    }
                case 7:  //按部门类别查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Branch from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2, "tb_Branch");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Branch";//现在还不知道有什么用
                        break;
                    }
                case 8:  //按职称类别查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Duthcall from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2, "tb_Duthcall");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Duthcall";//现在还不知道有什么用
                        break;
                    }
                case 9:  //按工资类别查询
                    {
                        //MyMC.CityInfo(comboBox2, "select distinct Laborage from tb_StuffBusic", 0);
                        MyMC.CoPassData(comboBox2, "tb_Laborage");//但是不一定能搜寻到结果，但上边的搜寻方法一定能够搜到
                        tem_Field = "Laborage";//现在还不知道有什么用
                        break;
                    }



            }
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tem_Value = comboBox2.SelectedItem.ToString();
                Condition_Lookup(tem_Value);
            }
            catch
            {
                comboBox2.Text = "";
                MessageBox.Show("只能以选择方式查询");
            }
        }
        #endregion

        #region 浏览按钮gruopBox2
        /// <summary>
        /// 四个按钮公用一个函数N_First_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void N_First_Click(object sender, EventArgs e)
        {
            int Collnd = 0;
            if (dataGridView1.CurrentCell.ColumnIndex == -1 || dataGridView1.CurrentCell.ColumnIndex > 1)//判断当前在第几列
                Collnd = 0;
            else
                Collnd = dataGridView1.CurrentCell.ColumnIndex;//0列或1列
            if(((Button)sender).Name=="N_First")
            {
                dataGridView1.CurrentCell = this.dataGridView1[Collnd, 0];
                MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 0, 0, 1, 1);
            }
            if (((Button)sender).Name == "N_Previous")
            {
                if(dataGridView1.CurrentCell.RowIndex==0)
                {
                    MessageBox.Show("当前已是第一条，不能再上翻");
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[Collnd, dataGridView1.CurrentCell.RowIndex-1];
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                }
                
            }
            if (((Button)sender).Name == "N_Next")
            {
                if (dataGridView1.CurrentCell.RowIndex == dataGridView1.RowCount-2)//为什么是加2，因为行数多了一行最后的空行
                {
                    MessageBox.Show("当前已是最后一条，不能再下翻");
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[Collnd, dataGridView1.CurrentCell.RowIndex + 1];
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                }

            }
            if (((Button)sender).Name == "N_Cauda")
            {
                dataGridView1.CurrentCell = this.dataGridView1[Collnd, dataGridView1.RowCount-2];
                MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 0, 0);
            }

        }
        private void N_Previous_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void N_Next_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void N_Cauda_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        #endregion

        #region  GroupBox3模块
        private void button1_Click(object sender, EventArgs e)
        {
            //2017.4.12
        }

        #endregion

        #region     DatagridView模块
        /// <summary>
        /// 当前selectCell发生改变时tabPage中的内容发生改变！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
        /// Form_LOad时除了基本职工信息tabpage添加了内容，其他Tabpage没有添加内容，而这个函数可以改变这种状况，当然也可以在form_Load 中加入显示其他Page内容的程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentCell.RowIndex>-1)
                {
                    textBox1.Text = Grid_Inof(dataGridView1);//显示基本职工信息TabPage的当前记录
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                    //获取工作简历表中的信息
                    DataSet WDset = MyDataClass.getDataSet("select Sut_ID,ID,BeginDate as 开始时间,EndDate as 结束时间,Branch as 部门,Business as 职务,WordUnit as 工作单位 from tb_WordResume where Sut_ID='" + tem_ID + "'","tb_WordResume");
                    MyMC.Correlation_Table(WDset, dataGridView2);
                    if (WDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(WDset.Tables[0].Columns.Count, groupBox7.Controls, "Word_");
                    //else 如果按此处注释的来显示会有Bug，所以这种不用，而是需要根据此页面的Datagridview的CellEnter来弄
                    //    MyMC.Show_DGrid(dataGridView2, groupBox7.Controls, "Word_");
                    
                    //获取家庭关系表中的信息
                    DataSet FDset = MyDataClass.getDataSet("select Sut_ID,ID,LeaguerName as 家庭成员名称,Nexus as 与本人的关系,BirthDate as 出生日期,WordUnit as 工作单位,Business as 职务,Visage as 政治面貌,Phone as 电话 from tb_Family where Sut_ID='" + tem_ID + "'", "tb_Family");
                    MyMC.Correlation_Table(FDset, dataGridView3);
                    if (FDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(FDset.Tables[0].Columns.Count, groupBox10.Controls, "Family_");
                    //else
                    //    MyMC.Show_DGrid(dataGridView3, groupBox10.Controls, "Family_");

                    //获取培训记录表中的信息
                    DataSet TDset = MyDataClass.getDataSet("select Sut_ID,ID,TrainFashion as 培训方式,BeginDate as 培训开始时间, EndDate as 培训结束时间, Speciality as 培训专业, TrainUnit as 培训单位, KulturMemo as 培训内容, Charge as 费用, Effect as 效果 from tb_TrainNote where Sut_ID='" + tem_ID + "'", "tb_TrainNote");
                    MyMC.Correlation_Table(TDset, dataGridView4);
                    if (TDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(TDset.Tables[0].Columns.Count, groupBox12.Controls, "TrainNote_");

                    //获取奖惩记录表中的信息
                    DataSet RDset = MyDataClass.getDataSet("select Sut_ID,ID,RPKind as 奖惩种类,RPDate as 奖惩时间, SealMan as 批准人, QuashDate as 撤消时间, QuashWhys as 撤消原因 from tb_RANDP where Sut_ID='" + tem_ID + "'", "tb_RANDP");
                    MyMC.Correlation_Table(RDset, dataGridView5);
                    if (RDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(RDset.Tables[0].Columns.Count, groupBox14.Controls, "RANDP_");

                    //获取个人简历表中的信息
                    SqlDataReader Read_Memo = MyDataClass.getcom("Select * from tb_Individual where ID='" + tem_ID + "'");
                    if (Read_Memo.Read())
                        Ind_Mome.Text = Read_Memo[1].ToString();
                    else
                        Ind_Mome.Clear();
                    //下面这个获取个人简历表中的信息的方法也是可以的
                    //DataSet MDset = MyDataClass.getDataSet("Select * from tb_Individual where ID='" + tem_ID + "'", "tb_Individual");
                    //Ind_Mome.Text = MDset.Tables[0].Rows[0][1].ToString();
                }
            }
            catch { }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView2, groupBox7.Controls, "Word_");
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView3, groupBox10.Controls, "Family_");
        }

        private void dataGridView4_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView4, groupBox12.Controls, "TrainNote_");
        }

        private void dataGridView5_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView5, groupBox14.Controls, "RANDP_");
        }

        #endregion

       
    }
}
