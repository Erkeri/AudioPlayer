using System;
using System.IO;

namespace AudioPlayer.Infrastructure.Converters
{
    public static class PathConverter
    {
        #region Путь к папке с аудио

        private const string _path = "Music";

        #endregion

        /// <summary>
        /// Возвращает имя файла из указанного пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileNameOfPath(string path)
        {
            string[] name = path.Split('\\');
            return name[name.Length - 1];
        }

        /// <summary>
        /// Возвращает путь к файлу с именем filename в директории проекта
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetFailPathInProject(string filename)
        {
            string filePath = _path + @"\" + filename;
            if (File.Exists(filePath))
                return filePath;
            else
                throw new Exception($"Файл: {filePath}, не существует");
        }
    }
}
