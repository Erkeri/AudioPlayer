   M S B A M L   `   `   `  ����F  BAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AudioPlayerAudioPlayer  5          AudioPlayer.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:AudioPlayer     5        �� 	Resources  5         SliderThumbTemplate �� 
TargetType � UseLayoutRounding F�Name �� Stretch �� Triggers P� Property P� Value �� 
TargetName	 �� Property
 �� Value ! SliderControlTemplateVertical ��Name J� SnapsToDevicePixels � ColumnDefinitions m�Name m� Fill m� 	Placement ��Name ]�Name ]� Thumb n�Name � OverridesDefaultStyle # SliderControlTemplateHorizontal � RowDefinitions��%�
  &	        &	 �    7   &	 �    7   �� 5   
   " n�66   .R�5      � $��Center=�6    . $��Center=�6I   .+�5	      F� $
 grip��6   +���� �  � ѠI � ѠI�y� � � �y� 	
��� ���$
 Fill=�6^   
�������6m   5
       5      P� 5       �@J�IsMouseOver . . �5      �� $
 grip��6-   	 � ��

 � ���6?   �� 5      $
 grip��6/   	 � ��

 �����6A   5      P� 5       �@n�
IsDragging . . �5      �� $
 grip��6-   	 � ��

 � ���6?   �� 5      $
 grip��6/   	 � ��

 �����6A   5      P� 5       � {� .  . �5      �� $
 grip��6-   	 � ��

 �����6?   �� 5      $
 grip��6/   	 � ��

 �����6A   5      5      �� 5   
   " ��6@   .R�5      �� $ border��6   #��z��6%   #��z��6Q   #��z��6�    . ._�5      �  5      �� 5      $
��Auto �6+   �� 5      #��z��6+   $
��Auto �6Q   �� 5       $
��Auto �6+   .+�5"      m� $ TopTick��6   $��0��6/   # z��6?   $��0,0,2,0q�6c   $
 Left=�6t   $y�	Collapsed=�6�   $��4��6�   m� 5#      $ 
BottomTick��6   $��2��62   # z��6B   $��2,0,0,0q�6f   $ Right=�6w   $y�	Collapsed=�6�   $��4��6�   �� 5$      $ TrackBackground��6   
���   �$��1q�6J   ���	#FFE7EAEA$��1��6u   $��Center=�6�   $	��0,5q�6�   $��4��6�   ._�5%      �� $��-1,-6q�6!   .+�5&      �� $ PART_SelectionRange��6(   #��� ��6E   $y�Hidden=�6�   $��4��6�   5'      5(      ]� 5)      $ 
PART_Track��6   $��1��60    5*      n� 5+      $ Thumb��5,   !   |�.  $��11��5-   3    . $	��Top=�5/   !   $��18��50   !   8��  52      54      55      56      57      �� 58   
   " ��6B   .R�59      �� $ border��6   #��z��6%   #��z��6Q   #��z��6�    . ._�5:      �  5;      �� 5<      $
��Auto �6(   �� 5=      $
��Auto �6(   #��z��66   �� 5>      $
��Auto �6(   .+�5@      m� $ TopTick��6   # z��6/   $��4��6S   $��0,0,0,2q�6^   $	 Top=�6o   $��0��6   $y�	Collapsed=�6�   m� 5A      $ 
BottomTick��6   # z��62   $��4��6V   $��0,2,0,0q�6a   $ Bottom=�6r   $��2��6�   $y�	Collapsed=�6�   �� 5B      $ TrackBackground��6   
���   �$��1q�6J   ���	#FFE7EAEA$��4��6u   $	��5,0q�6�   $��1��6�   $��Center=�6�   ._�5C      �� $��-6,-1q�6!   .+�5D      �� $ PART_SelectionRange��6(   #��� ��6E   $��4��6�   $y�Hidden=�6�   5E      5F      ]� 5G      $ 
PART_Track��6   $��1��60    5H      n� 5I      $ Thumb��5J   !   |�.  $��18��5L   !    . $��Center=�5N   !   $��11��5O   !   8��  5Q      5S      5T      5U      5V      5W      5X      