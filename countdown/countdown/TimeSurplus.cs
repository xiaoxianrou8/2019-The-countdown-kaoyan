using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace countdown
{
    /// <summary>
    /// 计算时间间隔
    /// </summary>
    public class TimeSurplus:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private int day;

        public int Day
        {
            get { return day; }
            set { day = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Day)));
            }
            

        }

        private int hour;

        public int Hour
        {
            get { return hour; }
            set { hour = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Hour)));
            }

        }
        private int min;

        public int Min
        {
            get { return min; }
            set { min = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Min)));
            }
        }
        private int second;

        public int Second
        {
            get { return second; }
            set { second = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Second)));
            }
        }
        private TimeSpan nowSpan;

       

        public TimeSpan NowSpan
        {
            get { return nowSpan; }
            set { nowSpan = value; }
        }
        public TimeSurplus()
        {
            Task.Run(async () =>
            {
                
                while (true)
                {
                    await Task.Delay(1000);
                    NowSpan=NowSpan.Subtract(new TimeSpan(0, 0, 1));
                    SpanToString();
                }
            });
        }
        /// <summary>
        /// 计算时间间隔
        /// </summary>
        /// <param name="dateTime"></param>
        public void SurplusTime(DateTime dateTime)
        {
            TimeSpan timeSpan = new TimeSpan();
            DateTime nowTime = new DateTime();
            nowTime = DateTime.Now;
            if (DateTime.Compare(nowTime, dateTime) > 0)
            {
                new Exception("时间设置必须比当前时间大");
            }
            timeSpan = dateTime.Subtract(nowTime).Duration();
            NowSpan = timeSpan;
            SpanToString();
        }
       
        /// <summary>
        /// 返回当前剩余时间天时分秒
        /// </summary>
        public void SpanToString()
        {
            Day = NowSpan.Days;
            Hour = NowSpan.Hours;
            Min = NowSpan.Minutes ;
            Second = NowSpan.Seconds;
        }

    }
}
