   M S B A M L   `   `   `  ����G  CWPFKnjižara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFKnjižara.FormeWPFKnjižara.Forme  5   	   #    WPFKnjižara.Forme.FrmNabavka   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFKnjižara.Forme     5   	     � Title$  Dodaj/Izmjeni nabavku��5   	   $	��300��6'   $	��300��64   
�������$��7q�5
   	   ��5      �� 5   
    �� ImageSource$= 7C:\Users\sarav\OneDrive\Radna površina\knjigeSlika.jpg��6   6\   .��5      � .+�5   
   �� $��	Korisnik:��6   $��Verdana)�6$   $
��Left=�69   $��	66,46,0,0q�6T   $	��Top=�6g   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��
136,46,0,0q�6B   $	��Top=�6V   $	��120��6n    �� DisplayMemberPath$ PrezimeKorisnika��6z    �� SelectedValuePath$ 
KorisnikID��6�   �� 5   
   $��Datum nabavke:��6   $��Verdana)�6)   $
��Left=�6>   $��	32,92,0,0q�6Y   $	��Top=�6l    J� RenderTransformOrigin$ 0.444,0.631&�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatumNabavke��5      $
��Left=�6+   $��
136,92,0,0q�6F   $	��Top=�6Z   $	��120��6r   �� 5   
   $��Cijena nabavke:��6   $��Verdana)�6*   $
��Left=�6?   $��23,0,0,0q�6Z   $��Center=�6l   �� 5   
   -   5         ��Name$ txtCijenaNabavke��5      $
��Left=�6,   $��	136,0,0,0q�6G    �� TextWrapping$
 Wrap=�6Z   $��Center=�6n   $	��120��6�   �� 5   
   -   5         ��Name$ txtbtnSacuvaj��5      $��Sačuvaj��6(   $��70��6:   $��25��6E   $��Verdana)�6Q   
����ح�$
��Left=�6}   $��
59,204,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ txtbtnOtkazi��5      $��Otkaži��6'   $��70��68   $��25��6C   $��Verdana)�6O   
����ح�$
��Left=�6{   $��162,204,0,0q�6�   $	��Top=�6�   $ 1.055,0.583&�6�   6�   5      5      