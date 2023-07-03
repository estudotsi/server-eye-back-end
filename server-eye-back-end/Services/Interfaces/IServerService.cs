using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IServerService
	{
		List<Server> ReadServers();
		Server ReadServerById(int Id);
	}
}
