   M S B A M L   `   `   `  ���� F  BAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AudioPlayerAudioPlayer      AudioPlayer.App   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     +localclr-namespace:AudioPlayer       �� 	Resources     SliderThumbTemplate �� 
TargetType � UseLayoutRounding F�Name �� Stretch �� Triggers P� Property P� Value �� 
TargetName	 �� Property
 �� Value  SliderControlTemplateVolume ��Name J� SnapsToDevicePixels � ColumnDefinitions m�Name m� Fill m� 	Placement ��Name ]�Name ]� Thumb n�Name � OverridesDefaultStyle  SliderControlTemplateTrack � RowDefinitions��%x  &	        &	 �    7   &	 
    7   �� " n�.R�� $��Center=� . $��Center=�.+�F� $
 grip��+���� �  � ѠI � ѠI�y� � � �y� 	
��� ���$
 Fill=�
������� P�  �@J�IsMouseOver . . ��� $
 grip��	 � ��

 � ����� $
 grip��	 � ��

 �����P�  �@n�
IsDragging . . ��� $
 grip��	 � ��

 � ����� $
 grip��	 � ��

 �����P�  � {� .  . ��� $
 grip��	 � ��

 ������� $
 grip��	 � ��

 ������� " ��.R��� $ border��#��z��#��z��#��z�� . ._��  �� $
��Auto ��� #��z��$
��Auto ��� $
��Auto �.+�m� $ TopTick��$��0��# z��$��0,0,2,0q�$
 Left=�$y�	Collapsed=�$��4��m� $ 
BottomTick��$��2��# z��$��2,0,0,0q�$ Right=�$y�	Collapsed=�$��4���� $ TrackBackground��
���   �$��1q����	#FFE7EAEA$��1��$��Center=�$	��0,5q�$��4��._��� $��-1,-6q�.+��� $ PART_SelectionRange��#��� ��$y�Hidden=�$��4��]� $ 
PART_Track��$��1�� n� $ Thumb��|�.  $��11�� . $	��Top=�$��18��8��  �� " ��.R��� $ border��#��z��#��z��#��z�� . ._��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $ TopTick��# z��$��4��$��0,0,0,2q�$	 Top=�$��0��$y�	Collapsed=�m� $ 
BottomTick��# z��$��4��$��0,2,0,0q�$ Bottom=�$��2��$y�	Collapsed=��� $ TrackBackground��
���   �$��1q����	#FFE7EAEA$��4��$	��5,0q�$��1��$��Center=�._��� $��-6,-1q�.+��� $ PART_SelectionRange��#��� ��$��4��$y�Hidden=�]� $ 
PART_Track��$��1�� n� $ Thumb��|�.  $��18�� . $��Center=�$��11��8��  