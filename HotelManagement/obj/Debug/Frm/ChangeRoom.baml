   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HotelManagement.FrmHotelManagement.Frm  5   	   $    HotelManagement.Frm.ChangeRoom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:HotelManagement.Frm     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Icon$ ..\Icon\edit-button.ico��5	   	    � Title$ Modify Room��5
   	    � 
ResizeMode$ NoResize=�6   $��417.6��63   $��618.8��6B   .��5      �� $
��Left=�6   $	��389��6(   $	��Top=�65   $	��609��6M   $��0,0,0,-1q�6Y   .+�5   
   �� $��Room:��6    �� Left$ 43��6    
 �� Top$ 45��61   $��16(�6A   �� 5   
   $��Type:��6   $ 43��6    $	 115��61   $��16(�6B   �� 5   
   $��	Category:��6   $ 43��6$   $	 185��65   $��16(�6F   �� 5   
   $��Price:��6   $ 43��6!   $	 255��62   $��16(�6C   �� 5   
   -   5         ��Name$ tbName��5      $��34��6"   $	 146��6.    �� TextWrapping$
 Wrap=�6@   $�� ��6T   $ 45��6\   $	��360��6l   $��16(�6x    �� 
IsReadOnly . {�.  6�   �� 5   
   -   5        $ tbPrice��5      $��34��6#   $	 146��6/   $
 Wrap=�6A   $�� ��6U   $	 255��6]   $	��360��6n   $��16(�6z   6�   �� 5   
   -   5        	 ��Name$	 boxType��5      $	 146��6$   $	 115��66   $	��360��6G   $��16(�6S   .@�5      �� $��Single��6   $
��Left=�6,   $��358.4��6G   �� 5      $��Double��6   $
��Left=�6,   $��358.4��6G   �� 5      $��Triple��6   $
��Left=�6,   $��358.4��6G   �� 5      $
��Quad��6   $
��Left=�6*   $��358.4��6E   �� 5      $��Queen��6   $
��Left=�6+   $��358.4��6F   �� 5      $
��King��6   $
��Left=�6*   $��358.4��6E   �� 5      $
��Twin��6   $
��Left=�6*   $��358.4��6E   5      �� 5   
   -   5        $	 boxCate��5      $	 146��6$   $	 185��66   $	��360��6G   $��16(�6S   .@�5      �� $��Standard��6   $
��Left=�6.   $��358.4��6I   �� 5      $��Deluxe��6   $
��Left=�6,   $��358.4��6G   �� 5      $��Alexander-Suite��6   $
��Left=�65   $��358.4��6P   5       �� 5!   
   -   5        $
��Save��5!      $	 215��6    $	 322��62   $	��173��6C   6O   5"      5$      