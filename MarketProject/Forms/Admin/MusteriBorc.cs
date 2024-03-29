﻿using MarketProject.Business.Abstract;
using MarketProject.Business.Concrete;
using MarketProject.Entities.Concrete;
using MarketProject.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketProject.Forms.Admin
{
    public partial class MusteriBorc : Form
    {
        private readonly ICustomerService _customerService = new CustomerManager();
        private readonly IDebtCustomerService _debtCustomerService = new DebtCustomerManager();

        List<CustomerTotalDebtDto> customerTotalDebts;
        CustomerTotalDebtDto customerTotalDebt;
        int _customerId;
        public MusteriBorc()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            int id = Int32.Parse(dataGridView1.Rows[select].Cells[0].Value.ToString());

            _customerId = id;
            customerTotalDebt = _debtCustomerService.GetTotalDebtByCustomerId(id).Data;
            textBox2.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
          
            textBox3.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[select].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusteriBorcDetay musteriBorcDetay = new MusteriBorcDetay(_customerId);
            musteriBorcDetay.ShowDialog();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var customer = _customerService.GetByPhoneNumber(textBox1.Text.ToString());

            //Performans için
            var response = customerTotalDebts.Where(x => x.PhoneNumber == textBox1.Text).ToList();
            if (response != null)
            {
                dataGridView1.DataSource = response; 
            }
        }

        private void MusteriBorc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var response = _debtCustomerService.GetListCustomerTotalDebt();
            if (response.Success)
            {
                customerTotalDebts = response.Data;
                dataGridView1.DataSource = customerTotalDebts;
            }
            else
            {
                MessageBox.Show("Veriler getirilemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dataGridView1.DataSource = customerTotalDebts;
        }
    }
}
