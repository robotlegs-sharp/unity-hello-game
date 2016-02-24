using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using prankard.extensions.language.api;
using prankard.extensions.language.impl;
using Robotlegs.Bender.Extensions.EventCommand.API;
using UnityEngine;
using System;

namespace prankard.extensions.language
{
	public class LanguageConfig : IConfig 
	{
		[Inject] public IMediatorMap mediatorMap;
		[Inject] public IEventCommandMap commandMap;
		[Inject] public ILanguageModel model;
		[Inject] public ILanguageSaveService saveService;
		[Inject] public ILogging logger;

		public void Configure ()
		{
			mediatorMap.Map<ILanguageView>().ToMediator<LanguageMediator>();
			mediatorMap.Map<ICurrentLanguageView>().ToMediator<CurrentLanguageMediator>();
			mediatorMap.Map<IChangeLanguageView>().ToMediator<ChangeLanguageMediator>();
			commandMap.Map(LanguageRequestEvent.Type.REQUEST_CONTENT).ToCommand<RequestTextCommand>();
			commandMap.Map(LanguageRequestEvent.Type.REQUEST_CURRENT_LANGUAGE).ToCommand<RequestTextCommand>();
			commandMap.Map(LanguageEvent.Type.CHANGE_LANGUAGE).ToCommand<ChangeLanguageCommand>();
			commandMap.Map(LanguageEvent.Type.CHANGE_LANGUAGE).ToCommand<SaveLanguageCommand>();

			string language;
			if (saveService.LanguageName == null)
			{
				language = Enum.GetName(typeof(SystemLanguage), Application.systemLanguage);
				logger.Info("Setting System Language: {0}", language);
			}
			else
			{
				language = saveService.LanguageName;
				logger.Info("Loading Saved Language: {0}", language);
			}
			model.SetCurrentLanguage(language);
		}
	}
}