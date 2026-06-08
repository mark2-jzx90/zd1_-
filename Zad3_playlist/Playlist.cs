using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3_playlist
{
    public class Playlist
    {
        // поля класа
        List<Song> list = new List<Song>(); // Список для хранения всех песен
        int index = 0;

        // добавление песни (перегрузка 1)
        
        public void AddSong(string author, string title, string file)
        {
            Song s;              // временная переменная для песни
            s.Author = author;   // автора
            s.Title = title;     // название
            s.Filename = file;   // путь к файлу
            list.Add(s);         // Добавляем готовую песню в список
        }

        //  добавление песни (перегрузка 2 - готовой структурой) 
        public void AddSong(Song s)
        {
            list.Add(s); // добавляем песню в список
        }

        // След песня
        public void SledSong()
        {
            // список не пуст И мы не в конце списка
            if (list.Count > 0 && index < list.Count - 1)
                index++; // Увеличиваем индекс на 1
        }

        // пред песня
        public void PredSong()
        {
            // список не пуст И мы не в начале списка
            if (list.Count > 0 && index > 0)
                index--; // Уменьшаем индекс на 1
        }

        // переход по индексу
        public void GoToIndex(int i)
        {
            // Проверяем что индекс существует
            if (i >= 0 && i < list.Count)
                index = i; // Устанавливаем новый индекс
        }

        // переход в начало
        public void GoVNachalo()
        {
            index = 0; // Просто ставим индекс на 0
        }

        // удаление по индексу
        public void RemoveAt(int i)
        {
            // Проверяем что индекс существует
            if (i >= 0 && i < list.Count)
            {
                list.RemoveAt(i); // Удаляем песню из списка

                // Если список стал пустым
                if (list.Count == 0)
                    index = 0; // Сбрасываем индекс в 0

                // Если текущий индекс стал больше размера списка
                else if (index >= list.Count)
                    index = list.Count - 1; // Ставим индекс на последнюю песню
            }
        }

        // удаление по значению   
        public void RemoveSong(Song s)
        {
            // Проходим по всему списку от начала до конца
            for (int i = 0; i < list.Count; i++)
            {
                // Сравниваем автора и название с искомой песней
                if (list[i].Author == s.Author && list[i].Title == s.Title)
                {
                    RemoveAt(i); // Нашли - удаляем по индексу
                    break;  // Выходим из цикла
                }
            }
        }

        // очистка плейлиста
        public void Clear()
        {
            list.Clear();
            index = 0;
        }

        // получить текущую песню
        public Song Current()
        {
            return list[index]; // Возвращаем песню из списка по текущему индексу
        }

        //Получить все песни
        public List<Song> GetAll()
        {
            return list; // Возвращаем полный список
        }
        // Получить кол-во песен
        public int Count()
        {
            return list.Count; // Возвращаем размер списка
        }

        // получить тек индекс
        public int CurrentIndex()
        {
            return index; // Возвращаем значение индекса
        }
    }
}
