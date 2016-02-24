using UnityEngine;
using Robotlegs.Bender.Extensions.Mediation.API;

namespace prankard.extensions.language.api
{
	public interface ILanguageView : IView
	{
		string Key { get; }
		void UpdateText(string text);
	}
}