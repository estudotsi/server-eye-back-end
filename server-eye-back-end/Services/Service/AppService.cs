using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Services.Service
{
	public class AppService : IAppService
	{
		private readonly DataContext _context;

		public AppService(DataContext context)
		{
			_context = context;
		}

		public List<App> ReadApps()
		{
			try
			{
				List<App> app = _context.Apps.Include(s => s.Server).Include(d => d.DB).ToList();

				if(app == null)
				{
					return null;
				}

				return app;
			}
			catch (Exception ex) 
			{
				throw new Exception(ex.Message);
			}
		}

		public App ReadAppById(int Id)
		{
			try
			{
				App app = _context.Apps.Include(s => s.Server).Include(d => d.DB).FirstOrDefault(a => a.Id == Id);

				if(app == null)
				{
					return null;
				}

				return app;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	
	}
}
