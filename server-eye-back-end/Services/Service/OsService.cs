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
				List<Os> oss = _context.Oss.Include(s => s.Servers).ToList();

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

		public Os ReadOsById(int Id)
		{
			try
			{
				Os os = _context.Oss.Include(s => s.Servers).FirstOrDefault(os => os.Id == Id);

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

		public Os AddOs(Os os)
		{
			_context.Oss.Add(os);
			_context.SaveChanges();

			return os;
		}
	}
}
