using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dance_Standards
{
    public partial class DanceStandartForm : Form
    {
        string fio;
        public DanceStandartForm(string fio)
        {
            InitializeComponent();
            this.fio = fio;
            UserNameTextBox.Text = fio;
        }

       static Workbook workbook = new Workbook("D:\\DanceStandart.xlsx");

        Worksheet worksheet = workbook.Worksheets[0];

        private void DanceStandartForm_Load(object sender, EventArgs e)
        {

            int worksheetRowCount = worksheet.Cells.MaxDataRow;
            int worksheetColumnCount = worksheet.Cells.MaxDataColumn;

            DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, worksheetRowCount+1, worksheetColumnCount+1, true);

            dataGridView1.DataSource = dataTable;
        }

        private void RestartTableButton_Click(object sender, EventArgs e)
        {

            int worksheetRowCount = worksheet.Cells.MaxDataRow;
            int worksheetColumnCount = worksheet.Cells.MaxDataColumn;

            DataTable dataTable = worksheet.Cells.ExportDataTable(0, 0, worksheetRowCount + 1, worksheetColumnCount + 1, true);

            dataGridView1.DataSource = dataTable;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            string id = IDTextBox.Text.ToString();
            string fio = UserNameTextBox.Text.ToString();
            string Skakalka = SkakalkaTextBox.Text.ToString();
            string Rastygka = RastygkaTextBox.Text.ToString();
            string Akrobatika = AkrobatikaTextBox.Text.ToString();
            string Improvizacia = ImprovizaciaTextBox.Text.ToString();
            string Postanovka = PostanovkaTextBox.Text.ToString();


            int worksheetRowCount1 = worksheet.Cells.MaxDataRow;
            int worksheetRowCount2 = worksheet.Cells.MaxDataRow;
            int worksheetRowCount3 = worksheet.Cells.MaxDataRow;
            int worksheetRowCount4 = worksheet.Cells.MaxDataRow;
            int worksheetRowCount5 = worksheet.Cells.MaxDataRow;
            int worksheetRowCount6 = worksheet.Cells.MaxDataRow;
            int worksheetRowCount7 = worksheet.Cells.MaxDataRow;

            if (Proverka(id, fio))
            {
                Cell ID = worksheet.Cells[worksheetRowCount1 + 1, 0];
                ID.PutValue(id);

                Cell FIO = worksheet.Cells[worksheetRowCount2 + 1, 1];
                FIO.PutValue(fio);

                Cell skakalka = worksheet.Cells[worksheetRowCount3 + 1, 2];
                skakalka.PutValue(Skakalka);

                Cell rastygka = worksheet.Cells[worksheetRowCount4 + 1, 3];
                rastygka.PutValue(Rastygka);

                Cell akrobatika = worksheet.Cells[worksheetRowCount5 + 1, 4];
                akrobatika.PutValue(Akrobatika);

                Cell improvizacia = worksheet.Cells[worksheetRowCount6 + 1, 5];
                improvizacia.PutValue(Improvizacia);

                Cell postanovka = worksheet.Cells[worksheetRowCount7 + 1, 6];
                postanovka.PutValue(Postanovka);


                worksheet.AutoFitRows();

                workbook.Save("D:\\DanceStandart(1).xlsx", SaveFormat.Xlsx);
            }
            else
            {
                MessageBox.Show("Нормативы с таким ID уже есть", "Ошибка");
            }

            worksheetRowCount1 = 0;
            worksheetRowCount2 = 0;
            worksheetRowCount3 = 0;
            worksheetRowCount4 = 0;
            worksheetRowCount5 = 0;
            worksheetRowCount6 = 0;
            worksheetRowCount7 = 0;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string id = IDTextBox.Text.ToString();
            string fio = UserNameTextBox.Text.ToString();
            string Skakalka = SkakalkaTextBox.Text.ToString();
            string Rastygka = RastygkaTextBox.Text.ToString();
            string Akrobatika = AkrobatikaTextBox.Text.ToString();
            string Improvizacia = ImprovizaciaTextBox.Text.ToString();
            string Postanovka = PostanovkaTextBox.Text.ToString();

            int worksheetRowCount = worksheet.Cells.MaxDataRow;
            bool proverka = false;

            for (int i = 0; i < worksheetRowCount + 1; i++)
            {
                if (Convert.ToString(worksheet.Cells[i, 0].Value) == id)
                {
                    proverka = true;
                    worksheetRowCount = i;
                    break;
                }
            }

            if (proverka) {
                Cell ID = worksheet.Cells[worksheetRowCount, 0];
                ID.PutValue(id);

                Cell FIO = worksheet.Cells[worksheetRowCount, 1];
                FIO.PutValue(fio);

                Cell skakalka = worksheet.Cells[worksheetRowCount, 2];
                skakalka.PutValue(Skakalka);

                Cell rastygka = worksheet.Cells[worksheetRowCount, 3];
                rastygka.PutValue(Rastygka);

                Cell akrobatika = worksheet.Cells[worksheetRowCount, 4];
                akrobatika.PutValue(Akrobatika);

                Cell improvizacia = worksheet.Cells[worksheetRowCount, 5];
                improvizacia.PutValue(Improvizacia);

                Cell postanovka = worksheet.Cells[worksheetRowCount, 6];
                postanovka.PutValue(Postanovka);


                worksheet.AutoFitRows();

                workbook.Save("D:\\DanceStandart.xlsx", SaveFormat.Xlsx);
            }
            else
            {
                MessageBox.Show("Нормативов с таким ID нет", "Ошибка");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                IDTextBox.Text = row.Cells["ID"].Value.ToString();
                SkakalkaTextBox.Text = row.Cells["Скакалка"].Value.ToString();
                RastygkaTextBox.Text = row.Cells["Растяжка"].Value.ToString();
                AkrobatikaTextBox.Text = row.Cells["Акробатика"].Value.ToString();
                ImprovizaciaTextBox.Text = row.Cells["Импровизация"].Value.ToString();
                PostanovkaTextBox.Text = row.Cells["Постановка"].Value.ToString();
            }
        }
        public bool Proverka(string id, string fio)
        {

            int worksheetRowCount = worksheet.Cells.MaxDataRow;
            bool proverka = false;

            for (int i = 0; i < worksheetRowCount + 1; i++)
            {
                if (Convert.ToString(worksheet.Cells[i, 0].Value) == id)
                {
                    if (Convert.ToString(worksheet.Cells[i, 1].Value) == fio) {
                        proverka = true;
                        break;
                    }
                }
            }

            if (proverka)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
