   M S B A M L   `   `   `  ����  Inteligenta    Inteligenta.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��270��6   $	��500��6)    � Icon$- '/Inteligenta;component/Images/brain.ico��65    � 
ResizeMode$ NoResize=�6d    � Topmost .   � WindowStyle$
 None=�6�    � WindowStartupLocation$ CenterScreen=�6�   ��5      �� 5   
    �� ImageSource$+ %/Inteligenta;component/Images/sah.png��6    � 	Resources 5	         btnGlass �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name �� CornerRadius J� RenderTransformOrigin � RowDefinitions ��Name �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY��%S  &	        �� 5   
   " ��6!   .�5      �� 	 � ��$
 28(�6)   �� 5      	 � ��

 �����6+   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5      �� $ ButtonBorder��6!   $ 2��67   $��0q�6H   ���	#FFDE0909
�������$ 0.5,0.5&�5   ,   ._�5      �  5   "   �� 5   &   $��* �64   �� 5   &   $
��1.7* �64   .+�5   "   �� $ ButtonContentPresenter��63   $��Center=�5   !   $��Center=�5   !   $��2��5   !   5      5       5!      P� 5"       � �� . . �5#   "   �� $ ButtonBorder��6D   	 � z�
 5$   &   V� 5%   *   .~�5&   .   �� $
 0.95Q�6=   $
 0.95Q�6K   5'   +   5)   #   5*      P� 5,       �@J�IsMouseOver . . �5-   "   �� $ ButtonBorder��6?   	 � ��
 �	#FFC309095.   #   5/      51      53      54      56      .��58      � -   5        $��grid1��58      .+�59   
   �� -   5        $
��exit��59   g   #��[  6   $��X��63   $��30��6?   $��Right=�6K   $	��Top=�6s   $��30��6�   $��22(�6�   $��Normal"�6�   $��Berlin Sans FB)�6�    � Cursor$
 Hand��6�   
���������6�   Z� 6  �� 5:   
   -   5        $��minimize��5:   y   #��[  6   $��_��63   $��30��6?   $��Right=�6K   $��0,0,32,0q�6g   $	��Top=�6�   $��30��6�   $��18(�6�   $��Normal"�6�   $��Berlin Sans FB)�6�   $
 Hand��6�   
���������6�   Z� 6!  �� 5;   
   -   5        $
��user��5;   \   $
��User��6   $��33��6   $
��Left=�6+   $��117,63,0,135q�6F   $��Stretch=�6h   $��66��6�   $��20(�6�   $��Times New Roman)�6�   
�������$��Stretch=�6�   �� 5<   
   -   5        $��parola��5<   �   $��Parolă��6   $��Times New Roman)�6!   $��20(�6>   
�������$��33��6_   $
��Left=�6k   $��117,98,0,100q�6�   $��Stretch=�6�   $��Stretch=�6�   $��66��6�   �� 5=   
   -   5        $��textBox1��5=   T   $��30��6   $��Stretch=�6   $��185,65,108,136q�6<   $��Stretch=�6d   $	��185��6�   $��16(�6�   $��Times New Roman)�6�   $��Center=�6�   6�   G� 5>   
   -   5        $��passwordBox1��5>   M   $��Stretch=�6   $��185,100,108,101q�64   $	��185��6a   $��30��6m   $��Center=�6y   $��16(�6�   6�   �� 5?   
   -   5        $��reamintire_parola��5?   �   $��Am uitat parola��6   $��Times New Roman)�6*   $��20(�6G   
�������$��33��6h   $��Center=�6t   $��171,0,171,6q�6�   $��Bottom=�6�   $��Stretch=�6�   $	��136��6�   $
 Hand��6	  6  �� 5@   
   -	   5        $��inregistrare��5@   �   $$��Nu ai cont? Înregistrează-te��6   $��Times New Roman)�67   $��20(�6T   
�������$��33��6u   $��Center=�6�   $��124,0,123,31q�6�   $��Bottom=�6�   $��Stretch=�6�   $	��231��6  $
 Hand��6  6   �� 5A   
   -
   5        $��login��5A   �   $��Autentificare��6'   $
 Hand��6?   $��Times New Roman)�6M   $��22(�6j   $��Normal"�6x   
�������$��35��6�   $��Stretch=�6�   $��164,140,164,56q�6�   #��[  6�   $��Stretch=�6  $	��150��6,  ��6   Z� 68  �� 5B   
   -   5        $��label1��5B   �   $��Omul şi inteligenţa��6   $��Monotype Corsiva)�6.   $��32(�6L   ���	#FFFFFFD3$��50��6q   $
��Left=�6}   $��5,5,0,0q�6�   $	��Top=�6�   $	��240��6�   5C      5D      