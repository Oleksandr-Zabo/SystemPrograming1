using System.Diagnostics;
        using System.Windows;
        using System.Windows.Controls;
        
        namespace WpfOpenPrograms.Pages
        {
            public partial class Select : UserControl
            {
                public Select()
                {
                    InitializeComponent();
                }
        
                private void OpenPaint(object sender, RoutedEventArgs e)
                {
                    try
                    {
                        Process.Start(@"C:\Windows\System32\mspaint.exe");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error: " + exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
        
                private void OpenNotepad(object sender, RoutedEventArgs e)
                {
                    Process.Start(@"C:\Windows\System32\notepad.exe");
                }
        
                private void OpenCalculator(object sender, RoutedEventArgs e)
                {
                    Process.Start(@"C:\Windows\System32\calc.exe");
                }

                private void OpenExploler(object sender, RoutedEventArgs e)
                {
                    Process.Start(@"C:\Windows\explorer.exe");
                }
            }
        }