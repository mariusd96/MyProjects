   M S B A M L   `   `   `  ����J  FCabinet medical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Cabinet_medicalCabinet_medical  5   	   !    Cabinet_medical.Medicamente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Cabinet_medical     5   	     � Title$  Medicamente��5   	   $	��600��6   $
��1024��6*    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�6\    � AllowsTransparency . $��5q�6�   ���	#FF00B09E��5	      �� 5
   
    �� ImageSource$ Resources/white.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles/btnGlass.xaml?�6%   �� 5      $ Styles/btnGlass2.xaml?�6%   �� 5      $ Styles/btnHexagon.xaml?�6%   �� 5      $ Styles/datagridStyle.xaml?�6%   �� 5      $! Styles/tabControlStyle.xaml?�6%   %    5      .��5      � .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��30��69   
������ $��0q�6^   $	��Top=�6i   .+�5      �� -   5         ��Name$ close��5      $��20��6$   $��Center=�60   $��20��6K   $��Right=�6V   $��	0,10,20,0q�6r   $��Right=�6�   
���  ��$
��Bold"�6�      btnGlass#��[  6�   $��14.667(�6�   $	��Top=�6�   	 � Cursor$
	 Hand��6  ��5      �� 5      $ Resources2/close.png��6!   5      �� 5       -   5        $ maximize��5       $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   
���  ��$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��6<  Z� .��5!      �� .+�5"      �� -   5        
 ��Name$
 maximize_img��5"   =   $��Resources2/maximize.png��6   6=   5#      5$      �� 5%      -   5        $ minimize��5%      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��5&      �� 5'      $ Resources2/minimize.png��6!   5)      5*      �� 5,   
   -   5         ��Name$ 
tabControl��5,      $��Center=�6)   $	��420��6F   $��Center=�6S   $	��700��6n   ���	#9900B0A0���	#FF00B0A0$��3q�6�   .@�5-      �� $��Medicamente��6   
�������.��5.      � .+�5/      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataGrid1��5/      $��Stretch=�62   $��Stretch=�6P   $	��600��6l   $	��250��6x    �� AlternationCount$ 2��6�   $��Times New Roman)�6�   $��14.667(�6�   $��45,67,45,70q�6�   ��6�   Z� 6�   �� 50      -   5        $ update��50      $��Salvează modificările��6-   $��Center=�6M   $��40��6j   $��	0,320,0,0q�6v   $	��170��6�     	btnGlass2#��[ 6�   
����������	#FF00B0A0$��3q�6�   $
	 Hand��6  �� 51      ���	#FF00B0A0$��3q�65   $��30��6I   $	��400��6U   
������� �� CornerRadius$ 15��6t   $��Center=�6�   $��145,20,145,337q�6�   ._�52      �� $��25��6!   .+�53      �� -	   5         ��Name$ label��53   $   $��Caută un medicament : ��63   $	��150��6T    �� Left$ 0��6`   
 �� Top$ 1��6p   $��Times New Roman)�6   $��14.667(�6�   $��8,3,5,5q�6�   $��Center=�6�   �� 54      -
   5        $ cauta��54   %   $��25��64    �� Right$ 5��6@   $ 0��6Q   $��30��6`   #��[  6k   $
	 Hand��6�   ��55   "   �� 56   &   $ Resources2/lupa.png��61   58      �� 59      -   5         ��Name$ 
cautareBox��59   &   $��25��6:    �� TextWrapping$ NoWrap=�6F   $	 150��6\   $	��205��6n   $��Center=�6z   $��Times New Roman)�6�   $��14.667(�6�   $��0q�6�   ��6�   Z� ��6�   Z� 6  5:      5;      5<      5=      5>      �� 5@   
   -   5        $ 	btn_meniu��5@      $��Center=�6$   $��40��6A   $��Bottom=�6M   $��40��6h     
btnHexagon#��[ 6s   $��487,0,487,20q�6�   $
	 Hand��6�   ��6�   Z� ��5A      �� 5B      $ Resources/menu.png��6   5D      5E      5F      