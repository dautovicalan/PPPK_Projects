   M S B A M L   `   `   `  ����B  >Zadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ZadatakZadatak  5          Zadatak.ListProfesorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Zadatak     5        N� Title$  ListProfesorPage��5	      .��5      �    GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ LvPeople��5   (   $��28,54,26,69q�6    �� AlternationCount$ 2��6:   ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � �� �� Value
 ��ح�63    �� Triggers 5      P� 5       P� Property �@��AlternationIndex P� Value$ 1��6G   . �5      ��  � ��
 �����6;   5      ]� 5      	 ]� 
Conditions	 5      �� 5   "   
 �� Property
 �@��
IsSelected �� Value . 6B   ./�5      ��  � ��
 ���_�6;   5      5       �� View 5      �� 5      .P�5       ��  �� Width$	 126��6%   $��	FirstName��61    �� DisplayMemberBinding 6D   �� *	FirstName+�� 5!      $	 126��6%   $��LastName��61    6C   �� *
LastName+�� 5"      $	 126��6%   $��Email��61    �� CellTemplate 5#      �� 5$      .R�5%   "   �� $��	Underline{�6C   
���   � � Cursor$
 Hand��6r   ��6,   �� *Email+ � ToolTip 5&   &   �� 5'   *    ��Name$ Picture��60   $��60��6Z   $��60��6e   $��0,0,5,0q�6q   ��6A   �� *Image+6q   5)   #   5*      5,      5-      5/      �� 51   
   -   5         ��Name$ BtnEdit��52      $
��Edit��53      $
��Left=�54      $	��Top=�55      $��75��56      
����������#13242C J� RenderTransformOrigin$ 1.101,3.807&�59   #   $��546,404,0,0q�6G   �� 5:   
   -   5        $ 	BtnDelete��5;      $��Delete��5<      $
��Left=�5=      $	��Top=�5>      $��75��5?      
����������	#FFD41B43$ 1.101,3.807&�5B   %   $��656,404,0,0q�6I   �� 5C   
   -   5        $ BtnAdd��5D      $	��Add��5E      $
��Left=�5F      $	��Top=�5G      $��74��5H      
����������	#FF246844$ 1.101,3.807&�5K   "   $��440,404,0,0q�6F   5M      5N      