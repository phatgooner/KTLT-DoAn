using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruMatHang
	{
		public static void LuuDanhSach(MatHang[] ds)
		{
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachMatHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamWriter file = new StreamWriter(filePath);
			int n = ds.Length;
			file.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				file.WriteLine($"{ds[i].Ma},{ds[i].Ten},{ds[i].Loai},{ds[i].CongTySX},{ds[i].NSX},{ds[i].HSD},{ds[i].Gia}");
			}
			file.Close();
		}

		public static MatHang[] DocDanhSach()
		{
			MatHang[] ds;
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachMatHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamReader file = new StreamReader(filePath);

			int n = int.Parse(file.ReadLine()!);
			ds = new MatHang[n];

			for (int i = 0; i < n; i++)
			{
				string s = file.ReadLine()!;
				string[] m = s.Split(",");
				ds[i].Ma = m[0];
				ds[i].Ten = m[1];
				ds[i].Loai = m[2];
				ds[i].CongTySX = m[3];
				ds[i].NSX = DateOnly.Parse(m[4]);
				ds[i].HSD = DateOnly.Parse(m[5]);
				ds[i].Gia = int.Parse(m[6]);
			}
			file.Close();
			return ds;
		}

		public static bool ThemMatHang(MatHang sp)
		{
			MatHang[] ds = DocDanhSach();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower() == sp.Ma.ToLower())
				{
					return false;
				}
			}
			MatHang[] dsNew;
			dsNew = new MatHang[ds.Length + 1];
			for (int i = 0; i < ds.Length; i++)
			{
				dsNew[i] = ds[i];
			}
			dsNew[dsNew.Length - 1] = sp;
			LuuDanhSach(dsNew);
			return true;
		}

		public static MatHang? DocMatHang(string mssp)
		{
			MatHang[] ds = DocDanhSach();
			foreach (MatHang sp in ds)
			{
				if (sp.Ma.ToLower() == mssp.ToLower())
				{
					return sp;
				}
			}
			return null;
		}

		public static MatHang? SuaMatHang(MatHang sp)
		{
			MatHang[] ds = DocDanhSach();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower() == sp.Ma.ToLower())
				{
					ds[i] = sp;
					LuuDanhSach(ds);
					return sp;
				}
			}
			return null;
		}

		public static void XoaMatHang(string mssp)
		{
			MatHang[] ds = DocDanhSach();
			MatHang[] dsNew;
			dsNew = new MatHang[ds.Length - 1];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ma.ToLower() != mssp.ToLower())
				{
					dsNew[j] = ds[i];
					j++;
				}
			}
			LuuDanhSach(dsNew);
		}
	}
}
