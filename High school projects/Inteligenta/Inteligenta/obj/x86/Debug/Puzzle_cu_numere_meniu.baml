   M S B A M L   `   `   `  ����  Inteligenta(    "Inteligenta.Puzzle_cu_numere_meniu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Puzzle_cu_numere_meniu��5   	   $	��768��6(   $
��1024��65    � Icon$- '/Inteligenta;component/Images/brain.ico��6B    � 
ResizeMode$ NoResize=�6q    � Topmost .  � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6�    � WindowStyle$
 None=�6�   ��5      �� 5   
    �� ImageSource$+ %/Inteligenta;component/Images/sah.png��6    � 	Resources 5	         btnGlass	 �� 
TargetType
 �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� RenderTransformOrigin � RowDefinitions ��Name �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY  btnlock  	btnGlass2��%�  &	        &	 ~    &	 ;    �� 5   
   "	 ��6!   .�5      �� 
 � �� 5      �� 5      " ��6&   .R�5      �� $ ButtonBorder��6!   $ 15��67   $��0q�6I   #��z��6]   
�������$ 0.5,0.5&�5   ,   ._�5      �  5   "   �� 5   &   $��* �64   �� 5   &   $
��1.7* �64   .+�5   "   �� $ ButtonContentPresenter��63   $��Center=�5   !   $��Center=�5   !   $��2��5   !   5      5       5      P� 5       � �� . . �5    "   �� $ ButtonBorder��6D   
 � z� 5!   &   V� 5"   *   .~�5#   .   �� $
 0.95Q�6=   $
 0.95Q�6K   5$   +   5&   #   5'      5)      5+      5,      �� 5.   
   "	 ��6    .�5/      �� 
 � �� 50      �� 51      " ��6&   .R�52      �� $ ButtonBorder��6!   $ 15��67   $��0q�6I   #��z��6]   
�������$ 0.5,0.5&�53   ,   ._�54      �  55   "   �� 56   &   $��* �64   �� 57   &   $
��1.7* �64   .+�59   "   �� $ ButtonContentPresenter��63   $��Center=�6S   $��Center=�5:   !   $��2��6>   5;   #   5<      5=      5>      5@      5A      �� 5C   
   "	 ��6"   .�5D      �� 
 � �� 5E      �� 5F      " ��6&   .R�5G      �� $ ButtonBorder��6!   $	 100��67   $��3q�6J   #��z��6^   #��z��5H      $ 0.5,0.5&�6?   ._�5I      �  5J   "   �� 5K   &   $��* �64   �� 5L   &   $
��1.7* �64   .+�5N   "   �� $ ButtonContentPresenter��63   $��Center=�5O   !   $��Center=�5P   !   $��2��5Q   !   5R      5T       5V      P� 5W       � �� . . �5X   "   �� $ ButtonBorder��6D   
 � z� 5Y   &   V� 5Z   *   .~�5[   .   �� $
 0.95Q�6=   $
 0.95Q�6K   5\   +   5^   #   5_      5a      5c      5d      5f      .��5h      � -   5        .+�5i   
   �� -   5        $��canvas1��5i   L   $	��130��6   $��Center=�6   $��167,319q�6;   $��Center=�6[   $	��690��6v   .+�5j      �� -   5        $��button1��5j   .   $��1��6   $	��130��6!   $	��130��6=    �� Left$ 0��6I   
 �� Top$ 0��6Y   ���	#FFFFFFD3���	#FF78200F$��Times New Roman)�6�   $��Italic$�6�   $��48(�6�   #��[  6�   �� 5k      -   5        $��button2��5k   �   ���	#FF78200F$	 140��6,   $ 0��6>   $��2��6M   $��Times New Roman)�6Y   $��48(�6v   $��Italic$�6�   ���	#FFFFFFD3$	��130��6�   #��[  6�   $	��130��6�   �� 5l      -   5        $��button3��5l   �   ���	#FFFFFFD3$	 280��6,   $ 0��6>   $��3��6M   $��Times New Roman)�6Y   $��48(�6v   $��Italic$�6�   ���	#FF78200F$	��130��6�   #��[  6�   $	��130��6�   �� 5m      -   5        $��button4��5m   �   ���	#FF78200F$	 420��6,   $ 0��6>   $��4��6M   $��Times New Roman)�6Y   $��48(�6v   $��Italic$�6�   ���	#FFFFFFD3$	��130��6�   #��[  6�   $	��130��6�   �� 5n      -   5        $��button5��5n   �   ���	#FFFFFFD3$	 560��6,   $ 0��6>   $��5��6M   $��Times New Roman)�6Y   $��48(�6v   $��Italic$�6�   ���	#FF78200F$	��130��6�   #��[  6�   $	��130��6�   �� 5p      -   5        $��image1��5p       $��40��6   $
��Fill=�6.   $��40��6=   $2��,/Inteligenta;component/Images/lock_brown.png��6H   $ 80��6~   $ 80��6�   �� 5q      -	   5        $��image2��5q   B   $	 220��6   $ 80��6&   $��40��66   $,��&/Inteligenta;component/Images/lock.png��6P   $
��Fill=�6�   $��40��6�   �� 5r      -
   5        $��image3��5r   B   $	 360��6   $ 80��6&   $��40��66   $2��,/Inteligenta;component/Images/lock_brown.png��6P   $
��Fill=�6�   $��40��6�   �� 5s      -   5        $��image4��5s   B   $	 500��6   $ 80��6&   $��40��66   $,��&/Inteligenta;component/Images/lock.png��6P   $
��Fill=�6�   $��40��6�   �� 5t      -   5        $��image5��5t   B   $	 640��6   $ 80��6&   $��40��66   $2��,/Inteligenta;component/Images/lock_brown.png��6P   $
��Fill=�6�   $��40��6�   5u      �� 5w   
   -   5        $��canvas_meniu��5w   P   $��50��6   $��Center=�6   $��416,0,416,20q�6:   $��Bottom=�6d   $	��170��6   .+�5x      �� -   5        $��inapoi��5x   �   ���	#FFFFFFD3$��Monotype Corsiva)�6,   $��30(�6J   $��Normal"�6X   
�������$��50��6   #��[ 6�   $��50��6�   $ 0��6�   $ 0��6�   ���	#FF78200F.��5y      �� .+�5z      �� -   5        $��
inapoi_img��5z   X   $8��2/Inteligenta;component/Images/back_arrow_brown.png��6   6X   5{      5|      �� 5}      -   5        $��acasa��5}   �   ���	#FFFFFFD3$��Monotype Corsiva)�6,   $��30(�6J   $��Normal"�6X   
�������$��50��6   #��[ 6�   $��50��6�   $ 60��6�   $ 0��6�   ���	#FF78200F.��5~      �� .+�5      �� -   5        $��	acasa_img��5   R   $2��,/Inteligenta;component/Images/home_brown.png��6   6R   5�      5�      �� 5�      -   5        $��nav_menu��5�   �   ���	#FFFFFFD3$��Monotype Corsiva)�6,   $��30(�6J   $��Normal"�6X   
�������$��50��6   #��[ 6�   $��50��6�   $	 120��6�   $ 0��6�   ���	#FF78200F.��5�      �� .+�5�      �� -   5        $��nav_menu_img��5�   R   $2��,/Inteligenta;component/Images/menu_brown.png��6   6R   5�      5�      5�      5�      5�      