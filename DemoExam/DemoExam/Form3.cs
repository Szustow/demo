using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DemoExam
{
    public partial class Form3 : Form
    {
        public Form3(PartnerData partner)
        {
            InitializeComponent();

            this.AcceptButton = button1;
            title.Text = partner.Title;
            type.SelectedItem = partner.Type;
            directorName.Text = (partner.Surname + " " + partner.Name + " " + partner.Patronymic).Trim();
            email.Text = partner.Email;
            phone.Text = partner.Phone;
            index.Text = partner.Postcode;
            region.Text = partner.Region;
            city.Text = partner.City;
            street.Text = partner.Street;
            home.Text = partner.Number;
            tin.Text = partner.TIN;
            rating.Text = partner.Rating.ToString();
        }


        private void Form3_Load(object sender, EventArgs e)
        {

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
