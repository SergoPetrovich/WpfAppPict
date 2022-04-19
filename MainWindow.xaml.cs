using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;


namespace WpfAppPict
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileUri = string.Empty;
        private string filePath = string.Empty;
        //private string lang = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
               Uri fileUri = new Uri(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
                img.Source = new BitmapImage(fileUri);
            }
        }

        private void RecogTextBtn_Click(object sender, RoutedEventArgs e)
        {
            Tesseract tesseract = new Tesseract(@"C:\Users\SP\Documents\testdata", "rus", OcrEngineMode.TesseractLstmCombined);
            tesseract.SetImage(new Image<Bgr, byte>(filePath));
          //  tesseract.SetImage(new Image<Bgr, byte>(fileUri));

            tesseract.Recognize();

            TextBl.Text = tesseract.GetUTF8Text();

            tesseract.Dispose();

        }
    }
}
