using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruHoaDonNhapHang
	{
		public static void LuuDanhSach(HoaDon[] ds)
		{
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachHoaDonNhapHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamWriter file = new StreamWriter(filePath);
			int n = ds.Length;
			file.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				file.WriteLine($"{ds[i].Ma},{ds[i].TenNguoi},{ds[i].NgayTao}");
			}
			file.Close();
		}

		public static HoaDon[] DocDanhSach()
		{
			HoaDon[] ds;
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachHoaDonNhapHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamReader file = new StreamReader(filePath);

			int n = int.Parse(file.ReadLine()!);
			ds = new HoaDon[n];

			for (int i = 0; i < n; i++)
			{
				string s = file.ReadLine()!;
				string[] m = s.Split(",");
				ds[i].Ma = m[0];
				ds[i].TenNguoi = m[1];
				ds[i].NgayTao = DateOnly.Parse(m[2]);
			}
			file.Close();
			return ds;
		}

		public static bool ThemHoaDon(HoaDon hd)
		{
			HoaDon[] ds = DocDanhSach();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower() == hd.Ma.ToLower())
				{
					return false;
				}
			}
			HoaDon[] dsNew;
			dsNew = new HoaDon[ds.Length + 1];
			for (int i = 0; i < ds.Length; i++)
			{
				dsNew[i] = ds[i];
			}
			dsNew[dsNew.Length - 1] = hd;
			LuuDanhSach(dsNew);
			return true;
		}

		public static HoaDon? DocHoaDon(string maHD)
		{
			HoaDon[] ds = DocDanhSach();
			foreach (HoaDon hd in ds)
			{
				if (hd.Ma.ToLower() == maHD.ToLower())
				{
					return hd;
				}
			}
			return null;
		}

		public static HoaDon? SuaHoaDon(HoaDon hd)
		{
			HoaDon[] ds = DocDanhSach();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower() == hd.Ma.ToLower())
				{
					ds[i] = hd;
					LuuDanhSach(ds);
					return hd;
				}
			}
			return null;
		}

		public static void XoaHoaDon(string maHD)
		{
			HoaDon[] ds = DocDanhSach();
			HoaDon[] dsNew;
			dsNew = new HoaDon[ds.Length - 1];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower() != maHD.ToLower())
				{
					dsNew[j] = ds[i];
					j++;
				}
			}
			LuuDanhSach(dsNew);
		}
	}
}
