   M S B A M L   `   `   `  ����A  =Lumino, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lumino.ControlsLumino.Controls  5   	   !    Lumino.Controls.AlertDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Lumino.Controls     5   	     � Title$  AlertDialog��5	   	   $	��200��6   $	��350��6*    � AllowsTransparency .  � ShowInTaskbar .   � WindowStyle$
 None=�6f   ��6y   Z�  � 	Resources 5
         
DialogShow �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value	   EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase
   
EasingMode  
DialogHide0  *System.Windows.Media.Animation.QuarticEase��%  &	        &	 �    �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5        $ 0��6'   $ 0Q�63   	 5        5      $
 	EaseInOut=�6$   5        5      $ 0:0:0.5��6'   $ 1Q�69   	 5        5      $
 	EaseInOut=�6$   5      5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5        $ 0��6'   $ 0Q�63   	 5        5      $
 	EaseInOut=�6$   5        5      $ 0:0:0.5��6'   $ 1Q�69   	 5        5       $
 	EaseInOut=�6$   5"      5#      5$      �� 5%   
   -   5        .��5&      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 grid��6�   .\�5'        $ 0��6'   $ 1Q�63     5(      $ 0:0:0.5��6'   $ 0Q�69   	 5)        5*      $
 	EaseInOut=�6&   5,      5-      U� 5.      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 grid��6�   .\�5/        $ 0��6'   $ 1Q�63     50      $ 0:0:0.5��6'   $ 0Q�69   	 51        52      $
 	EaseInOut=�6&   54      55      56      57       � Triggers 59      :� 5:   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5;      �� #��[  6   5<      .��5?      � -   5         �Name$
 grid��5?       J� RenderTransformOrigin$ 0.5,0.5&�6   z�5@   
   V� 5A      .~�5B      �� �� 5C      �� 5D      T� 5E      5F       � RowDefinitions 5H   
   �� 5I      $��7* �6   �� 5J      $��3* �6   .+�5L   
   �� $��Stretch=�6   $��2��6-   $��0��6>   $��Stretch=�6K    �� CornerRadius$ 10��6i   ���	#CCFFFFFF._�5M      � .+�5N      �� -   5         ��Name$ 	TextTitle��5N      $	��Top=�6/   $��CharacterEllipsis=�6G   $��제목��6h   $
��Wrap=�6r    �� TextAlignment$ Center=�6�   $��
20,20,20,0q�6�   $��Stretch=�6�   $��18.667(�6�   $
��Bold"�6�   �� 5O      -   5        $ TextContent��5O      $	��Top=�61   $��CharacterEllipsis=�6I   $��메시지 내용��6j   $
��Wrap=�6x   $
 Left=�6�   $��
20,55,20,0q�6�   $��Stretch=�6�   $��16(�6�   5P      5Q      �� 5R   
   $	��Top=�6    J� SnapsToDevicePixels . $��1��6D   $��1��6Q   ���	#B26E6E6E6\   �� 5S   
   -   5         ��Name$ ButtonStack��5S       �� Orientation$ 
Horizontal=�6*   $��1��6C   $��Stretch=�6P   $��Stretch=�6n   .+�5T      �� -   5         ��Name$ TextNO��5T      $��Stretch=�6$   $��취소��6@   $��Center=�6M   $��Center=�6o   $��Stretch=�6�   $��18.667(�6�   $
��Bold"�6�   ���	#FF4965976�   �� 5U      -   5         ��Name$ BorderButton��5U      $��Stretch=�6+    . $��1��6b   ���	#B26E6E6E6l   �� 5V      -   5        $ TextYES��5V      $��Stretch=�6%   $��확인��6A   $��Center=�6N   $��Center=�6p   $��Stretch=�6�   $��18.667(�6�   $
��Bold"�6�   ���	#FF4965976�   5W      5X      5Y      