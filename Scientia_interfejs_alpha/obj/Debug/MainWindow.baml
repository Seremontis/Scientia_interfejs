   M S B A M L   `   `   `  ����S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  5   	   )    #Scientia_interfejs_alpha.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Scientia_interfejs_alpha     5   	   -   5          � Title$!  Ewidencja Scientia Ingenium��5   	    � WindowStartupLocation$ CenterScreen=�6-    � WindowStyle$ ThreeDBorderWindow=�6}    � WindowState$ 	Maximized=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��112 �6   �� 5      $
��111* �6   �� 5      $
��112* �6   �� 5      $
��111* �6   �� 5      $
��112* �6   �� 5      $
��111* �6   .+�5   
   �� -   5         ��Name$
 plak��5      $��image/plak.png��6   $��5��66   $��2��6F   $��1��6Z   $��5��6g   $��UniformToFill=�6�   �� 5   
   -   5         ��Name$ BtnPanel��5      $��6��6#   $��0��63   $��Panel Administracyjny��6@   6`   �� 5   
   -   5        $
 BtnO��5      $��5��6   $��0��6/   $��O programie��6<   6R   �� 5   
   -   5         ��Name$ Lblkom��5      $H��BW celu wypożyczenia sprzętu przejdź do panelu administracyjnego��6    $��5��6j   $��2��6z   $��5��6�   $��Right=�6�   $��Bottom=�6�   $��30��6�   $��Bottom=�6�   6'  �� 5   
   -   5        $ Lblopis��5      $G��AWitaj w programie ewidencyjnym koła naukowego Scientia Ingenium!��6!   $��Center=�6l   $��Center=�6�   $��0��6�   $��1��6�   $��4��6�   �� 5    
   -   5        	 ��Name$	 CBfiltr��5       $��0��6$   $��0��64   $��30��6A   $	��Top=�6M   $��Center=�6e   $��Center=�6�   $��0,81,0,0q�6�   .@�5!      �� .��6   
wszystko6%   �� 5"      .��6   Laptopy i tablety6.   �� 5#      .��6   PC stacjonarny6+   �� 5$      .��6   
Telefony6%   �� 5%      .��6   Smartwatche6(   �� 5&      .��6   inne6!   5'      �� 5(   
   -   5        $ lblfiltr��5(      $��0��6"   $��0��62   $��Filtruj wg. kategorii��6?   $��Bottom=�6_   $��Center=�6z   $��
10,0,20,30q�6�   &   System.Windows.Controls.DataGrid  5)   
   -	   5        $��dgsprzet��5)      
   AutoGenerateColumns
 .  $��0��6?   $��1��6O   $��5��6\   $��5��6p      
IsReadOnly .    SelectionMode$ Single=�6�   
�������   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 200* 6%      Header$ Sprzęt��62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Nazwa+  5,      $
 200* 6%   $ 	Kategoria��62    6E   �� *	Kategoria+  5-      $
 200* 6%   $ Opis sprzętu��62    6H   �� *Opis+  5.      $
 200* 6%   $ Stan techniczny��62    6K   �� *Stan+4  .System.Windows.Controls.DataGridCheckBoxColumn  5/      $
 200* 6)   $ Czy do wypożyczania��66    6S   �� *Czywypozyczalny+  50      $
 200* 6)   $ Stan wypożyczenia��66    6Q   �� *Czywypozyczony+5>      5?      5@      