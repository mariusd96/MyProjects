   M S B A M L   `   `   `  ����J  FCabinet medical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Cabinet_medicalCabinet_medical  5   	        Cabinet_medical.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Cabinet_medical     5   	     � Title$  
MainWindow��5   	   $	��270��6   $	��510��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6Z    � AllowsTransparency . $��5q�6�   ���	#FF00B09E � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles/btnGlass.xaml?�6%   �� 5      $ Styles/btnGlass2.xaml?�6%   %    5      ��5      �� 5   
    �� ImageSource$ Resources/white.jpg��6   .��5      � -   5        $��grid1��5      .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��30��69   
������ $��0q�6^   $	��Top=�6i   .+�5      �� -   5         ��Name$ close��5      $��20��6$   $��Center=�60   $��20��6K   $��Right=�6V   $��	0,10,20,0q�6r   $��Right=�6�   
���  ��$
��Bold"�6�      btnGlass#��[  6�   $��14.667(�6�   $	��Top=�6�   	 � Cursor$
	 Hand��6  ��5      �� 5      $ Resources2/close.png��6!   5      �� 5      -   5        $ minimize��5      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��5      �� 5      $ Resources2/minimize.png��6!   5!      5"      �� 5$   
   $
��Left=�6   $	��100��6,   $��
175,60,0,0q�69   $	��Top=�6M   $	��320��6e   .+�5%      �� ���	#FFD20A0A$��3q�6-   
 �� CornerRadius$
 15��6A   $
��Left=�6S   $��30��6n   $	��Top=�6z   $	��200��6�   ���	#FFFF3737 �� Left$	 105��6�   
 �� Top$ 10��6�   ._�5&      �� -   5         ��Name$ user_textBox1��5&       �� TextWrapping$ NoWrap=�61   $��TextBox��6G   $��Times New Roman)�6l   $��16(�6�   
�������$��Center=�6�   $��0q�6�   $	��170��6�   ��6V   Z� 6�   5'      �� 5(      -   5         ��Name$ 
user_label��5(      $��
Utilizator��6(   $��30��6=   $ 10��6I   $ 10��6Z   $��75��6j   $��Times New Roman)�6u   $��16(�6�   $��Center=�6�   $��Center=�6�   �� 5)      ���	#FFD20A0A$��3q�6-   $
 15��6A   $
��Left=�6S   $��30��6n   $	��Top=�6z   $	��200��6�   ���	#FFFF3737$	 105��6�   $ 50��6�   ._�5*      G� -   5         G�Name$ passwordBox1��5*      $	��170��64    G� Password$ proiect��6@   $��Times New Roman)�6i   $��16(�6�   
�������$��Center=�6�   $��0q�6�   ��6S   Z� 6�   5+      �� 5,      -   5        $ parola_label��5,      $��Parolă��6*   $��30��6;   $ 10��6G   $ 50��6X   $��75��6h   $��Times New Roman)�6s   $��16(�6�   $��Center=�6�   $��Center=�6�   5-      �� 5/   
   -	   5         ��Name$ image1��5/      $	��150��6    $	��200��6,   $��10,41,340,19q�69   $��Resources/logo.png��6O   �� 50   
   -
   5        $ 	btn_login��50      $��Autentificare��6$   $
��Left=�6<   $��245,190,0,0q�6W   $	��Top=�6l   $	��180��6�   $��35��6�   $��Times New Roman)�6�   $��18.667(�6�   ���	#FFFF3737
�������  	btnGlass2#��[ 6�   $
	 Hand��6  ���	#FFD20A0A$��3q�6V  52      53      