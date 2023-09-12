namespace server_eye_back_end.Models
{
	public class DB
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
		public int ServerId { get; set; }
		public virtual Server? Server { get; set; }
		public virtual App? App { get; set; }
	}
}
