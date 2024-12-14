using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyMatHang
	{
		public static MatHang? KhoiTaoMatHang(string maHang, string ten, string loai, string congTy, string nsx, string hsd, int gia)
		{
			if (!string.IsNullOrEmpty(maHang) && !string.IsNullOrEmpty(ten) && !string.IsNullOrEmpty(loai) &&
				!string.IsNullOrEmpty(congTy) && !string.IsNullOrEmpty(nsx) && !string.IsNullOrEmpty(hsd) && gia > 0 &&
				 DateOnly.Parse(nsx) < DateOnly.Parse(hsd))
			{
				MatHang sp;
				sp.Ma = maHang;
				sp.Ten = ten;
				sp.Loai = loai;
				sp.CongTySX = congTy;
				sp.NSX = DateOnly.Parse(nsx);
				sp.HSD = DateOnly.Parse(hsd);
				sp.Gia = gia;
				return sp;
			}			
			return null;
		}

		public static bool ThemMatHang(MatHang sp)
		{
			return LuuTruMatHang.ThemMatHang(sp);
		}

		public static MatHang[] DocDanhSach(string tuKhoa = "")
		{
			MatHang[] kq;
			MatHang[] ds = LuuTruMatHang.DocDanhSach();

			//Lọc theo từ khóa
			int n = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ten.ToLower().Contains(tuKhoa.ToLower()))
				{
					n++;
				}
			}
			kq = new MatHang[n];
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

		public static MatHang[] DocDanhSachTheoLoai(string tenLoai = "")
		{
			MatHang[] kq;
			MatHang[] ds = LuuTruMatHang.DocDanhSach();

			//Lọc theo từ khóa
			int n = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Loai.ToLower() == tenLoai.ToLower())
				{
					n++;
				}
			}
			kq = new MatHang[n];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Loai.ToLower() == tenLoai.ToLower())
				{
					kq[j] = ds[i];
					j++;
				}
			}
			return kq;
		}

		public static MatHang? DocMatHang(string mssp)
		{
			return LuuTruMatHang.DocMatHang(mssp);
		}

		public static MatHang? SuaMatHang(string maHang, string ten, string loai, string congTy, string nsx, string hsd, int gia)
		{
			MatHang? sp = LuuTruMatHang.DocMatHang(maHang);
			if (sp.HasValue)
			{
				MatHang spNew = sp.Value;
				spNew.Ten = ten;
				spNew.Loai = loai;
				spNew.CongTySX = congTy;
				spNew.NSX = DateOnly.Parse(nsx);
				spNew.HSD = DateOnly.Parse(hsd);
				spNew.Gia = gia;
				return LuuTruMatHang.SuaMatHang(spNew);
			}
			return null;
		}

		public static void XoaMatHang(string mssp)
		{
			LuuTruMatHang.XoaMatHang(mssp);
		}

		public static void XoaMatHangTheoLoai(string tenLH)
		{
			MatHang[] dsmh = LuuTruMatHang.DocDanhSach();
			for (int i = 0; i < dsmh.Length; i++)
			{
				if (dsmh[i].Loai.ToLower() == tenLH.ToLower())
				{
					XoaMatHang(dsmh[i].Ma);
				}	
			}	
		}

		public static void SuaMatHangTheoLoai(string tenCu, string tenMoi)
		{
			MatHang[] dsmh = LuuTruMatHang.DocDanhSach();
			for (int i = 0; i < dsmh.Length; i++)
			{
				if (dsmh[i].Loai.ToLower() == tenCu.ToLower())
				{
					MatHang spNew;
					spNew.Ma = dsmh[i].Ma;
					spNew.Ten = dsmh[i].Ten;
					spNew.Loai = tenMoi;
					spNew.CongTySX = dsmh[i].CongTySX;
					spNew.NSX = dsmh[i].NSX;
					spNew.HSD = dsmh[i].HSD;
					spNew.Gia = dsmh[i].Gia;
					LuuTruMatHang.SuaMatHang(spNew);
				}
			}
		}
	}
}
