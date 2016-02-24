using System;
using System.Collections.Generic;

namespace prankard.extensions.language.api
{
	public struct LanguageContentVO
	{
		public Dictionary<string, string> languageContentByKey ;

		public string languageKey;

		public LanguageContentVO (string languageKey)
		{
			this.languageKey = languageKey;
			languageContentByKey = new Dictionary<string, string>();
		}
	}
}

