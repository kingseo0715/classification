using OpenCvSharp;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tesseract;

namespace Classification_server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReceiveImageSocket();
            
        }

        private async void ReceiveImageSocket()
        {

            await Task.Run(() =>
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 9000); ;
                listener.Start();

                while (true)
                {
                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] lengthBytes = new byte[4];
                        stream.Read(lengthBytes, 0, 4);
                        int imageLength = BitConverter.ToInt32(lengthBytes, 0);

                        byte[] imageBytes = new byte[imageLength];
                        int totalRead = 0;
                        while (totalRead < imageLength)
                        {
                            int read = stream.Read(imageBytes, totalRead, imageLength - totalRead);
                            if (read == 0) break;
                            totalRead += read;
                        }

                        File.WriteAllBytes("received_image.jpg", imageBytes);

                        Dispatcher.Invoke(() => 
                        {
                            BitmapImage image = new BitmapImage();
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = new Uri(System.IO.Path.GetFullPath("received_image.jpg"));
                            image.EndInit();
                            receiveImage.Source = image;

                        });




                        var extractor = new AddressExtractor();
                        string addressText = extractor.ExtractAddressFromImage("received_image.jpg");
                        //Console.WriteLine(">> OCR 추출결과 : \n" + addressText);

                        
                       

                        Dispatcher.Invoke(() =>
                        {
                            extractedAddressTextBlock.Text = addressText;
                           
                    
                        });
                    }
                }
                
            });
            
        }




    }
}




class AddressExtractor
{
    public string ExtractAddressFromImage(string imagePath)
    {
        // 1. 전처리
        Mat src = Cv2.ImRead(imagePath, ImreadModes.Color);

        //받는분 주소 영역만 crop
        OpenCvSharp.Rect roi = new OpenCvSharp.Rect(X: 90, Y: 100, Width: 430, Height: 160);
        Mat cropped = new Mat(src, roi);

        //전처리와 확대
        Mat gray = new Mat();
        Cv2.CvtColor(cropped, gray, ColorConversionCodes.BGR2GRAY);
        //테스트
        Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(3, 3), 0);
        Cv2.MedianBlur(gray, gray, 3);
        //테스트
        Cv2.AdaptiveThreshold(gray, gray, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 11, 5);
        Cv2.Resize(gray, gray, new OpenCvSharp.Size(), 3.0, 3.0, InterpolationFlags.Cubic);

        //Cv2.BilateralFilter(gray, gray, 9, 75, 75);
        Cv2.CopyMakeBorder(gray, gray, 10, 10, 10, 10, BorderTypes.Constant, Scalar.White);

        string tempPath = "temp_for_ocr.png";
        Cv2.ImWrite(tempPath, gray);

        // 2. OCR
        string ocrText = "";
        using (var ocr = new TesseractEngine(@"./tessdata", "kor", EngineMode.Default))
        {
            ocr.SetVariable("user_defined_dpi", "300");
            using (var img = Pix.LoadFromFile(tempPath))
            using (var page = ocr.Process(img))
            {
                ocrText = page.GetText();

                ocrText = ocrText.Replace("?=", ")-");
                ocrText = ocrText.Replace("=?", ")");
            }
        }



        var addressLines = new List<string>();
        foreach (var line in ocrText.Split('\n'))
        {
            string trimmed = line.Trim();

            if (Regex.IsMatch(trimmed, @"(서울|경기|광주|대전|대구|부산|세종|인천|충남|충북|전남|전북|경남|경북|제주)") ||
                Regex.IsMatch(trimmed, @"(로|길|구|동|번지)"))
            {
                addressLines.Add(trimmed);
            }
        }
        if (addressLines.Count == 0)
            addressLines.Add("❌ 주소를 인식하지 못했습니다.");

        return string.Join("\n", addressLines);

    }
}
