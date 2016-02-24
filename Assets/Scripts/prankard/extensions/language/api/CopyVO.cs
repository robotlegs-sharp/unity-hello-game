using System;

namespace prankard.extensions.language.api
{
	public class CopyVO
	{
		public string key;
		public string copy;

		public CopyVO (string key, string copy)
		{
			this.key = key;
			this.copy = copy;
		}
	}
}

