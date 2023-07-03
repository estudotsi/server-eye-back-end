namespace server_eye_back_end.Models
{
	public class Server
	{
		public int Id { get; set; }
		public string Ip { get; set; }
		public string Name { get; set; }
		public string Rede { get; set; }
		public int OsId { get; set; }
        public virtual Os Os { get; set; }
        public virtual List<App> Apps { get; set; }
		public virtual List<DB> DBs { get; set; }
	}
}
