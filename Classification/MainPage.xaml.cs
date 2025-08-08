using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

namespace Classification
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }




        private void StartWork_Click(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog
            {
                Title = "이미지 선택", 
                Filter = "이미지파일 (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            };
            if (openFile.ShowDialog() == true)
            {
                try
                {

                    string imagePath = openFile.FileName;
                    
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    LoadedImage.Source = bitmap;


                    SendImageSocket(imagePath);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("이미지오류");
                }
            }


        }
        private void SendImageSocket(string imagePath) 
        {
            try
            {
                byte[] imageData = File.ReadAllBytes(imagePath);

                using (TcpClient client = new TcpClient("127.0.0.1", 9000))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] lengthBytes = BitConverter.GetBytes(imageData.Length);
                    stream.Write(lengthBytes, 0, lengthBytes.Length);

                    stream.Write(imageData, 0, imageData.Length);

                    //MessageBox.Show("이미지전송완료");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("이미지 전송 실패");
            }
            

        }


    }
}
