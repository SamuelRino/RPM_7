using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPM_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Clone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ShallowClone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddToCollection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_SortCollection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ClearCollection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ShowVolume_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ShowInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Compare_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cb_FigureType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pnl_Ball == null || pnl_Parallelepiped == null) return;

            switch (cb_FigureType.SelectedIndex)
            {
                case 0:
                    pnl_Ball.Visibility = Visibility.Collapsed;
                    pnl_Parallelepiped.Visibility = Visibility.Visible;
                    break;
                case 1:
                    pnl_Parallelepiped.Visibility = Visibility.Collapsed;
                    pnl_Ball.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}