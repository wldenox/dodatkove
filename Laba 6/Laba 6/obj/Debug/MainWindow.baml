   M S B A M L   `   `   `  ����
  Laba 6    BandApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Band Management��5   	   $	��450��6!   $	��800��6.   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� -   5         ��Name$ 
LoadButton��5      $
��Load��6)   $��5q�6Q   �� 5      -   5        $ 
SaveButton��5      $
��Save��6)   $��5q�6Q   �� 5      -   5        $ 	AddButton��5      $��
Add Member��6(   $��5q�6U   �� 5      -   5        $ DeleteButton��5      $��Delete Member��6+   $��5q�6^   �� 5      -   5        $ 
SortButton��5      $��Sort by Role��6)   $��5q�6Y   �� 5      -   5         ��Name$ FilterTextBox��5      $	��200��6-   $��5q�69   �� 5      -   5        $ FilterButton��5      $��Filter by Role��6+   $��5q�6_   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MainDataGrid��5      $��1��6)      AutoGenerateColumns . $��10q�6Q   ��6]   �� *	Members+5      5      