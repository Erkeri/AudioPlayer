using System;
using System.Windows.Threading;

namespace AudioPlayer.Infrastructure.Management
{
    internal class TrackTimer
    {
        private DispatcherTimer timer = null;
        private Action TimerTick;

        /// <summary>
        /// Возвращает текущие значения таймера
        /// </summary>
        public int CurrentTimerValue { get; private set; }

        /// <summary>
        /// Запускает таймер
        /// </summary>
        public void StartTimer(int startValue = 0)
        {
            CurrentTimerValue = startValue;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(_timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Start();
        }

        /// <summary>
        /// Остонавливает таймер
        /// </summary>
        public void StopTimer()
        {
            if (timer != null)
            {
                timer.Tick -= new EventHandler(_timerTick);
                timer.Stop();
                timer = null;
            }
        }

        private void _timerTick(object sender, EventArgs e)
        {
            CurrentTimerValue++;
            TimerTick?.Invoke();
        }

        public TrackTimer() => TimerTick = null;

        /// <summary>
        /// customerTimerTick возникает в конце каждого тика таймера
        /// </summary>
        /// <param name="customTimerTick"></param>
        public TrackTimer(Action customTimerTick) => TimerTick = customTimerTick;

        ~TrackTimer() => StopTimer();
    }
}
