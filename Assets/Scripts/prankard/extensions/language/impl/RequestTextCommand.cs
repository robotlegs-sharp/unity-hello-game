using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using prankard.extensions.language.api;

namespace prankard.extensions.language.impl
{
	public class RequestTextCommand : ICommand 
	{
		[Inject] public LanguageRequestEvent evt;
		[Inject] public ILanguageModel model;
		[Inject] public IEventDispatcher dispatcher;

		public void Execute ()
		{
			switch ((LanguageRequestEvent.Type)evt.type)
			{
				case LanguageRequestEvent.Type.REQUEST_CONTENT:
					dispatcher.Dispatch(new LanguageResponseEvent(LanguageResponseEvent.Type.ON_REQUEST_CONTENT, model.GetText(evt.Key)));
					break;
				case LanguageRequestEvent.Type.REQUEST_CURRENT_LANGUAGE:
					dispatcher.Dispatch(new LanguageResponseEvent(LanguageResponseEvent.Type.ON_REQUEST_CURRENT_LANGUAGE, model.CurrentLanguage));
					break;
			}
		}
	}
}