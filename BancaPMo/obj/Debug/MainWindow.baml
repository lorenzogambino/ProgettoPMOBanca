   M S B A M L   `   `   `  ����C  ?BancaPMo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BancaPMoBancaPMo  5   	       BancaPMo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BancaPMo     5   	   -   5          �Name$  ___Nessun_nome_��5   	    � Title$ Conti��5   	   $	��450��6   $	��600��6$    � 
ResizeMode$ CanMinimize=�60    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �� .@�5   
   �� -   5         ��Name$ 	tabElenco��5      $��Elenco completo��6%   .��5      � .+�5      �� -   5         ��Name$ lvConti��5      ��6,   ��  �� Path$ Conti� �� View 5      �� 5      .P�5      �� -   5        hIntestatario��$
��Nome��5   D    �� DisplayMemberBinding 6R   �� $ proprietario��� 5      -   5        	hTipo��$
��Tipo��5   <    6J   �� *	tipoConto+�� 5      -   5        	hIban��$
��Iban��5   <    6J   �� *iban+�� 5      -   5        
hSaldo��$��Saldo��5   =    6L   �� *saldo+5      5      5      5      �� 5   
   -   5        $ TabCreazione��5      $��Creazione conto��6(   {�. .��5      � .+�5      	� -	   5        	 	�Name$	 CheckConsumo��5      $��Conto a consumo��64   $
��Left=�6N   $	��Top=�6i   $��	10,19,0,0q�6�   $��19��6�   $	��152��6�   	� 5      -
   5        $	 CheckStandard��5      $��Conto Standard��65   $
��Left=�6N   $	��Top=�6i   $��	10,45,0,0q�6�   $��19��6�   $	��137��6�   �� 5       -   5        
 ��Name$
 txtIntestatario��5       $
��Left=�63   $��23��6N   $��121,113,0,0q�6Z    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��120��6�   6�   �� 5!      -   5         ��Name$ btnCreazione��5!      $��Conferma��6/   $
��Left=�6B   $	��Top=�6]   $	��231��6u   $��
10,156,0,0q�6�   $��40��6�   	� 5"      -   5        $	 CheckBusiness��5"      $��Conto Business��65   $
��Left=�6N   $	��Top=�6i   $��	10,90,0,0q�6�   $��20��6�   $	��135��6�   	� 5#      -   5        $	 
CheckYoung��5#      $��Conto Young��62   $
��Left=�6H   $	��Top=�6c   $��	10,68,0,0q�6{   $��20��6�   $	��118��6�   �� 5$      $��Nome Intestatario��6   $
��Left=�64   $	��Top=�6O   $��
10,110,0,0q�6g   5&      5(      �� 5)   
   -   5        $ TabVersamento��5)      $��
Versamento��6)   {�.  .��5*      � .+�5,      �� -   5        $
 txtImporto1��5,      $
��Left=�6/   $��26��6J   $
 Wrap=�6V   $	��Top=�6j   $��75��6�   $��
147,19,0,0q�6�    �� TextAlignment$ Right=�6�   6�   �� 5-      -   5        $ btnVersamento��5-      $��Conferma��60   $
��Left=�6C   $��	10,60,0,0q�6^   $	��Top=�6q   $	��228��6�   $��22��6�   �� 5.      -   5         ��Name$ 	outEsito1��5.      $
��Left=�6/   $
��Wrap=�6J   $	��Top=�6^   $��	10,95,0,0q�6v   �� 5/      -   5        $ 	outSaldo1��5/      $
��Left=�6/   $
��Wrap=�6J   $	��Top=�6^   $��
80,115,0,0q�6v   �� 50      $'��!Scrivi qui l'importo 
da versare��6   $
��Left=�6L   $��	10,10,0,0q�6g   $	��Top=�6z   �� 51      $	��€��6   $
��Left=�6$   $��
219,15,0,0q�6?   $	��Top=�6S    J� RenderTransformOrigin$ 3.312,0.231&�6k   $��33��6�   $��16(�6�   �� 52      $��Il saldo è  €��6   $
��Left=�60   $��	5,110,0,0q�6K   $	��Top=�6^   $��70��6v   53      54      �� 55   
   -   5        $ TabPrelievo��55      $��Prelievo��6'   {�.  $��22��6K   $��Bottom=�6W   .��56      � .+�57      �� -   5        $
 txtImporto2��57      $
��Left=�6/   $��25��6J   $
 Wrap=�6V   $	��Top=�6j   $��92��6�   $��
133,20,0,0q�6�   $ Right=�6�   6�   �� 58      -   5        $ btnPrelievo��58      $��Conferma��6.   $
��Left=�6A   $��	13,60,0,0q�6\   $	��Top=�6o   $	��219��6�   $��22��6�   �� 59      -   5        $ 	outEsito2��59      $
��Left=�6/   $
��Wrap=�6J   $	��Top=�6^   $��	10,95,0,0q�6v   �� 5:      $��Il saldo è  €��6   $
��Left=�60   $��	5,110,0,0q�6K   $	��Top=�6^   $��70��6v   �� 5;      -   5        $ 	outSaldo2��5;      $
��Left=�6/   $��
80,115,0,0q�6J   $
��Wrap=�6^   $	��Top=�6r   �� 5<      $)��#Scrivi qui l'importo 
da prelevare��6   $
��Left=�6N   $��	10,12,0,0q�6i   $	��Top=�6|   �� 5=      $	��€��6   $
��Left=�6$   $��
224,18,0,0q�6?   $	��Top=�6S   $ -0.562,0.462&�6k   $��16(�6�   5>      5?      �� 5@   
   -   5        $ TabBonifico��5@      $��Bonifico��6'   {�.  .��5A      � .+�5B      �� -   5        $
 txtImporto3��5B      $
��Left=�6/   $��22��6J   $
 Wrap=�6V   $	��Top=�6j   $��52��6�   $��	66,19,0,0q�6�   $ Right=�6�   6�   �� 5C      -   5        $ btnBonifico��5C      $��Conferma��6.   $
��Left=�6A   $��	66,55,0,0q�6\   $	��Top=�6o   $	��427��6�   $��27��6�   �� 5D      $��Il saldo è  €��6   $
��Left=�60   $��	5,110,0,0q�6K   $	��Top=�6^   $��70��6v   �� 5E      -   5        $ 	outSaldo3��5E      $
��Left=�6/   $
��Wrap=�6J   $	��Top=�6^   $��
80,115,0,0q�6v   �� 5F      -   5        $
 txtDestinatario��5F      $
��Left=�63   $��40��6N   $
 Wrap=�6Z   $	��Top=�6n   $	��175��6�   $��
318,10,0,0q�6�   �� 5G      -   5        $ 	outEsito3��5G      $
��Left=�6/   $
��Wrap=�6J   $	��Top=�6^   $��	10,95,0,0q�6v   �� 5H      $��Importo 
bonifico��6   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k   $ 0.289,0.462&�6�   �� 5I      $��IBAN 
destinatario��6   $
��Left=�6>   $��
242,10,0,0q�6Y   $	��Top=�6m   $ 0.289,0.462&�6�   �� 5J      $	��€��6   $
��Left=�6$   $��
114,14,0,0q�6?   $	��Top=�6S   $��16(�6k   5L      5M      �� 5N   
   -   5        $ TabMovimenti��5N      $��Lista Movimenti��6(   {�.  .��5O      � .+�5P      �� -    5        $ btnMovimenti��5P      $��Richiedi Lista Movimenti��6/   $
��Left=�6R   $	��Top=�6m   $	��137��6�   $��37��6�   $��	10,10,0,0q�6�   �� 5Q      $��0,55,0,0q�6   .��5R      �� -!   5        $ 	outEsito4��5R   !   $
��Left=�64   $��10,0,0,0q�6O   $	��Top=�6a   $��16(�6y   5S      5U      5V      5W      5X      