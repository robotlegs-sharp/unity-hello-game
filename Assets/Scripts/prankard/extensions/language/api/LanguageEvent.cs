using Robotlegs.Bender.Extensions.EventManagement.Impl;

namespace prankard.extensions.language.api
{
	public class LanguageEvent : Event 
	{
		public enum Type
		{
			CHANGE_LANGUAGE,
			CHANGED_LANGUAGE
		}

		public string LanguageKey { get; private set; }

		public LanguageEvent (Type type, string languageKey) : base (type)
		{
			LanguageKey = languageKey;
		}
	}
}