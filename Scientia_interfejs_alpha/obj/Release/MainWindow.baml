   M S B A M L   `   `   `  ���� S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  )    #Scientia_interfejs_alpha.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Scientia_interfejs_alpha     -     � Title$!  Ewidencja Scientia Ingenium�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ ThreeDBorderWindow=� � WindowState$ 	Maximized=�.���  � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $	��112 ��� $
��111* ��� $
��112* ��� $
��111* ��� $
��112* ��� $
��111* �.+��� -    ��Name$
 plak��$��image/plak.png��$��5��$��2��$��1��$��5��$��UniformToFill=��� -    ��Name$ BtnPanel��$��6��$��0��$��Panel Administracyjny���� -   $
 BtnO��$��5��$��0��$��O programie���� -    ��Name$ Lblkom��$H��BW celu wypożyczenia sprzętu przejdź do panelu administracyjnego��$��5��$��2��$��5��$��Right=�$��Bottom=�$��30��$��Bottom=��� -   $ Lblopis��$G��AWitaj w programie ewidencyjnym koła naukowego Scientia Ingenium!��$��Center=�$��Center=�$��0��$��1��$��4���� -   	 ��Name$	 CBfiltr��$��0��$��0��$��30��$	��Top=�$��Center=�$��Center=�$��0,81,0,0q�.@��� .��
wszystko�� .��Laptopy i tablety�� .��PC stacjonarny�� .��
Telefony�� .��Smartwatche�� .��inne�� -   $ lblfiltr��$��0��$��0��$��Filtruj wg. kategorii��$��Bottom=�$��Center=�$��
10,0,20,30q�&   System.Windows.Controls.DataGrid  -	   $��dgsprzet��
   AutoGenerateColumns
 .  $��0��$��1��$��5��$��5��   
IsReadOnly .    SelectionMode$ Single=�
�������   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 200*    Header$ Sprzęt��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nazwa+  $
 200* $ 	Kategoria�� �� *	Kategoria+  $
 200* $ Opis sprzętu�� �� *Opis+  $
 200* $ Stan techniczny�� �� *Stan+4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 200* $ Czy do wypożyczania�� �� *Czywypozyczalny+  $
 200* $ Stan wypożyczenia�� �� *Czywypozyczony+