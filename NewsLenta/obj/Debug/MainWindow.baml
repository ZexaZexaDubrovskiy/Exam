   M S B A M L   `   `   `  ����D  @NewsLenta, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NewsLenta	NewsLenta  5   	       NewsLenta.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NewsLenta     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   $	��400��66   $	��600��6F    � WindowStartupLocation$ CenterScreen=�6U   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $	��160 �6   $	��240��6+   $	��160��6:   �� 5      $
��auto �6   �� 5      $��* �6   $	��300��6)    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��30 �6   $��30��6(   $��30��67   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0��69   .+�5      �� $��Комментатор��6   $��15(�6*   $��	ExtraBold"�68   $��Center=�6O   �� 5      -   5         ��Name$ newsPageButton��5      $��Новости��6-   $��
10,10,10,0q�6?   6S   �� 5      -   5        $ commentsPageButton��5      $��Комментарии��61   $��
10,10,10,0q�6G   6[   �� 5      -   5        $ kategoriesPageButton��5      $��Категории��63   $��
10,10,10,0q�6G   6[   �� 5      -   5        $ UsersPageButton��5      $��Пользователи��6.   $��
10,10,10,0q�6E   6Y   5      �� 5   
   $��0��6   $��1��6$   $��3��64   $��Stretch=�6?    � 5   
   -   5          �Name$ 	RootFrame��5      $��0��6#   $��2��60   $��2��6@     � NavigationUIVisibility$ Hidden=�6T   5       5!      