using Robotlegs.Bender.Framework.API;
using prankard.extensions.language.api;
using prankard.extensions.language.impl;

namespace prankard.extensions.language
{
	public class LanguageExtension : IExtension 
	{
		public void Extend (IContext context)
		{
			context.injector.Map<ILanguageModel>().ToSingleton<LanguageModel>();
			context.injector.Map<ILanguageParser>().ToSingleton<LanguageXMLParser>();
			context.injector.Map<ILanguageSaveService>().ToSingleton<LanguageSaveService>();
			context.Configure<LanguageConfig>();
		}
	}
}