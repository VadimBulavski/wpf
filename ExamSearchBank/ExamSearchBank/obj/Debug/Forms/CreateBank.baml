   M S B A M L   `   `   `  ����  ExamSearchBank%    ExamSearchBank.Forms.CreateBank   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Добавить банк��5   	   $	��400��6   $	��500��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   6,   �� 5      6   �� 5	      $
��0.2* �6   6,   .+�5   
   �� -   5         ��Name$ 
spBankName��5       �� Orientation$ 
Horizontal=�6)   $��Stretch=�6B   .+�5      �� $"��Название банка:��6   $��16(�6.   $��10q�6<   �� 5      -   5         ��Name$ 
tbBankName��5      $��
5,10,10,10q�6*   $	��200��6>   5      �� 5   
   -   5         ��Name$ gbKurs��5      $��	Курс:��6#   $��1��62   $��5q�6?   $��16(�6J   .��5      � -   5         �Name$ gridKurs��5       � ColumnDefinitions 5      �� 5      $
��0.5* �6'   66   �� 5      $��1* �6'   64   �� 5      $
��1.5* �6'   66   �� 5      $
��1.5* �6'   66   .+�5      �� -   5        $ spNumber��5      $��0��6/   .+�5      �� $��№п/п��6   �� 5      $��1��6   $��Center=�6(   �� 5      $��2��6   $��Center=�6(   �� 5      $��3��6   $��Center=�6(   �� 5      $��4��6   $��Center=�6(   �� 5      $��5��6   $��Center=�6(   �� 5      $��6��6   $��Center=�6(   5      �� 5       -   5        $ 	spValyuta��5       $��1��60   .+�5!      �� $��Валюта��6   $��Center=�6-   �� 5"      -   5         ��Name$ 
cbValyuta1��5"      $��2q�63   �� 5#      -	   5        $ 
cbValyuta2��5#      $��2q�63   �� 5$      -
   5        $ 
cbValyuta3��5$      $��2q�63   �� 5%      -   5        $ 
cbValyuta4��5%      $��2q�63   �� 5&      -   5        $ 
cbValyuta5��5&      $��2q�63   �� 5'      -   5        $ 
cbValyuta6��5'      $��2q�63   5(      �� 5)      -   5        $ spSell��5)      $��2��6-   .+�5*      �� $��Продажа��6   $��Center=�6.   �� 5+      -   5        $ tbSell1��5+      $��4q�6/   �� 5,      -   5        $ tbSell2��5,      $��4q�6/   �� 5-      -   5        $ tbSell3��5-      $��4q�6/   �� 5.      -   5        $ tbSell4��5.      $��4q�6/   �� 5/      -   5        $ tbSell5��5/      $��4q�6/   �� 50      -   5        $ tbSell6��50      $��4q�6/   51      �� 52      -   5        $ spBuy��52      $��3��6,   .+�53      �� $��Покупка��6   $��Center=�6.   �� 54      -   5        $ tbBuy1��54      $��4q�6.   �� 55      -   5        $ tbBuy2��55      $��4q�6.   �� 56      -   5        $ tbBuy3��56      $��4q�6.   �� 57      -   5        $ tbBuy4��57      $��4q�6.   �� 58      -   5        $ tbBuy5��58      $��4q�6.   �� 59      -   5        $ tbBuy6��59      $��4q�6.   5:      5;      5<      �� 5=   
   -   5        $ 
spSaveBank��5=      $ 
Horizontal=�6)   $��Right=�6B   $��2��6^   .+�5>      �� -   5        	 ��Name$	 btCreateValyuta��5>      $#��Добавить валюту��6.   $��10q�6H   6T   �� 5?      -   5        $	 btBankOk��5?      $��Сохранить��6'   $��10q�6;   $	��100��6G   6S   �� 5@      -   5        $	 btBankCancel��5@      $��Отмена��6+   $��10q�6<   $	��100��6H   5A      5B      5C      