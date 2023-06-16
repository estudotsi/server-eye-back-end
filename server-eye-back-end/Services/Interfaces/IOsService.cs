using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IOsService
	{
		List<Os> ReadOss();
		Os ReadOsBiId(int Id);
	}
}
