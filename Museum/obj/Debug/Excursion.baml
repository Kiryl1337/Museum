   M S B A M L   `   `   `  ����A  =Museum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MuseumMuseum  5   	       Museum.Excursion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Museum     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5      $	��950��6'     � WindowStartupLocation$  CenterScreen=�63   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��0.24* �6   .+�5   
   � ���	#FFCBC0C0$��2��6&   $��0,0,0,84q�67   .+�5      �� -   5        $��Label��5   (   $��Экскурсии��6   $
��Left=�65   $��	404,6,0,0q�6P   $	��Top=�6c   $��22(�6{   $
��Bold"�6�    J� RenderTransformOrigin$ 1.321,2.949&�6�   &   System.Windows.Controls.DataGrid  5      -   5        $��excursionGrid��5      ���	#FFCBC0C0$��432,45,0,25q�6C   $��18(�6Y      HeadersVisibility$	 All=�5         
IsReadOnly .    CanUserResizeColumns .  $��Center=�5   ?   $	��Top=�6]   $y�Hidden=�5   P   ��5   %   �� 5   P   �� 5      -   5        $��	view_data��5      $'��!Отобразить данные��6'   $
��Left=�6C   $��404,165,0,0q�6^   $	��Top=�6s   $	��136��6�   $��58��6�   6�   5!      �� 5%   
   -   5        $
��form��5%      ���	#FFCBC0C0��. $��0,41,527,84q�6S   $��Hidden=�6h   $��2��6�   $y�Hidden=�6�   .��5'      �� ���	#FF2D3E30 �� CornerRadius$ 20��6-   $	��492��6?   $	��469��6K   ._�5)      �� $��
10,10,93,0q�6   ���	#FFE0E058.+�5*      �� $0��*Информация о экскурсии��6   $��25(�6>   $��Center=�6L   �� 5-      $��Дата��6   $��16(�6,   $��
20,5,257,0q�6:   $��31��6N   (  "System.Windows.Controls.DatePicker  5/      -   5        $
��date��5/   !      SelectedDateFormat$ Short=�6.   $��18(�6I   $��	20,0,89,0q�6X   $��30��6k   �� 50      $)��#Название экскурсии��6   $��16(�69   $��
20,5,181,0q�6G   $��30��6[   �� 51      -   5         ��Name$
 name��51      	 �� TextWrapping$
	 Wrap=�6,   $��18(�6B   $��	20,0,41,0q�6P   $��50��6c   �� 52      $)��#Описание экскурсии��6   $��16(�69   $��
20,5,181,0q�6G   $��30��6[   �� 53      -   5        $ description��53      $
	 Wrap=�63   $��18(�6I   $��	20,0,41,0q�6W   $��58��6j   �� 55      $!��ФИО сотрудника��6   $��16(�66   $��
20,5,210,0q�6D   �� 56      -   5        $��chooseWorker��56   ?   $��	20,0,89,0q�6   $��26��62   
 �� DisplayMemberPath$
 Worker_Info��6k    �� SelectedValuePath$ Worker_Code��6�   ��6S   �� 6�   �� 57      $��Цена��6   $��16(�6+   $��
20,0,231,0q�69   �� 58      -	   5        $
��cost��58      $��18(�6*   $��
20,0,164,0q�68   �� 5:      -
   5        $��reset��5:      $��Сбросить��6+   $��27��6>   $��146,10,109,2q�6J   ���	#FF52D5EA6w   5=      5>      5?      � 5B   
   $��1��6   $��0,5,0,0q�6   ��5C      �� 5D       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5E      �  � Color$ 	LightGray��6#    � Offset$ 1Q�65   � 5F      $ 	#FF51B089��6#   5G       J� Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K         
BlurRadius$ 20Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5N      �� $��1��6    �� Orientation$ 
Horizontal=�6'   .+�5O      �� -   5        $��add_btn��5O      $��100,22,10,20q�6)   ���	#FFE0BC1C���	#FF8522BD$	��215��6�   {�.  .��5P      � $	��150��6   .+�5Q      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$	 Add=�62   $��Center=�6=   �� 5R      $��Center=�6$   $��Вставить��6A   $��Champagne & Limousines)�6Q   5S      5T      �� 5V      -   5        $��
update_btn��5V      $��20,22,10,20q�6+   ���	#FFA3CD93���	#FF8522BD$	��215��6o   {�.  .��5W      � $	��150��6   .+�5X        $
 Edit=�62   $��Center=�6>   �� 5Y      $��Center=�6$   $��Изменить��6A   $��Champagne & Limousines)�6Q   5Z      5[      �� 5\      -   5        $��
delete_btn��5\      $��20,22,10,20q�6,   ���	#FFE45B5B���	#FF8522BD$	��215��6p   {�.  .��5]      � $	��150��6   .+�5^        $ Delete=�62   $��Center=�6@   �� 5_      $��Center=�6$   $��Удалить��6A   $��Champagne & Limousines)�6P   5`      5a      5f      5g      5m      5n      