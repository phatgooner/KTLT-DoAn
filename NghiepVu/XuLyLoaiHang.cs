using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyLoaiHang
	{
		public static LoaiHang? KhoiTaoLoaiHang(string tenLoaiHang)
		{
			if (!string.IsNullOrEmpty(tenLoaiHang))
			{
				LoaiHang lh;
				lh.Ten = tenLoaiHang;
				return lh;
			}
			return null;
		}

		public static bool ThemLoaiHang(LoaiHang lh)
		{
			return LuuTruLoaiHang.ThemLoaiHang(lh);
		}

		public static LoaiHang[] DocDanhSach(string tuKhoa = "")
		{
			LoaiHang[] kq;
			LoaiHang[] dsOld = LuuTruLoaiHang.DocDanhSach();
			LoaiHang[] ds = LuuTruLoaiHang.CapNhatDanhSach(dsOld);

			//Lọc theo từ khóa
			int n = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ten.ToLower().Contains(tuKhoa.ToLower()))
				{
					n++;
				}
			}
			kq = new LoaiHang[n];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ten.ToLower().Contains(tuKhoa.ToLower()))
				{
					kq[j] = ds[i];
					j++;
				}
			}
			return kq;
		}

		public static LoaiHang? DocLoaiHang(string tenLH)
		{
			return LuuTruLoaiHang.DocLoaiHang(tenLH);
		}

		public static LoaiHang? SuaLoaiHang(string tenLoaiHangCu, string tenLoaiHangMoi)
		{
			XuLyMatHang.SuaMatHangTheoLoai(tenLoaiHangCu, tenLoaiHangMoi);
			LuuTruLoaiHang.XoaLoaiHang(tenLoaiHangCu);		

			LoaiHang? lh = LuuTruLoaiHang.DocLoaiHang(tenLoaiHangMoi);
			if (lh.HasValue)
			{
				return lh;
			}
			else
			{
				LoaiHang lhNew;
				lhNew.Ten = tenLoaiHangMoi;
				ThemLoaiHang(lhNew);
				return lhNew;
			}			
		}

		public static void XoaLoaiHang(string lh)
		{
			XuLyMatHang.XoaMatHangTheoLoai(lh);
			LuuTruLoaiHang.XoaLoaiHang(lh);
		}

		public static void CapNhat()
		{
			LoaiHang[] dsOld = LuuTruLoaiHang.DocDanhSach();
			LoaiHang[] ds = LuuTruLoaiHang.CapNhatDanhSach(dsOld);
			LuuTruLoaiHang.LuuDanhSach(ds);
		}
	}
}
