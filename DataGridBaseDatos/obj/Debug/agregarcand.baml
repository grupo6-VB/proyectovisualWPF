   M S B A M L   `   `   `  ����L  HDataGridBaseDatos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DataGridBaseDatosDataGridBaseDatos  5   	   #    DataGridBaseDatos.agregarcand   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DataGridBaseDatos     5   	   -   5          � Title$  Datos del candidato��5   	   $��443.679��6%   $��283.243��66    � Icon$ images/CHECK.png��6_   .��5	      � $��0,0,2,0q�6   .+�5
   
   � $	��397��6   $��10q�6   $	��253��6(   .+�5      �� -   5         ��Name$ btn_ok��5      $��Guardar��6%   $
��Left=�67   $��
93,338,0,0q�6R   $	��Top=�6f   $��75��6~   �� 5      -   5         ��Name$ lbl_cand��5      $��Dignidad��6&   $
��Left=�69   $��
26,250,0,0q�6T   $	��Top=�6h   �� 5      -   5        $ 
lbl_nombre��5      $��Nombre��6(   $
��Left=�69   $��	26,50,0,0q�6T   $	��Top=�6g   �� 5      -   5        $ lbl_apellido��5      $��Apellido��6*   $
��Left=�6=   $��	26,82,0,0q�6X   $	��Top=�6k   �� 5      -   5        $ 
lbl_cedula��5      $��Cedula��6(   $
��Left=�69   $��	26,20,0,0q�6T   $	��Top=�6g   �� 5      -   5         ��Name$ 
txt_cedula��5      $
��Left=�6B   $��26��6]   $��
109,20,0,0q�6i    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��120��6�   ��6*   �� *Cedula+6�   �� 5      -   5        $ 
txt_nombre��5      $
��Left=�6B   $��24��6]   $��
109,52,0,0q�6i   $
 Wrap=�6}   $	��Top=�6�   $	��120��6�   ��6*   �� *Nombre+6�   �� 5      -	   5        $ txt_apellido��5      $
��Left=�6F   $��26��6a   $��
109,82,0,0q�6m   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   ��6,   �� *
Apellido+6�   �� 5      -
   5         ��Name$ box_dignidades��5      $
��Left=�6G   $��109,252,0,0q�6b   $	��Top=�6w   $	��120��6�    �� Text 6/   �� *Puesto+.@�5      �� $��
presidente��6   �� 5      $��asambleista��6   �� 5      $��parlamento andino��6   5      �� 5      -   5        $ lbl_partido��5      $��Lista��6)   $
��Left=�69   $��
26,212,0,0q�6T   $	��Top=�6h   �� 5      -   5        $ 	box_lista��5      $
��Left=�6D   $��109,218,0,0q�6_   $	��Top=�6t   $	��120��6�    6*   �� *
Dignidad+.@�5      �� $��35��6   �� 5      $��21��6   �� 5      $��5��6   �� 5      $��6��6   �� 5      $��10��6   �� 5      $��2��6   �� 5       $��19��6   �� 5!      $��3��6   �� 5"      $��1��6   �� 5#      $��7��6   �� 5$      $��8��6   �� 5%      $��12��6   �� 5&      $��17��6   �� 5'      $��18��6   �� 5(      $��23��6   �� 5)      $��51��6   5*      �� 5+      -   5        $ lbl_usuario��5+      $��Usuario��6)   $
��Left=�6;   $��
26,120,0,0q�6V   $	��Top=�6j   �� 5,      -   5        $ txt_usuario��5,      $
��Left=�6C   $��24��6^   $��109,118,0,0q�6j   $
 Wrap=�6   $	��Top=�6�   $	��120��6�   ��6+   �� *Cedula+6�   �� 5-      -   5        $ 	lbl_clave��5-      $��Clave��6'   $
��Left=�67   $��
26,150,0,0q�6R   $	��Top=�6f   �� 5.      -   5        $ 	txt_clave��5.      $
��Left=�6A   $��26��6\   $��109,150,0,0q�6h   $
 Wrap=�6}   $	��Top=�6�   $	��120��6�   ��6)   �� *Cedula+6�   �� 5/      -   5        $ 
lbl_estado��5/      $��Estado��6(   $
��Left=�69   $��
26,184,0,0q�6T   $	��Top=�6h   �� 50      -   5        $ 
box_estado��50      $
��Left=�6C   $��109,184,0,0q�6^   $	��Top=�6s   $	��120��6�    6+   �� *Puesto+.@�51      �� $��FALSE��6   �� 52      $
��TRUE��6   53      �� 54      -   5        $ 	lbl_votos��54      $��Votos��6'   $
��Left=�67   $��
26,284,0,0q�6R   $	��Top=�6f   �� 55      -   5        $ 	txt_votos��55      $��0��6)   $
��Left=�62   $��26��6M   $��109,282,0,0q�6Y   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   56      57      58      