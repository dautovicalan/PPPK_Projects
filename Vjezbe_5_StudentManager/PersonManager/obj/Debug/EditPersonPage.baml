   M S B A M L   `   `   `  ����B  >Zadatak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ZadatakZadatak  5          Zadatak.EditPersonPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Zadatak     5        N� Title$  EditPage��5	      .��5      � -   5         �Name$ GridContainter��5   <      GradientBackground#��[  6   .+�5   
   �� -   5         ��Name$ BtnBack��5      
������ 
������ $
��Left=�5      $	��Top=�5      $��25��5      $��25��5      $��30q�5      .��5      �� $��/Assets/back.png��6   5      �� 5   
   $��First name:��5      $
��Left=�5      $��	57,89,0,0q�5      $	��Top=�5      ���	#FFF6F9FE5      �� 5    
   -   5         ��Name$ TbFirstName��5!      $
��Left=�5"      $��23��5#      $��
134,88,0,0q�5$       �� TextWrapping$
 Wrap=�5%      $	��Top=�5'      $	��171��6%   ��5&      �� *	FirstName+5'   %   �� 5)   
   $��
Last Name:��5*      $
��Left=�5+      $��
57,133,0,0q�5,      $	��Top=�5-      ���	#FFF6F9FE5.      �� 50   
   -   5        $ 
TbLastName��51      $
��Left=�52      $��23��53      $��134,134,0,0q�54      $
 Wrap=�55      $	��Top=�57      $	��171��6%   ��56      �� *
LastName+57   %   �� 59   
   $��Year of study��5:      $
��Left=�5;      $��
57,187,0,0q�5<      $	��Top=�5=      ���	#FFF6F9FE5>      �� 5@   
   -   5        $ TbAge��5A      $
��Left=�5B      $��23��5C      $��267,187,0,0q�5D      $
 Wrap=�5E      $	��Top=�5G      $��38��5H      
 � Tag$	 Int��5I      ��5F      �� *Age+5I      �� 5K   
   $��Email��5L      $
��Left=�5M      $��
57,235,0,0q�5N      $	��Top=�5O      ���	#FFF6F9FE5P      �� 5R   
   -   5        $ TbEmail��5S      $
��Left=�5T      $��23��5U      $��134,235,0,0q�5V      $
 Wrap=�5W      $	��Top=�5Y      $	��171��5Z      $ Email��5[      ��5X      �� *Email+5[      �� 5]   
   -   5        $ 	BtnCommit��5^      $��Commit��5_      $
��Left=�5`      $	��Top=�5a      $��75��5b      
����������#13242C$��
86,322,0,0q�5f      �� 5h   
   -   5        $ 	BtnUpload��5i      $��Upload Image��5j      $
��Left=�5k      $	��Top=�5l      $	��106��5m      
�������
��� ���$��199,322,0,0q�5q      �� 5s   
   -	   5         ��Name$ PictureBorder��5t      
�������$	��0.3q�5v      $��Right=�5w      $	��Top=�5x      $��	0,79,48,0q�6%   ._�5y      �� -
   5         ��Name$ Picture��5z      $��Uniform=�5{      $	��198��5|      $	��252��5}      ��5~      �� *Image+5�      5�      5�      