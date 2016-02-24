using UnityEngine;
using robotlegs.bender.extensions.mediatorMap.api;

namespace prankard.extensions.language.api
{
	public interface ILanguageView : IView
	{
		string Key { get; }
		void UpdateText(string text);
	}
}