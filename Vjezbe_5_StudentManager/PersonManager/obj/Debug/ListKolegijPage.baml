   M S B A M L   `   `   `  ����B  >Zadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ZadatakZadatak  5          Zadatak.ListKolegijPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Zadatak     5        N� Title$  ListKolegijPage��5	      .��5      �    GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ 	LvKolegij��5   (   $��28,54,26,69q�6    �� AlternationCount$ 2��6;   ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � �� �� Value
 ��ح�63    �� Triggers 5      P� 5       P� Property �@��AlternationIndex P� Value$ 1��6G   . �5      ��  � ��
 �����6;   5      ]� 5      	 ]� 
Conditions	 5      �� 5   "   
 �� Property
 �@��
IsSelected �� Value . 6B   ./�5      ��  � ��
 ���_�6;   5      5       �� View 5      �� 5      .P�5       ��  �� Width$	 126��6%   $��	IDKolegij��61    �� DisplayMemberBinding 6D   �� *	IDKolegij+�� 5!      $	 126��6%   $��KolegijName��61    6F   �� *KolegijName+�� 5"      $	 126��6%   $��
ProfesorID��61    6E   �� *
ProfesorID+5#      5%      �� 5'   
   -   5         ��Name$ BtnEdit��5(      $
��Edit��5)      $
��Left=�5*      $	��Top=�5+      $��75��5,      
����������#13242C J� RenderTransformOrigin$ 1.101,3.807&�5/   #   $��473,408,0,0q�6G   �� 50   
   -   5        $ 	BtnDelete��51      $��Delete��52      $
��Left=�53      $	��Top=�54      $��75��55      
����������	#FFD41B43$ 1.101,3.807&�58   %   $��593,408,0,0q�6I   �� 59   
   -   5        $ BtnAdd��5:      $	��Add��5;      $
��Left=�5<      $	��Top=�5=      $��75��5>      
����������	#FF246844$ 1.101,3.807&�5A   "   $��352,408,0,0q�6F   5C      5D      