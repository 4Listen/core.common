using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Types
{
    public class KeyValueDto<T, TV>
    {
		public KeyValueDto()
		{
		}

		public KeyValueDto(T key, TV value)
		{
			Key = key;
			Value = value;
		}

		public T Key { get; set; }

		public TV Value { get; set; }
	}

	public class KeyValueDto<T>
	{
		public KeyValueDto()
		{
		}

		public KeyValueDto(T key, string value)
		{
			Key = key;
			Value = value;
		}

		public T Key { get; set; }

		public string Value { get; set; }
	}

	public class KeyValueDto
	{
		public KeyValueDto()
		{
		}

		public KeyValueDto(string key, string value)
		{
			Key = key;
			Value = value;
		}

		public string Key { get; set; }

		public string Value { get; set; }
	}
}
