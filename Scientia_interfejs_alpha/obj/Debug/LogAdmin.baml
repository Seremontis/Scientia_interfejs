   M S B A M L   `   `   `  ����S  OScientia_interfejs_alpha, Version=1.0.5.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Scientia_interfejs_alphaScientia_interfejs_alpha  5   	   '    !Scientia_interfejs_alpha.LogAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Scientia_interfejs_alpha     5   	     � Title$  LogAdmin��5   	   $	��300��6   $	��600��6'    � 
ResizeMode$ CanMinimize=�63    � SizeToContent$ WidthAndHeight=�6L    � WindowStartupLocation$ CenterScreen=�6k    � WindowStyle$ 
ToolWindow=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��120 �6   �� 5      $��30 �6   �� 5      $��15 �6   �� 5      $��30 �6   �� 5      $��15 �6   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	txtboxlog��5      $��3��6%   $��1��65   $��20(�6B   6P   G� 5   
   -   5         G�Name$ 	txtboxpsw��5      $��3��6)   $��3��69   $��20(�6F   6T   �� 5   
   $��1��6   $��1��6    $��Login:��6-   $��Center=�6>   �� 5   
   $��1��6   $��3��6    $��Hasło:��6-   $��Center=�6>   �� 5   
   $��4��6   $��0��6$   $(��"Panel Administracyjny Wypożyczeń��61   $��Right=�6\   $��Center=�6   �� 5    
   -   5        	 ��Name$	 
btnzaloguj��5       $��3��6%   $��5��65   $��ZALOGUJ��6B   6T   �� 5!   
   -   5        
 ��Name$
 image��5!      $��image/knsi.png��6   $��0��67   $��Center=�6D   $��80��6a   $��20,10,63,10q�6m   $	��129��6�   $��2��6�    J� Opacity$	 0.2Q�6�   $
��Fill=�6�   �� 5"   
   -   5        $	 
btnkontakt��5"      $��1��6%   $��7��65   $��Kontakt��6B   $��20��6T   $��Bottom=�6`   6{   �� 5#   
   -   5        $	 btnwroc��5#      $��0��6"   $��7��62   $��Wróć do przeglądania��6?   $��20��6^   $	��Top=�6j   6�   5%      5&      