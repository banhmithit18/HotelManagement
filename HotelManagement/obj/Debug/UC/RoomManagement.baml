   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HotelManagement.UtilitiesHotelManagement.Utilities  5      1clr-namespace:HotelManagementHotelManagement  5      '    !HotelManagement.UC.RoomManagement   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HotelManagement.Utilities     5      9HotelManagementclr-namespace:HotelManagement     5      ���	#FFD3DEE2��5
   %   �� *ActualWidth+  �� Mode$  Default=� �� RelativeSource �� *FindAncestor+ �� AncestorType    HotelManagement.MainWindow"  ��6�   �� *ActualHeight+$  Default=� �� *FindAncestor+"   � 	Resources 5      3   -HotelManagement.Utilities.RowToIndexConverter  5   
      Keyvalueconverter  6=   .��5      � -   5         �Name$
 grid��5       � ColumnDefinitions 5   
   �� 5      ��6   �� *ActualWidth+$  Default=� �� *FindAncestor+"  6�    � RowDefinitions 5   
   �� 5      $
��0.2* �6   6,   �� 5      $��* �6   6)   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataRoom��5      $��0��6%   $��1��65   $
��Left=�6B   $	��Top=�6]      AutoGenerateColumns .  	   CanUserResizeColumns	 .  
   SelectionUnit$
 CellOrRowHeader=�6�      EnableRowVirtualization .     CanUserResizeRows .     CanUserDeleteRows .     CanUserAddRows .  ��6u   �� *ActualWidth+ �� ElementName$
 grid��$  Default=� � ContextMenu 5      �� 5      -   5         ��Name$ cmRoom��5      .@�5      m� -   5         m�Name$ Booking_MenuItem��5      $��Booking��69   6J   m� 5      -   5        $ Order_MenuItem��5      $��Order��67   6F   m� 5      -   5        $ Checkbill_MenuItem��5      $��
Check Bill��6<   6P   m� 5      -   5        $ Checkin_MenuItem��5      $��Check In��6:   6M   m� 5      -   5        $ EditNote_MenuItem��5      $��	Edit Note��6;   6N   m� 5      -	   5        $ CusInfo��5      $��Customer Information��60   m� 5       -
   5        $ DisRoom��5       $��Disable Room��60   6F   m� 5!      -   5        $ Edit_MenuItem��5!      $
��Edit��67   6F   5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Index��6�      CanUserResize .     
IsReadOnly .    CanUserReorder .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� $ DataGridRowL� �� 	Converter   6�     5(      $
 Name��6>    .   .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.1* 6t    .   6%   �� *NAME+6�     5)       .  $ Status��6V    . $
 0.1* 6x    .   6%   �� *STATUS+6�     5*       .  $
 Type��6U    . $
 0.1* 6u    .   6%   �� *TYPE+6�     5+      $ Category��6B    .   . $ 0.15* 6|    .   6%   �� *
CATEGORY+6�     5,      $ Price��6?    .   . $
 0.1* 6v    .   6%   �� *PRICE+6�     5-       .  $
 Note��6T    . $ 0.45* 6t    .   6%   �� *NOTE+   	CellStyle 5.      �� 5/       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�50      ��  �� Property �@�ToolTip �� Value 68   �� *NOTE+51         ElementStyle 53      �� 54      " ��6    .�55      ��  � ��$ Center=�6B   6S   56      58      5:      �� 5;   
   $
��Left=�6   $	��Top=�6-   $��0��6E   $��0��6U   .+�5<      �� -   5          ��Name$  btnAdd��5<      $��Add Room��6%   ! �� Left$! 58��68   
" �� Top$" 35��6I   $	��163��6Y   6e   �� 5=      -   5        # ��Name$# tbSearch��5=      $
��Left=�6(   $��37��6C   $ �� TextWrapping$
$ Wrap=�6O   $	��Top=�6d   $	��323��6|   $	! 614��6�   $" 30��6�   $��16(�6�   �� 5>      $��Search��6   $
��Left=�6%   $	��Top=�6@   % J� RenderTransformOrigin$% 1.056,0.533&�6X   $	! 538��6|   $" 30��6�   $��16(�6�   5@      5B      5D      