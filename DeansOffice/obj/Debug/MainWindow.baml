   M S B A M L   `   `   `  ����F  BDeansOffice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DeansOfficeDeansOffice  5   	       DeansOffice.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DeansOffice     5   	     � Title$  Ćwiczenie5��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��StudentsGrid��5
   r   $
��Left=�6   $	��253��6.   $��	37,84,0,0q�6;   $	��Top=�6N   $	��718��6f      CanUserAddRows .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwisko��6%      MinWidth$	 130Q�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
LastName+6T     5      $
 Imie��6%   $	 130Q�6Q    63   �� *	FirstName+6Q     5      $ Numer indeksu��6%   $	 130Q�6\    6<   �� *IndexNumber+6\     5      $ Adres��6%   $	 130Q�6P    64   �� *	Address+6P     5      $ Studia��6%   $	 190Q�6S    65   �� *	IdStudies+6S   ��5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      5      �� 5   
   -   5        $��ButtonDelete��5   �   $��Usuń��6   $
��Left=�6    $��641,362,0,0q�6;   $	��Top=�6P   $	��114��6h   $��32��6t   6�   �� 5   
   -   5        $��	ButtonAdd��5   �   $��Dodaj��6   $
��Left=�6!   $��501,362,0,0q�6<   $	��Top=�6Q   $	��117��6i   $��32��6u   6�   �� 5   
   $��Lista studentów��6   $
��Left=�6*   $��	37,40,0,0q�6E   $	��Top=�6X   $	��205��6p   $��39��6|   $��24(�6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��1��6T   $��0,34,0,0q�6_   $	��Top=�6q   $	��792��6�   �� 5   
   -   5        $��StudentsCount��5   �   $��Wybrałeś 0 studentów��6   $
��Left=�6/   $��
37,344,0,0q�6J   $	��Top=�6^   $	��156��6v   6�   �� 5   
   $
��Plik��6   $
��Left=�6   $��10,3,0,0q�6:   $	��Top=�6L   5!      5"      