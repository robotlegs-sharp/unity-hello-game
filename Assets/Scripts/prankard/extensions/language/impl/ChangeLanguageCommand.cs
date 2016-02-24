using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class ChangeLanguageCommand : ICommand 
	{
		[Inject] public LanguageEvent evt;
		[Inject] public ILanguageModel model;

		public void Execute ()
		{
			model.SetCurrentLanguage(evt.LanguageKey);
		}
	}
}