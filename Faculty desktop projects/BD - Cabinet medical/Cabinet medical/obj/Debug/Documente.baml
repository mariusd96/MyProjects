   M S B A M L   `   `   `  ����J  FCabinet medical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Cabinet_medicalCabinet_medical  5   	       Cabinet_medical.Documente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Cabinet_medical     5   	     � Title$  	Documente��5   	   $	��600��6   $
��1024��6(    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6Z    � AllowsTransparency . $��5q�6�   ���	#FF00B09E��5	      �� 5
   
    �� ImageSource$ Resources/white.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles/btnGlass.xaml?�6%   �� 5      $ Styles/btnHexagon.xaml?�6%   �� 5      $ Styles/datagridStyle.xaml?�6%   �� 5      $! Styles/tabControlStyle.xaml?�6%   %    5      .��5      � .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��30��69   
������ $��0q�6^   $	��Top=�6i   .+�5      �� -   5         ��Name$ close��5      $��20��6$   $��Center=�60   $��20��6K   $��Right=�6V   $��	0,10,20,0q�6r   $��Right=�6�   
���  ��$
��Bold"�6�      btnGlass#��[  6�   $��14.667(�6�   $	��Top=�6�   	 � Cursor$
	 Hand��6  ��5      �� 5      $ Resources2/close.png��6!   5      �� 5      -   5        $ maximize��5      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   
���  ��$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��6<  Z� .��5       �� .+�5!      �� -   5        
 ��Name$
 maximize_img��5!   =   $��Resources2/maximize.png��6   6=   5"      5#      �� 5$      -   5        $ minimize��5$      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��5%      �� 5&      $ Resources2/minimize.png��6!   5(      5)      �� 5+   
   -   5        $ 	btn_meniu��5+      $��Center=�6$   $��40��6A   $��Bottom=�6M   $��40��6h     
btnHexagon#��[ 6s   $��487,0,487,20q�6�   $
	 Hand��6�   ��6�   Z� ��5,      �� 5-      $ Resources/menu.png��6   5/      �� 51   
   -   5         ��Name$ 
tabControl��51      $��Center=�6)   $	��420��6F   $��Center=�6S   $	��850��6n   ���	#9900B0A0���	#FF00B0A0$��3q�6�   .@�52      �� $��Rețete��6   
�������6&   �� 53      $��Adeverințe medicale��6   
�������63   �� 54      $��Avize epidemiologice��6   
�������64   �� 55      $��Bilete de trimitere��6   
�������63   56      57      58      