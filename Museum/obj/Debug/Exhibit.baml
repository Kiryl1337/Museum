   M S B A M L   `   `   `  ����A  =Museum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MuseumMuseum  5   	       Museum.Exhibit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Museum     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5      $	��950��6'     � WindowStartupLocation$  CenterScreen=�63   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��0.25* �6   .+�5   
   � ���	#FFCBC0C0$��0,0,0,69q�6&   $��2��68   $��2��6L   .+�5      �� -   5        $��Label��5   (   $��Экспонаты��6   $
��Left=�65   $��	404,6,0,0q�6P   $	��Top=�6c   $��22(�6{   $
��Bold"�6�    J� RenderTransformOrigin$ 1.321,2.949&�6�   &   System.Windows.Controls.DataGrid  5      -   5        $��exhibitGrid��5      ���	#FFCBC0C0$��432,45,0,25q�6A   $��18(�6W      HeadersVisibility$	 All=�5         
IsReadOnly .    CanUserResizeColumns .  $��Center=�5   ?   $	��Top=�6]   $y�Hidden=�5   N   ��5   %   �� 5   N   �� 5      -   5        $��	view_data��5      $'��!Отобразить данные��6'   $
��Left=�6C   $��404,165,0,0q�6^   $	��Top=�6s   $	��136��6�   $��58��6�   6�   5       �� 5$   
   -   5        $
��form��5$      ���	#FFCBC0C0��. $��
0,41,527,0q�6S   $��2��6g   $��2��6x   $��Hidden=�6�   $y�Hidden=�6�   .��5&      �� ���	#FF2D3E30 �� CornerRadius$ 20��6-   $	��416��6?   $	��439��6K   ._�5(      �� $��10,10,19,101q�6   ���	#FFE0E058.+�5)      �� $2��,Информация о экспонатах��6   $��25(�6?   $��Center=�6M   �� 5,      $��Название��6   $��16(�60   $��
20,5,257,0q�6>   $��28��6R   �� 5-      -   5         ��Name$
 name��5-      $��18(�6,   $��
20,0,152,0q�6:   $��26��6N   �� 5/      $��Вид экспоната��6   $��16(�64   $��
20,5,195,0q�6B   $��30��6V   �� 50      -   5        $��chooseFormOfExhibit��50   @   $��
20,0,152,0q�6   $��26��63    �� DisplayMemberPath$ FormOfExhibit_Info��6s   	 �� SelectedValuePath$	 FormOfExhibit_Code��6�   ��6[   �� 6�   �� 52      $��Название зала��6   $��16(�64   $��
20,5,195,0q�6B   $��30��6V   �� 53      -   5        $��chooseRoomName��53   @   $��
20,0,152,0q�6   $��26��63   $ 	Room_Info��6n   $	 	Room_Code��6�   ��6V   �� 6�   �� 55      $��ФИО автора��6   $��16(�61   $��
20,5,195,0q�6?   $��30��6S   �� 56      -   5        $��chooseAuthorFIO��56   @   $��
20,0,109,0q�6   $��26��63   $ Author_Info��6o   $	 Author_Code��6�   ��6W   �� 6�   �� 57      -	   5        $��reset��57      $��Сбросить��6+   $��27��6>   $��146,10,109,2q�6J   ���	#FF52D5EA6w   5:      5;      5<      � 5?   
   $��0,10,0,0q�6   $��1��6"   $��2��6/   ��5@      �� 5A      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5B      �  � Color$ 	LightGray��6#    � Offset$ 1Q�65   � 5C      $ 	#FF51B089��6#   5D       J� Effect 5G      3  -System.Windows.Media.Effects.DropShadowEffect  5H         
BlurRadius$ 20Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5K      �� $��1��6    �� Orientation$ 
Horizontal=�6'   .+�5L      �� -
   5        $��add_btn��5L      $��100,22,10,20q�6)   ���	#FFE0BC1C���	#FF8522BD$	��215��6�   {�.  .��5M      � $	��150��6   .+�5N      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$	 Add=�62   $��Center=�6=   �� 5O      $��Center=�6$   $��Вставить��6A   $��Champagne & Limousines)�6Q   5P      5Q      �� 5S      -   5        $��
update_btn��5S      $��20,22,10,20q�6+   ���	#FFA3CD93���	#FF8522BD$	��215��6o   {�.  .��5T      � $	��150��6   .+�5U        $
 Edit=�62   $��Center=�6>   �� 5V      $��Center=�6$   $��Изменить��6A   $��Champagne & Limousines)�6Q   5W      5X      �� 5Y      -   5        $��
delete_btn��5Y      $��20,22,10,20q�6,   ���	#FFE45B5B���	#FF8522BD$	��215��6p   {�.  .��5Z      � $	��150��6   .+�5[        $ Delete=�62   $��Center=�6@   �� 5\      $��Center=�6$   $��Удалить��6A   $��Champagne & Limousines)�6P   5]      5^      5c      5d      5j      5k      