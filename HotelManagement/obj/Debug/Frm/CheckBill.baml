   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HotelManagement.UtilitiesHotelManagement.Utilities  5   	   #    HotelManagement.Frm.CheckBill   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:HotelManagement.Utilities     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Icon$ ..\Icon\Bill.ico��5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$
 Bill��5   	   $��526.17��6   $
��1000��6&   .��5      � -   5         �Name$
 grid��5       � ColumnDefinitions 5   
   �� 5      ��6   �� *ActualWidth+ �� ElementName$
 grid�� �� Mode$ Default=�6_    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��0.3* �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dataBill��5      $��0��6%   $��0��65   $
��Left=�6B   $	��Top=�6]   
   AutoGenerateColumns
 .     CanUserResizeColumns .     SelectionUnit$ CellOrRowHeader=�6�      EnableRowVirtualization .     CanUserResizeRows .     CanUserDeleteRows .     CanUserAddRows .  ��6u   �� *ActualWidth+$
 grid��$ Default=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Index��6�      CanUserResize .     
IsReadOnly .    CanUserReorder .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� �� 	Converter 3   -HotelManagement.Utilities.RowToIndexConverter  6�     5      $
 Name��6>    .   .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 0.15* 6t    .   6%   �� *NAME+6�     5       .  $ Quantity��6X    . $
 0.1* 6|    .   6%   �� *
QUANTITY+6�     5       .  $ Price��6V    . $
 0.1* 6w    .   6%   �� *PRICE+6�     5       .  $ Total��6V    . $
 0.1* 6w    .   6%   �� *TOTAL+6�     5       .  $ 
Order Date��6U    . $
 0.2* 6{    .   6%   �� *DATE+6�     5       .  $
 Note��6T    . $
 0.3* 6t    .   6%   �� *NOTE+   	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5      ��  �� Property �@�ToolTip �� Value 68   �� *NOTE+5          ElementStyle 5"      �� 5#      " ��6    .�5$      ��  � ��$ Center=�6B   6S   5%      5'      5)      �� 5+   
   $
��Left=�6   $	��Top=�6-   $��0��6E   $��1��6U   .+�5/      �� $��	Sub Total��6   $
��Left=�6(   $��
70,5.6,0,0q�6C   $��1��6W   $	��Top=�6d   $��16(�6|   �� 50      $��Taxes��6   $
��Left=�6$   $��70,40.6,0,0q�6?   $��1��6T   $	��Top=�6a   $��16(�6y   �� 51      $��Total��6   $
��Left=�6$   $��70,75.6,0,0q�6?   $��1��6T   $	��Top=�6a   $��16(�6y   �� 52      -   5          ��Name$  
lbSubTotal��52      $�� ��6)   $
��Left=�64   $��300,5.6,0,0q�6O   $��1��6d   $	��Top=�6q   $��16(�6�   �� 53      -   5        $  lbTaxes��53      $	��10%��6%   $
��Left=�63   $��300,40.6,0,0q�6N   $��1��6d   $	��Top=�6q   $��16(�6�   �� 54      -   5        $  lbTotal��54      $�� ��6%   $
��Left=�60   $��300,75.6,0,0q�6K   $��1��6a   $	��Top=�6n   $��16(�6�   �� 55      	! �� X1$! 10��56      	" �� Y1$" 10��6   	# �� X2$	# 350��57      	$ �� Y2$$ 10��6   
���   �$��2��59      % �� Left$% 60��6   
& �� Top$& 64��6*   �� 5:      -   5        $��	Check Out��5:      $
��Left=�6)   $��1��6D   $	��Top=�6Q   $	��166��6i   $��16(�6u   $	% 667��6�   $& 43��6�   6�   5<      5=      5>      