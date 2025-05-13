using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExam
{
    public partial class Form1 : Form
    {
        List<PartnerData> partnerData = new List<PartnerData>();
        public Form1()
        {
            InitializeComponent();
            displayPartnerData();
        }

        public void displayPartnerData()
        {
            partnerData = PartnerCRUD.PartnersListData();

            partnersView.DataSource = partnerData;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            partnersView.Columns[5].Visible = false;
            partnersView.Columns[6].Visible = false;
            partnersView.Columns[7].Visible = false;
            partnersView.Columns[8].Visible = false;
            partnersView.Columns[9].Visible = false;
            partnersView.Columns[10].Visible = false;
            partnersView.Columns[11].Visible = false;

            partnersView.Columns[0].HeaderText = "Партнер";
            partnersView.Columns[1].HeaderText = "Вид";
            partnersView.Columns[2].HeaderText = "Фамилия";
            partnersView.Columns[3].HeaderText = "Имя";
            partnersView.Columns[4].HeaderText = "Отчество";
            partnersView.Columns[12].HeaderText = "ИНН";
            partnersView.Columns[13].HeaderText = "Рейтинг";
            partnersView.Columns[14].HeaderText = "Скидка";

            partnersView.Columns[1].Width = 55;
            partnersView.Columns[13].Width = 65;
            partnersView.Columns[14].Width = 65;
            partnersView.Columns[0].Width = 130;

            partnersView.RowHeadersVisible = false;
            
            partnersView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            partnersView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 partnerAdd = new Form2();
            partnerAdd.StartPosition = FormStartPosition.CenterScreen;

            

            if (partnerAdd.ShowDialog() == DialogResult.OK)
            {
                string[] words = partnerAdd.directorName.Text.Trim().Split(' ');
                string[] wordsEdit = new string[3] { "", "", "" };
                for (int i = 0; i < words.Length && i <= 2; i++)
                {
                    wordsEdit[i] = words[i];
                }
                PartnerData partner = new PartnerData();
                partner.Title = partnerAdd.title.Text.Trim();
                partner.Type = partnerAdd.type.SelectedItem.ToString();
                partner.Surname = wordsEdit[0];
                partner.Name = wordsEdit[1];
                partner.Patronymic = wordsEdit[2];
                partner.Email = partnerAdd.email.Text.Trim();
                partner.Phone = partnerAdd.phone.Text.Trim();
                partner.Postcode = partnerAdd.index.Text.Trim();
                partner.Region = partnerAdd.region.Text.Trim();
                partner.City = partnerAdd.city.Text.Trim();
                partner.Street = partnerAdd.city.Text.Trim();
                partner.Number = partnerAdd.home.Text.Trim();
                partner.TIN = partnerAdd.tin.Text.Trim();
                partner.Rating = partnerAdd.rating.Text.Trim();

                try
                {
                    PartnerCRUD.AddPartner(partner);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.ToString());
                    return;
                }
            }
            displayPartnerData();
            partnerAdd.Close();
        }

        private void partnersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PartnerData partnerView = new PartnerData();
            int indexData = partnersView.CurrentCell.RowIndex;
            partnerView = partnerData[indexData];
            string Title = partnerView.Title;

            Form3 partnerUpdate = new Form3(partnerView);
            partnerUpdate.StartPosition = FormStartPosition.CenterScreen;

            if (partnerUpdate.ShowDialog() == DialogResult.OK)
            {
                string[] words = partnerUpdate.directorName.Text.Trim().Split(' ');
                string[] wordsEdit = new string[3] { "", "", "" };
                for (int i = 0; i < words.Length && i <= 2; i++)
                {
                    wordsEdit[i] = words[i];
                }
                PartnerData partner = new PartnerData();
                partner.Title = partnerUpdate.title.Text.Trim();
                partner.Type = partnerUpdate.type.SelectedItem.ToString();
                partner.Surname = wordsEdit[0];
                partner.Name = wordsEdit[1];
                partner.Patronymic = wordsEdit[2];
                partner.Email = partnerUpdate.email.Text.Trim();
                partner.Phone = partnerUpdate.phone.Text.Trim();
                partner.Postcode = partnerUpdate.index.Text.Trim();
                partner.Region = partnerUpdate.region.Text.Trim();
                partner.City = partnerUpdate.city.Text.Trim();
                partner.Street = partnerUpdate.city.Text.Trim();
                partner.Number = partnerUpdate.home.Text.Trim();
                partner.TIN = partnerUpdate.tin.Text.Trim();
                partner.Rating = partnerUpdate.rating.Text.Trim();

                try
                {
                    PartnerCRUD.UpdatePartner(partner, Title);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.ToString());
                    return;
                }
                
            }
            displayPartnerData();
            partnerUpdate.Close();
        }
    }
}
