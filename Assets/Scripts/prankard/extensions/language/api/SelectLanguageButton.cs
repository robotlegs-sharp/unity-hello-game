using UnityEngine;
using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;
using UnityEngine.UI;

namespace prankard.extensions.language.api
{
	[RequireComponent(typeof(Button))]
	public class SelectLanguageButton : EventView, ICurrentLanguageView, IChangeLanguageView
	{
		[SerializeField] private string _language;

		private Button _button;

		public string CurrentLanguage
		{
			set
			{
				if (_language == value)
					_button.interactable = false;
				else
					_button.interactable = true;
			}
		}

		protected override void Start ()
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClickButton);
			base.Start ();
		}

		public void OnClickButton()
		{
			dispatcher.Dispatch(new LanguageEvent(LanguageEvent.Type.CHANGE_LANGUAGE, _language));
		}
	}
}