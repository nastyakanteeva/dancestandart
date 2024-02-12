using System;
using Aspose.Cells;
using System.Windows.Forms;
using System.Diagnostics;

namespace Dance_Standards
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fio = fioTextBox.Text.ToString();
                string login = loginTextBox.Text.ToString();
                string password = passwordTextBox.Text.ToString();
                string passwordPov = passwordPovTextBox.Text.ToString();

                if (Proverka(login, password)) {
                    if (ProverkaPassword(password, passwordPov))
                    {
                        Workbook workbook = new Workbook("D:\\AutReg.xlsx");

                        Worksheet worksheet = workbook.Worksheets[0];

                        int worksheetRowCount1 = worksheet.Cells.MaxDataRow;
                        int worksheetRowCount2 = worksheet.Cells.MaxDataRow;
                        int worksheetRowCount3 = worksheet.Cells.MaxDataRow;


                        Cell FIO = worksheet.Cells[worksheetRowCount1 + 1, 0];
                        FIO.PutValue(fio);

                        Cell Login = worksheet.Cells[worksheetRowCount2 + 1, 1];
                        Login.PutValue(login);

                        Cell Password = worksheet.Cells[worksheetRowCount3 + 1, 2];
                        Password.PutValue(password);

                        worksheet.AutoFitRows();

                        workbook.Save("D:\\AutReg.xlsx", SaveFormat.Xlsx);

                        worksheetRowCount1 = 0;
                        worksheetRowCount2 = 0;
                        worksheetRowCount3 = 0;

                        MessageBox.Show("Регистрация успешна", "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже есть", "Ошибка");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        public bool ProverkaPassword (string password, string passwordPov)
        {
            if(password == passwordPov)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Proverka(string login, string password)
        {
            Workbook workbook = new Workbook("D:\\AutReg.xlsx");

            Worksheet worksheet = workbook.Worksheets[0];

            int worksheetRowCount = worksheet.Cells.MaxDataRow;
            bool proverka = false;

            for (int i = 0; i < worksheetRowCount + 1; i++)
            {
                if (Convert.ToString(worksheet.Cells[i, 1].Value) == login)
                {
                    if (Convert.ToString(worksheet.Cells[i, 2].Value) == password)
                    {
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

        private void label4_Click(object sender, EventArgs e)
        {
            AuthorizationForm form = new AuthorizationForm();
            form.Show();
            this.Close();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
