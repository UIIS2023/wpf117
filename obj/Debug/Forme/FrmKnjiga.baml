   M S B A M L   `   `   `  ����G  CWPFKnjižara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFKnjižara.FormeWPFKnjižara.Forme  5   	   "    WPFKnjižara.Forme.FrmKnjiga   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFKnjižara.Forme     5   	     � Title$  Dodaj/Izmjeni knjigu��5   	   $	��350��6&   $	��300��63   
�������$��7q�5
   	   ��5      �� 5   
    �� ImageSource$= 7C:\Users\sarav\OneDrive\Radna površina\knjigeSlika.jpg��6   6\   .��5      � .+�5   
   �� $��ISBN:��6   $
��Left=�6    $��	58,39,0,0q�6;   $	��Top=�6N   �� 5   
   -   5         ��Name$ txtISBN��5      $
��Left=�6#   $��
101,43,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   �� 5   
   $��Naslov:��6   $��Verdana)�6"   $
��Left=�68   $��	48,65,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ 	txtNaslov��5      $
��Left=�6%   $��
101,69,0,0q�6@   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   $��Pisac:��6   $��Verdana)�6!   $
��Left=�66   $��	57,96,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5         ��Name$ cbPisac��5      $
��Left=�6$   $��
101,96,0,0q�6?   $	��Top=�6S   $	��120��6k    �� DisplayMemberPath$ PrezimePisca��6w    �� SelectedValuePath$ PisacID��6�   �� 5   
   $��Žanr:��6   $��Verdana)�6    $
��Left=�65   $��
60,127,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ cbZanr��5      $
��Left=�6#   $��101,127,0,0q�6>   $	��Top=�6S   $	��120��6k   $ 
NazivZanra��6w   $ ZanrID��6�   �� 5   
   $��
Izdavanje:��6   $��Verdana)�6%   $
��Left=�6:   $��
34,153,0,0q�6U   $	��Top=�6i   �� 5   
   -   5        $ cbIzdavanje��5      $
��Left=�6(   $��103,157,0,0q�6C   $	��Top=�6X   $	��120��6p   $ NazivIzdanja��6|   $ IzdavanjeID��6�   �� 5   
   $��Račun:��6   $��Verdana)�6!   $
��Left=�66   $��
48,191,0,0q�6Q   $	��Top=�6e   �� 5   
   -   5        $ cbRacun��5      $
��Left=�6$   $��103,193,0,0q�6?   $	��Top=�6T   $	��120��6l   $ CijenaProdaje��6x   $ RacunID��6�   �� 5   
   $��Nabavka:��6   $��Verdana)�6#   $
��Left=�68   $��
38,231,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ 	cbNabavka��5      $
��Left=�6&   $��103,233,0,0q�6A   $	��Top=�6V   $	��120��6n   $ CijenaNabavke��6z   $ 	NabavkaID��6�   �� 5   
   -   5         ��Name$ txtbtnSacuvaj��5      $��Sačuvaj��6)   $��Verdana)�6;   
����ح�$
��Left=�6g   $��
78,274,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -	   5        $ txtbtnOtkazi��5      $��Otkaži��6'   $��Verdana)�68   
����ح�$
��Left=�6d   $��174,274,0,0q�6   $	��Top=�6�   6�   5!      5"      