   M S B A M L   `   `   `  ����S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  5   	   )    #Scientia_interfejs_alpha.PanelAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Scientia_interfejs_alpha     5   	   -   5          � Title$  
PanelAdmin��5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowState$ 	Maximized=�6A    � 
ResizeMode$ NoResize=�6Y    � WindowStyle$
 None=�6o   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   .+�5      o� $	��Top=�6   ��5      �� 5      .R�5      ]� $��Stretch=�6$   5      .@�5      m� $��Opcje Administracyjne��6   .@�5      m� -   5         m�Name$ 
MIedytczlo��5      $��Edytuj Członków��63   6L   m� 5      -   5        $ 
MIedytzaso��5      $��Edytuj Zasoby��63   6J   m� 5      -   5        $ MIplik��5      $��Zapisz dane do pliku��6/   6M   5      m� 5      $��Wyloguj��6   $��Right=�6,   .@�5      m� -   5        $ MIzamk��5      $��Zamknij program��6/    m� Icon 5      �� 5      $��image/close.png��6$   $��20��6=   5      �� 5       m� 5!      -   5        $ MIwroc��5!      $��Wróć do przeglądania��6E    5"      �� 5#      $��image/back.png��6$   $��20��6<   5%      5&      5'      5(      �� 5)   
   $��1��6   .@�5*      �� $��Wypożycz/Oddaj��6   .��5+      �  5,      �� 5-      $��* �6(   �� 5.      $��* �6(   �� 5/      $��* �6(   �� 50      $��* �6(   �� 51      $��* �6(   �� 52      $��* �6(   �� 53      $��* �6(    � ColumnDefinitions 55      �� 56      $	��74* �6+   �� 57      $	��30* �6+   �� 58      $
��104* �6+   �� 59      $
��104* �6+   �� 5:      $
��104* �6+   �� 5;      $
��104* �6+   �� 5<      $
��103* �6+   .+�5>      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgsprzet��5>      
   AutoGenerateColumns
 .  $��0��6M   $��0��6]   $��5��6j   $��7��6~      
IsReadOnly .    SelectionMode$ Single=�6�    �� SelectedValuePath$ 	ID_zasobu��6�    �� SelectedValue 6�   �� *	ID_zasobu+   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 150* 61      Header$ Sprzęt��6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *Nazwa+  5A      $
 150* 61   $	 Kod��6>    6K   �� *Kod+  5B      $
 150* 61   $ 	Kategoria��6>    6Q   �� *	Kategoria+  5C      $
 200* 61   $ Opis sprzętu��6>    6T   �� *Opis+  5D      $
 100* 61   $ Stan techniczny��6>    6W   �� *Stan_techniczny+4  .System.Windows.Controls.DataGridCheckBoxColumn  5E      $
 100* 66   $ Czy wypożyczalny��6C    6]   �� *Czy_wypozyczalny+  5F      $
 100* 66   $ Stan wypożyczenia��6C    6_   �� *Status_wypozyczenia+  5G      $
 100* 61   $ Data Wypożyczenia��6>    6Y   �� *Data_wypozyczenia+  5H      $
 100* 61   $ Data Zwrotu��6>    6S   �� *
Data_zwrot+  5I      $
 100* 61   $ Przez Kogo?��6>    6S   �� *Kto+5K      �� 5L      $��6��6!   $��3��61   $��10q�6>   .+�5M      	� -   5         	�Name$ RBczl��5M   &    	� 	GroupName$ RBkto��65   6G   �� 5N      $��Członek koła��6    	� 5O      -	   5        $ RBgosc��5O   &   $ RBkto��66   6H   �� 5P      $��Gość��6    5Q      �� 5R      -
   5         ��Name$ SPdane��5R   !   $��6��61   $��4��6A   $y�Hidden=�6N   .+�5S      �� -   5         ��Name$ 
txtboximie��5S   "   $	��200��66   $	��Top=�6B   $
��Left=�6Z   $��0,5,0,5q�6u   �� 5T      -   5        $ txtboxnazwisko��5T   "   $��20��6:   $	��200��6F   $	��Top=�6R   $
��Left=�6j   $��0,0,0,5q�6�   �� 5U      -   5        $ txtboxnumer��5U   "   $��20��67   $	��200��6C   $	��Top=�6O   $
��Left=�6g   5V      �� 5W      -   5         ��Name$ CBkto��5W      $��6��6.   $��4��6>   $��20��6K   $	��200��6W   $	��Top=�6c   $
��Left=�6{    �� 
IsEditable . $y�Hidden=�6�   $ id��6�    �� DisplayMemberPath$
 dane��6�   5Y      (  "System.Windows.Controls.DatePicker  5Z      -   5          Name$ DPdzis��5Z   !   $��6��61   $
��Left=�6A   $��1��6]   $	��Top=�6j   {�.  6�     5[      -   5        $ 	DPdokiedy��5[   !   $��6��64   $
��Left=�6D   $	��Top=�6`   $��2��6x   �� 5\      -   5         ��Name$ 
lbldzisiaj��5\      $��Data dzisiejsza��60   $��5��6J   $��Right=�6Z   $��1��6v   $	��Top=�6�   �� 5]      -   5        $ lblkom��5]      $#��Podaj osobę wypożyczającą��6,   $��5��6P   $��Right=�6`   $��3��6}   $	��Top=�6�   �� 5^      -   5        $ SPlbl��5^   !   $��5��60   $��4��6@   $y�Hidden=�6M   .+�5_      �� -   5        $ lblimie��5_       $(��"Podaj imię osoby wypożyczającej��61   $��Right=�6[   $	��Top=�6w   �� 5`      -   5        $ lblnazw��5`       $+��%Podaj nazwisko osoby wypożyczającej��61   $��Right=�6_   $	��Top=�6{   �� 5a      -   5        $ lblnumer��5a       $1��+Podaj numer telefonu osoby wypożyczającej��62   $��Right=�6f   $	��Top=�6�   5b      �� 5c      -   5        $ lblkto2��5c      $'��!Wybierz imię i nazwisko członka��6-   $��5��6W   $��Right=�6g   $��4��6�   $	��Top=�6�   $y�Hidden=�6�   �� 5d      -   5        $ 
lblwybierz��5d      $��Wybierz datę zwrotu��60   $��5��6N   $��Right=�6^   $��2��6z   $	��Top=�6�   �� 5e      -   5         ��Name$ btnwypozycz��5e      $��	Wypożycz��62   $��6��6E   $��6��6U   6b   �� 5f      -   5        $ btnoddaj��5f      $��Oddaj��6/   $��5��6?   $��6��6O   6\   5g      5h      �� 5i      $��Przeglądaj wypożyczenia��6   .��5j      � $��10q�6   .+�5l        -   5        $	 
DGprzeglad��5l      
 .   . $ Single=�6a    5m        5n      $	 200 61   $ Sprzęt��6=    6M   �� *Nazwa+  5o      $	 200 61   $	 Kod��6=    6J   �� *Kod+  5p      $	 200 66   $ Stan wypożyczenia��6B    6^   �� *
aktualne+  5q      $	 150 61   $ Data Wypożyczenia��6=    6X   �� *
Data_wypoz+  5r      $	 150 61   $ Data Zwrotu��6=    6R   �� *
Data_zwrot+  5s      $	 200 61   $ Przez Kogo?��6=    6R   �� *Kto+  5t      $	 200 61   $ Telefon��6=    6N   �� *	Telefon+5v      5w      5x      5y      5{      5|      