using System.Xml;
using prankard.extensions.language.api;
using System.Collections.Generic;

namespace prankard.extensions.language.impl
{
	public class LanguageXMLParser : ILanguageParser
	{
		public LanguageVO[] Parse(string xmlString)
		{
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlString);
			List<LanguageVO> languageVOs = new List<LanguageVO>();
			foreach (XmlNode languageNode in document.FirstChild.SelectNodes("language"))
			{
				string languageName = languageNode.Attributes.GetNamedItem("name").InnerText;
				List<CopyVO> copyVOs = new List<CopyVO>();
				foreach (XmlNode copy in languageNode.SelectNodes("copy"))
				{
					string key = copy.Attributes.GetNamedItem("key").InnerText;
					string content = copy.InnerText;
					copyVOs.Add(new CopyVO(key, content));
				}
				LanguageVO language = new LanguageVO();
				language.name = languageName;
				language.copy = copyVOs.ToArray();
				languageVOs.Add(language);
			}
			return languageVOs.ToArray();
		}
	}
}