using UnityEngine;
using UnityEngine.UI;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;

namespace prankard.extensions.language.api
{
	[RequireComponent(typeof(Text))]
	public class LanguageTextView : View, ILanguageView
	{
		public string Key
		{
			get
			{
				if (_key == null)
					_key = _text.text;
				return _key;
			}
		}

		public enum TextCase
		{
			REGULAR,
			UPPERCASE,
			LOWERCASE
		}

		public TextCase textCase = TextCase.REGULAR;

		private Text _text;

		private string _key;

		private void Awake()
		{
			_text = GetComponent<Text>();
		}

		protected override void Start ()
		{
			base.Start ();
		}

		public void UpdateText(string text)
		{
			switch (textCase)
			{
				case TextCase.LOWERCASE:
					text = text.ToLower();
					break;
				case TextCase.UPPERCASE:
					text = text.ToUpper();
					break;
			}
			_text.text = text;
		}
	}
}