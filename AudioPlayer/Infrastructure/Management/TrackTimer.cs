using System;
using System.Windows.Threading;

namespace AudioPlayer.Infrastructure.Management
{
    internal class TrackTimer
    {
        private DispatcherTimer _timer = null;
        private Action TimerTick;

        /// <summary>
        /// Возвращает текущие значения таймера
        /// </summary>
        public int CurrentTimerValue { get; private set; }

        /// <summary>
        /// Запускает таймер
        /// </summary>
        public void TimerStart(int startValue = 0)
        {
            CurrentTimerValue = startValue;
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(_timerTick);
            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Start();
        }

        /// <summary>
        /// Остонавливает таймер
        /// </summary>
        public void TimerStop()
        {
            if (_timer != null)
            {
                _timer.Tick -= new EventHandler(_timerTick);
                _timer.Stop();
                _timer = null;
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

        ~TrackTimer()
        {
            TimerStop();
        }
    }
}
