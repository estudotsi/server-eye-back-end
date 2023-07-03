using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IDBService
	{
		List<DB> ReadADbs();
		DB ReadDbById(int Id);
	}
}
