   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HotelManagement.FrmHotelManagement.Frm  5   	   $    HotelManagement.Frm.ChangePass   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:HotelManagement.Frm     5   	     � WindowStartupLocation$  CenterScreen=�5       � Icon$ ..\Icon\edit-button.ico��5	   	    � Title$ Change Password��5
   	    � 
ResizeMode$ NoResize=�6!   $��290.672��67   $��489.623��6H   .��5      �� $
��Left=�6   $	��257��6(   $	��Top=�65   $	��480��6M   .+�5   
   �� $��Old Password��6    �� Left$ 59��6'   
 �� Top$ 50��68   $��16(�6H   G� 5   
   -   5         G�Name$ 	tbOldPass��5      $	 180��6)   $ 50��6;   $	��250��6K   $��16(�6W    G� PasswordChar$	 •��6e   �� 5   
   -   5         ��Name$ tbOldPassUnmask��5      $	 180��6+   $ 50��6=   $	��250��6M   $��16(�6Y   $y�Hidden=�6g   �� 5   
   -   5        	 ��Name$	 ShowOldPassword��5      $
��SHOW��6-   $	 384��6�   $ 58��6�   �� 5   
   $��New Password��6   $ 59��6'   $	 100��68   $��16(�6I   G� 5   
   -   5        $ tbPass��5      $	 180��6&   $	 100��68   $	��250��6I   $��16(�6U   $	 •��6c   �� 5   
   -   5        $ tbPassUnmask��5      $	 180��6(   $	 100��6:   $	��250��6K   $��16(�6W   $y�Hidden=�6e   �� 5   
   -   5        $	 ShowPassword��5      $
��SHOW��6*   $	 384��6�   $	 108��6�   �� 5   
   -   5        $
��Save��5      $	 170��6    $	 185��62   $	��158��6C   $��32��6O   6[   5      5      