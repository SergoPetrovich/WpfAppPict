using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Emgu;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;


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
