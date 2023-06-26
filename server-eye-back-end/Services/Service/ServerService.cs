using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Services.Service
{
	public class ServerService : IServerService
	{
		private readonly DataContext _context;

		public ServerService(DataContext context)
		{
			_context = context;
		}

		public List<Server> ReadServers()
		{
			try
			{
				List<Server> servers = _context.Servers.Include(os => os.Os).Include(a => a.Apps).ToList();
				if(servers == null)
				{
					return null;
				}
					
				return servers;
			}
			catch(Exception ex) 
			{
				throw new Exception(ex.Message);
			}
		}

		public Server ReadServerBiId(int id)
		{
			try
			{
				Server server = _context.Servers.Include(os => os.Os).Include(a => a.Apps).FirstOrDefault(server => server.Id == id);
				if(server == null)
				{
					return null;
				}
				return server;
			}
			catch(Exception ex) 
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
