   M S B A M L   `   `   `  ����G  CFoodDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FoodDelivery.presentationFoodDelivery.presentation  5   	   ,    &FoodDelivery.presentation.ListaProduse   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FoodDelivery.presentation     5   	     � Title$  ListaProduse��5   	   $	��650��6   $	��950��6+    � WindowStyle$
 None=�67    � WindowStartupLocation$ CenterScreen=�6J    � AllowsTransparency . $��15q�6�   ��5	      �� 5
   
    �� ImageSource$3 -/FoodDelivery;component/Resources/contur2.png��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles/btnGlass.xaml?�6%   �� 5      $ /Styles/btnGlass2.xaml?�6%   �� 5      $! /Styles/ScrollBarStyle.xaml?�6%   %    5      .��5      � ��5   
   
� 5      .��5      �  � Color$ 	#FFF5C891��6   	 � Offset$	 1Q�61   � 5      $ 	#FFFFE5C3��6   $	 0.004Q�61   5      .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��60��69   
������ $��0q�6^   $	��Top=�6i   .+�5       �� -   5        
 ��Name$
 userOptions��5       $��24��6*   $��Center=�66   $��30��6Q   $��Right=�6\   $��	0,10,30,0q�6x   $��Right=�6�   
���  ��$
��Bold"�6�      	btnGlass2#��[  6�   $��14(�6�   $	��Top=�6�    � Cursor$
 Hand��6   � ToolTip$ Opțiuni��6#  $��0q�65  ��5!      �� 5"      $  /Resources/userOptions.png��6!    � ContextMenu 5%      �� 5&      ���	#FFFCE4C8���	#FFB34426.@�5'      m� -   5         m�Name$ Logout��5'   3   $��Logout��6#   6C   5(      5*      �� 5+      -   5        $
 minimize��5+      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��	0,10,15,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14(�6�   $��Center=�6�   $
 Hand��6  $ Minimize��6)  $��0q�6<  ��5,      �� 5-      $ /Resources/minimize.png��6!   5/      �� 50      -   5        $

 back��50      $��30��6#   $��Center=�6/   $��30��6J   $
��Left=�6U   $��	15,10,0,0q�6p   $
��Left=�6�   ���	#FFB34426#��[  6�   $��24(�6�   $��Center=�6�   $
 Hand��6  $ Înapoi��6  $��0q�6"  $��<��66  ���	#00000000$��Times New Roman)�6\  $
��Bold"�6y  6�  �� 51      -   5         ��Name$ image��51      $
��Left=�6#   $��50��6>   $��Center=�6J   $	��100��6e   $��	15,10,0,0q�6q   $��/Resources/logo.png��6�   $��Right=�6�   52      �� 54   
   -   5        $
 	addProdus��54      $��30��6$   $��Center=�60   $��30��6K   $
��Left=�6V   $��50,88,0,502q�6q   ���	#FFB34426  btnGlass#��[ 6�   $��15(�6�   $��Center=�6�   $
 Hand��6�   $ Adaugă Produs��6�   $��2q�6  $��+P��6)  ���	#00000000$��Times New Roman)�6M  $
��Bold"�6j  ���	#FFB344266�  �� 55   
   -   5        $
 addCategorie��55      $��30��6'   $��Center=�63   $��30��6N   $
��Left=�6Y   $��95,88,0,502q�6t   ���	#FFB34426#��[ 6�   $��15(�6�   $��Center=�6�   $
 Hand��6�   $ Adaugă Categorie��6   $��2q�6  $��+C��6/  ���	#00000000$��Times New Roman)�6S  $
��Bold"�6p  ���	#FFB344266�  �� 57   
   $��Center=�6   $��30��6.   $��	50,88,0,0q�6:   $	��Top=�6M   $	��410��6e   .+�58      �� -	   5         ��Name$ comboBoxCategorie��58      $��Center=�62   $��30��6O   $��Center=�6[   $	��270��6v    �� Left$	 140��6�   ���	#FFB34426
���   ����	#FFFCE4C86�   �� 59      -
   5         ��Name$ categoriProdusLabel��59      $��Categorie Produs��61   $��30��6L   $	��134��6X   ���	#FFB34426$��Times New Roman)�6{   $��16(�6�   $
��Bold"�6�   5:      �� 5<   
   -   5         ��Name$ scrollViewer��5<      $��Center=�6-   $	��470��6J   $��	0,120,0,0q�6W   $��Center=�6j   $	��850��6�   .��5=      �� -   5         ��Name$ 
stackPanel��5=      5I      5J      5K      5L      