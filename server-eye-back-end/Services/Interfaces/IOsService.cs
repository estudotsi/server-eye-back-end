using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IOsService
	{
		List<Os> ReadOss();
		Os ReadOsById(int Id);
		Os AddOs(Os os);
	}
}
