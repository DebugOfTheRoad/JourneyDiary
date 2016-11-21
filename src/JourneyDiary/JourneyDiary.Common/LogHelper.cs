using log4net;

namespace JourneyDiary.Common
{
    public class LogHelper
    {
        public static ILog Current { get; set; }

        static LogHelper()
        {
            Current = LogManager.GetLogger("RollingLogFileAppender");
        }
    }
}
