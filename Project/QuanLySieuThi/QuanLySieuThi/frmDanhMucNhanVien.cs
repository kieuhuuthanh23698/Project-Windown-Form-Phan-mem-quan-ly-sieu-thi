﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmDanhMucNhanVien : Form
    {
        KetNoiDuLieu kn;
        string manv;
        public frmDanhMucNhanVien(KetNoiDuLieu kn, string manv)
        {
            this.kn = kn;
            this.manv = manv;
            InitializeComponent();
            TaoTreeViewNV();
        }
        public void TaoTreeViewNV()
        {
            SqlDataReader rd = kn.comManReader("select TenNhanVien from NhanVien","Nhan Vien");
            while(rd.Read())
            {
                DevComponents.AdvTree.Node node= new DevComponents.AdvTree.Node(rd["TenNhanVien"].ToString());
                TreeViewNV.Nodes.Add(node);

            }
            this.kn.sql.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                if (KtraKhoaChinh(txtMa.Text) == true)
                {
                    MessageBox.Show("Đã tồn tại mã");
                    //ko them
                }
                else
                {
                    //them
                    int kq = this.kn.insert("INSERT INTO NhanVien VALUES('"+txtMa.Text+"',N'"+txtTen.Text+"','6/23/1998',N'Nam',8000000,'kieuhuuthanh23698','TP HCM',20,'"+txtUsers.Text+"','"+txtMatkhau.Text+"','Admin')");
                    //kq = 0 them that bai
                    if (kq == 0)
                        MessageBox.Show("Khong them duoc");
                    else
                        MessageBox.Show("Thêm thành công");
                }
            }
        }

        private bool KtraKhoaChinh(string s)
        {
            bool kq = true;
            string i = this.kn.commandScalar("select MaNhanVien from NhanVien where MaNhanVien='" + s + "'").Trim();
            if (i == "")
            {
                return false;
            }
            return kq;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDanhMucNhanVien_Load(object sender, EventArgs e)
        {

        }   
    }
}
