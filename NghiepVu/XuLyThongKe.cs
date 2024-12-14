using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyThongKe
	{
		public static int SoLuongHangConLai(string tenHang)
		{
			DanhMuc[] a = LuuTruDanhMucNhapHang.DocDanhSach();
			DanhMuc[] b = LuuTruDanhMucBanHang.DocDanhSach();
			int sum1 = 0;
			int sum2 = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i].TenHang == tenHang)
				{
					sum1 = sum1 + a[i].SoLuong;
				}
			}

			for (int i = 0; i < b.Length; i++)
			{
				if (b[i].TenHang == tenHang)
				{
					sum2 = sum2 + b[i].SoLuong;
				}
			}

			return (sum1 - sum2);
		}

		public static MatHang[] DocDanhSachMatHangHetHan()
		{
			MatHang[] kq;
			MatHang[] ds = LuuTruMatHang.DocDanhSach();

			//Lọc theo từ khóa
			int n = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].HSD < DateOnly.FromDateTime(DateTime.Now))
				{
					n++;
				}
			}
			kq = new MatHang[n];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].HSD < DateOnly.FromDateTime(DateTime.Now))
				{
					kq[j] = ds[i];
					j++;
				}
			}
			return kq;
		}

	}
}
