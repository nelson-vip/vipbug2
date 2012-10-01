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

using Emgu.CV;
using Emgu.CV.Structure;
using CamRecord2;
using AForge.Video;
using System.Drawing;
using AForge.Imaging.Filters;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using WPFSpark;


namespace vipbug2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SparkWindow
    {
        public MainWindow()
        {
            //*
            modules.RemoveAll(String.IsNullOrEmpty);
            for (int i = 0; i < modules.Count; ++i)
                modules[i] = String.Format("{0}.dll", modules[i]);
            CvInvoke.LoadUnmanagedModules(null, modules.ToArray());
            //*/
            String login = "viplab";
            String password = "leeg104";
            
            InitializeComponent();
            camControl = new Ipcam(this.Width, this.Height, login, password);
            if (!ipcStream.IsRunning)
            {
                ipcStream.Source = "http://" + "140.122.184.227" + "/nphMotionJpeg?Resolution=" + Width + "x" + Height + "&Quality=Clarity";
                ipcStream.Login = login;
                ipcStream.Password = password;
                ipcStream.NewFrame += new NewFrameEventHandler(newVideoFrame);
                ipcStream.Start();
            }

        }

        public void newVideoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //ResizeBilinear filter2 = new ResizeBilinear(400, 288);
            // Image<Bgr, Byte> BgrImg = new Image<Bgr, Byte>(filter2.Apply(ipcFrame));

            ipcFrame = (Bitmap)eventArgs.Frame.Clone();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream ms = new MemoryStream();
            ipcFrame.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();

            //Using the freeze function to avoid cross thread operations 
            bi.Freeze();

            //Calling the UI thread using the Dispatcher to update the 'Image' WPF control         
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                labcamCanvas.Source = bi; /*frameholder is the name of the 'Image' WPF control*/
            }));     

        }

        private void emgu_Initialized(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = new Image<Bgr, byte>(400, 100, new Bgr(255, 255, 255));
            MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_PLAIN, 3.0, 3.0);
            image.Draw("Hello, world", ref f, new System.Drawing.Point(10, 50), new Bgr(255.0, 0.0, 0.0));

            labcamCanvas.Source = BitmapSourceConvert.ToBitmapSource(image);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ipcStream.Stop();
        }
    }

   
}
