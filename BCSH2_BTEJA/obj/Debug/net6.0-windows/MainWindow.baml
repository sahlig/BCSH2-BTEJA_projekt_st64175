   M S B A M L   `   `   `  ????F  BBCSH2_BTEJA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BCSH2_BTEJABCSH2_BTEJA  5   	   3clr-namespace:BCSH2_BTEJA.ViewBCSH2_BTEJA.View  5   	   =#clr-namespace:BCSH2_BTEJA.ViewModelBCSH2_BTEJA.ViewModel  5   	   5clr-namespace:BCSH2_BTEJA.ModelBCSH2_BTEJA.Model  5	   	       BCSH2_BTEJA.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BCSH2_BTEJA     5   	   0viewsclr-namespace:BCSH2_BTEJA.View     5   	   9	viewModel#clr-namespace:BCSH2_BTEJA.ViewModel     5   	   1Modelclr-namespace:BCSH2_BTEJA.Model     5	   	     ? Title$  
MainWindow??5   	   $	??709??6   $
??1067??6)   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??40* ?6   ?? 5      $
??128* ?6   ?? 5      $
??377* ?6   ?? 5      $
??522* ?6   .+?5   
   ?? -   5         ??Name$ TextView??5      $
??Left=?6$   $??
10,173,0,0q?6?    ?? TextWrapping$
 Wrap=?6S   $	??Top=?6?   $	??301??6?   
???   ?
???????$	??509??6?   $??3??6?   ??6g   ?? *Input+ ?? Mode$ TwoWay=?6?   ?? 5   
   -   5         ??Name$ 
LoadButton??5      $??1??6%   $??Nahrát soubor??65   $
??Left=?6m   $??	10,26,0,0q?6?   $	??Top=?6?   $??2??6?   $??34??6?   $	??131??6?   ??6M   ?? *LoadCommand+6?   ?? 5   
   -   5        $ 
SaveButton??5      $??1??6%   $??Uložit do souboru??65   $
??Left=?6q   $??	10,77,0,0q?6?   $	??Top=?6?   $??34??6?   $	??131??6?   $??2??6?   ??6Q   ?? *SaveCommand+6?   ?? 5   
   -   5        $ StartButton??5      $??2??6&   $??Start??66   $
??Left=?6g   $??
266,43,0,0q?6?   $	??Top=?6?   $??2??6?   $??56??6?   $	??158??6?   ??6F   ?? *StartCommand+6?       BCSH2_BTEJA.View.TokenView  5   
   -   5          Name$ TokenViewControl??5      $??2??66   $??366,189,345,27q?6F   $??2??6^   ?? 5   
   $
??Left=?6   $??-160,516,0,0q?6.   $	??Top=?6D   $	??120??6\   "   BCSH2_BTEJA.View.MessageView  5   
   -   5          Name$ MessageViewControl??5      $??2??6:   $??148,189,19,27q?6J   !   BCSH2_BTEJA.View.OutputView  5   
   -   5          Name$ OutputViewControl??5      $??3??68   $??182,189,43,27q?6H   5      5      