   M S B A M L   `   `   `  ����A  =Museum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MuseumMuseum  5   	       Museum.Room   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Museum     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5      $	��950��6'     � WindowStartupLocation$  CenterScreen=�63   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��0.25* �6   .+�5   
   � ���	#FFCBC0C0$��0,0,0,69q�6&   $��2��68   $��2��6L   .+�5      �� -   5        $��Label��5   #   $��Залы��6   $
��Left=�60   $��	432,1,0,0q�6K   $	��Top=�6^   $��22(�6v   $
��Bold"�6�    J� RenderTransformOrigin$ 1.321,2.949&�6�   &   System.Windows.Controls.DataGrid  5      -   5        $��roomGrid��5      ���	#FFCBC0C0$��432,45,0,25q�6>   $��18(�6T      HeadersVisibility$	 All=�5         
IsReadOnly .    CanUserResizeColumns .  $��Center=�5   >   $	��Top=�6\   $y�Hidden=�5   K   ��5   $   �� 5   K   �� 5      -   5        $��	view_data��5      $'��!Отобразить данные��6'   $
��Left=�6C   $��404,165,0,0q�6^   $	��Top=�6s   $	��136��6�   $��58��6�   6�   5       �� 5$   
   -   5        $
��form��5$      ���	#FFCBC0C0$��Hidden=�6:   $��0,41,512,84q�6_   $��2��6t   $��2��6�   $y�Hidden=�6�   .��5&      �� ���	#FF2D3E30 �� CornerRadius$ 20��6-   $	��336��6?   $	��424��6L   ._�5(      �� $��10q�6   ���	#FFE0E058.+�5)      �� $&�� Информация о зале��6   $��25(�69   $��Center=�6G   �� 5+      -   5        $��id��5+      $��20(�6(   $��
20,0,222,0q�66   $��1��6J   $y�Hidden=�6U   �� 5,      $��Этаж��6   $��16(�6,   $��
20,5,257,0q�6:   $��28��6N   �� 5-      -   5         ��Name$ floor��5-      $��18(�6-   $��
20,0,195,0q�6;   $��26��6O   �� 5/      $��Площадь(м2)��6   $��16(�62   $��
20,5,257,0q�6@   $��30��6T   �� 50      -   5        $ square��50      $��18(�6.   $��
20,0,195,0q�6<   $��26��6P   �� 52      $��Название��6   $��16(�60   $��
20,5,257,0q�6>   �� 53      -   5        $
��name��53      $��18(�6*   $��
20,0,195,0q�68   $��26��6L   �� 54      -	   5        $��reset��54      $��Сбросить��6+   $��27��6>   $��146,40,109,0q�6J   ���	#FF52D5EA6w   56      57      58      � 5;   
   $��0,10,0,0q�6   $��1��6"   $��2��6/   ��5<      �� 5=       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5>      � 
 � Color$
 	LightGray��6#    � Offset$ 1Q�65   � 5?      $
 	#FF51B089��6#   5@       J� Effect 5C      3  -System.Windows.Media.Effects.DropShadowEffect  5D         
BlurRadius$ 20Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5G      �� $��1��6    �� Orientation$ 
Horizontal=�6'   .+�5H      �� -
   5        $��add_btn��5H      $��100,22,10,20q�6)   ���	#FFE0BC1C���	#FF8522BD$	��215��6�   {�.  .��5I      � $	��150��6   .+�5J      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$	 Add=�62   $��Center=�6=   �� 5K      $��Center=�6$   $��Вставить��6A   $��Champagne & Limousines)�6Q   5L      5M      �� 5O      -   5        $��
update_btn��5O      $��20,22,10,20q�6+   ���	#FFA3CD93���	#FF8522BD$	��215��6o   {�.  .��5P      � $	��150��6   .+�5Q        $
 Edit=�62   $��Center=�6>   �� 5R      $��Center=�6$   $��Изменить��6A   $��Champagne & Limousines)�6Q   5S      5T      �� 5U      -   5        $��
delete_btn��5U      $��20,22,10,20q�6,   ���	#FFE45B5B���	#FF8522BD$	��215��6p   {�.  .��5V      � $	��150��6   .+�5W        $ Delete=�62   $��Center=�6@   �� 5X      $��Center=�6$   $��Удалить��6A   $��Champagne & Limousines)�6P   5Y      5Z      5_      5`      5f      5g      