using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2NET
{
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

    public partial class WebForm1 : System.Web.UI.Page
    {
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

        private Thread bks;
        private List_op listOP = new List_op();

        protected void Page_Load(object sender, EventArgs e)
        {
            bks = new Thread(Data_Process);
            bks.IsBackground = true;
        }

        protected void Button_Start_Click(object sender, EventArgs e)
        {
            listOP.List_Clearn();
            bks.Start();
        }

        public void Data_Process()
        {
            //byte[] bufferBytes = new byte[] { 0 };
            //系统信息Test
            /*byte[] bufferBytes = new byte[]
            {0x51,0x4E,0x00,0x10,
                0x23,
                0x60,
                0x00,
                0x01,
                0x01,0x00,0x01,0x00,0x02,0x00,0x03,
                0x12,0x45 };

            */
            //故障信息Test

            byte[][] bufferBytes = new byte[3][]
            {
                    new byte[]{
                        0x51, 0x4E, 0x00, 0x10,
                        0x23,
                        0x60,
                        0x00,
                        0x01,
                        0x01, 0x00, 0x01, 0x00, 0x02, 0x00, 0x03,
                        0x12, 0x45
                    },
                    new byte[]{
                        0x51, 0x4E, 0x00, 0x10,
                        0x23,
                        0x70,
                        0x00,
                        0x01,

                        0x01,
                        0x00, 0x00,
                        0x01,
                        0x10,
                        0xFF,
                        0x00,

                        0x12, 0x45
                    },
                    new byte[]{
                        0x51, 0x4E, 0x00, 0x10,
                        0x23,
                        0x80,
                        0x00,
                        0x01,

                        0x01,
                        0x00, 0x00,
                        0x01, 0x02,
                        0x00, 0x01,
                        0xFF, 0xFF,
                        0x00, 0x01,
                        0x00, 0x01,
                        0x00, 0x01,
                        0x00, 0x01,
                        0x00, 0x01,
                        0x00, 0x01,
                        0x00, 0x01,
                        0x00, 0x01,

                        0x12, 0x45
                    }
            };

            //分区信息Test
            /*byte[] bufferBytes = new byte[]
            {0x51,0x4E,0x00,0x10,
            0x23,
            0xA0,
            0x00,
            0x01,

            0x01,
            0x00,0x00,
            0x01,0x02,
            0x00,0x01,
            0xFF,0xFF,
            0x00,0x01,
            0x00,0x01,
            0x00,0x01,
            0x00,0x01,
            0x00,0x01,
            0x00,0x01,
            0x00,0x01,
            0x00,0x01,

            0x12,0x45 };
            */
            //探测器信息Test

            //灭火器信息Test

            /*//网络相关代码
            //SocketAddress add = new SocketAddress(AddressFamily.InterNetwork);
            IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
            int pot=Convert.ToInt32(Console.ReadLine());
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, pot);

            //创建Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定地址
            socket.Bind(ipEndPoint);
            socket.Listen(100);//监听
            Socket temp = socket.Accept();//接受链接
            temp.Receive(bufferBytes);

            */
            //无关代码
            listOP.List_Clearn();
            Info_Adepter info_Adepter = new Info_Adepter();
            Transform_Info_From_T tmp = new Transform_Info_From_T();
            Data_Parsing dataParsing = new Data_Parsing();
            for (int i = 0; i < 3; i++)
                {
                    tmp = info_Adepter.String_2_Struct(bufferBytes[i]);

                    switch (dataParsing.Function_Code_Judge(tmp))
                    {
                        case 0x60:
                            info_Adepter.Show_Info(sysInfos, sysInfos.Count, sysInfos_num, TextBox1);
                            break;
                        case 0x70:
                            info_Adepter.Show_Info(bugInfos, bugInfos.Count, bugInfos_num, TextBox2);
                            break;
                        case 0x80:
                            info_Adepter.Show_Info(partitionInfos, partitionInfos.Count, partitionInfos_num, TextBox3);
                            break;
                        case 0x90:
                            info_Adepter.Show_Info(detectorInfos, detectorInfos.Count, detectorInfos_num);
                            break;
                        case 0xA0:
                            info_Adepter.Show_Info(fireExtinguisherInfos, fireExtinguisherInfos.Count, fireExtinguisherInfos_num);
                            break;
                            ;
                    }
                }
            //Transform_Info_From_T tmp = info_Adepter.String_2_Struct(bufferBytes);
        }

        public class Progress
        {
            
        }

        public struct Transform_Info_From_T
        {
            public char START1, START2;    //同步字符
            public ushort Info_Length;          //长度
            public byte ID;                           //ID
            public byte Function_Code;      //功能码
            /*60H   系统信息
             * 70H  故障信息
             * 80H  分区信息
             * 90H  探测器信息
             * A0H  灭火器信息
             */
            public byte Function_Tag;         //功能标识
            /*0     读取成功
             * 1    读取失败
             */
            public byte Data_Form;             //数据格式
            public byte[] Data;                    //数据内容
            public byte CRC;                       //CRC校验
            public byte END;                       //结束码
        };

        public struct Transform_Info_To_T
        {
            public char START1, START2;        //同步字符
            public ushort Info_Length;              //长度
            public byte ID;                              //ID
            public byte Function_Code;         //功能码
            public byte Recall_Tag;                //回复标识
            /*上传数据功能码   肯定回复标识
             * 7FH  否定回复标识
             */
            public byte Recall_Code;           //回复码
            /*00H   默认（肯定）
             *11H   服务不支持
             *E0H   CRC校验失败
             */
            public byte CRC;                       //CRC校验码
            public byte END;                      //结束码
        }

        public class Info_Adepter   //用来转换socket接收到的报文，转化成对应的结构体
        {
            public Transform_Info_From_T String_2_Struct(byte[] src_Info)      //解析socket报文，将其转化为 结构体
            {
                Transform_Info_From_T carry = new Transform_Info_From_T { };
                carry.START1 = Convert.ToChar(src_Info[0]);
                carry.START2 = Convert.ToChar(src_Info[1]);
                byte tmp1 = src_Info[2];
                byte tmp2 = src_Info[3];
                int uni = tmp1;
                uni <<= 8;
                uni += tmp2;
                carry.Info_Length = Convert.ToUInt16(uni);
                //carry.Info_Length = Convert.ToInt16(src_Info[2..4]);
                carry.ID = src_Info[4];
                carry.Function_Code = src_Info[5];
                carry.Function_Tag = src_Info[6];
                carry.Data_Form = src_Info[7];
                int poi = src_Info.GetUpperBound(0);
                carry.CRC = src_Info[poi - 1];
                carry.END = src_Info[poi];
                carry.Data = new byte[poi - 9];
                Array.Copy(src_Info, 8, carry.Data, 0, poi - 9);
                //carry.Data = src_Info[8..(poi - 1)];
                return carry;
            }

            private string Struct_2_String(Transform_Info_To_T stt)      //将回复报文转化为String类型，便于socket发送报文
            {
                StringBuilder send_info = new StringBuilder();
                send_info.Append(stt.START1);
                send_info.Append(stt.START2);
                send_info.Append(stt.Info_Length.ToString());
                send_info.Append(stt.ID.ToString());
                send_info.Append(stt.Function_Code.ToString());
                send_info.Append(stt.Recall_Tag.ToString());
                send_info.Append(stt.Recall_Code.ToString());
                send_info.Append(stt.CRC.ToString());
                send_info.Append(stt.END.ToString());
                return send_info.ToString();
            }

            public void Show_Info(Transform_Info_From_T TFT)
            {
                
                Console.WriteLine("同步字符1：{0}", TFT.START1);
                Console.WriteLine("同步字符2：{0}", TFT.START2);
                Console.WriteLine("信息长度：{0}", TFT.Info_Length);
                Console.WriteLine("ID ：{0}", TFT.ID);
                Console.WriteLine("功能代码：{0}", TFT.Function_Code);
                Console.WriteLine("功能标识：{0}", TFT.Function_Tag);
                Console.WriteLine("数据格式：{0}", TFT.Data_Form);
                Console.WriteLine("数据：{0}", Convert.ToBase64String(TFT.Data));
                Console.WriteLine("CRC：{0}", TFT.CRC);
                Console.WriteLine("结束：{0}", Convert.ToChar(TFT.END));
            }

            public void Show_Info(Transform_Info_To_T TTT)
            {

            }

            public void Show_Info(List<Sys_Info> sysInfos, int l, int count, TextBox label)
            {
                StringBuilder ss = new StringBuilder();
                ss.Append("******************\n系统信息\n******************\n");
                if (count == 0x01)
                {
                    for (int i = 0; i < l; i++)
                    {
                        ss.Append("总报警个数 ");
                        ss.AppendLine(sysInfos[i].waring_count.ToString());
                        ss.Append("总故障个数 ");
                        ss.AppendLine(sysInfos[i].bug_count.ToString());
                        ss.Append("总探测器个数 ");
                        ss.AppendLine(sysInfos[i].detector_count.ToString());
                    }
                }
                else
                {
                    ss.Append("读取信息失败");
                }
                label.Text = ss.ToString();
            }

            public void Show_Info(List<Bug_Info> bugInfos, int l, int count, TextBox label)
            {
                StringBuilder ss = new StringBuilder();
                ss.Append("******************\n错误信息\n******************\n");
                if (count != 0x00)
                {
                    for (int i = 0; i < l; i++)
                    {
                        ss.Append("预留扩展 ");
                        ss.Append(bugInfos[i].reserved1.ToString());
                        ss.AppendLine(bugInfos[i].reserved2.ToString());
                        //Console.WriteLine("预留扩展  {0} {1}", bugInfos[i].reserved1, bugInfos[i].reserved2);
                        ss.Append("防护区 ");
                        ss.AppendLine(bugInfos[i].def_zone.ToString());
                        //Console.WriteLine("防护区  {0}", bugInfos[i].def_zone);
                        ss.Append("设备类型 ");
                        ss.AppendLine(bugInfos[i].device_type.ToString());
                        //Console.WriteLine("设备类型  {0}", bugInfos[i].device_type);
                        ss.Append("设备编号 ");
                        ss.AppendLine(bugInfos[i].device_number.ToString());
                        //Console.WriteLine("设备类型  {0} ", bugInfos[i].device_number);
                        ss.Append("故障代码 ");
                        ss.AppendLine(bugInfos[i].bug_code.ToString());
                        //Console.WriteLine("设备类型  {0}", bugInfos[i].bug_code);
                    }
                }
                else
                {
                    ss.Append("读取失败");
                }
                label.Text = ss.ToString();
            }

            public void Show_Info(List<Partition_Info> partitionInfos, int l, int count, TextBox text)
            {
                StringBuilder ss = new StringBuilder();
                ss.Append("******************\n分区信息\n******************\n");
                if (count != 0x00)
                {
                    for (int i = 0; i < l; i++)
                    {
                        ss.Append("预留扩展  ");
                        ss.AppendLine(partitionInfos[i].reserved.ToString());
                        ss.Append("防护区  ");
                        ss.Append(partitionInfos[i].def_zone.ToString());
                        ss.Append("报警级别  ");
                        ss.AppendLine(partitionInfos[i].waring_level.ToString());
                        ss.Append("故障  ");
                        ss.AppendLine(partitionInfos[i].bug.ToString());
                        ss.Append("手动模式  ");
                        ss.AppendLine(partitionInfos[i].handla_mode.ToString());
                        ss.Append("自动模式 ");
                        ss.AppendLine(partitionInfos[i].auto_mode.ToString());
                        ss.Append("手动启动  ");
                        ss.AppendLine(partitionInfos[i].handla_boot.ToString());
                        ss.Append("手动急停 ");
                        ss.AppendLine(partitionInfos[i].handla_shut.ToString());
                        ss.Append("启动控制  ");
                        ss.AppendLine(partitionInfos[i].boot_ctrl.ToString());
                        ss.Append("延时  ");
                        ss.AppendLine(partitionInfos[i].delay.ToString());
                        ss.Append("启动喷洒  ");
                        ss.AppendLine(partitionInfos[i].spray_start.ToString());
                        ss.Append("喷洒  ");
                        ss.AppendLine(partitionInfos[i].spraying.ToString());
                    }
                }
                else
                {
                    ss.Append("读取失败");
                }
                text.Text = ss.ToString();
            }

            public void Show_Info(List<Detector_Info> detectorInfos, int l, int count)
            {

            }

            public void Show_Info(List<Fire_Extinguisher_Info> fireExtinguisherInfos, int l, int count)
            {
                if (count != 0x00)
                {
                    for (int i = 0; i < l; i++)
                    {
                        Console.WriteLine("1#  {0} ", fireExtinguisherInfos[i].sharpNumber);
                    }
                }
                else
                {
                    Console.WriteLine("读取失败");
                }
            }
        }

        public class Data_Parsing //用来实现对结构体的解析
        {
            //解析上传的报文的功能代码
            /*
            public List<Sys_Info> sysInfos = new List<Sys_Info>();
            public byte sysInfos_num;

            public List<Bug_Info> bugInfos = new List<Bug_Info>();
            public byte bugInfos_num;

            public List<Partition_Info> partitionInfos = new List<Partition_Info>();
            public byte partitionInfos_num;

            public List<Detector_Info> detectorInfos = new List<Detector_Info>();
            public byte detectorInfos_num;

            public List<Fire_Extinguisher_Info> fireExtinguisherInfos = new List<Fire_Extinguisher_Info>();
            public byte fireExtinguisherInfos_num;
            */
            //判定报文需要如何解析。
            public byte Function_Code_Judge(Transform_Info_From_T src)
            {
                switch (src.Function_Code)
                {
                    case 0x60:
                        //if (src.Function_Tag == 0x00)
                        System_Info_alz(src);
                        //break;
                        break;
                    case 0x70:
                        //if (src.Function_Tag == 0x00)
                        Bug_Info_alz(src);
                        break;
                    case 0x80:
                        //if (src.Function_Tag == 0x00)
                        Partition_Info_alz(src);
                        break;
                    case 0x90:
                        //if (src.Function_Tag == 0x00)
                        Detector_Info_alz(src);
                        break;
                    case 0xA0:
                        //if (src.Function_Tag == 0x00)
                        Fire_Extinguisher_Info_alz(src);
                        break;
                    default:
                        break;
                }

                return src.Function_Code;
            }
            //系统信息解析
            private void System_Info_alz(Transform_Info_From_T src)
            {
                //信息无误解析
                if (src.Function_Tag == 0x00)
                {
                    Sys_Info ss = new Sys_Info();
                    sysInfos_num = Convert.ToByte(src.Data[0]);
                    //ushort waring_count,bug_count,tt_count;
                    int tmp;
                    tmp = Convert.ToInt32(src.Data[1]);
                    tmp <<= 8;
                    ss.waring_count = Convert.ToUInt16(tmp + Convert.ToInt32(src.Data[2]));
                    tmp = Convert.ToInt32(src.Data[3]);
                    tmp <<= 8;
                    ss.bug_count = Convert.ToUInt16(tmp + Convert.ToInt32(src.Data[4]));
                    tmp = Convert.ToInt32(src.Data[5]);
                    tmp <<= 8;
                    ss.detector_count = Convert.ToUInt16(tmp + Convert.ToInt32(src.Data[6]));
                    sysInfos.Add(ss);
                }
                else if (src.Function_Tag == 0x01)
                {
                    sysInfos_num = 0x00;
                }
                else
                {

                }
                return;
            }
            //故障信息解析
            private void Bug_Info_alz(Transform_Info_From_T src)
            {
                if (src.Function_Tag == 0x00)
                {
                    byte[] str = src.Data;
                    bugInfos_num = str[0];
                    int i = 1;
                    while (i < str.Length)
                    {
                        Bug_Info bug = new Bug_Info();
                        bug.reserved1 = str[i++];
                        bug.reserved2 = str[i++];
                        bug.def_zone = str[i++];
                        bug.device_type = str[i++];
                        bug.device_number = str[i++];
                        bug.bug_code = str[i++];
                        bugInfos.Add(bug);
                    }

                }
                else if (src.Function_Tag == 0x01)
                {
                    bugInfos_num = 0x00;
                }
            }
            //分区信息解析
            private void Partition_Info_alz(Transform_Info_From_T src)
            {
                if (src.Function_Tag == 0x00)
                {
                    byte[] str = src.Data;
                    int i = 0;
                    partitionInfos_num = Convert.ToByte(str[i++]);
                    while (i < str.Length)
                    {
                        Partition_Info partitionInfo = new Partition_Info();
                        //预留
                        partitionInfo.reserved = DecodeUshort(str, i);
                        //防护区
                        partitionInfo.def_zone = DecodeUshort(str, i += 2);
                        //报警等级
                        partitionInfo.waring_level = DecodeUshort(str, i += 2);
                        //故障
                        partitionInfo.bug = DecodeUshort(str, i += 2);
                        //手动模式
                        partitionInfo.handla_mode = DecodeUshort(str, i += 2);
                        //自动模式
                        partitionInfo.auto_mode = DecodeUshort(str, i += 2);
                        //手动启动
                        partitionInfo.handla_boot = DecodeUshort(str, i += 2);
                        //手动急停
                        partitionInfo.handla_shut = DecodeUshort(str, i += 2);
                        //启动控制
                        partitionInfo.boot_ctrl = DecodeUshort(str, i += 2);
                        //延时
                        partitionInfo.delay = DecodeUshort(str, i += 2);
                        //启动喷洒
                        partitionInfo.spray_start = DecodeUshort(str, i += 2);
                        //喷洒
                        partitionInfo.spraying = DecodeUshort(str, i += 2);
                        i += 2;
                        partitionInfos.Add(partitionInfo);
                    }
                }
                else if (src.Function_Tag == 0x01)
                {
                    partitionInfos_num = 0x00;
                }
            }
            //探测器信息解析
            private void Detector_Info_alz(Transform_Info_From_T src)
            {
                if (src.Function_Tag == 0x00)
                {
                    byte[] str = src.Data;
                    int i = 0;
                    detectorInfos_num = Convert.ToByte(src.Data[i++]);
                    while (i < str.Length)
                    {
                        Detector_Info detectorInfo = new Detector_Info();
                        detectorInfo.reserved = DecodeUshort(str, i += 2);
                        detectorInfo.def_zone = DecodeUshort(str, i += 2);
                        detectorInfo.type = DecodeUshort(str, i += 2);
                        detectorInfo.ID = DecodeUshort(str, i += 2);
                        detectorInfo.waring_level = DecodeUshort(str, i += 2);
                        detectorInfo.temperaturer = DecodeUshort(str, i += 2);
                        detectorInfo.CO = DecodeUshort(str, i += 2);
                        detectorInfo.VOC = DecodeUshort(str, i += 2);
                        detectorInfo.smoke = DecodeUshort(str, i += 2);
                        i += 2;
                        detectorInfos.Add(detectorInfo);
                    }
                }
                else if (src.Function_Tag == 0x01)
                {
                    detectorInfos_num = 0x00;
                }
            }
            //灭火器信息解析
            private void Fire_Extinguisher_Info_alz(Transform_Info_From_T src)
            {
                if (src.Function_Tag == 0x00)
                {
                    byte[] str = src.Data;
                    int i = 0;
                    fireExtinguisherInfos_num = str[i++];
                    while (i < str.Length)
                    {
                        Fire_Extinguisher_Info fireExtinguisherInfo = new Fire_Extinguisher_Info();
                        fireExtinguisherInfo.sharpNumber = DecodeUshort(str, i);
                        fireExtinguisherInfos.Add(fireExtinguisherInfo);
                        i += 2;
                    }
                }
                else if (src.Function_Tag == 0x01)
                {
                    Console.WriteLine("读取失败");
                }
            }

            //解析双字节数据Ushort/Int16
            private ushort DecodeUshort(byte[] ss, int i)
            {
                int tmp;
                tmp = Convert.ToInt32(ss[i]);
                tmp <<= 8;
                return Convert.ToUInt16(tmp + Convert.ToInt32(ss[++i]));
            }
        }

        public class List_op
        {
            public void List_Clearn()
            {
                sysInfos.Clear();
                bugInfos.Clear();
                partitionInfos.Clear();
                detectorInfos.Clear();
                fireExtinguisherInfos.Clear();
                sysInfos_num = 0;
                bugInfos_num = 0;
                partitionInfos_num = 0;
                detectorInfos_num = 0;
                fireExtinguisherInfos_num = 0;
            }
        }

        protected void Button_Stop_Click(object sender, EventArgs e)
        {
            Label1.Text = "已停止记录";
            try
            {
                bks.Abort();
                listOP.List_Clearn();
            }
            catch (Exception exception)
            {

            }
            finally
            {

            }
        }
        
    }

}