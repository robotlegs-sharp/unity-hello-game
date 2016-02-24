using robotlegs.bender.extensions.commandCenter.api;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class SaveLanguageCommand : ICommand 
	{
		[Inject] public ILanguageSaveService saveService;
		[Inject] public LanguageEvent evt;

		public void Execute ()
		{
			saveService.SaveLanguage(evt.LanguageKey);
		}
	}
}