using System;
using System.Drawing;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TuoPanFrom
{
    public partial class Form1 : Form, IDisposable
    {

        public string OnSrc = ConfigurationManager.AppSettings["OnSrc"];
        public string OffSrc = ConfigurationManager.AppSettings["OffSrc"];

        public Form1()
        {
            InitializeComponent();
            Init();
            MessageBox.Show("监控启动成功");
        }
        protected override void SetVisibleCore(bool x)
        {
            base.SetVisibleCore(false);
        }

        #region 初始化
        private void Init()
        {
            ServiceName = ConfigurationManager.AppSettings["ServiceName"];
            ServiceController Sc = new ServiceController(ServiceName);
            sc = Sc;
            开启关闭自启动ToolStripMenuItem.Text = "自启动（关闭）";
            try
            {
             
                if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    mainNotifyIcon.Icon = new Icon(OffSrc);
                    sc.Refresh();
                }
                else
                {
                    mainNotifyIcon.Icon = new Icon(OnSrc);
                    sc.Refresh();
                }
                #region 起线程实现
                Thread thread = new Thread(new ThreadStart(theout));
                thread.IsBackground = true;
                //ThreadStart threadStart = new ThreadStart(theout);
                //Thread thread = new Thread(threadStart);
                thread.Start();
                #endregion
                #region 定时器实现
             //   System.Timers.Timer t = new System.Timers.Timer(50);
             //   t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
             ////   t.Elapsed += new System.Timers.ElapsedEventHandler(theout);
             //   t.Elapsed += new System.Timers.ElapsedEventHandler(Qidong);
             //   t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

        #region 事件
        private void 关闭MS服务ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sc.Status.Equals(ServiceControllerStatus.Running)) || (sc.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    sc.Stop();

                    mainNotifyIcon.Icon = new Icon(OffSrc);
                }
                sc.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void 启动MS服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) || (sc.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    sc.Start();
                    mainNotifyIcon.Icon = new Icon(OnSrc);
                }
                sc.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainNotifyIcon.Dispose();
            System.Environment.Exit(0);
        }
        private void 开启关闭自启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stute();
        }
        private void Stute()
        {

            Zidong = Zidong == 0 ? Zidong = 1 : Zidong = 0;
            if (Zidong == 1)
            {
                开启关闭自启动ToolStripMenuItem.Text = "自启动（开启）";
            }
            else
            {
                开启关闭自启动ToolStripMenuItem.Text = "自启动（关闭）";
            }
        }
        private void 选择进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form2Entity> list = new List<Form2Entity>();
            ServiceController[] services = System.ServiceProcess.ServiceController.GetServices();
            for (int i = 0; i < services.Length; i++)
            {
                Form2Entity entity = new Form2Entity();
                string xxx = string.Format("{0} {1} {2}", services[i].ServiceName, services[i].DisplayName, services[i].Status.ToString());
                entity.PId = services[i].ServiceName;
                entity.Name = services[i].DisplayName;
                if (services[i].Status == ServiceControllerStatus.Stopped)
                {
                    entity.Describe = "停止";
                }
                if (services[i].Status == ServiceControllerStatus.Running)
                {
                    entity.Describe = "正在运行";
                }
                list.Add(entity);
            }
          //  Form2 form2 = new Form2(list);
            Form2 form2 = Form2.CreateInstrance(list);
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.ShowDialog(this);
            #region MyRegion


            //遍历电脑中的进程
            //Process[] processes = Process.GetProcesses();

            //for (int i = 0; i < processes.GetLength(0); i++)
            //{
            //    Form2Entity entity = new Form2Entity();
            //    //我是要找到我需要的YZT.exe的进程,可以根据ProcessName属性判断
            //    entity.PId = processes[i].Id;
            //    entity.Name = processes[i].ProcessName;
            //    entity.Describe = processes[i].MainWindowTitle;
            //    list.Add(entity);
            //}
            //遍历电脑中的服务
            #endregion
        }
        private void AccessAppSettings(Form2Entity entity)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings.AllKeys.Contains("ServiceName"))
            {
                //根据Key读取<add>元素的Value
                //string name = config.AppSettings.Settings["ServiceName"].Value;
                //写入<add>元素的Value
                config.AppSettings.Settings["ServiceName"].Value = entity.Name;
            }
            else
            {
                //增加<add>元素
                config.AppSettings.Settings.Add("ServiceName", entity.Name);
            }
            //删除<add>元素
            //config.AppSettings.Settings.Remove("name");
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }
        public void Get(Form2Entity entity)
        {
            try
            {

                ServiceName = ConfigurationManager.AppSettings["ServiceName"];
                ServiceController Sc = new ServiceController(ServiceName);
                sc = Sc;
                if (entity != null)
                {
                    AccessAppSettings(entity);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        #endregion

        #region 线程内方法
        public void theout()
        {

            try
            {
                while (true)
                {
                    ServiceName = ConfigurationManager.AppSettings["ServiceName"];
                    ServiceController Sc = new ServiceController(ServiceName);
                    sc = Sc;
                    if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                    {
                        mainNotifyIcon.Icon = new Icon(OffSrc);
                        sc.Refresh();
                    }
                    else
                    {
                        mainNotifyIcon.Icon = new Icon(OnSrc);
                        sc.Refresh();
                    }
                    if (sc.Status.Equals(ServiceControllerStatus.Stopped) && Zidong == 1)
                    {
                        sc.Start();
                        sc.Refresh();
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        bool x;
        public void Qidong(object source, System.Timers.ElapsedEventArgs e)
        {
           
            try
            {
                if (x)
                {
                    mainNotifyIcon.Icon = new Icon(OffSrc);
                    x = !x;
                }
                else
                {
                    mainNotifyIcon.Icon = new Icon(OnSrc);
                    x = !x;
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

        #region 属性
        private int zidong=0;
        public int Zidong
        {
            get
            {
                return zidong;
            }

            set
            {
                zidong = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return serviceName;
            }

            set
            {
                serviceName = value;
            }
        }

        public ServiceController sc
        {
            get
            {
                return _sc;
            }

            set
            {
                _sc = value;
            }
        }

        private string serviceName;
        private ServiceController _sc;
        #endregion
    }
}
