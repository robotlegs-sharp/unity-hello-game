using UnityEngine;
using System.Collections;

using robotlegs.bender.platforms.unity.extensions.mediatorMap.impl;
using UnityEngine.UI;
using prankard.extensions.sound.api.events;

namespace prankard.extensions.sound.api.view
{
	public class ClickSoundView : EventView, ISoundView
	{
		[SerializeField] private string soundEffectID = "button";

		public void OnClick()
		{
			dispatcher.Dispatch(new SoundEvent(SoundEvent.Type.PLAY_SOUND_EFFECT, soundEffectID));
		}

		override protected void Start()
		{
			base.Start();
			this.GetComponent<Button>().onClick.AddListener(OnClick);
		}

		protected override void OnDestroy ()
		{
			this.GetComponent<Button>().onClick.RemoveListener(OnClick);
			base.OnDestroy ();
		}
	}
}