   M S B A M L   `   `   `  ����J  FCabinet medical, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Cabinet_medicalCabinet_medical  5   	   !    Cabinet_medical.Meniu_medic   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Cabinet_medical     5   	     � Title$  Meniu_medic��5   	   $	��600��6   $
��1024��6*    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�6\    � AllowsTransparency . $��5q�6�   ���	#FF00B09E � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles/btnHexagon.xaml?�6%   �� 5      $ Styles/btnGlass.xaml?�6%   %    5      ��5      �� 5   
    �� ImageSource$ Resources/white.jpg��6   .��5      � .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��30��69   
������ $��0q�6^   $	��Top=�6i   .+�5      �� -   5         ��Name$ close��5      $��20��6$   $��Center=�60   $��20��6K   $��Right=�6V   $��	0,10,20,0q�6r   $��Right=�6�   
���  ��$
��Bold"�6�      btnGlass#��[  6�   $��14.667(�6�   $	��Top=�6�   	 � Cursor$
	 Hand��6  ��5      �� 5      $ Resources2/close.png��6!   5      �� 5      -   5        $ maximize��5      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   
���  ��$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��6<  Z� .��5      �� .+�5       �� -   5        
 ��Name$
 maximize_img��5    =   $��Resources2/maximize.png��6   6=   5!      5"      �� 5#      -   5        $ minimize��5#      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��0,10,5,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14.667(�6�   $��Center=�6�   $
	 Hand��6  ��5$      �� 5%      $ Resources2/minimize.png��6!   5'      5(      �� 5)   
   $��Center=�6   $	��470��6.   $��Center=�6;   $	��990��6V   .+�5*      �� -   5        $ pacient��5*       �� Left$ 20��6&   
 �� Top$ 20��67   $	��150��6G   $	��150��6S     
btnHexagon#��[ 6`   $
	 Hand��6�   ���	#FFD20A0A � ToolTip$ 	Pacienți��6�   ��5+      �� 5,      $ Resources/pacient.png��6!   5/      �� 50      -   5        $ 
programari��50      $	 220��6)   $ 20��6;   $	��150��6K   $	��150��6W   #��[ 6d   $
	 Hand��6�   ���	#FFD20A0A$ Programări��6�   ��51      �� 52      $ Resources/programari.png��6!   54      �� 55      -   5        $ consultatii��55      $	 420��6*   $ 20��6<   $	��150��6L   $	��150��6X   #��[ 6e   $
	 Hand��6�   ���	#FFD20A0A$ Consultații��6�   ��56      �� 57      $ Resources/consultatie.png��6!   59      �� 5:      -	   5        $ bebelusi��5:      $	 620��6'   $ 20��69   $	��150��6I   $	��150��6U   #��[ 6b   $
	 Hand��6�   ���	#FFD20A0A$ Registru copii sub un an��6�   ��5;      �� 5<      $ Resources/baby.png��6!   5>      �� 5?      -
   5        $ femei_insarcinate��5?      $	 820��60   $ 20��6B   $	��150��6R   $	��150��6^   #��[ 6k   $
	 Hand��6�   ���	#FFD20A0A$# Registrul femei însărcinate��6�   ��5@      �� 5A      $% Resources/femei_insarcinate.png��6!   5C      �� 5D      -   5        $ bolnavi_cronici��5D      $	 120��6.   $	 163��6@   $	��150��6Q   $	��150��6]   #��[ 6j   $
	 Hand��6�   ���	#FFD20A0A$ Registrul bolnavi cronici��6�   ��5E      �� 5F      $# Resources/bolnavi-cronici.png��6!   5H      �� 5I      -   5        $ chemari_domiciliu��5I      $	 320��60   $	 163��6B   $	��150��6S   $	��150��6_   #��[ 6l   $
	 Hand��6�   ���	#FFD20A0A$ Chemări la domiciliu��6�   ��5J      �� 5K      $% Resources/chemari-domiciliu.png��6!   5M      �� 5N      -   5        $ tratamente_boli��5N      $	 520��6.   $	 163��6@   $	��150��6Q   $	��150��6]   #��[ 6j   $
	 Hand��6�   ���	#FFD20A0A$) #Registrul de tratamente pentru boli��6�   ��5O      �� 5P      $! Resources/registru-boli.png��6!   5R      �� 5S      -   5        $ vaccin��5S      $	 720��6%   $	 163��67   $	��150��6H   $	��150��6T   #��[ 6a   $
	 Hand��6�   ���	#FFD20A0A$ 	Vaccinuri��6�   ��5T      �� 5U      $ Resources/vaccin.png��6!   5W      �� 5X      -   5        $ 	documente��5X      $ 20��6(   $	 300��69   $	��150��6J   $	��150��6V   #��[ 6c   $
	 Hand��6�   ���	#FFD20A0A$ Documente eliberate��6�   ��5Y      �� 5Z      $ Resources/documente.png��6!   5\      �� 5]      -   5        $ medicamente��5]      $	 220��6*   $	 300��6<   $	��150��6M   $	��150��6Y   #��[ 6f   $
	 Hand��6�   ���	#FFD20A0A$ Medicamente din cabinet��6�   ��5^      �� 5_      $ Resources/medicament.png��6!   5a      �� 5b      -   5        $ obiecte_sanitare��5b      $	 420��6/   $	 300��6A   $	��150��6R   $	��150��6^   #��[ 6k   $
	 Hand��6�   ���	#FFD20A0A$" Obiecte sanitare din cabinet��6�   ��5c      �� 5d      $$ Resources/obiecte-sanitare.png��6!   5f      �� 5g      -   5        $ aparatura_medicala��5g      $	 620��61   $	 300��6C   $	��150��6T   $	��150��6`   #��[ 6m   $
	 Hand��6�   ���	#FFD20A0A$% Aparatura medicală din cabinet��6�   ��5h      �� 5i      $ Resources/aparatura.png��6!   5k      �� 5l      -   5        $ logout��5l      $	 820��6%   $	 300��67   $	��150��6H   $	��150��6T   #��[ 6a   $
	 Hand��6�   ���	#FFD20A0A$ Logout��6�   ��5m      �� 5n      $ Resources/logout.png��6!   5p      5q      5r      5s      