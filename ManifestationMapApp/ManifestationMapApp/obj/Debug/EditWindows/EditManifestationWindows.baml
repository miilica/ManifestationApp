   M S B A M L   `   `   `  ����N  JManifestationMapApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ManifestationMapAppManifestationMapApp  5   	   2    ,ManifestationMapApp.EditManifestationWindows   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ManifestationMapApp     5   	     � Title$  EditManifestationWindows��5   	   $	��800��6*   $	��850��67   .��5
   
   � ���	#FF9CD487.+�5      �� $��Edit manifestation��6   $
��Left=�61   $��
279,18,0,0q�6L   $	��Top=�6`   $��28(�6x   $
��Bold"�6�    J� RenderTransformOrigin$ 
0.851,0.32&�6�   �� 5      $	��ID:��6   $
��Left=�6"   $��
10,116,0,0q�6=   $	��Top=�6Q   $��22(�6i   $
��Bold"�6w   �� 5      -   5        $��txtID��5       �� 
IsReadOnly . $
��Left=�65   $��40��6P   $��167,114,0,0q�6\    �� TextWrapping$
 Wrap=�6q   $��Center=�6�   $�� ��6�   $	��Top=�6�   $	��194��6�   $��22(�6�   $
��Bold"�6�   �� 5      $��Name:��6   $
��Left=�6$   $��
10,286,0,0q�6?   $	��Top=�6S   $��22(�6k   $
��Bold"�6y   $ 0.594,2.408&�6�   �� 5      -   5        $��txtName��5      $
��Left=�6%   $��40��6@   $��162,286,0,0q�6L   $
 Wrap=�6a   $��Center=�6u   $�� ��6�   $	��Top=�6�   $	��643��6�   $��22(�6�   $
��Bold"�6�   �� 5      $��Description:��6   $
��Left=�6+   $��
10,349,0,0q�6F   $	��Top=�6Z   $��22(�6r   $
��Bold"�6�   $ 0.594,2.408&�6�   �� 5      -   5        $��txtDesc��5      $
��Left=�6%   $	��113��6@   $��162,349,0,0q�6M   $
 Wrap=�6b   $��Center=�6v   $�� ��6�   $	��Top=�6�   $	��643��6�   $��22(�6�   $
��Bold"�6�   �� 5      $��Type:��6   $
��Left=�6$   $��
10,170,0,0q�6?   $	��Top=�6S   $��22(�6k   $
��Bold"�6y   $ 0.594,2.408&�6�   �� 5   
   -   5        $��cmbType��5      $
��Left=�6"   $��22(�6_   $
��Bold"�6m   $��167,168,0,0q�6   $	��Top=�6�   $	��194��6�   $��40��6�   ��6=   �� *	TypesList+��5      �� 5      .R�5      �� ��6   �� *Name+5      5      �� 5   
   ���	#33000000$
��Left=�6%   $��7��6@   $��
10,486,0,0q�6K   
���   �$	��Top=�6n   $	��823��6�   �� 5      $��Serving Alcohol:��6   $
��Left=�6/   $��
10,520,0,0q�6J   $	��Top=�6^   $��22(�6v   $
��Bold"�6�   $ 0.594,2.408&�6�   �� 5      -   5        $��cmbAlc��5      $
��Left=�6%   $
��Bold"�6d   $��22(�6v   $��194,520,0,0q�6�   $	��Top=�6�   $	��194��6�   $��40��6�   ��6@   �� *AlcoholList+6�   �� 5      $��Price Category:��6   $
��Left=�6.   $��
10,569,0,0q�6I   $	��Top=�6]   $��22(�6u   $
��Bold"�6�   $ 0.594,2.408&�6�   �� 5       -   5        $��cmbPrice��5       $
��Left=�6'   $
��Bold"�6l   $��22(�6~   $��194,569,0,0q�6�   $	��Top=�6�   $	��194��6�   $��40��6�   ��6B   �� *PriceCategoryList+6�   �� 5!      $��	Visitors:��6   $
��Left=�6(   $��
10,617,0,0q�6C   $	��Top=�6W   $��22(�6o   $
��Bold"�6}   $ 0.594,2.408&�6�   �� 5"      -   5        $��txtVisitors��5"      $
��Left=�6)   $��40��6D   $��194,617,0,0q�6P   $
 Wrap=�6e   $��Center=�6y   $�� ��6�   $	��Top=�6�   $	��194��6�   $��22(�6�   $
��Bold"�6�   �� 5#      $��Date:��6   $
��Left=�6$   $��
10,228,0,0q�6?   $	��Top=�6S   $��22(�6k   $
��Bold"�6y   $ 0.594,2.408&�6�   (  "System.Windows.Controls.DatePicker  5$      -   5        $��dpDate��5$      $
��Left=�6'   $��162,228,0,0q�6B   $	��Top=�6W   $��35��6o   $	��226��6{   $��20(�6�   �� 5%      -	   5        $��btnSave��5%      $
��Save��6$   $
��Left=�63   $��231,707,0,0q�6N   $	��Top=�6c   $	��157��6{   $��20(�6�   $
��Bold"�6�   $��45��6�   6�   �� 5&      -
   5        $��	btnCancel��5&      $��Cancel��6&   $
��Left=�67   $��453,707,0,0q�6R   $	��Top=�6g   $	��157��6   $��20(�6�   $
��Bold"�6�   $��45��6�   6�   �� 5'      -   5        $��	rtSmoking��5'      ���	#33000000$��2��6:   $
��Left=�6N   $��40��6i   $��496,516,0,0q�6u   $	��Top=�6�   $	��307��6�   
������ 6�   	� 5(      -   5        $��	rbSmoking��5(      $��Smoking��6+    	� 	GroupName$ rbSmokingGroup��6=   $
��Left=�6X   $��506,524,0,0q�6s   $	��Top=�6�   $��20(�6�   $
��Bold"�6�   	� 5)      -   5        $��rbNoSmoking��5)      $��
No Smoking��6-   $ rbSmokingGroup��6B   $
��Left=�6]   $��647,524,0,0q�6x   $	��Top=�6�   $��20(�6�   $
��Bold"�6�   �� 5*      -   5        $��rtInside��5*      ���	#33000000$��2��69   $
��Left=�6M   $��40��6h   $��498,569,0,0q�6t   $	��Top=�6�   $	��307��6�   
������ $ 0.5,0.5&�6�   	� 5+      -   5        $��rbInside��5+      $��Inside��6*   $ rbOutsideGroup��6;   $
��Left=�6V   $��516,577,0,0q�6q   $	��Top=�6�   $��20(�6�   $
��Bold"�6�   $ 0.5,0.5&�6�   	� 5,      -   5        $��	rbOutside��5,      $��Outside��6+   $ rbOutsideGroup��6=   $
��Left=�6X   $��649,577,0,0q�6s   $	��Top=�6�   $��20(�6�   $
��Bold"�6�   $ 0.5,0.5&�6�   �� 5-      -   5        $��
cbDisabled��5-      $��For Disabled People��6)   $
��Left=�6G   $��536,625,0,0q�6b   $	��Top=�6w   $��20(�6�   $
��Bold"�6�   $	��228��6�   �� 5.      -   5        $��btnImg��5.      $��Browse��6#   $
��Left=�64   $��461,228,0,0q�6O   $	��Top=�6d   $	��130��6|   $��20(�6�   $
��Bold"�6�   $��40��6�   6�   �� 5/      -   5        $��imgManifestation��5/      $
��Left=�6,   $��Images/img13.png��6G   $	��100��6a   $��448,108,0,0q�6n   $	��Top=�6�   $	��160��6�   $
��Fill=�6�   �� 51      ���	#33000000$
��Left=�6)   $��7��6D   $��
10,680,0,0q�6O   
���   �$	��Top=�6r   $	��823��6�   �� 52      $��Image��6   $
��Left=�6$   $��
492,79,0,0q�6?   $	��Top=�6S   $��22(�6k   $
��Bold"�6y   �� 53      -   5        $��error��53      $�� ��6!   $
��Left=�6,   $��
240,53,0,0q�6G   $	��Top=�6[   $��20(�6s   $
��Bold"�6�   
���  ��6�   �� 54      -   5        $��lblErrorVisitors��54      $��Must be a number!��6,   $
��Left=�6H   $��194,651,0,0q�6c   $	��Top=�6x   $��18(�6�   $
��Bold"�6�   $ 0.594,2.408&�6�   $	��243��6�   $��36��6�   
���  ��6�   �� 55      $��Tags:��6   $
��Left=�6$   $��
627,85,0,0q�6?   $	��Top=�6S   $��22(�6k   $
��Bold"�6y   $ 16.87,0.595&�6�   �� 57   
   -   5        $��comboBoxTags��57      $��20(�6H   $
��Bold"�6V   
�������$��613,130,29.2,596.4q�6{   ��6'   �� *	TheList+��58      �� 59      .R�5:      �� $��cmbTag��6   ��6.   �� *Description+
 � Tag 6N   �� *Id+ d� 	IsChecked 6a   �� *	Cekiran+5;      5=      �� 5>      -   5        $��btnAddNewTag��5>   @   $��Add New Tag...��6   $
��Bold"�6.   $��18(�6U   $��Stretch=�6c   $��671,187,29.2,543.4 q�6�   6�   5@      5A      