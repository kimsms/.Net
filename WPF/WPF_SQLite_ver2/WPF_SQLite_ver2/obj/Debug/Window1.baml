   M S B A M L   `   `   `  ����J  FWPF_SQLite_ver2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_SQLite_ver2WPF_SQLite_ver2  5   	       WPF_SQLite_ver2.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_SQLite_ver2     5   	   -   5          �Name$  	NewWindow��5   	    � Title$ 검색��5   	   $	��340��6   $	��400��6!   $	��400��6-   $	��340��6<   $	��400��6L   $	��340��6[    � WindowStyle$ 
ToolWindow=�6k    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � -   5        $��10,10,-6.8,-1q�5	   "    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ combox1��5      $
��Left=�6$   $	��Top=�6?   $	��120��6W   $��	25,47,0,0q�6c    �� SelectedIndex$ 0��6v   �� 5   
   -   5         ��Name$ sqlbox��5      $
��Left=�6"   $��23��6=    �� TextWrapping$
 Wrap=�6I   $	��Top=�6]   $	��120��6u   $��
167,46,0,0q�6�   6�   �� 5   
   -   5        	 ��Name$	 	selectbtn��5      $��검색��6$   $
��Left=�61   $	��Top=�6L   $��75��6d   $��260,157,0,0q�6o   6�   �� 5   
   $��	테이블��6   $
��Left=�6   $	��Top=�69   $��	59,16,0,0q�6Q   �� 5   
   $��이름��6   $
��Left=�6   $	��Top=�68   $��
211,16,0,0q�6P   �� 5   
   -   5        $	 testbtn��5      $��Button��6"   $
��Left=�63   $	��Top=�6N   $��75��6f   $��260,113,0,0q�6q   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 ViewGrid��5      $
��Left=�6%   $	��175��6@   $	��Top=�6M   $	��201��6e   $��	25,90,0,0q�6q      CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	테이블��6k      Width5  /System.Windows.Controls.DataGridLengthConverter$ 66 6x   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ 	TableGrid�   ClipboardContentBinding 6H   Z� 6x     5      $ 이름��6j   $ 66 6v    6%   �� $ NameGrid� 6G   Z� 6v     5      $ 나이��6i   $ 66 6u    6%   �� $ AgeGrid� 6F   Z� 6u   5      5      5      