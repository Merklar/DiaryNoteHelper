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

namespace DiaryNoteHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private string imgFileAdress;

        private List<Label> Labels = new List<Label>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImgDrop_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    imgFileAdress = file.ToString();
                }
            }
            
            try
            {
                Uri uri             = new Uri(imgFileAdress);
                BitmapImage bitmap  = new BitmapImage(uri);
                ImgContainer.Source = bitmap;
            }
            catch
            {

            }
        }

        private void CreateTextLabel()
        {
            Label label = new Label();
            label.Content = "Label " + Labels.Count + 1;
            Labels.Add(label);
        }

        private void CreateLblBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateTextLabel();
        }
    }
}
