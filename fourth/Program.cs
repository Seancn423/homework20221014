using System;
using System.Timers;

namespace fourth
{
    class weatherStationInformation : EventArgs//气象站信息
    {
        public DateTime lastAcquisitionTime { get; set; }//最后采集时间
        public double temperature { get; set; }//温度
        public double humidity { get; set; }//湿度

        public weatherStationInformation(){}
        public weatherStationInformation(DateTime lastAcquisitionTime, double temperature, double humidity)
        {
            this.lastAcquisitionTime = lastAcquisitionTime;
            this.temperature = temperature;
            this.humidity = humidity;
        }
    }
    class weatherStation//气象站
    {
        public event EventHandler<weatherStationInformation> newWeatherStationInformationEvent;//定义事件：新的气象站信息
        public weatherStationInformation currentWeatherStationInformation { get; set; }
        public weatherStation()
        {
            currentWeatherStationInformation = new weatherStationInformation();
            currentWeatherStationInformation.lastAcquisitionTime = DateTime.Now;
            currentWeatherStationInformation.temperature = 0;
            currentWeatherStationInformation.humidity = 0;
        }
        //获取新的气象站信息
        public void getNewWeatherStationInformation(double _temperature, double _humidity)
        {
            currentWeatherStationInformation.lastAcquisitionTime = DateTime.Now;
            currentWeatherStationInformation.temperature = _temperature;
            currentWeatherStationInformation.humidity = _humidity;
        }
        //触发事件方法
        public void raiseNewWeatherStationInformation()
        {
            if(newWeatherStationInformationEvent != null)
            {
                newWeatherStationInformationEvent.Invoke(this, currentWeatherStationInformation);
            }
        }
    }
    class screenDisplay//屏幕显示
    {
        public void screenDisplay_OnNewWeatherStationInformationEvent(Object sender, weatherStationInformation e)
        {
            weatherStationInformation mi = (weatherStationInformation)e;
            Console.WriteLine($"屏幕显示了最新气象时间{mi.lastAcquisitionTime}的气象信息");
        }
    }
    class databaseSaving//数据库保存
    {
        public void databaseSaving_OnNewWeatherStationInformationEvent(Object sender, weatherStationInformation e)
        {
            weatherStationInformation mi = (weatherStationInformation)e;
            Console.WriteLine($"数据库保存了最新气象时间{mi.lastAcquisitionTime}的气象信息");
        }
    }
    class Program
    {
        public static void OnTimerElapsedHander(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine();
            ws.getNewWeatherStationInformation(10, 20);
        }
        public static Timer timer = new Timer(3000);//定时器
        public static weatherStation ws = new weatherStation();//气象站
        public static screenDisplay screen = new screenDisplay();
        public static databaseSaving database = new databaseSaving();
        static void Main(string[] args)
        {
            //订阅事件
            ws.newWeatherStationInformationEvent += screen.screenDisplay_OnNewWeatherStationInformationEvent;
            ws.newWeatherStationInformationEvent += database.databaseSaving_OnNewWeatherStationInformationEvent;
            //设置相关参数
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += OnTimerElapsedHander;
            timer.Start();
            Console.WriteLine();
        }
    }
}