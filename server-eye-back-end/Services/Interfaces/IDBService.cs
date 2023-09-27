using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IDBService
	{
		List<DB> ReadADbs();
        List<DB> ReadADbAvaiable();
        DB ReadDbById(int Id);
		DB AddDb(DB db);
        DB DeleteDb(int Id);
        DB UpdateDb(DB db, int Id);
    }
}
