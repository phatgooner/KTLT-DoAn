using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyDanhMucBanHang
	{
		public static DanhMuc? KhoiTaoDanhMuc(string maHoaDon, string tenHang, string donVi, int soLuong, int donGia)
		{
			if (!string.IsNullOrEmpty(maHoaDon) && !string.IsNullOrEmpty(tenHang) && !string.IsNullOrEmpty(donVi) 
				&& soLuong > 0 && donGia >0)
			{
				DanhMuc dm;
				dm.MaHoaDon = maHoaDon;
				dm.TenHang = tenHang;
				dm.DonVi = donVi;
				dm.SoLuong = soLuong;
				dm.DonGia = donGia;
				return dm;
			}
			return null;
		}

		public static bool ThemDanhMuc(DanhMuc dm)
		{
			return LuuTruDanhMucBanHang.ThemDanhMuc(dm);
		}

		public static DanhMuc[] DocDanhSachTheoHoaDon(string maHD = "")
		{
			DanhMuc[] kq;
			DanhMuc[] ds = LuuTruDanhMucBanHang.DocDanhSach();

			//Lọc theo từ khóa
			int n = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].MaHoaDon.ToLower() == maHD.ToLower())
				{
					n++;
				}
			}
			kq = new DanhMuc[n];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].MaHoaDon.ToLower() == maHD.ToLower())
				{
					kq[j] = ds[i];
					j++;
				}
			}
			return kq;
		}

		public static DanhMuc? DocDanhMuc(string maHD, string tenHang)
		{
			return LuuTruDanhMucBanHang.DocDanhMuc(maHD, tenHang);
		}

		public static DanhMuc? SuaDanhMuc(string maHoaDon, string tenHangCu, string tenHangMoi, string donVi, int soLuong, int donGia)
		{
			DanhMuc? dm = LuuTruDanhMucBanHang.DocDanhMuc(maHoaDon, tenHangCu);
			if (dm.HasValue)
			{
				DanhMuc dmNew = dm.Value;
				dmNew.TenHang = tenHangMoi;
				dmNew.DonVi = donVi;
				dmNew.SoLuong = soLuong;
				dmNew.DonGia = donGia;
				
				LuuTruDanhMucBanHang.ThemDanhMuc(dmNew);
			}
			return null;
		}

		public static void XoaDanhMucTheoHoaDon(string maHD)
		{
			LuuTruDanhMucBanHang.XoaDanhMucTheoHoaDon(maHD);
		}

		public static void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang)
		{
			LuuTruDanhMucBanHang.XoaDanhMucTheoTenMatHang(maHD, tenMatHang);
		}
	}
}
