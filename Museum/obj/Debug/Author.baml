   M S B A M L   `   `   `  ����A  =Museum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MuseumMuseum  5   	       Museum.Author   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Museum     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5      $	��950��6'     � WindowStartupLocation$  CenterScreen=�63   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��0.25* �6   .+�5   
   � ���	#FFCBC0C0$��0,0,0,69q�6&   $��2��68   $��2��6L   .+�5      �� -   5        $��Label��5   $   $��
Автор��6   $
��Left=�61   $��	432,1,0,0q�6L   $	��Top=�6_   $��22(�6w   $
��Bold"�6�    J� RenderTransformOrigin$ 1.321,2.949&�6�   &   System.Windows.Controls.DataGrid  5      -   5        $��
authorGrid��5      ���	#FFCBC0C0$��432,45,0,25q�6@   $��18(�6V      HeadersVisibility$	 All=�5         
IsReadOnly .    CanUserResizeColumns .  $��Center=�5   ?   $	��Top=�6]   $y�Hidden=�5   M   ��5   %   �� 5   M   �� 5      -   5        $��	view_data��5      $'��!Отобразить данные��6'   $
��Left=�6C   $��404,165,0,0q�6^   $	��Top=�6s   $	��136��6�   $��58��6�   6�   5      �� 5#   
   -   5        $
��form��5#      ���	#FFCBC0C0$��Hidden=�6:   $��0,41,512,84q�6_   $��2��6t   $��2��6�   $y�Hidden=�6�   .��5%      �� ���	#FF2D3E30 �� CornerRadius$ 20��6-   $	��336��6?   $	��424��6L   ._�5'      �� $��10q�6   ���	#FFE0E058.+�5(      �� $*��$Информация о авторе��6   $��25(�6;   $��Center=�6I   �� 5*      -   5        $��newId��5*      $��20(�6+   $��
20,0,222,0q�69   $��1��6M   $y�Hidden=�6X   �� 5+      $��ФИО��6   $��16(�6+   $��
20,5,257,0q�69   $��28��6M   �� 5,      -   5         ��Name$ newFIO��5,      $��18(�6.   $��	20,0,97,0q�6<   $��26��6O   �� 5.      $��Страна��6   $��16(�6-   $��
20,5,257,0q�6;   $��30��6O   �� 5/      -   5        $ 
newCountry��5/      $��18(�62   $��
20,0,195,0q�6@   $��26��6T   �� 51      $ ��Специальность��6   $��16(�65   $��
20,5,257,0q�6C   �� 52      -   5        $��newSpecialty��52      $��18(�62   $��
20,0,195,0q�6@   $��26��6T   �� 53      -	   5        $��reset��53      $��Сбросить��6+   $��27��6>   $��146,40,109,0q�6J   ���	#FF52D5EA6w   55      56      57      � 5:   
   $��0,10,0,0q�6   $��1��6"   $��2��6/   ��5;      �� 5<       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5=      � 
 � Color$
 	LightGray��6#    � Offset$ 1Q�65   � 5>      $
 	#FF51B089��6#   5?       J� Effect 5B      3  -System.Windows.Media.Effects.DropShadowEffect  5C         
BlurRadius$ 20Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5F      �� $��1��6    �� Orientation$ 
Horizontal=�6'   .+�5G      �� -
   5        $��add_btn��5G      $��100,22,10,20q�6)   ���	#FFE0BC1C���	#FF8522BD$	��215��6�   {�.  .��5H      � $	��150��6   .+�5I      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$	 Add=�62   $��Center=�6=   �� 5J      $��Center=�6$   $��Вставить��6A   $��Champagne & Limousines)�6Q   5K      5L      �� 5N      -   5        $��
update_btn��5N      $��20,22,10,20q�6+   ���	#FFA3CD93���	#FF8522BD$	��215��6o   {�.  .��5O      � $	��150��6   .+�5P        $
 Edit=�62   $��Center=�6>   �� 5Q      $��Center=�6$   $��Изменить��6A   $��Champagne & Limousines)�6Q   5R      5S      �� 5T      -   5        $��
delete_btn��5T      $��20,22,10,20q�6,   ���	#FFE45B5B���	#FF8522BD$	��215��6p   {�.  .��5U      � $	��150��6   .+�5V        $ Delete=�62   $��Center=�6@   �� 5W      $��Center=�6$   $��Удалить��6A   $��Champagne & Limousines)�6P   5X      5Y      5^      5_      5e      5f      