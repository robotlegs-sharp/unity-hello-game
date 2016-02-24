using robotlegs.bender.extensions.mediatorMap.api;

namespace prankard.extensions.language.api
{
	public interface ICurrentLanguageView : IEventView 
	{
		string CurrentLanguage { set; }
	}
}