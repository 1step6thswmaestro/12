   M S B A M L   `   `   `  ����@  <Music, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MusicMusic  5          Music.MusicView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Music     5      ���	#00000000  � 	Resources  5
       �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� Stretch �� Triggers	 P� Property
 P� Value �� 
TargetName �� Angle �� RelativeSource �� Path��%�  '�       �� 5   
   " �6   .�5      ��  � �� 5      �� 5      " �6&   .R�5      � $
 Root��65   ��6   Z� .+�5      �� $ 
PART_Track��6(   $
 Fill=�6<   ��6K   Z� �� 5      $ PART_Indicator��6(   $
��Left=�6@   #��z��6[   5       5      P� 5      	 �@�Orientation$
 Vertical=�6=   . �5   "   �� $
 Root��6)    �@�LayoutTransform 5   &   �� 5   *   $	 270Q�6:   5   #   �� 5   "   $
 Root��6)    6L   ��  �� *TemplatedParent+$ Height� � ���� 5   "   $
 Root��6)    6M   ��  �� *TemplatedParent+$ Width� � ��5      5      5!      5"      5#      .��5%      (� .��5&   
   � .+�5'      � -   5        $ SpectrumPanel��5'      $��Stretch=�6*   $��Center=�6H   A� 5(      -   5         A�Name$ EllipseAlbum��5(      $��Stretch=�6,   $��Stretch=�6J   $	��210��6f   $	��210��6r   $��-5,5,0,0q�6   ��5)      �� 5*       �� ImageSource$) #/Music;component/Images/Default.png��6!   5,      A� 5-      -   5        $ EllipseAlbumOver��5-      $��Stretch=�60   $��Stretch=�6N   $	��210��6j   $	��210��6v   $��-5,5,0,0q�6�   ���	#7F0000006�   �� 5.      $��Center=�6   .+�5/      �� -   5         ��Name$ 	TextTitle��5/      
�������$	��200��51       �� TextAlignment$ Center=�52      $��24(�53      $
��Bold"�54      $��CharacterEllipsis=�55       �� Padding$
 10,0q�56      &   System.Windows.Media.TextOptions   TextRenderingMode$ Aliased=�57         TextFormattingMode$ Ideal=�58      �� 5:      -   5        $ 
TextArtist��5:      
�������$	��200��5<      $ Center=�5=      $��18(�5>      $��CharacterEllipsis=�5?      $
 10,0q�5@      $ Aliased=�5A      $ Ideal=�5B      5C      �� 5D      -   5        $ TextTime��5D      
�������$	��200��5F      $ Center=�5G      $��10(�5H      $��CharacterEllipsis=�5I      $
 10,0q�5J      $��Center=�5K      $ Aliased=�5L      $ Ideal=�5M      $��2.5,99,2.5,0q�5N      5O      5P      5Q      