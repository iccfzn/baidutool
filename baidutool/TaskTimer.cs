using System;

namespace baidutool
{
    /// <summary>
     /// 自定义定时器
     /// </summary>
    public class TaskTimer : System.Timers.Timer
    {
        #region <变量>
        /// <summary>
          /// 定时器id
          /// </summary>
        private int id;

        /// <summary>
          /// 定时器参数
          /// </summary>
        private string param;
        #endregion

        #region <属性>
        /// <summary>
          /// 定时器id属性
          /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
          /// 定时器参数属性
          /// </summary>
        public string Param
        {
            set { param = value; }
            get { return param; }
        }
        #endregion

        /// <summary>
          /// 构造函数
          /// </summary>
        public TaskTimer() : base()
        {

        }
    }
}
