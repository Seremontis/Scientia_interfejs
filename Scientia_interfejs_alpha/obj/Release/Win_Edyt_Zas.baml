   M S B A M L   `   `   `  ���� S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  +    %Scientia_interfejs_alpha.Win_Edyt_Zas   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Scientia_interfejs_alpha     -     � Title$  Edytuj zasoby��$	��600��$	��900��.���  � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�&   System.Windows.Controls.DataGrid  -     Name$ DGzasob��$��2��   CanUserDeleteRows .     CanUserAddRows .     SelectionMode$ Single=�   
IsReadOnly .    AutoGenerateColumns .   �� SelectedValuePath$ 	ID_zasobu��	 �� SelectedValue	 �� *	ID_zasobu+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 150*    Header$ Nazwa��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nazwa+  $
 150* $	 Kod�� �� *Kod+  $
 150* $
 Opis�� �� *Opis+  $
 150* $ 	Kategoria�� �� *	Kategoria+  $
 150* $ Stan Techniczny�� �� *Stan_techniczny+4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 100* $ Czy wypożyczalny�� �� *Czy_wypozyczalny+�� -    ��Name$ txtnazwa��$��2��$
��Left=�$��22��$��167,378,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� -   $ txtkod��$��2��$
��Left=�$��22��$��167,406,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ txtopis��$��2��$
��Left=�$��22��$��167,434,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ txtstan��$��2��$
��Left=�$��24��$��167,488,0,0q�$
 Wrap=�$	��Top=�$	��120���� -    ��Name$ cb_czywypoz��$��Czy wypożyczalny��$��2��$
��Left=�$��167,516,0,0q�$	��Top=� d� 	IsChecked$
 TrueY��� -    ��Name$ cmb_kat��$��2��$
��Left=�$��167,462,0,0q�$	��Top=�$	��120��.@��� -	   $��LAPTAB��.��Laptopy i tablety�� -
   $��PC��.��PC stacjonarny�� -   $	��TEL��.��
Telefony�� -   $��SMWATCH��.��Smartwatche�� -   $
��INNE��.��Inne�� $��Nazwa��$��2��$
��Left=�$��117,378,0,0q�$	��Top=��� $	��Kod��$��2��$
��Left=�$��131,406,0,0q�$	��Top=��� $
��Opis��$��2��$
��Left=�$��129,434,0,0q�$	��Top=��� $��	Kategoria��$��2��$
��Left=�$��101,462,0,0q�$	��Top=��� $��Stan techniczny��$��2��$
��Left=�$��
69,488,0,0q�$	��Top=��� -    ��Name$ btndodaj��$��Dodaj��$��2��$
��Left=�$��213,538,0,0q�$	��Top=�$��74���� $��Dodaj nowy sprzęt��$
��Left=�$	��287��$��2��$��	5,319,0,0q��� -   $ 	btnedytuj��$��Edytuj��$��2��$
��Left=�$��134,538,0,0q�$	��Top=�$��74��{�.  �� -   $ btnczysc��$��	Wyczyść��$��2��$
��Left=�$��213,353,0,0q�$	��Top=�$��74��