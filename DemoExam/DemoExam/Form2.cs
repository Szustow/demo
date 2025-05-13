using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExam
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (title.Text.Trim() == "" || directorName.Text.Trim() == "" ||
                    type.SelectedItem is null || email.Text.Trim() == "" ||
                    phone.Text.Trim() == "" || index.Text.Trim() == "" ||
                    region.Text.Trim() == "" || city.Text.Trim() == "" ||
                    street.Text.Trim() == "" || home.Text.Trim() == "" ||
                    tin.Text.Trim() == "" || rating.Text.Trim() == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int ratingNum = Convert.ToInt32(rating.Text);
                if (ratingNum < 0) throw new Exception("Рейтинг партнера должен быть целым неотрицательным числом");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
