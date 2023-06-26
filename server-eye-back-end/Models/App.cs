namespace server_eye_back_end.Models
{
	public class App
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ServerId { get; set; }
        public virtual Server Server { get; set; }
    }
}
