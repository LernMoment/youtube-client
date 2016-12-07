using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YouTubeClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Com com = new Com();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = com;
        }

        private void btnApiKey_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlgGetApiKey = new Microsoft.Win32.OpenFileDialog();
            dlgGetApiKey.ShowDialog();
            dlgGetApiKey.InitialDirectory = @"c:\Temp";
            string dateiName = dlgGetApiKey.FileName;
            lblApiKey.Content = File.ReadAllText(dateiName);
        }

        private void btnChannelId_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlgGetChannelId = new Microsoft.Win32.OpenFileDialog();
            dlgGetChannelId.ShowDialog();
            dlgGetChannelId.InitialDirectory = @"c:\Temp";
            string dateiName = dlgGetChannelId.FileName;
            lblChannelId.Content = File.ReadAllText(dateiName);
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            if ((lblApiKey.Content != null) && (lblChannelId.Content != null) )
            {
                com.VideoInfosAusUploadPlaylistHolen(lblApiKey.Content as string, lblChannelId.Content as string);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Bitte geben Sie den Api Key   u n d   die Channel ID ein!", "Achtung", 
                                                           MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        void dataCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VideoDetails videos = new VideoDetails();
            videos.Show();
            //DataGridRow row = e.Source as DataGridRow;
            //VideoDetail videoDetail = new VideoDetail((Vhs)row.Item);
            //videoDetail.Show();
        }


    }
}
