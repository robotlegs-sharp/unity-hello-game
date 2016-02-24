using robotlegs.bender.extensions.eventDispatcher.impl;

namespace prankard.extensions.language.impl
{
	public class LanguageResponseEvent : Event 
	{
		public enum Type
		{
			ON_REQUEST_CONTENT,
			ON_REQUEST_CURRENT_LANGUAGE
		}

		public string Content { get; private set; }

		public LanguageResponseEvent (Type type, string content) : base (type)
		{
			Content = content;
		}
	}
}