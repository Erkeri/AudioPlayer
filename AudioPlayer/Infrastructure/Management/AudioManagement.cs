using System;
using Un4seen.Bass;

namespace AudioPlayer.Infrastructure.Management
{
    public static class AudioManagement
    {
        /// <summary>
        /// Частота дискретизации
        /// </summary>
        private static int samplingFrequency = 44100;

        /// <summary>
        /// Состояние инициализации Bass.dll
        /// </summary>
        private static bool initializedDefaultDevice;

        /// <summary>
        /// Канал звука
        /// </summary>
        private static int stream { get; set; }

        /// <summary>
        /// Громкость звука
        /// </summary>
        private static int volume = 100;

        /// <summary>
        /// Инициализация Bass.dll
        /// </summary>
        /// <param name="samplingFrequency"></param>
        /// <returns></returns>
        public static bool InitializeBass()
        {
            if (!initializedDefaultDevice)
                initializedDefaultDevice = Bass.BASS_Init(-1, samplingFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            return initializedDefaultDevice;
        }

        /// <summary>
        /// Создаёт канал звука из файла
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateStreamByFile(string filename, int volume)
        {
            if (InitializeBass())
            {
                Stop();
                stream = Bass.BASS_StreamCreateFile(filename, 0, 0, BASSFlag.BASS_SAMPLE_FX);
                SetVolumeToStream(volume);
            }
        }

        /// <summary>
        /// Запускает установленный поток
        /// </summary>
        /// <param name="volume"></param>
        public static void Play()
        {
            if (InitializeBass() && stream != 0)
                Bass.BASS_ChannelPlay(stream, false);
        }

        /// <summary>
        /// Останавливает текущий поток и перематывает его на начало
        /// </summary>
        public static void Stop()
        {
            Bass.BASS_ChannelStop(stream);
            SetPositionScroll(0);
        }

        /// <summary>
        /// Останавливает текущий поток
        /// </summary>
        public static void Pause() => Bass.BASS_ChannelPause(stream);

        /// <summary>
        /// Останавливает текущий поток и очищает его
        /// </summary>
        public static void ClearStream()
        {
            Bass.BASS_ChannelStop(stream);
            Bass.BASS_StreamFree(stream);
        }

        /// <summary>
        /// Получение длительности канала в секунду
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int GetTimeOfStream()
        {
            long timeBytes = Bass.BASS_ChannelGetLength(stream);
            double time = Bass.BASS_ChannelBytes2Seconds(stream, timeBytes);
            return (int)time;
        }

        /// <summary>
        /// Получение текущей позиции в секунду
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int GetPositionOfStream()
        {
            long positionBytes = Bass.BASS_ChannelGetPosition(stream);
            double positionSeconds = Bass.BASS_ChannelBytes2Seconds(stream, positionBytes);
            return (int)positionSeconds;
        }

        /// <summary>
        /// Перемотка текущей позиции
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="pos"></param>
        public static void SetPositionScroll(int position) => Bass.BASS_ChannelSetPosition(stream, (double)position);

        /// <summary>
        /// Установка громкости
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="volume"></param>
        public static void SetVolumeToStream(int volumeValue)
        {
            volume = volumeValue;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, volume / 100f);
        }
    }
}
