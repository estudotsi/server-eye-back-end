namespace server_eye_back_end.Models
{
	public class Os
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Server> Servers { get; set; }
	}
}
