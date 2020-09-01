using System;
using System.IO;
using System.Windows;
using Un4seen.Bass;

namespace AudioPlayer.Infrastructure.Management
{
    public static class AudioManagement
    {
        /// <summary>
        /// Частота дискретизации
        /// </summary>
        public static int SamplingFrequency = 44100;

        /// <summary>
        /// Состояние инициализации Bass.dll
        /// </summary>
        public static bool InitDefaultDevice;

        /// <summary>
        /// Канал звука
        /// </summary>
        public static int Stream;

        /// <summary>
        /// Громкость звука
        /// </summary>
        public static int Volume = 100;

        /// <summary>
        /// Инициализация Bass.dll
        /// </summary>
        /// <param name="samplingFrequency"></param>
        /// <returns></returns>
        public static bool InitBass(int samplingFrequency)
        {
            if (!InitDefaultDevice)
                InitDefaultDevice = Bass.BASS_Init(-1, samplingFrequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            return InitDefaultDevice;
        }
        /// <summary>
        /// Создаёт канал звука из файла
        /// </summary>
        /// <param name="filename"></param>
        public static void CreateStreamOfFile(string filename, int volume)
        {
            if (InitBass(SamplingFrequency))
            {
                Stop();
                Stream = Bass.BASS_StreamCreateFile(filename, 0, 0, BASSFlag.BASS_DEFAULT);
                SetVolumeToStream(Stream, volume);
            }
        }

        /// <summary>
        /// Запускает установленный поток
        /// </summary>
        /// <param name="volume"></param>
        public static void Play()
        {
            if (InitBass(SamplingFrequency) && Stream != 0)
                Bass.BASS_ChannelPlay(Stream, false);
        }

        /// <summary>
        /// Останавливает текущий поток и перематывает его на начало
        /// </summary>
        public static void Stop()
        {
            Bass.BASS_ChannelStop(Stream);
            SetPositionScroll(Stream, 0);
        }

        /// <summary>
        /// Останавливает текущий поток
        /// </summary>
        public static void Pause() => Bass.BASS_ChannelPause(Stream);

        /// <summary>
        /// Останавливает текущий поток и очищает его
        /// </summary>
        public static void ClearStream()
        {
            Bass.BASS_ChannelStop(Stream);
            Bass.BASS_StreamFree(Stream);
        }

        /// <summary>
        /// Получение длительности канала в секунду
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int GetTimeOfStream(int stream)
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
        public static int GetPositionOfStream(int stream)
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
        public static void SetPositionScroll(int stream, int pos) => Bass.BASS_ChannelSetPosition(stream, (double)pos);

        /// <summary>
        /// Установка громкости
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="volume"></param>
        public static void SetVolumeToStream(int stream, int volume)
        {
            Volume = volume;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, Volume / 100f);
        }
    }
}
