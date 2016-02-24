using Robotlegs.Bender.Framework.API;
using prankard.extensions.language.impl;
using prankard.extensions.language.api;

namespace prankard.extensions.language
{
	public class LanguageXMLConfig : IConfig
	{
		private string _xmlString;

		[Inject] public ILanguageParser parser;
		[Inject] public ILanguageModel model;

		public LanguageXMLConfig(string xmlString)
		{
			_xmlString = xmlString;
		}

		public void Configure ()
		{
			model.AddLanguages(parser.Parse(_xmlString));
		}
	}
}

