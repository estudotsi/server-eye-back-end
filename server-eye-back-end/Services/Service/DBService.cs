using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Services.Service
{
	public class DBService : IDBService
	{
		private readonly DataContext _context;

		public DBService(DataContext context)
		{
			_context = context;
		}
		public List<DB> ReadADbs()
		{
			try
			{
				List<DB> db = _context.DBs.Include(s => s.Server).Include(a => a.App).ToList();

				if(db == null)
				{
					return null;
				}

				return db;

			}
			catch(Exception ex) 
			{
				throw new Exception(ex.Message);
			}

		}

		public DB ReadDbById(int Id)
		{
			try
			{
				DB db = _context.DBs.Include(s => s.Server).Include(a => a.App).FirstOrDefault(d => d.Id == Id);

				if(db == null)
				{
					return null;
				}

				return db;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
