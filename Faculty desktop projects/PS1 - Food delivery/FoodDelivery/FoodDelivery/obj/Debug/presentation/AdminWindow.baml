   M S B A M L   `   `   `  ����G  CFoodDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FoodDelivery.presentationFoodDelivery.presentation  5   	   +    %FoodDelivery.presentation.AdminWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FoodDelivery.presentation     5   	     � Title$  AdminWindow��5   	   $	��400��6   $	��850��6*    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�6I    � AllowsTransparency . $��15q�6�   ��5	      �� 5
   
    �� ImageSource$3 -/FoodDelivery;component/Resources/contur2.png��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Styles/btnGlass.xaml?�6%   �� 5      $ /Styles/btnGlass2.xaml?�6%   %    5      .��5      � ��5   
   
� 5      .��5      �  � Color$ 	#FFF5C891��6   	 � Offset$	 1Q�61   � 5      $ 	#FFFFE5C3��6   $	 0.004Q�61   5      .+�5   
   ]� -   5        $��TitleBar��5      $	��Top=�6$   $��60��69   
������ $��0q�6^   $	��Top=�6i   .+�5      �� -   5        
 ��Name$
 userOptions��5      $��24��6*   $��Center=�66   $��30��6Q   $��Right=�6\   $��	0,10,30,0q�6x   $��Right=�6�   
���  ��$
��Bold"�6�      	btnGlass2#��[  6�   $��14(�6�   $	��Top=�6�    � Cursor$
 Hand��6   � ToolTip$ Opțiuni��6#  $��0q�65  ��5       �� 5!      $  /Resources/userOptions.png��6!    � ContextMenu 5$      �� 5%      ���	#FFFCE4C8���	#FFB34426.@�5&      m� -   5         m�Name$ Logout��5&   3   $��Logout��6#   6C   5'      5)      �� 5*      -   5        $
 minimize��5*      $��20��6'   $��Center=�63   $��20��6N   $��Right=�6Y   $��	0,10,15,0q�6u   $��Right=�6�   ���	#FF00B0A0$
��Bold"�6�   #��[  6�   $��14(�6�   $��Center=�6�   $
 Hand��6  $ Minimize��6)  $��0q�6<  ��5+      �� 5,      $ /Resources/minimize.png��6!   5.      �� 5/      -   5         ��Name$ image��5/      $
��Left=�6#   $��50��6>   $��Center=�6J   $	��100��6e   $��	15,10,0,0q�6q   $��/Resources/logo.png��6�   $��Right=�6�   50      �� 52   
   $��Center=�6   $	��150��6.   $��Center=�6;   $	��700��6V   .+�53      �� -   5        $
 
createCont��53       �� Left$ 0��6)   
 �� Top$ 0��69   $	��200��6H     btnGlass#��[ 6T   $	��150��6v   $��5q�6�   ���	#FFB34426$ Adăugare cont��6�   $
 Hand��6�   ��54      �� 55      $3 -/FoodDelivery;component/Resources/addUser.png��6!    j� Stretch$ Uniform=�6]   57      �� 59      -   5        $
 
updateCont��59      $	 250��6)   $ 0��6;   $	��200��6J   #��[ 6V   $	��150��6x   $��5q�6�   ���	#FFB34426$ Modificare cont��6�   $
 Hand��6�   ��5:      �� 5;      $: 4/FoodDelivery;component/Resources/updateUserInfo.png��6!   $ Uniform=�6d   5=      �� 5?      -   5        $
 
updateMenu��5?      $	 500��6)   $ 0��6;   $	��200��6J   #��[ 6V   $	��150��6x   $��5q�6�   ���	#FFB34426$ Modificare meniu��6�   $
 Hand��6�   ��5@      �� 5A      $7 1/FoodDelivery;component/Resources/updateMeniu.png��6!   $ Uniform=�6a   5C      5D      5E      5F      