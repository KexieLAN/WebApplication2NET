using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2NET
{
    #region 遗弃代码

    public class Filed_Info
    {

    }
    public class Sys_Info
    {
        //public Sys_Info per;
        public ushort waring_count;     //总报警个数
        public ushort bug_count;         //总故障个数
        public ushort detector_count;  //总探测器个数
        //public Sys_Info next;
    }
    public class Bug_Info
    {
        //public Bug_Info per;
        public byte reserved1;          //预留扩展
        public byte reserved2;
        public byte def_zone;           //防护区
        public byte device_type;        //设备类型
        public byte device_number;  //设备编号
        public byte bug_code;           //故障代码
        //public Bug_Info next;
    }
    public class Partition_Info
    {
        //public Partition_Info per;
        public ushort reserved;         //预留扩展
        public ushort def_zone;         //防护区
        public ushort waring_level;     //警报等级
        public ushort bug;                  //故障
        public ushort handla_mode;  //手动模式
        public ushort auto_mode;      //自动模式
        public ushort handla_boot;      //手动启动
        public ushort handla_shut;      //手动急停
        public ushort boot_ctrl;            //启动控制
        public ushort delay;                //延时
        public ushort spray_start;   //启动喷洒
        public ushort spraying;             //喷洒
        //public Partition_Info next;
    }
    public class Detector_Info
    {
        //public Detector_Info per;
        public ushort reserved;         //预留扩展
        public ushort def_zone;         //防护区
        public ushort type;                 //类型
        public ushort ID;                   //ID
        public ushort waring_level;     //警报等级
        public ushort temperaturer;     //温度
        public ushort CO;                   //CO
        public ushort VOC;                  //VOC
        public ushort smoke;                //烟雾
        //public Detector_Info next;
    }
    public class Fire_Extinguisher_Info
    {
        //public Detector_Info per;
        public ushort sharpNumber;
        //public Detector_Info next;
    }

    #endregion

    public partial class WebForm1 : System.Web.UI.Page
    {
        #region 遗弃代码
        /*
        public static List<Sys_Info> sysInfos = new List<Sys_Info>();
        public static byte sysInfos_num;

        public static List<Bug_Info> bugInfos = new List<Bug_Info>();
        public static byte bugInfos_num;

        public static List<Partition_Info> partitionInfos = new List<Partition_Info>();
        public static byte partitionInfos_num;

        public static List<Detector_Info> detectorInfos = new List<Detector_Info>();
        public static byte detectorInfos_num;

        public static List<Fire_Extinguisher_Info> fireExtinguisherInfos = new List<Fire_Extinguisher_Info>();
        public static byte fireExtinguisherInfos_num;

        //private Thread bks;

        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            bks = new Thread(Data_Process);
            bks.IsBackground = true;
        }
        */

        #endregion
        string connectString = @"Data Source=KEXIELAN\SQLEXPRESS;Database=MySer;User ID=WebMSU;Pwd=LXY621621;";
        private SqlConnection sConn;

        protected void Button_Start_Click(object sender, EventArgs e)
        {
            sConn = new SqlConnection(connectString);
            try
            { 
                sConn.Open(); 
                Label_Sta.Text = "数据库连接成功，开始监视";
            }
            catch (Exception err) 
            { 
                Label_Sta.Text = "数据库连接失败，监视失败";
            }
        }

        protected void Button_Stop_Click(object sender, EventArgs e)
        {
            Label_Sta.Text = "已停止";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region MyRegion
            /*
            if (sConn==null)
            {
                sConn = new SqlConnection(connectString);
                try
                {
                    sConn.Open();
                    Label_Sta.Text = "数据库连接成功";
                }
                catch (Exception err)
                {
                    Label_Sta.Text = "数据库连接失败";
                }
            }
            */
            #endregion
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sConn!=null)
            {
                sConn.Close();
            }
        }

    }
    
}