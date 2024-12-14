using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyHoaDonBanHang
	{
		public static HoaDon? KhoiTaoHoaDon(string maHoaDon, string tenNguoiMua, string ngayTao)
		{
			if (!string.IsNullOrEmpty(maHoaDon) && !string.IsNullOrEmpty(tenNguoiMua) && !string.IsNullOrEmpty(ngayTao) &&
				DateOnly.Parse(ngayTao) <= DateOnly.FromDateTime(DateTime.Now))
			{
				HoaDon hd;
				hd.Ma = maHoaDon;
				hd.TenNguoi = tenNguoiMua;
				hd.NgayTao = DateOnly.Parse(ngayTao);
				return hd;
			}
			return null;
		}

		public static bool ThemHoaDon(HoaDon hd)
		{
			return LuuTruHoaDonBanHang.ThemHoaDon(hd);
		}

		public static HoaDon[] DocDanhSach(string tuKhoa = "")
		{
			HoaDon[] kq;
			HoaDon[] ds = LuuTruHoaDonBanHang.DocDanhSach();

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
			return LuuTruHoaDonBanHang.DocHoaDon(maHD);
		}

		public static HoaDon? SuaHoaDon(string maHoaDon, string tenNguoiMua, string ngayTao)
		{
			HoaDon? hd = LuuTruHoaDonBanHang.DocHoaDon(maHoaDon);
			if (hd.HasValue)
			{
				HoaDon hdNew = hd.Value;
				hdNew.TenNguoi = tenNguoiMua;
				hdNew.NgayTao = DateOnly.Parse(ngayTao);
				return LuuTruHoaDonBanHang.SuaHoaDon(hdNew);
			}
			return null;
		}

		public static void XoaHoaDon(string maHD)
		{
			XuLyDanhMucBanHang.XoaDanhMucTheoHoaDon(maHD);
			LuuTruHoaDonBanHang.XoaHoaDon(maHD);
		}	
		
		public static int TongGiaTriHoaDon(string maHD)
		{
			int sum = 0;
			DanhMuc[] ds = XuLyDanhMucBanHang.DocDanhSachTheoHoaDon(maHD);
			for (int i = 0; i < ds.Length; i++)
			{
				sum = sum + (ds[i].DonGia * ds[i].SoLuong);
			}	
			return sum;
		}

		public static void CapNhatHoaDon()
		{
			HoaDon[] dshd = LuuTruHoaDonBanHang.DocDanhSach();
			DanhMuc[] dsdm = LuuTruDanhMucBanHang.DocDanhSach();

			for (int i = 0; i < dshd.Length;i++)
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
					LuuTruHoaDonBanHang.XoaHoaDon(dshd[i].Ma);
				}	
			}	
		}
	}
}
