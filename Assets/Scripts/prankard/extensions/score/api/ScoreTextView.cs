using UnityEngine;
using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;
using UnityEngine.UI;

namespace prankard.extensions.score.api
{
	[RequireComponent(typeof(Text))]
	public class ScoreTextView : EventView, IDisplayScoreView
	{
		public int Score
		{
			set
			{
				_text.text = _prependText + value + _appendText;
			}
		}

		[SerializeField] private string _prependText;
		[SerializeField] private string _appendText;
		private Text _text;

		protected override void Start ()
		{
			_text = GetComponent<Text>();
			base.Start ();
		}
	}
}