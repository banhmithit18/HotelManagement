   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HotelManagementHotelManagement  5      E'clr-namespace:HotelManagement.UtilitiesHotelManagement.Utilities  5      *    $HotelManagement.UC.ServiceManagement   5      1HotelManagementclr-namespace:HotelManagement  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HotelManagement.Utilities     5      ���	#FFD3DEE2��5   %   �� *ActualWidth+  �� Mode$  Default=� �� RelativeSource �� *FindAncestor+ �� AncestorType    HotelManagement.MainWindow"  ��6�   �� *ActualHeight+$  Default=� �� *FindAncestor+"   � 	Resources 5	      3   -HotelManagement.Utilities.RowToIndexConverter  5
   
      Keyvalueconverter  6=   .��5      � -   5         �Name$
 grid��5       � ColumnDefinitions 5   
   �� 5      ��6   �� *ActualWidth+$  Default=� �� *FindAncestor+"  6�    � RowDefinitions 5   
   �� 5      $
��0.2* �6   6,   �� 5      $��* �6   6)   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataService��5      $��0��6(   $��1��68   $
��Left=�6E   $	��Top=�6`      AutoGenerateColumns .  	   CanUserResizeColumns	 .  
   SelectionUnit$
 CellOrRowHeader=�6�      EnableRowVirtualization .     CanUserResizeRows .     CanUserDeleteRows .     CanUserAddRows .  ��6x   �� *ActualWidth+ �� ElementName$
 grid��$  Default=� � ContextMenu 5      �� 5      -   5         ��Name$ cmSrv��5      .@�5      m� -   5         m�Name$ Edit_MenuItem��5      $��Edit Service��67   6M   m� 5      -   5        $ Disable_MenuItem��5      $��Disable Service��69   6S   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Index��6�      CanUserResize .     
IsReadOnly .    CanUserReorder .     Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.1* 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� $ DataGridRowL� �� 	Converter   6�     5      $
 Name��6>    .   .  .  $
 0.2* 6�    6%   �� *NAME+6�     5        .  $
 Type��6U    .  .  $
 0.2* 6�    6%   �� *TYPE+6�     5!      $ Price��6?    .   .  .  $
 0.2* 6�    6%   �� *PRICE+6�     5"      $ Status��6@    .   .  .  $
 0.3* 6�    6%   �� *STATUS+6�   5$      �� 5%   
   $
��Left=�6   $	��Top=�6-   $��0��6E   $��0��6U   .+�5&      �� -   5        $��Add Service��5&       �� Left$ 58��6+   
 �� Top$ 35��6<   $	��163��6L   6X   �� 5'      -   5         ��Name$ tbSearch��5'      $
��Left=�6(   $��37��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6d   $	��323��6|   $	 614��6�   $ 30��6�   $��16(�6�   �� 5(      $��Search��6   $
��Left=�6%   $	��Top=�6@    J� RenderTransformOrigin$ 1.056,0.533&�6X   $	 538��6|   $ 30��6�   $��16(�6�   5)      5*      5+      