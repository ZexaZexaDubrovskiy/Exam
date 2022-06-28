using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NewsLenta.Pages
{
    /// <summary>
    /// Interaction logic for NewsPage.xaml
    /// </summary>
    public partial class NewsPage : Page
    {
        public NewsPage()
        {
            InitializeComponent();
            UpdateGrid(null);
            NewsDlgLoad(false, "");
            DataContext = this;
            newsGrid.ItemsSource = SourceCore.MyBase.News.ToList();

            kategoriesComboBox.ItemsSource = SourceCore.MyBase.Kategories.ToList(); // для комбобоккс
        }
        private int DlgMode = -1;
        public Base.News SelectedNews;
        public ObservableCollection<Base.News> News;

        private void UpdateGrid(Base.News news)
        {
            if (news == null && newsGrid.ItemsSource != null) news = (Base.News)newsGrid.SelectedItem;
            ObservableCollection<Base.News> newss = new ObservableCollection<Base.News>(SourceCore.MyBase.News);
            newsGrid.ItemsSource = newss;
            newsGrid.SelectedItem = news;
            //для комбобокса
            kategoriesComboBox.ItemsSource = SourceCore.MyBase.Kategories.ToList();
        }
        public void NewsDlgLoad(bool b, string DlgModeContent)
        {
            if (b == true)
            {
                newsColumnChange.Width = new GridLength(400);
                newsGrid.IsHitTestVisible = false;
                newsDoingLabel.Content = DlgModeContent;
                AddCommitButton.Content = DlgModeContent; //chto eto&
                addNews.IsEnabled = false;
                copyNews.IsEnabled = false;
                editNews.IsEnabled = false;
                deleteNews.IsEnabled = false;
            }
            else
            {
                newsColumnChange.Width = new GridLength(0);
                newsGrid.IsHitTestVisible = true;
                addNews.IsEnabled = true;
                copyNews.IsEnabled = true;
                editNews.IsEnabled = true;
                deleteNews.IsEnabled = true;
                DlgMode = -1;
            }
        }
        //hz
        private void deleteNews_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {

                try
                {
                    // Ссылка на удаляемую Accessory
                    Base.News DeletingNews = (Base.News)newsGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (newsGrid.SelectedIndex < newsGrid.Items.Count - 1)
                    {
                        newsGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (newsGrid.SelectedIndex > 0) newsGrid.SelectedIndex--;
                    }
                    Base.News SelectingNews = (Base.News)newsGrid.SelectedItem;
                    SourceCore.MyBase.News.Remove(DeletingNews);
                    SourceCore.MyBase.SaveChanges();
                    UpdateGrid(SelectingNews);
                }
                catch
                {

                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }
        //hz
        private void editNews_Click(object sender, RoutedEventArgs e)
        {
            if (newsGrid.SelectedItem != null)
            {
                NewsDlgLoad(true, "Изменить Аксекссуар");
                SelectedNews = (Base.News)newsGrid.SelectedItem;
                //text
                newsDisctiptions.Text = SelectedNews.descriptions;
                newsFullText.Text = SelectedNews.full_text;
                newsDateMake.Text = SelectedNews.date_make.ToString();
                newsDateUpdate.Text = SelectedNews.date_update.ToString();
                //combo
                kategoriesComboBox.Text = SelectedNews.Kategories.name_kategory;

            }
            else MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
        }
        //yes
        private void copyNews_Click(object sender, RoutedEventArgs e)
        {
            if (newsGrid.SelectedItem != null)
            {
                NewsDlgLoad(true, "Копировать Аксекссуар");
                SelectedNews = (Base.News)newsGrid.SelectedItem;
                //text
                newsDisctiptions.Text = SelectedNews.descriptions;
                newsFullText.Text = SelectedNews.full_text;
                newsDateMake.Text = SelectedNews.date_make.ToString();
                newsDateUpdate.Text = SelectedNews.date_update.ToString();
                //combo
                kategoriesComboBox.Text = SelectedNews.Kategories.name_kategory;

                DlgMode = 0;
            }
            else MessageBox.Show("Не выбрано ниодной строки!", "Сообщение", MessageBoxButton.OK);
        }
        //yes
        private void addNews_Click(object sender, RoutedEventArgs e)
        {
            NewsDlgLoad(true, "добавить новость");
            DataContext = null;
            DlgMode = 0;
        }
        //вообще не трогай
        public Boolean Proverka()
        {
            //StringBuilder errors = new StringBuilder();
            //if (string.IsNullOrEmpty(AccessoryTextAccName.Text))
            //    errors.AppendLine("Укажите название AccName");
            //if (int.TryParse(AccessoryTextVAT.Text, out int number))
            //{
            //    if (int.Parse(AccessoryTextVAT.Text) < 0 || int.Parse(AccessoryTextVAT.Text) > 1)
            //        errors.AppendLine("значение должно быть <= x <= 1");
            //}

            //if (errors.Length > 0)
            //{
            //    MessageBox.Show(errors.ToString());
            //    return false;
            //}
            return true;
        }
        private void AddCommitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Proverka())
                return;

            if (DlgMode == 0)
            {
                var NewNews = new Base.News();
                DateTime.TryParse(newsDateMake.Text, out DateTime date1);
                DateTime.TryParse(newsDateUpdate.Text, out DateTime date2);
                //text
                NewNews.descriptions = newsDisctiptions.Text;
                NewNews.full_text = newsFullText.Text;
                NewNews.date_make = date1;
                NewNews.date_update = date2;

                //ComboBox
                NewNews.Kategories = kategoriesComboBox.SelectedItem as Base.Kategories;
                SourceCore.MyBase.News.Add(NewNews);
                SelectedNews = NewNews;
            }
            else
            {
                var EditNews = new Base.News();
                DateTime.TryParse(newsDateMake.Text, out DateTime date1);
                DateTime.TryParse(newsDateUpdate.Text, out DateTime date2);
                EditNews = SourceCore.MyBase.News.First(p => p.news_id == SelectedNews.news_id);
                EditNews.descriptions = newsDisctiptions.Text;
                EditNews.full_text = newsFullText.Text;
                EditNews.date_make = date1;
                EditNews.date_update = date2;
            }
            try
            {
                SourceCore.MyBase.SaveChanges();
                NewsDlgLoad(false, "");
                UpdateGrid(SelectedNews);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewsDlgLoad(false, "");
            UpdateGrid(SelectedNews);
        }




        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                Columns.Add(newsGrid.Columns[i].Header.ToString());
            }
            newsComboBox.ItemsSource = Columns;
            newsComboBox.SelectedIndex = 0;

            // Запрет на управление сортировкой щелчком по заголовку столбца
            foreach (DataGridColumn Column in newsGrid.Columns)
            {
                Column.CanUserSort = false;
            }
        }

        private void newsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            switch (newsComboBox.SelectedIndex)
            {
                case 0:
                    newsGrid.ItemsSource = SourceCore.MyBase.News.Where(q => q.descriptions.Contains(textbox.Text)).ToList();
                    break;
                case 1:
                    newsGrid.ItemsSource = SourceCore.MyBase.News.Where(q => q.full_text.Contains(textbox.Text)).ToList();
                    break;
                case 2:
                    newsGrid.ItemsSource = SourceCore.MyBase.News.Where(q => q.date_make.ToString().Contains(textbox.Text)).ToList();
                    break;
                case 3:
                    newsGrid.ItemsSource = SourceCore.MyBase.News.Where(q => q.date_update.ToString().Contains(textbox.Text)).ToList();
                    break;
            }
        }
    }
}
