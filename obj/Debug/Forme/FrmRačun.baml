   M S B A M L   `   `   `  ����G  CWPFKnjižara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFKnjižara.FormeWPFKnjižara.Forme  5   	   "    WPFKnjižara.Forme.FrmRačun   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFKnjižara.Forme     5   	     � Title$  Dodaj/Izmjeni račun��5   	   $	��300��6%   $	��350��62   
�������$��7q�5
   	   ��5      �� 5   
    �� ImageSource$= 7C:\Users\sarav\OneDrive\Radna površina\knjigeSlika.jpg��6   6\   .��5      � .+�5   
   �� $��	Korisnik:��6   $��Verdana)�6$   $
��Left=�69   $��	91,52,0,0q�6T   $	��Top=�6g    J� RenderTransformOrigin$ 0.924,0.556&�6   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��
156,54,0,0q�6B   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$ PrezimeKorisnika��6z    �� SelectedValuePath$ 
KorisnikID��6�   �� 5   
   $��Kupac:��6   $��Verdana)�6!   $
��Left=�66   $��
100,88,0,0q�6Q   $	��Top=�6e   �� 5   
   -   5        $ cbKupac��5      $
��Left=�6$   $��
156,92,0,0q�6?   $	��Top=�6S   $	��120��6k   $ PrezimeKupca��6w   $ KupacID��6�   �� 5   
   $��Datum izdavanja:��6   $��Verdana)�6+   $
��Left=�6@   $��
43,142,0,0q�6[   $	��Top=�6o   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumIzdavanja��5      $
��Left=�6-   $��156,142,0,0q�6H   $	��Top=�6]   $	��120��6u   �� 5   
   $��Cijena prodaje:��6   $��Verdana)�6*   $
��Left=�6?   $��
57,187,0,0q�6Z   $	��Top=�6n   $ 0.659,1.211&�6�   �� 5   
   -   5         ��Name$ txtCijenaProdaje��5      $
��Left=�6,   $��156,190,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   �� 5   
   -   5         ��Name$ txtbtnSacuvaj��5      $��Sačuvaj��6(   $��Verdana)�6:   
����ح�$
��Left=�6f   $��111,227,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ txtbtnOtkazi��5      $��Otkaži��6'   $��Verdana)�68   
����ح�$
��Left=�6d   $��197,227,0,0q�6   $	��Top=�6�   6�   5      5      