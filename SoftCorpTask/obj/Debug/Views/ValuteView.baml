   M S B A M L   `   `   `  ����G  CSoftCorpTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SoftCorpTask.ViewsSoftCorpTask.Views  5   	   #    SoftCorpTask.Views.ValuteView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SoftCorpTask.Views     5   	     � Title$  Котировки��5	   	   $	��450��6   $	��800��6(    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ResourceDictionary.xaml?�6%   %    5      .��5      �  � ShowGridLines .   � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      $
��0.5* �6   6.   �� 5      6!   �� 5      6!   .+�5    
   �� -   5         ��Name$ UploadCodes��5          ButtonStyle#��[  6&   $��0��6K   $��0��6[   $��Загрузить��6h   6   �� 5!   
   -   5        $ UpdateCourses��5!      #��[  6(   $��1��6M   $��0��6]   $��Обновить��6j   6�   �� 5"   
   -   5         ��Name$ ValuteCodes��5"      $��0��6(   $��1��68   $��2��6E   $��3��6Y   	 �� View	 5#      �� 5$      .P�5%      �� $��Код��6%   
 �� Width$

 Auto��62    �� DisplayMemberBinding 5&      �� *	NumCode+�� 5'      $��Страна��6%   $

 Auto��65    5(      �� *
CharCode+5)      5+      �� 5,   
   -   5        $ ValuteCourses��5,      $��3��6+   $��0��6;   $��2��6H   $��2��6\   	 5-      �� 5.      .P�5/      �� $��Код��6%   $

 Auto��62    50      �� *	NumCode+�� 51      $��Стоимость��6%   $

 Auto��68    52      �� *Value+53      55      �� 56   
   $��3��6   $��2��6%   $"��Конвертировать��62   $	��Top=�6H   6c   �� 57   
   -   5         ��Name$ ComboBoxFrom��57        ComboBoxStyle#��[ 6*   $��3��6}   $��2��6�    �� SelectedItem 6R   �� *SelectedValueCB1+6�   �� 58   
   -   5        $ 
ComboBoxTo��58      #��[ 6(   $��3��6y   $��3��6�    6O   �� *SelectedValueCB2+6�   �� 59   
   -   5         ��Name$ ConvertValue��59        TextBoxStyle#��[ 6)   $��4��6O   $��2��6_   6p   �� 5:   
   -   5         ��Name$ ConvertResult��5:        TextBlockStyle#��[ 6,   $��4��6T   $��3��6d   $��Center=�6q   6�   �� 5;   
   -	   5        $ 
SearchText��5;      #��[ 6'   $��0��6M   $��0��6V   $��4��6f   6v   �� 5<   
   -
   5        $ Search��5<      #��[  6!   $��1��6F   $��4��6V   $��
Поиск��6c   6v   �� 5=   
   -   5        $ SearchResults��5=      $��3��6*   $��4��6:   $��2��6G   ��5>      �� 5?      .R�5@      �� ��6    �� 5A      5C      5D      5E      