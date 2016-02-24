using robotlegs.bender.bundles.mvcs;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class CurrentLanguageMediator : Mediator
	{
		[Inject] public ICurrentLanguageView view;

		public override void Initialize ()
		{
			AddContextListener<LanguageEvent>(LanguageEvent.Type.CHANGED_LANGUAGE, OnChangedLanguage);
			GetLanguage();
		}

		private void GetLanguage()
		{
			AddContextListener<LanguageResponseEvent>(LanguageResponseEvent.Type.ON_REQUEST_CURRENT_LANGUAGE, OnGotLanguage);
			Dispatch(new LanguageRequestEvent(LanguageRequestEvent.Type.REQUEST_CURRENT_LANGUAGE));
		}

		private void OnGotLanguage(LanguageResponseEvent evt)
		{
			RemoveContextListener<LanguageResponseEvent>(LanguageResponseEvent.Type.ON_REQUEST_CURRENT_LANGUAGE, OnGotLanguage);
			view.CurrentLanguage = evt.Content;
		}

		private void OnChangedLanguage(LanguageEvent evt)
		{
			view.CurrentLanguage = evt.LanguageKey;
		}
	}
}