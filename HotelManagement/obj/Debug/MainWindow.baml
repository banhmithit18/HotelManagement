   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HotelManagementHotelManagement  5   	   7 clr-namespace:HotelManagement.UCHotelManagement.UC  5   	        HotelManagement.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HotelManagement     5   	   /UC clr-namespace:HotelManagement.UC     5   	   -   5          �Name$  MainForm��5	       � Title$ 
MainWindow��6	   $	��450��6.   $	��800��6;   .��5
      ]� .+�5   
   o� -   5         o�Name$
 menu��5      $	��Top=�6   $
��Left=�62   $��40��6M   $��0q�6Y   $	��Top=�6d   ��6|   �� *Width+ �� ElementName$ MainForm�� �� Mode$ OneWayToSource=�.@�5      m� $��16(�6   $��Account��6&   $��40��67   .@�5      m� -   5         m�Name$ ChangeItemMenu��5      $��Change password��63   6L   m� 5      -   5        $��Log out��5      6,   5      m� 5      -   5        $ menuMngItem��5      $��16(�6,   $��
Management��6:   $��40��6N   .@�5      m� -   5        $
��Room��5      ��6)   �� *ActualWidth+$ menuMngItem��$ Default=�6n   m� 5      -   5        $ 
menuMngSrv��5      $��Service��6/   6@   m� 5      -   5        $ 	menuMngBk��5      $��Booking��6.   6?   m� 5      -	   5        $ 
menuMngCus��5      $��Customer��60   6B   m� 5      -
   5        $ 
menuMngEmp��5      $��Employee��6/   6A   5      m� 5      $��16(�6   $
��Help��6&   $��40��64   5      � 5   
   -   5         �Name$ grMain��5      ��6   �� *Height+$ MainForm��$ OneWayToSource=���6d   �� *Width+$ MainForm��$ OneWayToSource=���5      �� 5       �� Color$ 	#FFD3DEE2��6"    �� Opacity$	 0.6Q�64   5       5#      5%      