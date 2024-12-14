using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyNguoiDung
	{
		public static NguoiDung? KhoiTaoNguoiDung(string id, string pass)
		{
			bool laHopLe = true;
			if (id.Length < 3 || pass.Length < 8)
			{
				laHopLe = false;
			}

			if (laHopLe == true && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(pass))
			{
				NguoiDung user;
				user.Username = id;
				user.Password = pass;
				return user;
			}
			return null;
		}

		public static bool ThemNguoiDung(NguoiDung user)
		{
			return LuuTruNguoiDung.ThemNguoiDung(user);
		}

		public static NguoiDung? KiemTraDangNhap(string id, string pass)
		{
			bool laHopLe = true;
			if (id.Length < 3 || pass.Length < 8)
			{
				laHopLe = false;
			}
			if (laHopLe == true)
			{
				NguoiDung[] ds = LuuTruNguoiDung.DocDanhSachNguoiDung();
				NguoiDung user;
				for (int i = 0; i < ds.Length; i++)
				{
					if (ds[i].Username == id && ds[i].Password == pass)
					{
						user = ds[i];
						return user;
					}
				}
			}
			return null;
		}

		public static NguoiDung? DocNguoiDung(string username)
		{
			return LuuTruNguoiDung.DocNguoiDung(username);
		}
	}
}
