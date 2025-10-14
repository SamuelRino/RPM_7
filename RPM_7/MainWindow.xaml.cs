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
using RPM_7_library;

namespace RPM_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Parallelepiped p;
        Ball b;
        List<IFigure> figures;
        IFigure currentFig;

        public MainWindow()
        {
            InitializeComponent();
            p = new Parallelepiped();
            b = new Ball();
            figures = new List<IFigure>();
            currentFig = p;
            pOutPut();
            bOutPut();
            UpdateCurrentFigureInfo();
            UpdateStatistics();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (cb_FigureType.SelectedIndex)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(tb_Length.Text) && !string.IsNullOrEmpty(tb_Width.Text) && !string.IsNullOrEmpty(tb_Height.Text))
                        {
                            int length = Convert.ToInt32(tb_Length.Text);
                            int width = Convert.ToInt32(tb_Width.Text);
                            int height = Convert.ToInt32(tb_Height.Text);

                            p = new Parallelepiped(length, width, height);
                            currentFig = p;
                            pOutPut();
                        }
                        else MessageBox.Show("Заполните поля");
                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(tb_Radius.Text))
                        {
                            int radius = Convert.ToInt32(tb_Radius.Text);

                            b = new Ball(radius);
                            currentFig = b;
                            bOutPut();
                        }
                        break;
                }
                UpdateCurrentFigureInfo();
            }
            catch { }
        }

        private void Btn_Clone_Click(object sender, RoutedEventArgs e)
        {
            if (currentFig != null)
            {
                try
                {
                    if (currentFig is Parallelepiped)
                    {
                        p = (Parallelepiped)((Parallelepiped)currentFig).Clone();
                        currentFig = p;
                        pOutPut();
                    }
                    else if (currentFig is Ball)
                    {
                        b = (Ball)((Ball)currentFig).Clone();
                        currentFig = b;
                        bOutPut();
                    }
                    UpdateCurrentFigureInfo();
                    MessageBox.Show("Фигура успешно клонирована (глубокое клонирование)", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка клонирования: {ex.Message}", "Ошибка");
                }
            }
        }

        private void Btn_ShallowClone_Click(object sender, RoutedEventArgs e)
        {
            if (currentFig != null)
            {
                try
                {
                    if (currentFig is Parallelepiped)
                    {
                        p = ((Parallelepiped)currentFig).ShallowClone();
                        currentFig = p;
                        pOutPut();
                    }
                    else if (currentFig is Ball)
                    {
                        b = ((Ball)currentFig).ShallowClone();
                        currentFig = b;
                        bOutPut();
                    }
                    UpdateCurrentFigureInfo();
                    MessageBox.Show("Фигура успешно клонирована (поверхностное клонирование)", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка клонирования: {ex.Message}", "Ошибка");
                }
            }
        }

        private void Btn_AddToCollection_Click(object sender, RoutedEventArgs e)
        {
            if (currentFig != null)
            {
                try
                {
                    if (currentFig is Parallelepiped)
                    {
                        figures.Add(new Parallelepiped(p.Length, p.Width, p.Height));
                    }
                    else if (currentFig is Ball)
                    {
                        figures.Add(new Ball(b.Radius));
                    }

                    UpdateFiguresList();
                    UpdateStatistics();
                    MessageBox.Show("Фигура добавлена в коллекцию", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка добавления в коллекцию: {ex.Message}", "Ошибка");
                }
            }
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
                    currentFig = p;
                    UpdateCurrentFigureInfo();
                    break;
                case 1:
                    pnl_Parallelepiped.Visibility = Visibility.Collapsed;
                    pnl_Ball.Visibility = Visibility.Visible;
                    currentFig = b;
                    UpdateCurrentFigureInfo();
                    break;
            }
        }

        private void NumberOnlyTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Back || e.Key == Key.OemMinus)
            {
                return;
            }
            e.Handled = true;
        }

        private void pOutPut()
        {
            tb_Length.Text = p.Length.ToString();
            tb_Width.Text = p.Width.ToString();
            tb_Height.Text = p.Height.ToString();
        }

        private void bOutPut()
        {
            tb_Radius.Text = b.Radius.ToString();
        }

        private void UpdateCurrentFigureInfo()
        {
            if (currentFig != null)
            {
                tbl_CurrentFigureInfo.Text = currentFig.GetInfo();
            }
        }

        private void UpdateFiguresList()
        {
            lbox_Figures.ItemsSource = null;
            lbox_Figures.ItemsSource = figures;
        }

        private void UpdateStatistics()
        {
            int parallelepipedsCount = figures.Count(f => f is Parallelepiped);
            int ballsCount = figures.Count(f => f is Ball);

            tbl_Statistics.Text = $"Всего фигур: {figures.Count}\n" + $"Параллелепипедов: {parallelepipedsCount}\n" + $"Шаров: {ballsCount}";
        }
    }
}