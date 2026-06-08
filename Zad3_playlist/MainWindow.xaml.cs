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

namespace Zad3_playlist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Playlist pl = new Playlist(); //Новый плейлист

        public MainWindow()
        {
            InitializeComponent();
            Show();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) //Кнопка добавить
        {
            pl.AddSong(txtAuthor.Text, txtTitle.Text, "");  // Добавляем песню из текстовых полей
            txtAuthor.Text = "";
            txtTitle.Text = "";
            Show(); // Обновляем экран
        }

        private void BtnPred_Click(object sender, RoutedEventArgs e) //Кнопка предыдущая
        {
            pl.PredSong(); // Уменьшаем индекс текущей песни на 1
            Show();
        }

        private void BtnSled_Click(object sender, RoutedEventArgs e) //Кнопка следующая
        {
            pl.SledSong(); // Увеличиваем индекс текущей песни на 1
            Show();
        }

        private void BtnVNachalo_Click(object sender, RoutedEventArgs e) // Кнопка в начало
        {
            pl.GoVNachalo(); // Устанавливаем индекс текущей песни в 0
            Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) // Кнопка удалить
        {
            // Если в списке выбрана какая-то песня
            if (lstSongs.SelectedItem != null)
            {
                Song selected = (Song)lstSongs.SelectedItem; // Получаем выбранную песню
                pl.RemoveSong(selected); // Удаляем её из плейлиста
                Show();
            }
            // Если ничего не выбрано но песни есть то удаляем текущую песню
            else if (pl.Count() > 0)
            {
                pl.RemoveAt(pl.CurrentIndex()); // Удаляем песню по текущему индексу
                Show();
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e) //Кнопка очистить
        {
            pl.Clear(); // Очищаем весь список песен
            Show();
        }

        private void Vibor(object sender, System.Windows.Controls.SelectionChangedEventArgs e) //Нопка выбора песен в списке
        {
            // Если выбран какой-то элемен
            if (lstSongs.SelectedIndex >= 0)
                pl.GoToIndex(lstSongs.SelectedIndex); // Переключаемся на выбранную песню
            Show();
        }

        private void Show() //метод обноваления экрана
        {
            lstSongs.ItemsSource = null; // Очищаем список
            lstSongs.ItemsSource = pl.GetAll(); // Загружаем свежий список песен из плейлиста

            if (pl.Count() > 0)// Если в плейлисте есть песни
            {
                txtCurrentSong.Text = pl.Current().Author + " - " + pl.Current().Title;  // Показываем текст "Автор - Название"
            }  
            else // Если плейлист пуст
            {
                txtCurrentSong.Text = "Нет песен";
            }
            txtInfo.Text = "Песен: " + pl.Count() + "  Индекс: " + pl.CurrentIndex(); //обнова инф строки
        }
    }
}

