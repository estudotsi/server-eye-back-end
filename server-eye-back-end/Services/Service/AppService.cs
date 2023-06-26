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
				var app = _context.Apps.Include(s => s.Server).ToList();
			}
			catch (Exception ex) 
			{
			}
		}

		public App ReadAppBiId(int Id)
		{
			throw new NotImplementedException();
		}

	
	}
}
