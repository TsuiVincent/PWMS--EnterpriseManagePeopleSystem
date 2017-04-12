using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace PWMS__EnterpriseManagePeopleSystem.ModuleClass
{
    class MyModule
    {
        DataClass.MyMeans MyDataClass = new DataClass.MyMeans();
        public static string ADDs = "";//存储添加或修改的sql的语句
        public static string FindValue = "";
        public static string Address_ID = "";
        public static string User_ID = "";
        public static string User_Name = "";

        #region 调用相应子公共窗体(n是标识)
        public void Show_Form(string FrmName, int n)
        {
            if (n == 1) //打开相应窗口
            {
                if (FrmName == "人事档案管理")
                {
                    PerForm.F_ManFile FrmManFile = new PerForm.F_ManFile();
                    FrmManFile.Text = "人事档案管理";
                    FrmManFile.ShowDialog();
                    FrmManFile.Dispose();
                }
                if (FrmName == "人事资料查询")
                {
                    PerForm.F_Find FrmFind = new PerForm.F_Find();
                    FrmFind.Text = "人事资料查询";
                    FrmFind.ShowDialog();
                    FrmFind.Dispose();
                }
                if (FrmName == "人事资料统计")
                {
                    PerForm.F_Stat FrmStat = new PerForm.F_Stat();
                    FrmStat.Text = "人事资料统计";
                    FrmStat.ShowDialog();
                    FrmStat.Dispose();
                }
                if (FrmName == "员工生日提示")
                {
                    InfoAddForm.F_ClewSet FrmClewSet = new InfoAddForm.F_ClewSet();
                    FrmClewSet.Text = "员工生日提示";
                    FrmClewSet.Tag = 1;      //为1时是员工生日提醒，为2时是员工合同提示
                    FrmClewSet.ShowDialog();
                    FrmClewSet.Dispose();
                }
                if (FrmName == "员工合同提示")
                {
                    InfoAddForm.F_ClewSet FrmClewSet = new InfoAddForm.F_ClewSet();
                    FrmClewSet.Text = "员工合同提示";
                    FrmClewSet.Tag = 2;      //为1时是员工生日提醒，为2时是员工合同提示
                    FrmClewSet.ShowDialog();
                    FrmClewSet.Dispose();
                }
                if (FrmName == "日常记事")
                {
                    PerForm.F_WordPad FrmWordPad = new PerForm.F_WordPad();
                    FrmWordPad.Text = "日常记事";
                    FrmWordPad.ShowDialog();
                    FrmWordPad.Dispose();
                }
                if (FrmName == "通讯录")
                {
                    PerForm.F_AddressList FrmAddressList = new PerForm.F_AddressList();
                    FrmAddressList.Text = "通讯录";
                    FrmAddressList.ShowDialog();
                    FrmAddressList.Dispose();
                }
                if (FrmName == "备份/还原数据库")
                {
                    PerForm.F_HaveBack FrmHaveBack = new PerForm.F_HaveBack();
                    FrmHaveBack.Text = "备份/还原数据库";
                    FrmHaveBack.ShowDialog();
                    FrmHaveBack.Dispose();
                }
                if (FrmName == "清空数据库")
                {
                    PerForm.F_ClearData FrmClearData = new PerForm.F_ClearData();
                    FrmClearData.Text = "清空数据库";
                    FrmClearData.ShowDialog();
                    FrmClearData.Dispose();
                }
                if (FrmName == "重新登陆")
                {
                    F_Login FrmLogin = new F_Login();
                    FrmLogin.Tag = 2;
                    FrmLogin.ShowDialog();
                    FrmLogin.Dispose();
                }
                if (FrmName == "用户设置")
                {
                    PerForm.F_User FrmUser = new PerForm.F_User();
                    FrmUser.Text = "用户设置";
                    FrmUser.ShowDialog();
                    FrmUser.Dispose();
                }

                //启动系统程序
                if (FrmName == "计算器")
                {
                    System.Diagnostics.Process.Start("calc.exe");//系统程序计算器calculator
                }
                if (FrmName == "记事本")
                {
                    System.Diagnostics.Process.Start("notepad.exe");//
                }
                if (FrmName == "系统帮助")
                {
                    System.Diagnostics.Process.Start("readme.doc");//是系统带的还是自己制作的？？？？？？？！
                }


            }
            //****************
            if (n == 2)  //只打开F_basic窗口，将窗口名改为相应名称，进行操作
            {
                string FrmStr = "";//记录窗体名称
                if (FrmName == "民族类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Folk";
                    DataClass.MyMeans.Mean_Table = "tb_Folk";
                    DataClass.MyMeans.Mean_Field = "FolkName";
                    FrmStr = FrmName;
                }
                if (FrmName == "职工类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_EmployeeGenre";
                    DataClass.MyMeans.Mean_Table = "tb_EmployeeGenre";
                    DataClass.MyMeans.Mean_Field = "EmployeeName";
                    FrmStr = FrmName;
                }
                if (FrmName == "文化程度设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Culture";
                    DataClass.MyMeans.Mean_Table = "tb_Culture";
                    DataClass.MyMeans.Mean_Field = "CultureName";
                    FrmStr = FrmName;
                }
                if (FrmName == "政治面貌设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Visage";
                    DataClass.MyMeans.Mean_Table = "tb_Visage";
                    DataClass.MyMeans.Mean_Field = "VisageName";
                    FrmStr = FrmName;
                }
                if (FrmName == "部门类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Branch";
                    DataClass.MyMeans.Mean_Table = "tb_Branch";
                    DataClass.MyMeans.Mean_Field = "BranchName";
                    FrmStr = FrmName;
                }
                if (FrmName == "工资类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Laborage";
                    DataClass.MyMeans.Mean_Table = "tb_Laborage";
                    DataClass.MyMeans.Mean_Field = "LaborageName";
                    FrmStr = FrmName;
                }
                if (FrmName == "职务类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Business";
                    DataClass.MyMeans.Mean_Table = "tb_Business";
                    DataClass.MyMeans.Mean_Field = "BusinessName";
                    FrmStr = FrmName;
                }
                if (FrmName == "职称类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_Duthcall";
                    DataClass.MyMeans.Mean_Table = "tb_Duthcall";
                    DataClass.MyMeans.Mean_Field = "DuthcallName";
                    FrmStr = FrmName;
                }
                if (FrmName == "奖惩类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_RPKind";
                    DataClass.MyMeans.Mean_Table = "tb_RPKind";
                    DataClass.MyMeans.Mean_Field = "RPKind";
                    FrmStr = FrmName;
                }
                if (FrmName == "记事本类别设置")
                {
                    DataClass.MyMeans.Mean_SQL = "select * from tb_WordPad";
                    DataClass.MyMeans.Mean_Table = "tb_WordPad";
                    DataClass.MyMeans.Mean_Field = "WordPad";
                    FrmStr = FrmName;
                }
                InfoAddForm.F_Basic FrmBasic = new InfoAddForm.F_Basic();
                FrmBasic.Text = FrmStr;//设置窗体名称
                FrmBasic.ShowDialog();
                FrmBasic.Dispose();
            }
        }
        #endregion

        #region 将statusstrip控件中的信息添加到treeview控件中
        public void GetMenu(TreeView treeV, MenuStrip MenuS)
        {
            //遍历MenuStrip组件中的一级菜单
            for (int i = 0; i < MenuS.Items.Count; i++)
            {
                TreeNode newNode1 = treeV.Nodes.Add(MenuS.Items[i].Text);
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                {
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                        //将二级菜单名称添加到TREEVIEW的子节点newnode1中
                        TreeNode newNode2 = newNode1.Nodes.Add(newmenu.DropDownItems[j].Text);
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)
                        {
                            //将三级菜单名称添加到treeview的子节点newnode2中
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                            {
                                newNode2.Nodes.Add(newmenu2.DropDownItems[p].Text);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 清空指定控件,文字或图片
        public void Clear_Control(Control.ControlCollection Con)
        {
            foreach (Control C in Con)
            {
                if (C.GetType().Name == "TextBox")
                {
                    if (((TextBox)C).Visible == true)
                    {
                        ((TextBox)C).Clear();
                    }
                }
                if (C.GetType().Name == "MaskedTextBox")//maskedTEXTbox为限制输入格式的文本框
                {
                    if (((MaskedTextBox)C).Visible == true)
                    {
                        ((MaskedTextBox)C).Clear();
                    }
                }
                if (C.GetType().Name == "ComboBox")
                {
                    if (((ComboBox)C).Visible == true)
                    {
                        ((ComboBox)C).Text = "";
                    }
                }
                if (C.GetType().Name == "PictureBox")
                {
                    if (((PictureBox)C).Visible == true)
                    {
                        ((PictureBox)C).Image = null;
                    }
                }
            }
        }
        #endregion

        #region 将日期转化为指定格式
        public string Date_Format(string NDate)
        {
            string sm, sd;//字符串形式的月与日
            int y, m, d;
            try
            {
                y = Convert.ToDateTime(NDate).Year;
                m = Convert.ToDateTime(NDate).Month;
                d = Convert.ToDateTime(NDate).Day;
            }
            catch
            {
                return "";
            }
            if (y == 1900)
                return "";
            if (m < 10)
            {
                sm = "0" + Convert.ToString(m);
            }
            else
                sm = Convert.ToString(m);
            if (d < 10)
                sd = "0" + Convert.ToString(d);
            else
                sd = Convert.ToString(d);
            return Convert.ToString(y) + "-" + sm + "-" + sd;
        }
        #endregion

        #region 保存添加或修改的信息
        /// <summary>
        /// 有点不明白！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
        /// </summary>
        /// <param name="Sarr">数据表中所有字段</param>
        /// <param name="ID1">第一个字段值，数据表中的ID字段名，在修改表时，用于条件字段</param>
        /// <param name="ID2">第二个字段值，数据表中的职工编号字段，可以为空</param>
        /// <param name="Contr">指定控件的数据集</param>
        /// <param name="BoxName">要搜索的控件名称</param>
        /// <param name="TableName">数据表名称</param>
        /// <param name="n">控件个数</param>
        /// <param name="m">标识，用于判断是添加还是修改</param>
        public void Part_SaveClass(string Sarr, string ID1, string ID2, Control.ControlCollection Contr, string BoxName, string TableName, int n, int m)
        {
            string tem_Field = "", tem_Value = "";
            int p = 2;//为一时表示第一字段ID1不为空，而第二字段为空，为2时表示剩下的情况
            if (m == 1)//m为一时是添加数据
            {
                if (ID1 != "" && ID2 == "")//有第一字段而无第二字段值
                {
                    tem_Field = "ID";
                    tem_Value = "'" + ID1 + "'";
                    p = 1;
                }
                else
                {
                    tem_Field = "Sta_id,ID";
                    tem_Value = "'" + ID1 + "','" + ID2 + "'";
                }
            }
            else if (m == 2)//修改数据信息
            {
                if (ID1 != "" && ID2 == "")
                {
                    tem_Value = "ID='" + ID1 + "'";
                    p = 1;
                }
                else
                    tem_Value = "Sta_ID='" + ID1 + "',ID='" + ID2 + "'";

                if (m > 0)//添加或者修改
                {
                    string[] Parr = Sarr.Split(Convert.ToChar(','));
                    for (int i = p; i < n; i++)
                    {
                        string sID = BoxName + i.ToString();
                        foreach (Control C in Contr)
                        {
                            if (C.GetType().Name == "TextBox" | C.GetType().Name == "maskedTextBox" | C.GetType().Name == "ComboBox")
                            {
                                if (C.Name == sID)//控件名slD为自己设定的，，而c.gettype.name为控件类型名
                                {
                                    string Ctext = C.Text;
                                    if (C.GetType().Name == "maskedTextBox")
                                        Ctext = Date_Format(C.Text);
                                    if (m == 1)//组合SQL语句中insert的相关语句
                                    {
                                        tem_Field = tem_Field + "," + Parr[i];
                                        if (Ctext == "")
                                        {
                                            tem_Value = tem_Value + "," + "NULL";
                                        }
                                        else
                                        {
                                            tem_Value = tem_Value + "," + "'" + Ctext + "'";
                                        }
                                    }
                                    if (m == 2)//组合SQL中的update相关语句
                                    {
                                        if (Ctext == "")
                                        {
                                            tem_Value = tem_Value + "," + Parr[i] + "=NULL";
                                        }
                                        else
                                        {
                                            tem_Value = tem_Value + "," + Parr[i] + "='" + Ctext + "'";
                                        }
                                    }

                                }
                            }
                        }
                    }
                    ADDs = "";
                    if (m == 1)
                        ADDs = "insert into " + TableName + " (" + tem_Field + ") values(" + tem_Value + ")";
                    if (m == 2)
                    {
                        if (ID2 == "")
                            ADDs = "update " + TableName + " set " + tem_Value + " where ID='" + ID1 + "'";
                        else
                            ADDs = "update " + TableName + " set " + tem_Value + " where ID='" + ID2 + "'";
                    }
                }
            }

        }
        #endregion

        #region 自动编号
        public string GetAutocoding(string TableName, string ID)
        {
            //查找指定表中ID号为最大的记录
            SqlDataReader MyDR = MyDataClass.getcom("select max(" + ID + ") as NID from " + TableName);//getcom("select max(" + ID + ")  NID from " + TableName)把as省略了
            int Num = 0;
            if (MyDR.HasRows)
            {
                MyDR.Read();
                if (MyDR[0].ToString() == "")
                    return "0001";
                Num = Convert.ToInt32(MyDR[0].ToString());
                ++Num;
                string s = string.Format("{0:0000}", Num);
                return s;
            }
            else
            {
                return "0001";
            }
        }
        #endregion

        #region 向combobox控件传递数据表中的数据，向下拉列表中传递数据
        public void CoPassData(ComboBox cobox, string TableName)
        {
            cobox.Items.Clear();
            DataClass.MyMeans MyDataClsaa = new DataClass.MyMeans();
            SqlDataReader MyDR = MyDataClsaa.getcom("select * from " + TableName);
            if (MyDR.HasRows)
            {
                while (MyDR.Read())//添加表中第2列的数据***.[1]
                {
                    if (MyDR[1].ToString() != "" && MyDR[1].ToString() != null)
                        cobox.Items.Add(MyDR[1].ToString());
                }
            }
        }
        #endregion

        #region 动态向combobox传递各省市名称，添加到下拉列表中
        public void CityInfo(ComboBox cobox, string SQLstr, int n)
        {
            cobox.Items.Clear();
            DataClass.MyMeans MyDataClsaa = new DataClass.MyMeans();
            SqlDataReader MyDR = MyDataClsaa.getcom(SQLstr);
            if (MyDR.HasRows)
            {
                while (MyDR.Read())
                {
                    if (MyDR[n].ToString() != "" && MyDR[n].ToString() != null)
                        cobox.Items.Add(MyDR[n].ToString());
                }
            }
        }
        #endregion

        #region 将时间转换成指定的格式
        public string Time_Format(string NDate)
        {
            string sh, sm, se;
            int hh, mm, ss;
            try
            {
                hh = Convert.ToDateTime(NDate).Hour;
                mm = Convert.ToDateTime(NDate).Minute;
                ss = Convert.ToDateTime(NDate).Second;
            }
            catch
            {
                return "";
            }
            sh = Convert.ToString(hh);
            if (sh.Length < 2)
                sh = "0" + sh;
            sm = Convert.ToString(mm);
            if (sm.Length < 2)
                sm = "0" + sm;
            se = Convert.ToString(ss);
            if (se.Length < 2)
                se = "0" + se;
            return sh + sm + se;
        }
        #endregion

        #region 设置maskedTextBox控件的格式设为yyyy-mm-dd格式
        /// <summary>
        /// 将maskedTextBox控件的格式设为yyyy-mm-dd格式
        /// </summary>
        /// <param name="MTBox"></param>
        public void MaskedTextBox_Format(MaskedTextBox MTBox)
        {
            MTBox.Mask = "0000-00-00";
            MTBox.ValidatingType = typeof(System.DateTime);//设置文本输入的格式类型为system.datetime
        }
        #endregion

        #region 用按钮控制数据记录移动时，改变按钮的可用状态//设置按钮是否可用
        public void Ena_Button(Button B1, Button B2, Button B3, Button B4, int n1, int n2, int n3, int n4)
        {
            B1.Enabled = Convert.ToBoolean(n1);
            B2.Enabled = Convert.ToBoolean(n2);
            B3.Enabled = Convert.ToBoolean(n3);
            B4.Enabled = Convert.ToBoolean(n4);
        }
        #endregion
        #region  将当前的数据信息显示在指定的控件datagridview上
        /// <summary>
        /// 将当前在datagrid控件的当前记录显示在其他控件上
        /// </summary>
        /// <param name="DGrid"></param>
        /// <param name="GBox">GroupBox控件的数据集</param>
        /// <param name="TName">获取信息控件的部分名称</param>
        public void Show_DGrid(DataGridView DGrid,Control.ControlCollection GBox,string TName)
        {
            string sID = "";
            if(DGrid.RowCount>0)
            {
                for(int i=2;i<DGrid.ColumnCount;i++)
                {
                    sID = TName + i.ToString();
                    foreach(Control C in GBox)
                    {
                        if(C.GetType().Name=="TextBox"|C.GetType().Name=="MaskedTextBox"| C.GetType().Name == "ComboBox")
                        {
                            if(C.Name==sID)
                            {
                                if (C.GetType().Name != "MaskedTextBox")
                                    C.Text = DGrid[i, DGrid.CurrentCell.RowIndex].Value.ToString();
                                else
                                    C.Text = Date_Format(Convert.ToString(DGrid[i, DGrid.CurrentCell.RowIndex].Value).Trim());
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region  清空groupbox控件上的信息(n为控件个数)
        public void Clear_Grids(int n, Control.ControlCollection GBox,string TName)
        {
            string sID = "";
            for(int i=2;i<n;i++)
            {
                sID = TName + i.ToString();
                foreach(Control C in GBox)
                {
                    if(C.GetType().Name=="TextBox"| C.GetType().Name == "MaskedTextBox" | C.GetType().Name == "ComboBox" )
                        if(C.Name==sID)
                        {
                            C.Text = "";
                        }
                }

            }
        }

        #endregion

        #region 控制数据表的显示字段（correlation相关性相互关系）
        /// <summary>
        /// 将表数据显示在控件上，并使得表的第一列第二列不显示，并且表空间的行头一列不显示，选择时只能整行整行选择
        /// </summary>
        /// <param name="DSet"></param>
        /// <param name="DGrid"></param>
        public void Correlation_Table(DataSet DSet,DataGridView DGrid )
        {
            DGrid.DataSource = DSet.Tables[0];
            DGrid.Columns[0].Visible = false;
            DGrid.Columns[1].Visible = false;
            DGrid.RowHeadersVisible = false;
            DGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

        #region  组合查询条件
        /// <summary>
        /// 该方法主要功能是查找指定可视化控件集中空间名包含TName参数值的所有控件
        /// </summary>
        /// <param name="GBox">groupbox控件数据集</param>
        /// <param name="TName">Tname为获取信息控件的部分名称</param>
        /// <param name="ANDSign">查询关系,逻辑运算符AND、OR</param>
        public void Find_Grids(Control.ControlCollection GBox,string TName,string ANDSign)
        {
            string sID = "";
            if (FindValue.Length > 0)//findvalue为公共字符串
                FindValue = FindValue + ANDSign;
            foreach(Control C in GBox)
            {
                if(C.GetType().Name=="TextBox"| C.GetType().Name == "ComboBox" )
                {
                    if(C.GetType().Name=="ComboBox" && C.Text!="" )
                    {
                        sID = C.Name;  //获取当前控件名称
                        if(sID.IndexOf(TName)>-1)//判断TName参数值是否为当前控件名的子字符串
                        {
                            string[] Astr = sID.Split(Convert.ToChar('_'));//用“_”符号分隔当前控件的名称,获取相应的字段名
                            FindValue = FindValue + "(" + Astr[1] + "='" + C.Text + "')" + ANDSign;//生成查询条件 select *.....
                        }
                    }
                    if(C.GetType().Name=="TextBox"&&C.Text!="")
                    {
                        sID = C.Name;
                        if(sID.IndexOf(TName)>-1)
                        {
                            string[] Astr = sID.Split(Convert.ToChar('_'));
                            string m_Sign = "";//记录逻辑运算符
                            string mID = "";//记录字段名
                            if (Astr.Length > 2)//数组元素大于2时
                                mID = Astr[1] + "_" + Astr[2];
                            else
                                mID = Astr[1];
                            foreach(Control C1 in GBox)
                            {
                                if(C1.GetType().Name=="ComboBox")//判断是否为复合框
                                    if((C1.Name).IndexOf(mID)>-1)
                                    {
                                        if (C1.Text == "")//查询条件为空时
                                            break;
                                        else
                                        {
                                            m_Sign = C1.Text;
                                            break;
                                        }
                                    }
                            }
                            if(m_Sign!="")
                            {
                                FindValue = FindValue + "(" + mID + m_Sign + C.Text + ")" + ANDSign;//组合SQL语句查询条件
                            }
                        }
                    }
                }
            }
            if (FindValue.Length > 0)  //当存储查询条件的变量不为空时，删除逻辑运算符and和or
            {
                if (FindValue.IndexOf("AND") > -1)
                    FindValue = FindValue.Substring(0, FindValue.Length - 4);//提取除了and的子字符
                if (FindValue.IndexOf("OR") > -1)
                    FindValue = FindValue.Substring(0, FindValue.Length - 3);
            }
            else
                FindValue = "";

        }
        #endregion

        #region 评估字符型日期是否正确
        public bool Estimate_Date(MaskedTextBox MTbox)
        {
            try
            {
                DateTime DT = DateTime.Parse(MTbox.Text.Trim());
                return true;
            }
            catch
            {
                MTbox.Text = "";
                MessageBox.Show("日期输入错误，请重新输入！");
                return false;
            }
        }
        #endregion

        #region 设置文本框只能输入数字型字符串
        /// <summary>
        /// *********************************????????????????????????????????
        /// </summary>
        /// <param name="e"></param>
        /// <param name="s">文本框字符串</param>
        /// <param name="n">标识，判断是数字型还是单精度型</param>
        public void Estimate_Key(KeyPressEventArgs e,string s,int n)
        {
            if(n==0) //只能输入数字型整型
            {
                if(!(e.KeyChar<='9'&&e.KeyChar>='0')&&e.KeyChar!='\r'&&e.KeyChar!='\b')
                {
                    e.Handled = true;
                }
            }
            if(n==1)
            {
                if((!(e.KeyChar<='9'&&e.KeyChar>='0'))&&e.KeyChar!='.'&&e.KeyChar != '\r' && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
                else
                {
                    if(e.KeyChar=='.')
                    {
                        if (s == "")
                            e.Handled = true;
                        else
                        {
                            if(s.Length>0)
                            {
                                if (s.IndexOf(".") > -1)
                                    e.Handled = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 添加用户权限
        /// <summary>
        /// 添加用户时，将权限模板中的信息添加到用户权限中
        /// </summary>
        /// <param name="ID">用户编号</param>
        /// <param name="n">权限值</param>
        public void ADD_Pope(string ID,int n)
        {
            DataSet DSet;
            DSet = MyDataClass.getDataSet("select PopeName from tb_PopeModel", "tb_PopeModel");
            for(int i=0;i<DSet.Tables[0].Rows.Count;i++)
            {
                MyDataClass.getsqlcom("insert into tb_UserPope (ID,PopeName,Pope) values ('" + ID + "," + Convert.ToString(DSet.Tables[0].Rows[i][0]) + "'," + n + ")");

            }
        }
        #endregion

        #region 清空数据库所有数据表++++++++++++
        public void Clear_Table(Control.ControlCollection GBox,string TName)
        {
            string sID = "";
            foreach(Control C in GBox)
            {
                if(C.GetType().Name=="CheckBox")
                {
                    sID = C.Name;
                    if(sID.IndexOf(TName)>-1)
                    {
                        if(((CheckBox)C).Checked==true)
                        {
                            string TableName = "";
                            string[] Astr = sID.Split(Convert.ToChar('_'));
                            TableName = "tb_" + Astr[1];
                            if(Astr[1].ToUpper()==("Clew").ToUpper())
                            {
                                MyDataClass.getsqlcom("update" + TableName + " set Fate=0,Unlock=0 where ID>0");
                            }
                            else
                            {
                                MyDataClass.getsqlcom("Delete " + TableName);
                                if(Astr[1].ToUpper()==("Login").ToUpper())
                                {
                                    MyDataClass.getsqlcom("insert into "+TableName+" （ID,Name,Pass）values('0001','TSoft','111')");
                                    ADD_Pope("0001", 1);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 显示用户权限
        public void Show_Pope(Control.ControlCollection GBox,string TID)
        {
            string sID = "";
            string CheckName = "";
            bool t = false;
            DataSet DSet = MyDataClass.getDataSet("select ID,PopeName,Pope from tb_UserPope where ID='" + TID + "'", "tb_UserPope");
            for(int i=0;i<DSet.Tables[0].Rows.Count;i++)
            {
                sID = Convert.ToString(DSet.Tables[0].Rows[i][1]);//得到的是PopeName
                if ((int)(DSet.Tables[0].Rows[i][2]) == 1) //查看当前选项的权限是否为1
                {
                    t = true;
                }
                else
                    t = false;
                foreach (Control C in GBox)
                {
                    if(C.GetType().Name=="CheckBox")
                    {
                        CheckName = C.Name;
                        if(CheckName.IndexOf(sID)>-1)
                        {
                            ((CheckBox)C).Checked = t;          //确认当前用户的权限，在F_UerPope对话框中，有权限的打钩；
                        }
                    }
                }
            }
        }
        #endregion

        #region 修改指定用户权限
        public void Amend_Pope(Control.ControlCollection GBox,string TID)
        {
            string CheckName = "";
            int tt = 0;   //权限，1有权限，0无权限
            foreach(Control C in GBox)
            {
                if(C.GetType().Name=="CheckBox")
                {
                    if (((CheckBox)C).Checked)
                        tt = 1;                 //在F_UserPope中修改权限，打钩则tt变为1
                    else
                        tt = 0;
                    CheckName = C.Name;
                    string[] Astr = CheckName.Split(Convert.ToChar('_'));
                    //将修改后的权限传入数据库，Astr[1]为POPE名
                    MyDataClass.getsqlcom("update tb_UserPope set Pope=" + tt + " where (ID='" + TID + "') and PopeName='" + Astr[1].Trim() + "')");
                    
                }
            }
        }
        #endregion

        #region 设置主窗体菜单不可用
        /// <summary>
        /// 初始化主窗体，使得底层菜单( 菜单栏中的各子菜单项)不可用，即不含Menu的下拉菜单不可用MainMEnuFalse
        /// </summary>
        /// <param name="MenuS"></param>
        public void MainMenuF(MenuStrip MenuS)
        {
            string Men = "";
            for(int i=0;i<MenuS.Items.Count;i++)
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name;//ToolStripDropDownItem,而不是ToolStripMenuItem???
                if(Men.IndexOf("Menu")==-1)//如果不含有menu,不可用
                {
                    ((ToolStripDropDownItem)MenuS.Items[i]).Enabled = false;
                }
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if(newmenu.HasDropDownItems&&newmenu.DropDownItems.Count>0)
                {
                    for(int j=0;j<newmenu.DropDownItems.Count;j++)
                    {
                        Men = newmenu.DropDownItems[j].Name;
                        if (Men.IndexOf("Menu") == -1)
                            newmenu.DropDownItems[j].Enabled = false;
                        ToolStripDropDownItem newmenu2 = (ToolStripDropDownItem)newmenu.DropDownItems[j];
                        if (newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)
                            for (int p = 0; p < newmenu2.DropDownItems.Count; p++)
                                newmenu2.DropDownItems[p].Enabled = false;//为什么直接不能用了？？因为主窗体中三级菜单名根本不含Menu,所以直接不可用
                    }
                }
            }
        }
        #endregion

        #region  根据用户权限设置主窗体菜单
        /// <summary>
        /// 设置2,3级别菜单是否可用
        /// </summary>
        /// <param name="Menus"></param>
        /// <param name="UName"></param>
        public void MainPope(MenuStrip Menus,string UName)
        {
            string Str = "";
            string MenuName = "";
            DataSet DSet = MyDataClass.getDataSet("select ID from tb_Login where Name='" + UName + "'", "tb_Login");
            string UID = Convert.ToString(DSet.Tables[0].Rows[0][0]);//获取当前用户ID编号
            DSet = MyDataClass.getDataSet("select ID,PopeName,Pope from tb_UserPope where ID='" + UID + "'", "tb_UserPope");//获取当前用户权限信息
            bool bo = false;
            for(int k=0;k<DSet.Tables[0].Rows.Count;k++)
            {
                Str = Convert.ToString(DSet.Tables[0].Rows[k][1]);//权限名称
                if (Convert.ToInt32(DSet.Tables[0].Rows[k][2]) == 1)//判断该项权限
                {
                    bo = true;
                }
                else
                    bo = false;
                for(int i=0;i<Menus.Items.Count;i++)
                {
                    ToolStripDropDownItem newmenu = (ToolStripDropDownItem)Menus.Items[i];
                    if(newmenu.HasDropDownItems&&newmenu.DropDownItems.Count>0)
                        for(int j=0;j< newmenu.DropDownItems.Count;j++)//遍历二级菜单
                        {
                            MenuName = newmenu.DropDownItems[j].Name;
                            if(MenuName.IndexOf(Str)>-1)//如果包含权限名称,则将使得改菜单的可用状态变为bo
                            {
                                newmenu.DropDownItems[j].Enabled = bo;
                            }
                            ToolStripDropDownItem newmenu2= (ToolStripDropDownItem)newmenu.DropDownItems[j];
                            if(newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count > 0)//如果存在三级菜单
                            {
                                for(int p=0;p<newmenu2.DropDownItems.Count;p++)//遍历三级菜单
                                {
                                    MenuName = newmenu2.DropDownItems[p].Name;
                                    if(MenuName.IndexOf(Str)>-1)
                                    {
                                        newmenu2.DropDownItems[p].Enabled = bo;
                                    }
                                }
                            }
                        }
                }

            }
        }
        #endregion

        #region 用treeview控件调用statusstrip控件下的菜单的单击事件
        /// <summary>
        /// 通过Menustrip打开相应窗口
        /// </summary>
        /// <param name="MenuS"></param>
        /// <param name="e"></param>
        public void TreeMenuF(MenuStrip MenuS,TreeNodeMouseClickEventArgs e)
        {
            string Men = "";
            for(int i=0;i<MenuS.Items.Count;i++)//遍历menustrip控件中主菜单
            {
                Men = ((ToolStripDropDownItem)MenuS.Items[i]).Name;
                if (Men.IndexOf("Menu") == -1)//no sub menu
                {
                    if (((ToolStripDropDownItem)MenuS.Items[i]).Text == e.Node.Text)
                    {
                        if (((ToolStripDropDownItem)MenuS.Items[i]).Enabled == false)
                        {
                            MessageBox.Show("当前用户无权限调用" + "\"" + e.Node.Text + "\"" + "窗体");//\为转义；当前用户无权调用“node.text”窗体
                            break;
                        }
                        else
                            Show_Form(((ToolStripDropDownItem)MenuS.Items[i]).Text.Trim(),1);
                    }
                }
                //有子菜单时
                ToolStripDropDownItem newmenu = (ToolStripDropDownItem)MenuS.Items[i];
                if(newmenu.HasDropDownItems&&newmenu.DropDownItems.Count>0)
                {
                    for(int j=0;j<newmenu.DropDownItems.Count;j++)
                    {
                        Men = ((ToolStripDropDownItem)newmenu.DropDownItems[j]).Name;
                        if(Men.IndexOf("Menu")==-1)
                        {
                            if(((ToolStripDropDownItem)newmenu.DropDownItems[j]).Text==e.Node.Text)
                            {
                                if (((ToolStripDropDownItem)newmenu.DropDownItems[j]).Enabled == false)
                                {
                                    MessageBox.Show("当前用户无权限调用" + "\"" + e.Node.Text + "\"" + "窗体");//\为转义；当前用户无权调用“node.text”窗体
                                    break;
                                }
                                else
                                    Show_Form(newmenu.DropDownItems[j].Text.Trim(), 1);
                            }
                            
                        }
                        else  //可以加else，可以不加
                        {
                            ToolStripDropDownItem newmenu2= (ToolStripDropDownItem)newmenu.DropDownItems[j];
                            if(newmenu2.HasDropDownItems && newmenu2.DropDownItems.Count>0)
                            {
                                for(int p=0;p<newmenu2.DropDownItems.Count;p++)
                                {
                                    if(((ToolStripDropDownItem)newmenu2.DropDownItems[p]).Text==e.Node.Text)
                                    {
                                        if (((ToolStripDropDownItem)newmenu2).DropDownItems[p].Enabled == false)
                                        {
                                            MessageBox.Show("当前用户无权限调用" + "\"" + e.Node.Text + "\"" + "窗体");//\为转义；当前用户无权调用“node.text”窗体
                                            break;
                                        }
                                        else
                                        {
                                            //员工生日提示，员工合同提示只在三级菜单，即二级下拉菜单
                                            if((newmenu2.DropDownItems[p]).Text.Trim()=="员工生日提示"||(newmenu2.DropDownItems[p]).Text.Trim()=="员工合同提示")
                                            {
                                                Show_Form((newmenu2.DropDownItems[p]).Text.Trim(), 1);
                                            }
                                            else
                                                Show_Form((newmenu2.DropDownItems[p]).Text.Trim(), 2);//此时是基础数据设置，包括民族类别设置、职工类别设置.......
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 查询指定范围内生日与合同到期的职工(Tb_clew为提示表)
        /// <summary>
        /// 查找kind=i种类并且未被锁定的员工，提示表信息1是生日提醒2是合同日期提醒
        /// </summary>
        /// <param name="i"></param>
        public void PactDay(int i)
        {
            DataSet DSet = MyDataClass.getDataSet("select * from tb_Clew where kind=" + i + " and unlock=1", "tb_clew");
            if(DSet.Tables[0].Rows.Count>0)
            {
                string Vfield = "";
                string dSQL = "";
                int sday = Convert.ToInt32(DSet.Tables[0].Rows[0][1]);//得到的是Fate,期限
                if(i==1)
                {
                    Vfield = "Birthday";
                    //DATEDIFF(datepart,startdate,enddate)函数返回两个日期之间的时间；
                    //getdate()返回当前的日期与时间
                    //CAST()函数可以将某种数据类型的表达式转化为另一种数据类型/cast表达式 as 数据类型)/ex:CAST('234' as int)+123
                    //CONVERT()函数也可以将制定的数据类型转换为另一种数据类型/convert(数据类型[(长度)],表达式[,样式])/ex:convert(Varchar(10),年龄)+'岁',时间 from Table_2
                    ///得到的是birthda满足0<=datediff(day,today,birthday)<=sday的数据
                    dSQL = "select * from tb_Stuffbusic where (datediff(day,getdate(),convert(Nvarchar(12),cast (cast (year(getdate()) as char(4))+'-'+ cast(month(" + Vfield + ") as char(2))+'-'+	cast (day(" + Vfield + ") as char(2)) as datetime),110))<=" + sday + ") and (datediff(day,getdate(),convert(Nvarchar(12),cast (cast (year(getdate()) as char(4))+'-'+ cast(month(" + Vfield + ") as char(2))+'-'+cast (day(" + Vfield + ") as char(2)) as datetime),110))>=0)";

                }
                else
                {
                    Vfield = "Pact_E";//Pact_E是合同截止日期??Fate到底是什么？？？？？？？？？Fate是提醒期限，提前几天
                    ///得到的是Pact_E满足0>=(today-Pact_E)>=-sday的数据
                    dSQL = "select * from tb_Stuffbusic where ((getdate()-convert(Nvarchar(12)," + Vfield + ",110))>=-" + sday + " and (getdate()-convert(Nvarchar(12)," + Vfield + ",110))<=0)";
                }
                DSet = MyDataClass.getDataSet(dSQL, "tb_Stuffbusic");
                if(DSet.Tables[0].Rows.Count>0)
                {
                    if (i == 1)
                        Vfield = "是否查看" + sday.ToString() + "天内过生日的职工信息？";
                    else
                        Vfield = "是否查看" + sday.ToString() + "天内合同到期的职工信息？";
                    if(MessageBox.Show(Vfield,"提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        DataClass.MyMeans.AllSql = dSQL;//F_ManFile窗口所需要的语句（存储职工基本信息表中的SQL语句）
                        Show_Form("人事档案管理", 1);//打开F_ManFile窗口
                    }
                }
            }
        }

        #endregion

        #region 将图片存储到数据库中
        /// <summary>
        /// 以二进制形式将图片存储到数据库中
        /// </summary>
        /// <param name="MID">职工编号</param>
        /// <param name="p">图片二进制形式</param>
        public void SaveImage(string MID,byte[] p)
        {
            MyDataClass.con_open();
            StringBuilder strSql = new StringBuilder();//stringBuilder为可变字符串类
            strSql.Append("update tb_Stuffbusic Set Photo=@Photo where ID=" + MID);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), DataClass.MyMeans.My_conn);
            cmd.Parameters.Add("@Photo", SqlDbType.Binary).Value = p;//sqlDbType为数据库数据类型类
            cmd.ExecuteNonQuery();
            DataClass.MyMeans.My_conn.Close();
        }
        #endregion
    }
}
