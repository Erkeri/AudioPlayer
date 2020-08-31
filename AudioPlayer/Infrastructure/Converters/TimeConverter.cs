using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.Infrastructure.Converters
{
    public static class TimeConverter
    {
        /// <summary>
        /// Преобразует количество секунд в строку вида 00:00:00
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string SecondsInString(int seconds)
        {
            int sec = (int)TimeSpan.FromSeconds(seconds).TotalSeconds,
                minutes = (int)TimeSpan.FromSeconds(seconds).TotalMinutes,
                hourses = (int)TimeSpan.FromSeconds(seconds).TotalHours;
            minutes -= hourses * 60;
            sec -= (minutes * 60 + hourses * 60 * 60);
            return $"{GetTimeToString(hourses)}:{GetTimeToString(minutes)}:{GetTimeToString(sec)}";
        }
        private static string GetTimeToString(int time)
        {
            if (time < 10)
                return time == 0 ? "00" : $"0{time}";
            else
                return time.ToString();
        }

        /// <summary>
        /// Преобразует вида вида 00:00:00 в количество секунд
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int StringInSeconds(string time)
        {
            string[] times = time.Split(':');
            if (times.Length == 3)
                return Convert.ToInt32(times[0]) * 60 * 60
                       + Convert.ToInt32(times[1]) * 60
                       + Convert.ToInt32(times[2]);
            else
                return 0;
        }
    }
}
