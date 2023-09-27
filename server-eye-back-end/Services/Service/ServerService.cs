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
				List<Server> servers = _context.Servers.Include(os => os.Os).Include(a => a.Apps).Include(d => d.DBs).ToList();

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

		public Server ReadServerById(int id)
		{
			try
			{
				Server server = _context.Servers.Include(os => os.Os).Include(a => a.Apps).Include(d => d.DBs).FirstOrDefault(server => server.Id == id);

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

		public List<Server> RedeServerByRede(string rede)
		{
			try
			{
				List<Server> servers = _context.Servers.Include(os => os.Os).Include(a => a.Apps).Include(d => d.DBs).Where(server => server.Rede == rede).ToList();

				if(servers == null)
				{
					return null;
				}
				return servers;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        public Server AddServer(Server server)
        {
            _context.Servers.Add(server);
			_context.SaveChanges();

			return server;
        }

		public Server DeleteServer(int Id)
		{
			try
			{
				Server server = _context.Servers.FirstOrDefault(server => server.Id == Id);

				if (server == null)
				{
					return null;
				}
				_context.Servers.Remove(server);
				_context.SaveChanges();
				return server;
			}
			catch (Exception ex)
			{
				//throw new Exception(ex.Message);
				return null;
			}
		}

        public Server UpdateServer(Server serverRecebido, int Id)
        {
            try
            {
                if (Id != serverRecebido.Id)
                {
                    return null;
                }

                Server server = _context.Servers.AsNoTracking().FirstOrDefault(s => s.Id == Id);
               
                if (server == null)
                {
                    return null;
                }

                server = serverRecebido;
              
                _context.Update(server);
                _context.SaveChanges();
                return server;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


