using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace countdown
{
    /// <summary>
    /// 获取窗口大小
    /// </summary>
    public class GetScreenSize
    {
        public double ScrHeight { get; set; }
        public double ScrWidth { get; set; }
        /// <summary>
        /// 设置窗口大小为分辨率的1/5
        /// </summary>
        public GetScreenSize()
        {
            ScrWidth = SystemParameters.PrimaryScreenWidth/5;
            ScrHeight = ScrWidth;
        }
        static GetScreenSize WindowSize = new GetScreenSize();
    }
}
