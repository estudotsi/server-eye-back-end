using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Services.Service
{
	public class OsService : IOsService
	{
		private readonly DataContext _context;

		public OsService(DataContext context)
		{
			_context = context;
		}

		public List<Os> ReadOss()
		{
			try
			{
				var oss = _context.Oss.Include(s => s.Servers).ToList();

				if (oss == null)
				{
					return null;
				}
					
				return oss;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Os ReadOsBiId(int Id)
		{
			try
			{
				var os = _context.Oss.Include(s => s.Servers).FirstOrDefault(os => os.Id == Id);
				if(os == null)
				{
					return null;
				}
				return os;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
