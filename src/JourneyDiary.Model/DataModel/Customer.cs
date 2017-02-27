using System;

namespace JourneyDiary.Model.DataModel
{
    public class Customer:BaseDataModel
    {
        /// <summary>
        ///  手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否启用账号
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
