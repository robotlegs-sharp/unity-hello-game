using UnityEngine;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine.UI;

namespace prankard.extensions.highscore.api
{
	[RequireComponent(typeof(Text))]
	public class HighscoreTextView : EventView, IHighscoreView
	{
		[SerializeField] private string _prependText;
		[SerializeField] private string _appendText;
		private Text _text;

		public int Highscore
		{
			set
			{
				_text.text = _prependText + value + _appendText;
			}
		}

		protected override void Start ()
		{
			_text = GetComponent<Text>();
			base.Start ();
		}
	}
}