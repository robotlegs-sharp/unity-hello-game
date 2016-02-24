using Robotlegs.Bender.Bundles.MVCS;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class LanguageMediator : Mediator
	{
		[Inject] public ILanguageView view;

		public override void Initialize ()
		{
			AddContextListener(LanguageEvent.Type.CHANGED_LANGUAGE, OnChangedLanguage);
			RequestText();
		}

		private void RequestText()
		{
			AddContextListener<LanguageResponseEvent>(LanguageResponseEvent.Type.ON_REQUEST_CONTENT, OnRequestText);
			Dispatch(new LanguageRequestEvent(LanguageRequestEvent.Type.REQUEST_CONTENT, view.Key));
		}

		private void OnRequestText(LanguageResponseEvent evt)
		{
			RemoveContextListener<LanguageResponseEvent>(LanguageResponseEvent.Type.ON_REQUEST_CONTENT, OnRequestText);
			view.UpdateText(evt.Content);
		}

		private void OnChangedLanguage()
		{
			RequestText();
		}
	}
}