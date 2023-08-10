using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IServerService
	{
		List<Server> ReadServers();
		Server ReadServerById(int Id);
		List<Server> RedeServerByRede(string rede);
		Server AddServer(Server server);
		Server DeleteServer(int Id);
        Server UpdateServer(Server server, int Id);
    }
}


