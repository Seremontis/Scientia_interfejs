   M S B A M L   `   `   `  ����S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  5   	   +    %Scientia_interfejs_alpha.Win_Edyt_Zas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Scientia_interfejs_alpha     5   	   -   5          � Title$  Edytuj zasoby��5   	   $	��600��6   $	��900��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGzasob��5      $��2��6$      CanUserDeleteRows .     CanUserAddRows .     SelectionMode$ Single=�6i      
IsReadOnly .    AutoGenerateColumns .   �� SelectedValuePath$ 	ID_zasobu��6   	 �� SelectedValue	 6�   �� *	ID_zasobu+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 150* 6%      Header$ Nazwa��62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Nazwa+  5      $
 150* 6%   $	 Kod��62    6?   �� *Kod+  5      $
 150* 6%   $
 Opis��62    6@   �� *Opis+  5      $
 150* 6%   $ 	Kategoria��62    6E   �� *	Kategoria+  5      $
 150* 6%   $ Stan Techniczny��62    6K   �� *Stan_techniczny+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $
 100* 6*   $ Czy wypożyczalny��67    6Q   �� *Czy_wypozyczalny+5      �� 5   
   -   5         ��Name$ txtnazwa��5      $��2��6$   $
��Left=�64   $��22��6O   $��167,378,0,0q�6[    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtkod��5      $��2��6"   $
��Left=�62   $��22��6M   $��167,406,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtopis��5      $��2��6#   $
��Left=�63   $��22��6N   $��167,434,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtstan��5      $��2��6#   $
��Left=�63   $��24��6N   $��167,488,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ cb_czywypoz��5      $��Czy wypożyczalny��6(   $��2��6C   $
��Left=�6S   $��167,516,0,0q�6n   $	��Top=�6�    d� 	IsChecked$
 TrueY�6�   �� 5   
   -   5         ��Name$ cmb_kat��5      $��2��6$   $
��Left=�64   $��167,462,0,0q�6O   $	��Top=�6d   $	��120��6|   .@�5      �� -	   5        $��LAPTAB��5      .��6)   Laptopy i tablety6<   �� 5       -
   5        $��PC��5       .��6%   PC stacjonarny65   �� 5!      -   5        $	��TEL��5!      .��6&   
Telefony60   �� 5"      -   5        $��SMWATCH��5"      .��6*   Smartwatche67   �� 5#      -   5        $
��INNE��5#      .��6'   Inne6-   5$      �� 5%   
   $��Nazwa��6   $��2��6    $
��Left=�60   $��117,378,0,0q�6K   $	��Top=�6`   �� 5&   
   $	��Kod��6   $��2��6   $
��Left=�6.   $��131,406,0,0q�6I   $	��Top=�6^   �� 5'   
   $
��Opis��6   $��2��6   $
��Left=�6/   $��129,434,0,0q�6J   $	��Top=�6_   �� 5(   
   $��	Kategoria��6   $��2��6$   $
��Left=�64   $��101,462,0,0q�6O   $	��Top=�6d   �� 5)   
   $��Stan techniczny��6   $��2��6*   $
��Left=�6:   $��
69,488,0,0q�6U   $	��Top=�6i   �� 5*   
   -   5         ��Name$ btndodaj��5*      $��Dodaj��6#   $��2��63   $
��Left=�6C   $��213,538,0,0q�6^   $	��Top=�6s   $��74��6�   6�   �� 5+   
   $��Dodaj nowy sprzęt��6   $
��Left=�6.   $	��287��6I   $��2��6U   $��	5,319,0,0q�6e   �� 5,   
   -   5        $ 	btnedytuj��5,      $��Edytuj��6$   $��2��65   $
��Left=�6E   $��134,538,0,0q�6`   $	��Top=�6u   $��74��6�   {�.  6�   �� 5-   
   -   5        $ btnczysc��5-      $��	Wyczyść��6#   $��2��65   $
��Left=�6E   $��213,353,0,0q�6`   $	��Top=�6u   $��74��6�   6�   5.      5/      