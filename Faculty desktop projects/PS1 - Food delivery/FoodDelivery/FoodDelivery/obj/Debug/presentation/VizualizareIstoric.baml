   M S B A M L   `   `   `  ����G  CFoodDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FoodDelivery.presentationFoodDelivery.presentation  5   	   2    ,FoodDelivery.presentation.VizualizareIstoric   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FoodDelivery.presentation     5   	     � Title$  VizualizareIstoric��5   	   $	��650��6$   $	��950��61    � WindowStyle$
 None=�6=    � WindowStartupLocation$ CenterScreen=�6P    � AllowsTransparency . $��15q�6�   ��5	      �� 5
   
    �� ImageSource$3 -/FoodDelivery;component/Resources/contur2.png��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles/btnGlass.xaml?�6%   �� 5      $ /Styles/btnGlass2.xaml?�6%   �� 5      $! /Styles/ScrollBarStyle.xaml?�6%   �� 5      $ /Styles/TextBoxStyle.xaml?�6%   %    5      .��5      � ��5   
   
� 5      .��5      �  � Color$ 	#FFF5C891��6   	 � Offset$	 1Q�61   � 5      $ 	#FFFFE5C3��6   $	 0.004Q�61   5      .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��60��69   
������ $��0q�6^   $	��Top=�6i   .+�5       �� -   5        
 ��Name$
 close��5       $��20��6$   $��Center=�60   $��20��6K   $��Right=�6V   $��	0,10,20,0q�6r   $��Right=�6�   
���  ��$
��Bold"�6�      	btnGlass2#��[  6�   $��14(�6�   $	��Top=�6�    � Cursor$
 Hand��6   � ToolTip$ Închide��6  $��0q�6/  ��5!      �� 5"      $ /Resources/close.png��6!   5$      �� 5%      -   5         ��Name$ image��5%      $
��Left=�6#   $��50��6>   $��Center=�6J   $	��100��6e   $��	15,10,0,0q�6q   $��/Resources/logo.png��6�   $
��Left=�6�   5&      �� 5'   
   $��Center=�6   $��30��6.   $��0,95,0,0q�6:   $	��Top=�6L   $	��500��6d   .+�5(      �� $��Data1��6   $��Times New Roman)�6$   $��16(�6A   ���	#FFB344266O   (  "System.Windows.Controls.DatePicker  5)      -   5          Name$ 	firstDate��5)      $
��Left=�6,   $	��Top=�6G    �� Left$ 60��6_   
 �� Top$ 2��6p   $��16(�6   $��Times New Roman)�6�   6�   �� 5*      $��Data2��6   $��Times New Roman)�6$   $��16(�6A   ���	#FFB34426$	 319��6f   $ 1��6x     5+      -   5        $ 
secondDate��5+      $
��Left=�6-   $	��Top=�6H   $	 385��6`   $ 2��6r   $��16(�6�   $��Times New Roman)�6�   6�   5,      �� 5.   
   -   5         ��Name$ scrollViewer��5.      $��Center=�6-   $	��380��6J   $��35,140,35,100q�6W   $��Center=�6n   $	��850��6�   .��5/      �� -   5         ��Name$ 
stackPanel��5/      50      51      �� 52   
   -   5         ��Name$ canvas��52      $��Center=�6!   $��35��6>   $��	0,550,0,0q�6J   $	��Top=�6]   $	��850��6u   .+�53      �� $��E client loial ?��6   ���	#FFB44627$��Times New Roman)�6F   $��16(�6c   $ 4��6q   	� 54      -	   5         	�Name$ 
daRadioBtn��54      $��DA��6.   $	 170��6;   $ 10��6M   ���	#FFB44627$��Times New Roman)�6t   $��16(�6�   	� 55      -
   5        $ 
nuRadioBtn��55      $��NU��6.   $	 250��6;   $ 10��6M   ���	#FFB44627$��Times New Roman)�6t   $��16(�6�   �� 56      -   5        $
 
salvareBtn��56      $��	Salvează��6)     btnGlass#��[ 6<   $	 665��6^   $ 1��6p   $	��175��6   $��35��6�   $��Times New Roman)�6�   $��16(�6�   ���	#FFB34426���	#FFB34426���	#FFFCE4C8$��4q�6  $
 Hand��6  $��Italic$�6C  57      58      59      