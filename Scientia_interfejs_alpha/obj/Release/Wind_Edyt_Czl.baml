   M S B A M L   `   `   `  ���� S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  ,    &Scientia_interfejs_alpha.Wind_Edyt_Czl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:Scientia_interfejs_alpha     -     � Title$  Edytuj Członków��$	��600��$
��1200��.���  � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�&   System.Windows.Controls.DataGrid  -     Name$ DGczlon��$��2��   CanUserDeleteRows .     CanUserAddRows .     SelectionMode$ Single=�   
IsReadOnly .    AutoGenerateColumns .   �� SelectedValuePath$ ID_osoby��	 �� SelectedValue	 �� *
ID_osoby+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 150*    Header$ Nazwisko��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Nazwisko+  $
 150* $ Imię�� �� *Imie+  $
 150* $ 	Nr albumu�� �� *	Nr_albumu+  $
 150* $ Ranga�� �� *Ranga+  $
 150* $ Login�� �� *Logg+  $
 150* $ Hasło�� �� *Haslo+  $
 150* $ Telefon�� �� *	Telefon+  $
 150* $ E-Mail�� �� *E_mail+  $
 150* $
 Opis�� �� *Opis+4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 100* $ Czy aktywny�� �� *Czy_aktywny+�� -    ��Name$ txtimie��$��2��$
��Left=�$��22��$��257,256,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� -   $ txtnazwi��$��2��$
��Left=�$��22��$��257,284,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ 	txtnr_alb��$��2��$
��Left=�$��22��$��257,312,0,0q�$
 Wrap=�$	��Top=�$	��120���� -   $ txtlog��$��2��$
��Left=�$��24��$��257,366,0,0q�$
 Wrap=�$	��Top=�$	��120���� -    ��Name$ 
cb_czyakty��$��Czy aktywny��$��2��$
��Left=�$��301,508,0,0q�$	��Top=� d� 	IsChecked$
 TrueY��� -    ��Name$ cmb_rang��$��2��$
��Left=�$��257,340,0,0q�$	��Top=�$	��120��.@��� -	   $	��ADM��.��Admin�� -
   $	��CZL��.��
Członek�� -   $
��GOSC��.��Gość�� $��Imię��$��2��$
��Left=�$��219,256,0,0q�$	��Top=��� $��Nazwisko��$��2��$
��Left=�$��197,284,0,0q�$	��Top=��� $��	Nr albumu��$��2��$
��Left=�$��191,312,0,0q�$	��Top=��� $��Ranga��$��2��$
��Left=�$��211,340,0,0q�$	��Top=��� $��Login��$��2��$
��Left=�$��215,366,0,0q�$	��Top=��� -    ��Name$ btndodaj��$��Dodaj��$��2��$
��Left=�$��307,536,0,0q�$	��Top=�$��74���� $��Dodaj nowego członka��$
��Left=�$	��271��$��2��$��116,214,0,5q��� -   $ 	btnedytuj��$��Edytuj��$��2��$
��Left=�$��227,536,0,0q�$	��Top=�$��74��{�.  �� -   $ btnczysc��$��	Wyczyść��$��2��$
��Left=�$��303,232,0,0q�$	��Top=�$��74���� -   $ txthaslo��$��2��$
��Left=�$��24��$��257,394,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��Hasło��$��2��$
��Left=�$��215,394,0,0q�$	��Top=��� -   $ txttele��$��2��$
��Left=�$��24��$��257,422,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��Telefon��$��2��$
��Left=�$��207,422,0,0q�$	��Top=��� -   $ txtmail��$��2��$
��Left=�$��24��$��257,450,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��Email��$��2��$
��Left=�$��217,452,0,0q�$	��Top=��� -   $ txtopis��$��2��$
��Left=�$��24��$��257,478,0,0q�$
 Wrap=�$	��Top=�$	��120���� $
��Opis��$��2��$
��Left=�$��221,480,0,0q�$	��Top=�