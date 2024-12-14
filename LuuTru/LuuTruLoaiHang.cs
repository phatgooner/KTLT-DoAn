using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruLoaiHang
	{
		public static void LuuDanhSach(LoaiHang[] ds)
		{
			LoaiHang[] a = CapNhatDanhSach(ds);
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachLoaiHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);

			StreamWriter file = new StreamWriter(filePath);
			int n = a.Length;
			file.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				file.WriteLine($"{a[i].Ten}");
			}
			file.Close();
		}

		public static LoaiHang[] DocDanhSach()
		{
			LoaiHang[] ds;
			string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string fileName = "../../../Stored/DanhSachLoaiHang.txt";
			string filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);

			int n = int.Parse(file.ReadLine()!);
			ds = new LoaiHang[n];

			for (int i = 0; i < n; i++)
			{
				string s = file.ReadLine()!;
				ds[i].Ten = s;
			}
			file.Close();
			return ds;
		}

		public static bool ThemLoaiHang(LoaiHang lh)
		{
			LoaiHang[] ds = DocDanhSach();
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ten.ToLower() == lh.Ten.ToLower())
				{
					return false;
				}
			}
			LoaiHang[] dsNew;
			dsNew = new LoaiHang[ds.Length + 1];
			for (int i = 0; i < ds.Length; i++)
			{
				dsNew[i] = ds[i];
			}
			dsNew[dsNew.Length - 1] = lh;
			LuuDanhSach(dsNew);
			return true;
		}

		public static LoaiHang? DocLoaiHang(string tenLH)
		{
			LoaiHang[] ds = DocDanhSach();
			foreach (LoaiHang lh in ds)
			{
				if (lh.Ten.ToLower() == tenLH.ToLower())
				{
					return lh;
				}
			}
			return null;
		}		

		public static void XoaLoaiHang(string tenLH)
		{
			LoaiHang[] ds = DocDanhSach();
			LoaiHang[] dsNew;
			dsNew = new LoaiHang[ds.Length - 1];
			int j = 0;
			for (int i = 0; i < ds.Length; i++)
			{
				if (ds[i].Ten.ToLower() != tenLH.ToLower())
				{
					dsNew[j] = ds[i];
					j++;
				}
			}
			LuuDanhSach(dsNew);
		}
		
		//Cập nhật danh sách loại hàng từ danh sách mặt hàng
		public static LoaiHang[] CapNhatDanhSach(LoaiHang[] dslh)
		{
			MatHang[] dsmh = LuuTruMatHang.DocDanhSach();
			LoaiHang[] a = new LoaiHang[dsmh.Length + dslh.Length];
			for (int i = 0; i < dsmh.Length; i++)
			{
				a[i].Ten = dsmh[i].Loai;
			}
			for (int i = 0; i < dslh.Length; i++)
			{
				a[dsmh.Length + i].Ten = dslh[i].Ten;
			}

			//Xóa những loại hàng bị trùng
			for (int i = 0; i < a.Length - 1; i++)
			{
				for (int j = i + 1; j < a.Length; j++)
				{
					if (a[i].Ten != null && a[j].Ten != null)
					{
						if (a[i].Ten.ToLower() == a[j].Ten.ToLower())
						{
							a[j].Ten = null!;
						}
					}						
				}
			}
			int count = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i].Ten != null)
				{
					count++;
				}	
			}	

			//Tạo danh sách mới đã xóa loại hàng bị trùng
			LoaiHang[] c = new LoaiHang[count];
			int k = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i].Ten != null)
				{
					c[k].Ten = a[i].Ten;
					k++;
				}	
			}
			return c;
		}
	}
}
