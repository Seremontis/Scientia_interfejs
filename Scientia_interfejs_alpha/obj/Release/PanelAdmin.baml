   M S B A M L   `   `   `  ���� S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  )    #Scientia_interfejs_alpha.PanelAdmin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Scientia_interfejs_alpha     -     � Title$  
PanelAdmin�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.���  � RowDefinitions �� $��20 ��� $��* �.+�]� $��0��.+�o� $	��Top=����� .R�]� $��Stretch=�.@�m� $��Opcje Administracyjne��.@�m� -    m�Name$ 
MIedytczlo��$��Edytuj Członków��m� -   $ 
MIedytzaso��$��Edytuj Zasoby��m� -   $ MIplik��$��Zapisz dane do pliku��m� $��Wyloguj��$��Right=�.@�m� -   $ MIzamk��$��Zamknij program�� m� Icon �� $��image/close.png��$��20���� m� -   $ MIwroc��$��Wróć do przeglądania�� �� $��image/back.png��$��20���� $��1��.@��� $��Wypożycz/Oddaj��.���  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $	��74* ��� $	��30* ��� $
��104* ��� $
��104* ��� $
��104* ��� $
��104* ��� $
��103* �.+�&   System.Windows.Controls.DataGrid  -   	  Name$	 dgsprzet��
   AutoGenerateColumns
 .  $��0��$��0��$��5��$��7��   
IsReadOnly .    SelectionMode$ Single=� �� SelectedValuePath$ 	ID_zasobu�� �� SelectedValue �� *	ID_zasobu+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 150*    Header$ Sprzęt��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nazwa+  $
 150* $	 Kod�� �� *Kod+  $
 150* $ 	Kategoria�� �� *	Kategoria+  $
 200* $ Opis sprzętu�� �� *Opis+  $
 100* $ Stan techniczny�� �� *Stan_techniczny+4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 100* $ Czy wypożyczalny�� �� *Czy_wypozyczalny+  $
 100* $ Stan wypożyczenia�� �� *Status_wypozyczenia+  $
 100* $ Data Wypożyczenia�� �� *Data_wypozyczenia+  $
 100* $ Data Zwrotu�� �� *
Data_zwrot+  $
 100* $ Przez Kogo?�� �� *Kto+�� $��6��$��3��$��10q�.+�	� -    	�Name$ RBczl�� 	� 	GroupName$ RBkto���� $��Członek koła��	� -	   $ RBgosc��$ RBkto���� $��Gość���� -
    ��Name$ SPdane��$��6��$��4��$y�Hidden=�.+��� -    ��Name$ 
txtboximie��$	��200��$	��Top=�$
��Left=�$��0,5,0,5q��� -   $ txtboxnazwisko��$��20��$	��200��$	��Top=�$
��Left=�$��0,0,0,5q��� -   $ txtboxnumer��$��20��$	��200��$	��Top=�$
��Left=��� -    ��Name$ CBkto��$��6��$��4��$��20��$	��200��$	��Top=�$
��Left=� �� 
IsEditable . $y�Hidden=�$ id�� �� DisplayMemberPath$
 dane��(  "System.Windows.Controls.DatePicker  -     Name$ DPdzis��$��6��$
��Left=�$��1��$	��Top=�{�.    -   $ 	DPdokiedy��$��6��$
��Left=�$	��Top=�$��2���� -    ��Name$ 
lbldzisiaj��$��Data dzisiejsza��$��5��$��Right=�$��1��$	��Top=��� -   $ lblkom��$#��Podaj osobę wypożyczającą��$��5��$��Right=�$��3��$	��Top=��� -   $ SPlbl��$��5��$��4��$y�Hidden=�.+��� -   $ lblimie��$(��"Podaj imię osoby wypożyczającej��$��Right=�$	��Top=��� -   $ lblnazw��$+��%Podaj nazwisko osoby wypożyczającej��$��Right=�$	��Top=��� -   $ lblnumer��$1��+Podaj numer telefonu osoby wypożyczającej��$��Right=�$	��Top=��� -   $ lblkto2��$'��!Wybierz imię i nazwisko członka��$��5��$��Right=�$��4��$	��Top=�$y�Hidden=��� -   $ 
lblwybierz��$��Wybierz datę zwrotu��$��5��$��Right=�$��2��$	��Top=��� -    ��Name$ btnwypozycz��$��	Wypożycz��$��6��$��6���� -   $ btnoddaj��$��Oddaj��$��5��$��6���� $��Przeglądaj wypożyczenia��.��� $��10q�.+�  -   $	 
DGprzeglad��
 .   . $ Single=�   $	 200 $ Sprzęt�� �� *Nazwa+  $	 200 $	 Kod�� �� *Kod+  $	 200 $ Stan wypożyczenia�� �� *
aktualne+  $	 150 $ Data Wypożyczenia�� �� *
Data_wypoz+  $	 150 $ Data Zwrotu�� �� *
Data_zwrot+  $	 200 $ Przez Kogo?�� �� *Kto+  $	 200 $ Telefon�� �� *	Telefon+