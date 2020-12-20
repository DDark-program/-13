using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibMas
{
    public class Mass
    {
        /// <summary>
        /// Заполнение двухмерного массива случайными числами
        /// </summary>
        /// <param name="matr"></param>
        public static void FillMatr(DataGridView matr)
        {
            Random rnd = new Random();

            for(int j = 0; j < matr.RowCount; j++)
            {
                for(int i = 0; i < matr.ColumnCount; i++)
                {
                    matr[i, j].Value = rnd.Next(-10, 10);
                }
            }
        }
        /// <summary>
        /// Очищение двухмерного массива
        /// </summary>
        /// <param name="matr"></param>
        public static void ClearMatr(DataGridView matr)
        {
            for (int j = 0; j < matr.RowCount; j++)
            {
                for (int i = 0; i < matr.ColumnCount; i++)
                {
                    matr[j, i].Value = null;
                }
            }
        }
        /// <summary>
        /// Сохранение двухмерного массива в файл
        /// </summary>
        /// <param name="mas">сохраняемый одномерный массив</param>
        /// <param name="path">путь к файлу</param>
        public static void SaveMatr(DataGridView matr)
        {
            //Создание объекта диалогового окна для сохранения
            SaveFileDialog save = new SaveFileDialog();

            //Установка стандартных свойств
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            //Если пользователь нажал ОК
            if (save.ShowDialog() == DialogResult.OK)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamWriter file = new StreamWriter(save.FileName);

                //Записываем размер матрицы в файл
                file.WriteLine(matr.ColumnCount);
                file.WriteLine(matr.RowCount);

                //Записываем элемент массива в файл
                for (int j = 0; j < matr.RowCount; j++)
                {
                    for (int i = 0; i < matr.ColumnCount; i++)
                    {
                        file.WriteLine(matr[i, j].Value);
                    }
                }
                file.Close();
            }
        }
        /// <summary>
        /// Открытие двухмерного масиива из файла
        /// </summary>
        /// <param name="mas">открываемый одномерный массив</param>
        /// <param name="path">путь к файлу</param>
        public static void OpenMatr(DataGridView matr)
        {
            OpenFileDialog open = new OpenFileDialog();
            //Установка стандартных свойств
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            //Если пользователь нажал ОК
            if (open.ShowDialog() == DialogResult.OK)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamReader file = new StreamReader(open.FileName);
                matr.ColumnCount = Convert.ToInt32(file.ReadLine());
                for (int j = 0; j < matr.RowCount; j++)
                {
                    for (int i = 0; i < matr.ColumnCount; i++)
                    {
                        matr[i, j].Value = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }
        }
        public static int TaskMatr(DataGridView matr)
        {
            int global_max = 0;//Глобальный счетчик
            int first_column = 0;//Счетчик для вывода строки содержащую макс одинаковых элементов
            for (int i = 0; i < matr.ColumnCount; i++)
            {
                int max = 0;//Счетчик максимального количества одинаковых элементов

                for (int num = -11; num < 11; num++)// прогоняем переменную num от 0 до 9
                {
                    int temp_max = 0;//Временные счетчик наибольшох значений из полученных количеств
                    for (int j = 0; j < matr.RowCount; j++)
                    {
                        if ((int)matr[i, j].Value == num)// рассчитываем количество чисел num в i-й колонке и выбираем наибольшее из полученных количеств
                        {
                            temp_max++;
                        }
                    }
                    if (temp_max > max)
                    {
                        max = temp_max;// сохраняем в переменную max
                    }
                }
                if (max > global_max)
                {
                    global_max = max;
                    first_column = i++;
                }
            }
            return first_column;
        }
    }
}