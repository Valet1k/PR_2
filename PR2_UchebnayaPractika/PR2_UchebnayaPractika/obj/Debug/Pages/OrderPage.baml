   M S B A M L   `   `   `  ����P  LPR2_UchebnayaPractika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PR2_UchebnayaPractika.PagesPR2_UchebnayaPractika.Pages  5      +    %PR2_UchebnayaPractika.Pages.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:PR2_UchebnayaPractika.Pages     5        N� Title$%  Страница заказов��5	      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��10 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   .+�5      �� $&�� Имя оборудования:��6   $	��0,5q�65   �� 5      -   5         ��Name$ EquipmentTextBox��5       $��25��5      $��0,0,0,10q�5!      �� 5$      $;��5Серийный номер оборудования:��6   $	��0,5q�6@   �� 5%      -   5        $ SerialNumberTextBox��5'      $��25��5&      $��0,0,0,10q�5(      �� 5*      $(��"Тип неисправности:��6   $	��0,5q�66   �� 5+      -   5        $ MalfunctionTextBox��5-      $��25��5,      $��0,0,0,10q�5.      50      �� 52      $��2��6   .+�53      �� $)��#Ваш номер телефона:��6   $	��0,5q�67   �� 54      -   5        $ UserPhoneTextBox��56      $��25��55      $��0,0,0,10q�57      5;      5<      �� 5>   
   $��1��6   $��Bottom=�6"   $
��0,10q�6=   .+�5?      �� $(��"Описание проблемы:��6   $	��0,5q�62   �� 5@      -   5        $ ProblemDescriptionTextBox��5@       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5A   (   $��80��5B      " �� VerticalScrollBarVisibility$
 Auto=�6   5C      �� 5E   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $
��0,10q�6W   .+�5F      �� -   5         ��Name$ BtnBack��5G      $��Отмена��5I      $	��100��5J      $��0,0,10,0q�5K      �� 5L      -   5        $��
BtnAddSave��5N      $%��Сохранить заявку��5M      $	��150��5P      
������
�������$
��Bold"�5S      5T      5U      5W      