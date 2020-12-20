using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibMas;

namespace Практ_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Table.ColumnCount = 5;
            Table.RowCount = 5;
            statusStrip1.Items[0].Text = "Размер таблицы =" + " " + numericUpDownColumns.Value.ToString() + " " + "на" + " " + numericUpDownRows.Value.ToString();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            Mass.FillMatr(Table);
        }

        private void Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void numericUpDownColumns_ValueChanged(object sender, EventArgs e)
        {
            Table.ColumnCount = Convert.ToInt32(numericUpDownColumns.Value);
            statusStrip1.Items[0].Text = "Размер таблицы =" + " " + numericUpDownColumns.Value.ToString() + " " + "на" + " " + numericUpDownRows.Value.ToString();
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            Table.RowCount = Convert.ToInt32(numericUpDownRows.Value);
            statusStrip1.Items[0].Text = "Размер таблицы =" + " " + numericUpDownColumns.Value.ToString() + " " + "на" + " " + numericUpDownRows.Value.ToString();
        }

        private void Table_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            statusStrip1.Items[1].Text = "Выбрана cтрока : " + Table.CurrentCell.RowIndex.ToString() + " ," + " Столбец : " + " " + Table.CurrentCell.ColumnIndex.ToString();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Mass.SaveMatr(Table);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Mass.OpenMatr(Table);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Mass.ClearMatr(Table);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Mass.FillMatr(Table);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №11\n" +
                "Подъяблонского Данилы Владимировича\n" +
                "Задание:\n" +
                "Дана целочисленная матрица размера M * N\n" +
                "Найти номер первого из ее столбцов,содержащих максимальное количество одинаковых элементов.");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Mass.OpenMatr(Table);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Mass.ClearMatr(Table);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №11\n" +
                "Подъяблонского Данилы Владимировича\n" +
                "Задание:\n" +
                "Дана целочисленная матрица размера M * N\n" +
                "Найти номер первого из ее столбцов,содержащих максимальное количество одинаковых элементов.");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mass.SaveMatr(Table);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mass.OpenMatr(Table);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №11\n" +
                "Подъяблонского Данилы Владимировича\n" +
                "Задание:\n" +
                "Дана целочисленная матрица размера M * N\n" +
                "Найти номер первого из ее столбцов,содержащих максимальное количество одинаковых элементов.");
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            textBox1.Text = Mass.TaskMatr(Table).ToString();
        }
    }
}
