namespace AudioPlayer.Infrastructure.OutputTemplates
{
    public class TitleAudioTemplate
    {
        public string PathImage { get; private set; }
        public string NameAudio { get; set; }

        public TitleAudioTemplate() => PathImage = "/Resources/Icon/IconMusic.png";
    }
}
