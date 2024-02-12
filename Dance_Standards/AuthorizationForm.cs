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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
            this.Hide();

        }

        private void AuthorizationButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text.ToString();
            string password = passwordTextBox.Text.ToString();
            string fio = "";

            Workbook workbook = new Workbook("D:\\AutReg.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            int worksheetRowCount = worksheet.Cells.MaxDataRow;
            bool proverka = false;

            for(int i = 0; i < worksheetRowCount+1; i++)
            {
                if (Convert.ToString(worksheet.Cells[i, 1].Value) == login)
                {
                    if (Convert.ToString(worksheet.Cells[i, 2].Value) == password) {
                        proverka = true;
                        fio = Convert.ToString(worksheet.Cells[i, 0].Value);
                        break;
                    }
                }
            }

            if (proverka)
            {
                DanceStandartForm danceStandartForm = new DanceStandartForm(fio);
                danceStandartForm.Show();
                this.Hide();
            }
            else{
                MessageBox.Show("Введён неверный логин или пароль", "Ошибка");
            }
        }
    }
}
