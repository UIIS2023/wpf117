   M S B A M L   `   `   `  ����G  CWPFKnjižara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPFKnjižaraWPFKnjižara  5   	       WPFKnjižara.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPFKnjižara     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ 	Knjižara��5   	   $	��350��6   $	��630��6'   
�������$��10q�5
   	   ��5      �� 5   
    �� ImageSource$; 5C:\Users\sarav\OneDrive\Radna površina\knjizara1.jpg��6    j� Stretch$
 Fill=�6X   .��5      � .+�5   
   �� $��Center=�6   $��30��62   $	��Top=�6>   $
��auto��6V    � Cursor$
 Hand��6c    �� Orientation$ 
Horizontal=�6q   $��2��6�   .+�5      �� -   5         ��Name$ 	btnKnjiga��5      $��Knjiga��6(   $��Verdana)�69   
����ح�$��75��6f   $��30��6q   $
��Left=�6}   $	��Top=�6�   6�   �� 5      -   5        $ btnPisac��5      $��Pisac��6'   $��Verdana)�67   
����ح�$��75��6d   $��30��6o   $
��Left=�6{   $	��Top=�6�   6�   �� 5      -   5        $ btnZanr��5      $��Žanr��6&   $��Verdana)�65   
����ح�$��75��6b   $��30��6m   $
��Left=�6y   $	��Top=�6�   6�   �� 5      -   5        $ 
btnIzdanje��5      $��Izdanje��6)   $��Verdana)�6;   
����ح�$��75��6g   $��30��6r   $
��Left=�6~   $	��Top=�6�   6�   �� 5      -   5        $ 
btnNabavka��5      $��Nabavka��6)   $��Verdana)�6;   
����ح�$��75��6g   $��30��6r   $
��Left=�6~   $	��Top=�6�   6�   �� 5      -   5        $ btnRacun��5      $��Račun��6'   $��Verdana)�67   
����ح�$��75��6c   $��30��6n   $
��Left=�6z   $	��Top=�6�   6�   �� 5      -   5        $ btnKorisnik��5      $��Korisnik��6*   $��Verdana)�6=   
����ح�$��75��6i   $��30��6t   $
��Left=�6�   $	��Top=�6�   6�   �� 5      -   5        $ btnKupac��5      $��Kupac��6'   $��Verdana)�67   
����ح�$��75��6c   $��30��6n   $
��Left=�6z   $	��Top=�6�   6�   5      �� 5   
   $
��Left=�6   $��Bottom=�60   $
��auto��6K   $ 
Horizontal=�6X   $��2��6q   $��	110,0,0,0q�6�   .+�5      �� -	   5        $ btnDodaj��5      $��Dodaj��6'   $��Verdana)�67   
����ح�$	��120��6c   $��30��6o   6{   �� 5      -
   5        $ 
btnIzbrisi��5      $��Izbriši��6)   $��Verdana)�6;   
����ح�$	��120��6g   $��30��6s   6   �� 5      -   5        $ 
btnIzmjeni��5      $��Izmjeni��6)   $��Verdana)�6;   
����ح�$	��120��6h   $��30��6t   6�   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGridCentar��5!      $��Center=�6+   $
��Auto��6H   $
��Auto��6V   $��Center=�6c      
IsReadOnly . 	   AlternatingRowBackground
	 �����
   CanUserAddRows
 .     SelectionUnit$ FullRow=�5"   _      SelectionMode$ Single=�6w   5&      5'      