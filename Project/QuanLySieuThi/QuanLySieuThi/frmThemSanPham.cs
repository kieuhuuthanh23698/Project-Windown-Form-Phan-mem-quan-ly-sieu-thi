﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmThemSanPham : Form
    {
        KetNoiDuLieu link;

        public frmThemSanPham(KetNoiDuLieu link)
        {
            this.link = link;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
