   M S B A M L   `   `   `  ����E  AHeroEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:HeroEditor.View.ControlsHeroEditor.View.Controls  5      f bGalaSoft.MvvmLight.Platform, Version=5.2.0.37226, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5      '    !HeroEditor.View.Controls.HeroView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:HeroEditor.View.Controls     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      WcmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform  5        � DataContext  5      ��    Locator �� Source# [   �� Path$
 Hero� � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $, &../../../Templates/ControlsStyles.xaml?�6%   %    5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5   
   ]� ��.  .+�5      �� $%��А вот и наш герой!��6   $	��Top=�61   �� 5      $	��Top=�6   ��6+   �� $
 Name�]� 5      $��5,10,0,5q�6   $
��Auto��6+   $	��Top=�68   ��.  .+�5      �� $
��Left=�6   $!��Слот для шляпы!��6.   $
��Auto��6I   �� 5        SlotItemStyle#��[ 6   $
��Left=�6K   .��5      �� ��6   �� $ HatImage���5       �� $ ActualWidth� �� RelativeSource �� *FindAncestor+ �� AncestorType" ��.  (System.Windows.Interactivity.Interaction	   Triggers	 5#      /  )System.Windows.Interactivity.EventTrigger  5$      
   	EventName$
 	MouseDown��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5%      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 61   �� *HatMouseDown+6R   5&        5'      $

 Drop��6)   . 5(         .  61   �� *	HatDrop+6M   5)      5+      5,      ]� 50      $��5,10,0,5q�6   $
��Auto��6+   $	��Top=�68   ��.  .+�51      �� $
��Left=�6   $!��Слот для брони!��6.   $
��Auto��6H   �� 52      #��[ 6   $
��Left=�6L   .��53      �� ��6   �� $ 
ChestImage���54      �� $ ActualWidth� �� *FindAncestor+" ��	 56        57      $
 	MouseDown��6)   . 58         .  61   �� *ChestMouseDown+6T   59        5:      $

 Drop��6)   . 5;         .  61   �� *	ChestDrop+6O   5<      5>      5?      ]� 5C      $��5,10,0,5q�6   $
��Auto��6+   $	��Top=�68   ��.  .+�5D      �� $
��Left=�6   $#��Слот для оружия!��6.   $
��Auto��6I   �� 5E      #��[ 6   $
��Left=�6K   .��5F      �� ��6   �� $ WeaponImage���5G      �� $ ActualWidth� �� *FindAncestor+" ��	 5H        5I      $
 	MouseDown��6)   . 5J         .  61   �� *WeaponMouseDown+6U   5K        5L      $

 Drop��6)   . 5M         .  61   �� *
WeaponDrop+6P   5N      5P      5Q      �� 5S      $	��Top=�6   $��Сохранить��6*   ��6>   �� $ 
ButtonSave�5Y      ]� 5[   
   .+�5\      �� $	��Top=�6   $ 
Horizontal=�6.   .+�5]      �� $��Атака : ��6   $��60��6+   �� 5^      ��6   �� $ Attack�5_      �� 5`      $	��Top=�6   $ 
Horizontal=�6.   .+�5a      �� $��Защита : ��6   $��60��6,   �� 5b      ��6   �� $ Defense�5c      5d      5e      5f      