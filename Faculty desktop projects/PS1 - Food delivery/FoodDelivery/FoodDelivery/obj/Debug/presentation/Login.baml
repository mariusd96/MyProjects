   M S B A M L   `   `   `  ����G  CFoodDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FoodDelivery.presentationFoodDelivery.presentation  5   	   %    FoodDelivery.presentation.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FoodDelivery.presentation     5   	     � Title$  Login��5   	   $	��325��6   $	��625��6$    � WindowStyle$
 None=�60    � WindowStartupLocation$ CenterScreen=�6C    � AllowsTransparency . $��15q�6�   ��5	      �� 5
   
    �� ImageSource$3 -/FoodDelivery;component/Resources/contur2.png��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles/btnGlass.xaml?�6%   �� 5      $ /Styles/btnGlass2.xaml?�6%   %    5      .��5      � ��5   
   
� 5      .��5      �  � Color$ 	#FFF5C891��6   	 � Offset$	 1Q�61   � 5      $ 	#FFFFE5C3��6   $	 0.004Q�61   5      .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��30��69   
������ $��0q�6^   $	��Top=�6i   .+�5      �� -   5        
 ��Name$
 close��5      $��20��6$   $��Center=�60   $��20��6K   $��Right=�6V   $��	0,10,20,0q�6r   $��Right=�6�   
���  ��$
��Bold"�6�      	btnGlass2#��[  6�   $��14(�6�   $	��Top=�6�    � Cursor$
 Hand��6   � ToolTip$ Închide aplicația��6  $��0q�69  ��5       �� 5!      $ /Resources/close.png��6!   5#      �� 5$      -   5        $
 minimize��5$      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14(�6�   $��Center=�6�   $
 Hand��6  $ Minimize��6(  $��0q�6;  ��5%      �� 5&      $ /Resources/minimize.png��6!   5(      5)      �� 5+   
   -   5         ��Name$ image��5+      $
��Left=�6   $	��150��6:   $��Center=�6G   $	��250��6b   $��/Resources/logo.png��6n   $��	0,72,0,73q�6�   �� 5,   
   $��Right=�6   $	��175��6-   $��Center=�6:   $	��325��6U   $��0,0,20,0q�6a   .+�5-      �� -   5         ��Name$ 	userLabel��5-      $��
Utilizator��6'    �� Left$ 10��6<   
 �� Top$ 10��6M   $��Times New Roman)�6]   $��16(�6z   $��35��6�   $��Center=�6�   ���	#FFB34426$��Italic$�6�   �� 5.      $��4q�6   $��35��6)    �� Right$ 10��65   $ 10��6G   $	��220��6W    �� CornerRadius$ 15��6c   ���	#FFFCE4C8���	#FFB34426._�5/      �� -   5         ��Name$ userTextBox��5/      ���	#FFB34426$��	10,0,10,0q�6\   $��Times New Roman)�6o   $��0q�6�   $��16(�6�   $��Center=�6�   $��Italic$�6�   ��6/   Z� 6�   50      �� 51      -   5        $ passwordLabel��51      $��Parolă��6+   $ 10��6<   $ 60��6M   $��Times New Roman)�6]   $��16(�6z   $��35��6�   $��Center=�6�   ���	#FFB34426$��Italic$�6�   �� 52      $��4q�6   $��35��6)   $ 10��65   $ 60��6G   $	��220��6W   $ 15��6c   ���	#FFFCE4C8���	#FFB34426._�53      G� -   5         G�Name$ passwordBox��53      $��	10,0,10,0q�6I   ���	#FFB34426$��Times New Roman)�6s   $��0q�6�   $��16(�6�   $��Center=�6�   $��Italic$�6�   ��63   Z� 6�   54      �� 55      -	   5        $
 autentificareBtn��55      $��Autentificare��6/     btnGlass#��[ 6G   $ 75��6i   $	 125��6z   $	��175��6�   $��35��6�   $��Times New Roman)�6�   $��16(�6�   ���	#FFB34426���	#FFB34426���	#FFFCE4C8$��4q�6  $
 Hand��6(  $��Italic$�6U  56      57      58      