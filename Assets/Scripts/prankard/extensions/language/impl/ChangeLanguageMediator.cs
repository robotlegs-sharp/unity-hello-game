using robotlegs.bender.bundles.mvcs;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class ChangeLanguageMediator : Mediator
	{
		public override void Initialize ()
		{
			AddViewListener(LanguageEvent.Type.CHANGE_LANGUAGE, Dispatch);
		}
	}
}