using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruNguoiDung
	{
		public static void LuuDanhSachNguoiDung(NguoiDung[] ds)
		{
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachNguoiDung.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamWriter file = new StreamWriter(filePath);
			int n = ds.Length;
			file.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				file.WriteLine($"{ds[i].Username},{ds[i].Password}");
			}
			file.Close();
		}

		public static NguoiDung[] DocDanhSachNguoiDung()
		{
			NguoiDung[] ds;
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachNguoiDung.txt";
			string filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);

			int n = int.Parse(file.ReadLine()!);
			ds = new NguoiDung[n];

			for (int i = 0; i < n; i++)
			{
				string s = file.ReadLine()!;
				string[] m = s.Split(",");
				ds[i].Username = m[0];
				ds[i].Password = m[1];
			}
			file.Close();
			return ds;
		}

		public static bool ThemNguoiDung(NguoiDung user)
		{
			NguoiDung[] ds = DocDanhSachNguoiDung();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Username == user.Username)
				{
					return false;
				}
			}
			NguoiDung[] dsNew;
			dsNew = new NguoiDung[ds.Length + 1];
			for (int i = 0; i < ds.Length; i++)
			{
				dsNew[i] = ds[i];
			}
			dsNew[dsNew.Length - 1] = user;
			LuuDanhSachNguoiDung(dsNew);
			return true;
		}

		public static NguoiDung? DocNguoiDung(string username)
		{
			NguoiDung[] ds = DocDanhSachNguoiDung();
			foreach (NguoiDung user in ds)
			{
				if (user.Username == username)
				{
					return user;
				}
			}
			return null;
		}
	}
}
