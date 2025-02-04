﻿using PMQuanLyCuaHangThuY.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangThuY.View
{
    public partial class UC_NhapHang : UserControl
    {
        public static UC_NhapHang ucNhapHang = new UC_NhapHang();
        BL_NhapHang db = new BL_NhapHang();
        public static Boolean save;
        public static string TrangThai;
        public static string MaHD;
        public UC_NhapHang()
        {
            InitializeComponent();
        }
        private void HienThi()
        {
            HienThiHoaDon();
            if (dtgvDataHD.Rows.Count > 0)
            {
                var row = this.dtgvDataHD.Rows[0];
                HienThiChiTietHoaDon(row.Cells["MaHD"].Value.ToString());
            }
            else
            {
                HienThiChiTietHoaDon("");
            }
        }
        private void HienThiHoaDon()
        {
            string NhaCungCap = lbkNhaCungCap.SelectedValue != null ? lbkNhaCungCap.SelectedValue.ToString() : null;

            dtgvDataHD.DataSource = db.HienThiHOADON(dtNgay1.Value.ToString("yyyy-MM-dd"), dtNgay2.Value.ToString("yyyy-MM-dd"), NhaCungCap);
            dtgvDataHD.Columns[0].HeaderText = "Mã HD";
            dtgvDataHD.Columns[1].HeaderText = "Mã NCC";
            dtgvDataHD.Columns[2].HeaderText = "Tên NCC";
            dtgvDataHD.Columns[3].HeaderText = "Ngày HĐ";
            dtgvDataHD.Columns[4].HeaderText = "Mã NV";
            dtgvDataHD.Columns[5].HeaderText = "Tên NV";
            dtgvDataHD.Columns[6].HeaderText = "Tổng tiền";
            dtgvDataHD.Columns[7].HeaderText = "Diễn giải";
            dtgvDataHD.Columns[8].HeaderText = "Trạng thái";

            dtgvDataHD.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataHD.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            // Cấu hình định dạng cho cột "Tổng tiền"
            dtgvDataHD.Columns[6].DefaultCellStyle.Format = "N0";
            dtgvDataHD.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            UC_NhanVien.CustomDataGridView(dtgvDataHD);
        }
        private void HienThiChiTietHoaDon(string value)
        {
            dtgvDataCTHD.DataSource = db.HienThiCHITIETHOADON(value);
            dtgvDataCTHD.Columns[0].HeaderText = "Mã HĐ";
            dtgvDataCTHD.Columns[1].HeaderText = "Mã VT";
            dtgvDataCTHD.Columns[2].HeaderText = "Tên VT";
            dtgvDataCTHD.Columns[3].HeaderText = "Đơn giá";
            dtgvDataCTHD.Columns[4].HeaderText = "Số lượng";
            dtgvDataCTHD.Columns[5].HeaderText = "Thành tiền";
            dtgvDataCTHD.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataCTHD.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataCTHD.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataCTHD.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataCTHD.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dtgvDataCTHD.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            // Cấu hình định dạng cho cột "Đơn giá"
            dtgvDataCTHD.Columns[3].DefaultCellStyle.Format = "N0";
            dtgvDataCTHD.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Cấu hình định dạng cho cột "Số lượng"
            dtgvDataCTHD.Columns[4].DefaultCellStyle.Format = "N2";
            dtgvDataCTHD.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Cấu hình định dạng cho cột "Thành tiền"
            dtgvDataCTHD.Columns[5].DefaultCellStyle.Format = "N0";
            dtgvDataCTHD.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            UC_NhanVien.CustomDataGridView(dtgvDataCTHD);
        }
        private void UC_NhapHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ds_VatTu.VATTU' table. You can move, or remove it, as needed.
            this.nHACUNGCAPTableAdapter.Fill(this.ds_DmNhaCungCap.NHACUNGCAP);
            // Set giá trị mặc định cho lbkVatTu là null hoặc giá trị trống
            lbkNhaCungCap.SelectedIndex = -1; // hoặc lbkVatTu.Text = "";

            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            save = true;
            FormNhapHangThongTin frm = new FormNhapHangThongTin();
            frm.Text = "Thêm mới phiếu nhập hàng";
            frm.ShowDialog();
            HienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvDataHD.Rows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = this.dtgvDataHD.Rows[dtgvDataHD.CurrentCell.RowIndex];
            save = false;
            MaHD = row.Cells[0].Value.ToString();

            FormNhapHangThongTin frm = new FormNhapHangThongTin();
            frm.Text = "Sửa thông tin phiếu nhập hàng";
            frm.ShowDialog();
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvDataHD.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtgvDataHD.Rows[dtgvDataHD.CurrentCell.RowIndex];
            TrangThai = row.Cells[8].Value.ToString();

            if (TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu này đã được thanh toán, không được xóa.");
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa hóa đơn này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    db.DinhChi(dtgvDataHD.Rows[dtgvDataHD.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    HienThi();
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã phát sinh dữ liệu, không được xóa.");
                    return;
                }
            }
            else
                return;


            /*

            DialogResult dr = MessageBox.Show("Có chắc chắn xóa hóa đơn này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    db.DinhChi(dtgvDataHD.Rows[dtgvDataHD.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    HienThi();
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã phát sinh dữ liệu, không được xóa.");
                    return;
                }
            }
            else
                return;
            */
        }

        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dtgvDataHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDataHD.Rows[e.RowIndex];
                HienThiChiTietHoaDon(row.Cells[0].Value.ToString());
            }
        }

        private void dtgvDataHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dữLiệuĐìnhChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHDNhapDinhChi frm = new FormHDNhapDinhChi();
            frm.Text = "Dữ liệu đã đình chỉ";
            frm.ShowDialog();
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvDataHD.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtgvDataHD.Rows[dtgvDataHD.CurrentCell.RowIndex];
            MaHD = row.Cells[0].Value.ToString();

            // Gọi tới form in hóa đơn và truyền mã hóa đơn
            FormMauInHDBH frmMauInHDBH = new FormMauInHDBH(MaHD);
            frmMauInHDBH.ShowDialog();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtgvDataHD.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtgvDataHD.Rows[dtgvDataHD.CurrentCell.RowIndex];
            MaHD = row.Cells[0].Value.ToString();
            TrangThai = row.Cells[8].Value.ToString();
            if (TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu này đã được thanh toán.");
                return;
            }

            DialogResult ok = new DialogResult();
            ok = MessageBox.Show("Bạn có muốn tính tiền cho hóa đơn này Không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ok == DialogResult.Yes)
            {
                MessageBox.Show("TỔNG SỐ TIỀN THANH TOÁN LÀ " + row.Cells[6].Value.ToString(), "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                db.UpdateTrangThaiSauThanhToan(row.Cells[0].Value.ToString());
                HienThi();
            }
            else
            {
                return;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void xuấtExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dtgvDataHD.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtgvDataHD.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dtgvDataHD.Rows.Count; i++)
            {
                for (int j = 0; j < dtgvDataHD.Columns.Count; j++)
                {
                    if (dtgvDataHD.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtgvDataHD.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }
    }
}
