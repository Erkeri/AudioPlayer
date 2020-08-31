using AudioPlayer.Infrastructure.OutputTemplates;
using System.Collections.Generic;

namespace AudioPlayer.Infrastructure.Converters
{
    public static class AudioListConverter
    {
        /// <summary>
        /// Конвертирует список audioList в List<TitleAudioTemplate>
        /// </summary>
        /// <param name="audioList"></param>
        /// <returns></returns>
        public static List<TitleAudioTemplate> ConvertToListTitleAudio(List<string> audioList)
        {
            List<TitleAudioTemplate> titleAudioList = new List<TitleAudioTemplate>();
            for (int item = 0; item < audioList?.Count; item++)
            {
                titleAudioList.Add(
                    new TitleAudioTemplate { NameAudio = audioList[item] });
            }
            return titleAudioList;
        }
    }
}
