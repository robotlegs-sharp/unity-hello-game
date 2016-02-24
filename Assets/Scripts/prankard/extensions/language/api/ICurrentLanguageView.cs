using Robotlegs.Bender.Extensions.Mediation.API;

namespace prankard.extensions.language.api
{
	public interface ICurrentLanguageView : IEventView 
	{
		string CurrentLanguage { set; }
	}
}