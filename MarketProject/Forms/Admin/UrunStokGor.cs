﻿using MarketProject.Business.Abstract;
using MarketProject.Business.Concrete;
using MarketProject.Entities.Concrete;
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
    public partial class UrunStokGor : Form
    {
        private readonly IProductService _productService = new ProductManager();
        List<Product> products;
        Product product;

        public UrunStokGor()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            int id = Int32.Parse(dataGridView1.Rows[select].Cells[0].Value.ToString());

            product = _productService.GetById(id).Data;
            textBox2.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[select].Cells[6].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product updatedProduct = new Product()
            {
                Id = product.Id,
                WayBillId = Convert.ToInt32(textBox2.Text),
                Code = textBox3.Text.ToString(),
                BarcodeNo = textBox4.Text,
                Name = textBox5.Text,
                Amount = Convert.ToInt32(textBox6.Text),
                UnitOfPrice = Convert.ToDecimal(textBox7.Text)
            };
            _productService.Update(updatedProduct);
            LoadData();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            _productService.Delete(product);
            LoadData();
        }

        private void LoadData()
        {
            var response = _productService.GetList();
            if (response.Success)
            {
                products = response.Data;
                dataGridView1.DataSource = products;
            }
            else
            {
                MessageBox.Show("Veriler getirilemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunStokGor_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}