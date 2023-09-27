using Microsoft.AspNetCore.Hosting.Server;
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
				List<DB> db = _context.DBs.Include(s => s.Server).Include(a => a.Apps).ToList();

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

        public List<DB> ReadADbAvaiable()
        {
			try
			{
				List<DB> db = (from d in _context.DBs join a in _context.Apps on d.Id equals a.DBId where (d.Id != a.DBId) select d).ToList();

                if (db == null)
                {
                    return null;
                }

                return db;

            }
			catch (Exception ex) 
			{
                throw new Exception(ex.Message);
            }
        }

        public DB ReadDbById(int Id)
		{
			try
			{
				DB db = _context.DBs.Include(s => s.Server).Include(a => a.Apps).FirstOrDefault(d => d.Id == Id);

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

		public DB AddDb(DB db)
		{
			_context.DBs.Add(db);
			_context.SaveChanges();

			return db;
		}

        public DB DeleteDb(int Id)
        {
            try
			{
				DB db = _context.DBs.FirstOrDefault(db => db.Id == Id);

				if (db == null)
				{
					return null;
				}
				_context.DBs.Remove(db);
				_context.SaveChanges();
				return db;

			}
			catch
			{
                return null;
            }
        }

        public DB UpdateDb(DB dbRecebido, int Id)
        {
			try
			{
				if (Id != dbRecebido.Id)
				{
					return null;
				}

				DB db = _context.DBs.AsNoTracking().FirstOrDefault(db => db.Id == Id);

				if (db == null)
				{
					return null;
				}

				db = dbRecebido;
				_context.Update(db);
				_context.SaveChanges();
				return db;

			}
			catch(Exception ex)
			{
                throw new Exception(ex.Message);
            }
        }

    }
}



