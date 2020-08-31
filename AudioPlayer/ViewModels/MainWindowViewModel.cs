using AudioPlayer.Infrastructure.Commands;
using AudioPlayer.Infrastructure.Converters;
using AudioPlayer.Infrastructure.Management;
using AudioPlayer.Infrastructure.OutputTemplates;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace AudioPlayer.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private bool _repeatAudio;
        private enum ConditionStream
        {
            Play,
            Pause,
            Stop
        }
        private ConditionStream _conditionStream;

        #region Timer

        private TrackTimer trackTimer;

        private void TimerTick()
        {
            int currentTimerValue = trackTimer.CurrentTimerValue;
            if (SliderValue < SliderMaximumValue)
            {
                CurrentTimeAudio = TimeConverter.SecondsInString(currentTimerValue);
                SliderValue = currentTimerValue;
            }
            else
            {
                if (!_repeatAudio)
                {
                    if (ListBoxSelectedIndex != AudioList.Count - 1)
                    {
                        ++ListBoxSelectedIndex;
                        SelectionChangedCommand.Execute(null);
                        PlayMusicCommand.Execute(null);
                    }
                    else
                    {
                        SelectionChangedCommand.Execute(null);
                    }
                }
                else
                {
                    SelectionChangedCommand.Execute(null);
                    PlayMusicCommand.Execute(null);
                }
            }
        }

        #endregion

        #region Properties

        #region ListBoxSelectedIndex

        private int _listBoxSelectedIndex;

        public int ListBoxSelectedIndex
        {
            get => _listBoxSelectedIndex;
            set => Set(ref _listBoxSelectedIndex, value);
        }

        #endregion

        #region TextBlockAudioName

        private string _textBlockAudioName;

        public string TextBlockAudioName
        {
            get => _textBlockAudioName;
            set => Set(ref _textBlockAudioName, value);
        }

        #endregion

        #region SliderValue

        private int _sliderValue;

        public int SliderValue
        {
            get => _sliderValue;
            set => Set(ref _sliderValue, value);
        }

        #endregion

        #region SliderMaximumValue

        private int _sliderMaximumValue;

        public int SliderMaximumValue
        {
            get => _sliderMaximumValue;
            set => Set(ref _sliderMaximumValue, value);
        }

        #endregion

        #region MaximumTimeAudio

        private string _maximumTimeAudio;

        public string MaximumTimeAudio
        {
            get => _maximumTimeAudio;
            set => Set(ref _maximumTimeAudio, value);
        }

        #endregion

        #region CurrentTimeAudio

        private string _currentTimeAudio;

        public string CurrentTimeAudio
        {
            get => _currentTimeAudio;
            set => Set(ref _currentTimeAudio, value);
        }

        #endregion

        #region VolumeValue

        private int _volumeValue;

        public int VolumeValue
        {
            get => _volumeValue;
            set => Set(ref _volumeValue, value);
        }

        #endregion

        #region VolumeMaximumValue

        private int _volumeMaximumValue;

        public int VolumeMaximumValue
        {
            get => _volumeMaximumValue;
            set
            {
                _volumeMaximumValue = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region RepeatBackground

        private string _repeatBackground;

        public string RepeatBackground
        {
            get => _repeatBackground;
            set
            {
                _repeatBackground = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region AudioList

        private List<TitleAudioTemplate> _audioList;

        public List<TitleAudioTemplate> AudioList
        {
            get => _audioList;
            set => Set(ref _audioList, value);
        }

        #endregion

        #endregion

        #region Commands

        #region PlayMusicCommand

        public ICommand PlayMusicCommand { get; }

        private bool CanPlayMusicCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 0 && _conditionStream != ConditionStream.Play)
                return true;
            else
                return false;
        }

        private void OnPlayMusicCommandExecuted(object parameter)
        {
            trackTimer = new TrackTimer(TimerTick);
            AudioManagement.Play(VolumeValue);
            trackTimer.TimerStart(SliderValue);
            _conditionStream = ConditionStream.Play;
        }

        #endregion

        #region PauseMusicCommand

        public ICommand PauseMusicCommand { get; }

        private bool CanPauseMusicCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 0 && _conditionStream != ConditionStream.Pause)
                return true;
            else
                return false;
        }

        private void OnPauseMusicCommandExecuted(object parameter)
        {
            AudioManagement.Pause();
            trackTimer?.TimerStop();
            _conditionStream = ConditionStream.Pause;
        }

        #endregion

        #region StopMusicCommand

        public ICommand StopMusicCommand { get; }

        private bool CanStopMusicCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 0 && _conditionStream != ConditionStream.Stop)
                return true;
            else
                return false;
        }

        private void OnStopMusicCommandExecuted(object parameter)
        {
            AudioManagement.Stop();
            trackTimer.TimerStop();
            _conditionStream = ConditionStream.Stop;
            CurrentTimeAudio = "00:00:00";
            SliderValue = 0;
        }

        #endregion

        #region NextMusicTrackCommand

        public ICommand NextMusicTrackCommand { get; }

        private bool CanNextMusicTrackCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex + 1 != AudioList.Count)
                return true;
            else
                return false;
        }

        private void OnNextMusicTrackCommandExecuted(object parameter)
        {
            ListBoxSelectedIndex = ListBoxSelectedIndex + 1;
            PlayMusicCommand.Execute(null);
        }

        #endregion

        #region PreviousMusicTrackCommand

        public ICommand PreviousMusicTrackCommand { get; }

        private bool CanPreviousMusicTrackCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 1)
                return true;
            else
                return false;
        }

        private void OnPreviousMusicTrackCommandExecuted(object parameter)
        {
            ListBoxSelectedIndex = ListBoxSelectedIndex - 1;
            PlayMusicCommand.Execute(null);
        }

        #endregion

        #region SelectionChangedCommand

        public ICommand SelectionChangedCommand { get; }

        private void OnSelectionChangedCommandExecuted(object parameter)
        {
            try
            {
                trackTimer?.TimerStop();
                SliderValue = 0;
                CurrentTimeAudio = "00:00:00";
                if (_listBoxSelectedIndex != -1)
                {
                    _conditionStream = ConditionStream.Stop;
                    AudioManagement.CreateStreamOfFile(PathConverter.GetFailPathInProject(_audioList[ListBoxSelectedIndex].NameAudio));
                    SliderMaximumValue = AudioManagement.GetTimeOfStream(AudioManagement.Stream);
                    TextBlockAudioName = AudioList[ListBoxSelectedIndex].NameAudio;
                    MaximumTimeAudio = TimeConverter.SecondsInString(AudioManagement.GetTimeOfStream(AudioManagement.Stream));

                }
                else
                {
                    AudioManagement.ClearStream();
                    SliderMaximumValue = 100;
                    TextBlockAudioName = "";
                    MaximumTimeAudio = "00:00:00";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        #endregion

        #region RewindAudioCommand

        public ICommand RewindAudioCommand { get; }

        private bool CanRewindAudioCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 0)
                return true;
            else
                return false;
        }

        private void OnRewindAudioCommandExecuted(object parameter)
        {
            AudioManagement.SetPositionScroll(AudioManagement.Stream, SliderValue);
            trackTimer?.TimerStop();
            if (_conditionStream == ConditionStream.Play)
            {
                trackTimer.TimerStart(SliderValue);
            }
            else
            {
                _conditionStream = SliderValue == 0 ? ConditionStream.Stop : ConditionStream.Pause;
            }
            CurrentTimeAudio = TimeConverter.SecondsInString(SliderValue);
        }

        #endregion

        #region VolumeChangedCommand

        public ICommand VolumeChangedCommand { get; }

        private bool CanVolumeChangedCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 0)
                return true;
            else
                return false;
        }

        private void OnVolumeChangedCommandExecuted(object parameter)
        {
            AudioManagement.SetVolumeToStream(AudioManagement.Stream, VolumeValue);
        }

        #endregion

        #region RepeatCommand

        public ICommand RepeatCommand { get; }

        private void OnRepeatCommandExecuted(object parameter)
        {
            if (_repeatAudio)
            {
                _repeatAudio = false;
                RepeatBackground = "LightGray";
            }
            else
            {
                _repeatAudio = true;
                RepeatBackground = "Gold";
            }
        }

        #endregion

        #region SetAudioCommand

        public ICommand SetAudioCommand { get; }

        private void OnSetAudioCommandExecuted(object parameter)
        {
            FileManagement.SetAudio();
            UpdateAudioListCommand.Execute(null);
        }

        #endregion

        #region RemoveAudioCommand

        public ICommand RemoveAudioCommand { get; }

        private bool CanRemoveAudioCommandExecute(object parameter)
        {
            if (ListBoxSelectedIndex >= 0)
                return true;
            else
                return false;
        }
        private void OnRemoveAudioCommandExecuted(object parameter)
        {
            string fileName = AudioList[ListBoxSelectedIndex].NameAudio;
            try
            {
                if (FileManagement.AudioFileExists(fileName))
                    FileManagement.RemoveAudio(fileName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            UpdateAudioListCommand.Execute(null);
        }

        #endregion

        #region UpdateAudioListCommand

        public ICommand UpdateAudioListCommand { get; }

        private void OnUpdateAudioListCommandExecuted(object parameter)
        {
            ListBoxSelectedIndex = -1;
            AudioList = AudioListConverter.ConvertToListTitleAudio(FileManagement.GetAudioList());
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            RepeatBackground = "LightGray";
            _repeatAudio = false;
            ListBoxSelectedIndex = -1;
            VolumeMaximumValue = 100;
            VolumeValue = 20;
            SliderMaximumValue = 100;
            SliderValue = 0;
            CurrentTimeAudio = "00:00:00";
            MaximumTimeAudio = "00:00:00";
            #region initialization commands

            PlayMusicCommand = new ActionCommand(OnPlayMusicCommandExecuted, CanPlayMusicCommandExecute);
            PauseMusicCommand = new ActionCommand(OnPauseMusicCommandExecuted, CanPauseMusicCommandExecute);
            StopMusicCommand = new ActionCommand(OnStopMusicCommandExecuted, CanStopMusicCommandExecute);
            NextMusicTrackCommand = new ActionCommand(OnNextMusicTrackCommandExecuted, CanNextMusicTrackCommandExecute);
            PreviousMusicTrackCommand = new ActionCommand(OnPreviousMusicTrackCommandExecuted, CanPreviousMusicTrackCommandExecute);
            SelectionChangedCommand = new ActionCommand(OnSelectionChangedCommandExecuted, null);
            RewindAudioCommand = new ActionCommand(OnRewindAudioCommandExecuted, CanRewindAudioCommandExecute);
            VolumeChangedCommand = new ActionCommand(OnVolumeChangedCommandExecuted, CanVolumeChangedCommandExecute);
            RepeatCommand = new ActionCommand(OnRepeatCommandExecuted, null);
            SetAudioCommand = new ActionCommand(OnSetAudioCommandExecuted, null);
            RemoveAudioCommand = new ActionCommand(OnRemoveAudioCommandExecuted, CanRemoveAudioCommandExecute);
            UpdateAudioListCommand = new ActionCommand(OnUpdateAudioListCommandExecuted, null);

            #endregion
            UpdateAudioListCommand.Execute(null);
        }
    }
}
