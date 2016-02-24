using robotlegs.bender.extensions.eventDispatcher.impl;

namespace prankard.extensions.language.impl
{
	public class LanguageRequestEvent : Event 
	{
		public enum Type
		{
			REQUEST_CONTENT,
			REQUEST_CURRENT_LANGUAGE
		}

		public string Key { get; private set; }

		public LanguageRequestEvent (Type type) : base (type) {}

		public LanguageRequestEvent (Type type, string key) : base (type)
		{
			Key = key;
		}
	}
}