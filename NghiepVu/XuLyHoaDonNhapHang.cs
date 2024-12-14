using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyHoaDonNhapHang
	{
		public static HoaDon? KhoiTaoHoaDon(string maHoaDon, string tenNguoiBan, string ngayTao)
		{
			if (!string.IsNullOrEmpty(maHoaDon) && !string.IsNullOrEmpty(tenNguoiBan) && !string.IsNullOrEmpty(ngayTao) &&
				DateOnly.Parse(ngayTao) <= DateOnly.FromDateTime(DateTime.Now))
			{
				HoaDon hd;
				hd.Ma = maHoaDon;
				hd.TenNguoi = tenNguoiBan;
				hd.NgayTao = DateOnly.Parse(ngayTao);
				return hd;
			}
			return null;
		}

		public static bool ThemHoaDon(HoaDon hd)
		{
			return LuuTruHoaDonNhapHang.ThemHoaDon(hd);
		}

		public static HoaDon[] DocDanhSach(string tuKhoa = "")
		{
			HoaDon[] kq;
			HoaDon[] ds = LuuTruHoaDonNhapHang.DocDanhSach();

			//Lọc theo từ khóa
			int n = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower().Contains(tuKhoa.ToLower()))
				{
					n++;
				}
			}
			kq = new HoaDon[n];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower().Contains(tuKhoa.ToLower()))
				{
					kq[j] = ds[i];
					j++;
				}
			}
			return kq;
		}

		public static HoaDon? DocHoaDon(string maHD)
		{
			return LuuTruHoaDonNhapHang.DocHoaDon(maHD);
		}

		public static HoaDon? SuaHoaDon(string maHoaDon, string tenNguoiBan, string ngayTao)
		{
			HoaDon? hd = LuuTruHoaDonNhapHang.DocHoaDon(maHoaDon);
			if (hd.HasValue)
			{
				HoaDon hdNew = hd.Value;
				hdNew.TenNguoi = tenNguoiBan;
				hdNew.NgayTao = DateOnly.Parse(ngayTao);
				return LuuTruHoaDonNhapHang.SuaHoaDon(hdNew);
			}
			return null;
		}

		public static void XoaHoaDon(string maHD)
		{
			XuLyDanhMucNhapHang.XoaDanhMucTheoHoaDon(maHD);
			LuuTruHoaDonNhapHang.XoaHoaDon(maHD);
		}

		public static int TongGiaTriHoaDon(string maHD)
		{
			int sum = 0;
			DanhMuc[] ds = XuLyDanhMucNhapHang.DocDanhSachTheoHoaDon(maHD);
			for (int i = 0; i < ds.Length; i++)
			{
				sum = sum + (ds[i].DonGia * ds[i].SoLuong);
			}
			return sum;
		}

		public static void CapNhatHoaDon()
		{
			HoaDon[] dshd = LuuTruHoaDonNhapHang.DocDanhSach();
			DanhMuc[] dsdm = LuuTruDanhMucNhapHang.DocDanhSach();

			for (int i = 0; i < dshd.Length; i++)
			{
				int count = 0;
				for (int j = 0; j < dsdm.Length; j++)
				{
					if (dshd[i].Ma.ToLower() == dsdm[j].MaHoaDon.ToLower())
					{
						count++;
						break;
					}
				}
				if (count == 0)
				{
					LuuTruHoaDonNhapHang.XoaHoaDon(dshd[i].Ma);
				}
			}
		}
	}
}
