namespace Core.Common.Types
{
	public class FileResultBase
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string OriginalName { get; set; }

		public long Size { get; set; }

		public string Extension { get; set; }

		public string ContentType { get; set; }
	}
}