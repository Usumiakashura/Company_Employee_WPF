   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.DialogsWpfApp1.Dialogs  5   	   '    !WpfApp1.Dialogs.EditCompanyWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Dialogs     5   	     � Title$  EditCompanyWindow��5   	   $	��140��6#   $	��400��60    � 	Resources 5
         	tBx_style �� 
TargetType �� Property �� Value  	lab_style��%�   &	        &	 N     �� 5   
   " ��6"   .�5      ��  � ��$ 5 15 5 0q�6'   5      �� 5   
   " ��6"   .�5      ��  � ��$ 5 15 5 0q�6'   5      5      .��5      � -   5         �Name$
 grid��5       � RowDefinitions 5   
   �� 5      $��40��6   6-   �� 5      $��70��6   6-    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $'��!Название компании��6   $��0��6,   #��[ 69   �� 5   
   -   5         ��Name$ textBoxNameCompany��5      #��[  6.   $��0��5       $��1��6   ��5      �� 	 �� Path$	 NameCompany�5       �� 5"   
   -   5        
 ��Name$
 ButtonOK��5"      $��OK��6#   $��5��5#      $��0��6   $
��5 15q�5$      5%      �� 5&   
   -   5        $
 ButtonCancel��5&      $��Cancel��6'   $��5��5'      $��1��6   $
��5 15q�5(      5)      5*      5+      