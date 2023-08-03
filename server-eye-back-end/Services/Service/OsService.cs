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

		public Os DeleteOs(int Id)
		{
			try
			{
				Os os = _context.Oss.FirstOrDefault(os => os.Id == Id);

				if (os == null)
				{
					return null;
				}
				_context.Oss.Remove(os);
				_context.SaveChanges();
				return os;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public Os UpdateOs(Os osRecebido, int id)
		{
			try
			{
				if (id != osRecebido.Id)
				{
					return null;
				}

				Os os = _context.Oss.AsNoTracking().FirstOrDefault(os => os.Id == id);
				var nameImage = os.ImagemURL;

				if (os == null)
				{
					return null;
				}

				os = osRecebido;
				os.ImagemURL = nameImage;
				_context.Update(os);
				_context.SaveChanges();
				return os;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool SearchFilename(string name)
		{

			bool flag = _context.Oss.Any(os => os.ImagemURL == name);

			try
			{
				if (flag)
				{
					return true;
				}
				else return false;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
