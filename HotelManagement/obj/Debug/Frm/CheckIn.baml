   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HotelManagement.FrmHotelManagement.Frm  5   	   !    HotelManagement.Frm.CheckIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:HotelManagement.Frm     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Icon$ ..\Icon\check-in.ico��5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Check In��5   	   $��469.055��6   $��707.987��6+   .��5      �� $
��Left=�6   $	��438��6(   $	��Top=�65   $	��698��6M   .+�5   
   �� $��Customer ID Card: ��6    �� Left$ 59��6-   
 �� Top$ 50��6>   $��16(�6N   �� 5   
   -   5         ��Name$ tbIDCard��5      $��27��6$   $	 256��60    �� TextWrapping$
 Wrap=�6B   $�� ��6V   $ 50��6^   $	��285��6n   $��16(�6z   �� 5   
   -   5        $��Check��5      $	 576��6!   $ 47��63   $��90��6C   6N   �� 5   
   $��Customer Name��6   $ 59��6(   $	 100��69   $��16(�6J   �� 5   
   -   5        $ 	tbCusName��5      $��27��6%   $	 256��61   $
 Wrap=�6C   $�� ��6W   $	 100��6_   $	��285��6p   $��16(�6|   �� 5   
   $��Customer Age��6   $ 59��6'   $	 150��68   $��16(�6I   �� 5   
   -   5        $ tbCusAge��5      $��27��6$   $	 256��60   $
 Wrap=�6B   $�� ��6V   $	 150��6^   $	��285��6o   $��16(�6{   6�   �� 5   
   $��Customer Phone Number��6   $ 59��60   $	 200��6A   $��16(�6R   �� 5   
   -   5        $ 
tbCusPhone��5      $��27��6&   $	 256��62   $
 Wrap=�6D   $�� ��6X   $	 200��6`   $	��285��6q   $��16(�6}   6�   �� 5   
   $��Customer Address��6   $ 59��6+   $	 250��6<   $��16(�6M   �� 5   
   -   5        $ tbCusAddress��5      $��27��6(   $	 256��64   $
 Wrap=�6F   $�� ��6Z   $	 250��6b   $	��285��6s   $��16(�6   �� 5   
   $��	Check Out��6   $ 59��6$   $	 300��65   $��16(�6F   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
dpCheckOut��5      $	 256��6)   $	 300��6;   $��29��6L   $	��285��6X   $��16(�6d   �� 5   
   -   5        $��Check In��5      $	 256��6$   $	 367��66   $	��189��6G   $��34��6S   6_   5      5      