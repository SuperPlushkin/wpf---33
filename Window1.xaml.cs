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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private List<string> images;
        private int currentIndex = 0;
        public Window1()
        {
            InitializeComponent();
            LoadAllImages(AppDomain.CurrentDomain.BaseDirectory + "IMAGES");
            DisplayImage();
        }
        private void LoadAllImages(string path)
        {
            if(Directory.Exists(path))
            {
                images = new List<string>(Directory.GetFiles((path), "*.jpeg"));
                images.AddRange(Directory.GetFiles((path), "*.gif"));
                images.AddRange(Directory.GetFiles((path), "*.jpg"));
                images.AddRange(Directory.GetFiles((path), "*.png"));
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void DisplayImage()
        {
            if (images == null || images.Count == 0)
            {
                MessageBox.Show("There are no images to show");
                return;
            }
            var imagePath = images[currentIndex];
            DisplayImageForm.Source = new BitmapImage(new Uri(imagePath));
        }
        private void MenuItemClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MenuItem_NextImg(object sender, RoutedEventArgs e)
        {
            if (currentIndex < images.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
            DisplayImage();
        }
        private void MenuItem_PrevImg(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = images.Count - 1;
            }
            DisplayImage();
        }
    }
}
