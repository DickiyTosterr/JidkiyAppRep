   M S B A M L   `   `   `  ????D  @jidkiyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:jidkiyApp.PagesjidkiyApp.Pages  5          jidkiyApp.Pages.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:jidkiyApp.Pages     5      -   5          N? Title$  	OrderPage??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ?? .+?5      ?? -   5         ??Name$ 	CBProduct??5       ?? DisplayMemberPath$
 Name??6*   ??6C   ?? *	Product+?? 5      -   5         ??Name$ AddBtn??5      $	??Add??6%   63   ?? 5      -   5        $ DelBtn??5      $??Delete??6%   66   ?? 5      -   5        $ SaveBtn??5      $
??Save??6&   65   ?? 5      -   5        $ 
DelGoodBtn??5      $??Delete Good??6)   6?   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	DGProduct??5       $??1??6      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Наименование??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   ?? *Product.Name+  5      $
 Цена??6%    63   ?? *Product.Price+5      5      5      