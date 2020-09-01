using AudioPlayer.Infrastructure.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AudioPlayer.Infrastructure.Management
{
    public static class FileManagement
    {
        #region Путь к папке с аудио

        private const string _path = "Music";

        #endregion

        private static List<string> supportedFormat = new List<string>()
        {
            ".mp3",
            ".flac",
            ".ogg",
            ".aac",
            ".ac3",
            ".opus",
            ".tta"
        };

        /// <summary>
        /// Возвращает список аудиозаписей из папки Music или создаёт эту папку если она не существует
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAudioList()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
                return null;
            }
            else
            {
                List<string> audioList = new List<string>();
                foreach (var format in supportedFormat)
                    foreach (var item in Directory.GetFileSystemEntries(_path, $"*{format}").ToList())
                        audioList.Add(item);
                for (int item = 0; item < audioList.Count; item++)
                    audioList[item] = PathConverter.GetFileNameOfPath(audioList[item]);
                return audioList;
            }
        }

        /// <summary>
        /// Копирует файл из указанного пути в директорию проекта
        /// </summary>
        /// <param name="path"></param>
        private static void CopyAudio(string path)
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            try { File.Copy(path, _path + @"\" + PathConverter.GetFileNameOfPath(path)); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Удаляет файл с именем filename из директории проекта
        /// </summary>
        /// <param name="filename"></param>
        public static void RemoveAudio(string filename)
        {
            try { File.Delete(PathConverter.GetFailPathInProject(filename)); }
            catch { throw; }
        }

        /// <summary>
        /// Открывает FileDialog и сохраняет выбранные файлы в директории проекта
        /// </summary>
        public static void SetAudio()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();//.mid .flac .ogg .aac .ac3 .opus .tta .wv
            openFileDialog.Filter = GetOpenDialogFilter();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                foreach(string fileName in fileNames)
                    CopyAudio(fileName);
            }
        }

        private static string GetOpenDialogFilter()
        {
            string fileFilter = "";
            string allformat = "";
            foreach (var format in supportedFormat)
            {
                fileFilter += $"{format} files |*{format}|";
                allformat += $"*{format};";
            }
            return fileFilter + $"All files({allformat})|{allformat}";
        }

        /// <summary>
        /// Проверяет существует ли файл с именем fileName в директории проекта
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool AudioFileExists(string fileName)
        {
            try { return File.Exists(PathConverter.GetFailPathInProject(fileName)); }
            catch { throw; }
        }
    }
}
