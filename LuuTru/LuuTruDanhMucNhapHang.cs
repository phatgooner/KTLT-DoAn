using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruDanhMucNhapHang
	{
		public static void LuuDanhSach(DanhMuc[] ds)
		{
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhMucNhapHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamWriter file = new StreamWriter(filePath);
			int n = ds.Length;
			file.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				file.WriteLine($"{ds[i].MaHoaDon},{ds[i].TenHang},{ds[i].DonVi},{ds[i].SoLuong},{ds[i].DonGia}");
			}
			file.Close();
		}

		public static DanhMuc[] DocDanhSach()
		{
			DanhMuc[] ds;
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhMucNhapHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamReader file = new StreamReader(filePath);

			int n = int.Parse(file.ReadLine()!);
			ds = new DanhMuc[n];

			for (int i = 0; i < n; i++)
			{
				string s = file.ReadLine()!;
				string[] m = s.Split(",");
				ds[i].MaHoaDon = m[0];
				ds[i].TenHang = m[1];
				ds[i].DonVi = m[2];
				ds[i].SoLuong = int.Parse(m[3]);
				ds[i].DonGia = int.Parse(m[4]);
			}
			file.Close();
			return ds;
		}

		public static bool ThemDanhMuc(DanhMuc dm)
		{
			DanhMuc[] ds = DocDanhSach();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].MaHoaDon.ToLower() == dm.MaHoaDon.ToLower() && ds[i].TenHang.ToLower() == dm.TenHang.ToLower())
				{
					return false;
				}
			}
			DanhMuc[] dsNew;
			dsNew = new DanhMuc[ds.Length + 1];
			for (int i = 0; i < ds.Length; i++)
			{
				dsNew[i] = ds[i];
			}
			dsNew[dsNew.Length - 1] = dm;
			LuuDanhSach(dsNew);
			return true;
		}

		public static DanhMuc? DocDanhMuc(string maHD, string tenHang)
		{
			DanhMuc[] ds = DocDanhSach();
			foreach (DanhMuc dm in ds)
			{
				if (dm.MaHoaDon.ToLower() == maHD.ToLower() && dm.TenHang.ToLower() == tenHang.ToLower())
				{
					return dm;
				}
			}
			return null;
		}

		public static void XoaDanhMucTheoHoaDon(string maHD)
		{
			DanhMuc[] ds = DocDanhSach();
			DanhMuc[] dsNew;

			int count = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].MaHoaDon.ToLower() == maHD.ToLower())
				{
					count++;
				}
			}
			dsNew = new DanhMuc[ds.Length - count];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].MaHoaDon.ToLower() != maHD.ToLower())
				{
					dsNew[j] = ds[i];
					j++;
				}
			}
			LuuDanhSach(dsNew);
		}

		public static void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang)
		{
			DanhMuc[] ds = DocDanhSach();
			DanhMuc[] dsNew;

			int count = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].MaHoaDon.ToLower() == maHD.ToLower() && ds[i].TenHang.ToLower() == tenMatHang.ToLower())
				{
					count++;
				}
			}
			dsNew = new DanhMuc[ds.Length - count];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (!(ds[i].MaHoaDon.ToLower() == maHD.ToLower() && ds[i].TenHang.ToLower() == tenMatHang.ToLower()))
				{
					dsNew[j] = ds[i];
					j++;
				}
			}
			LuuDanhSach(dsNew);
		}
	}
}
