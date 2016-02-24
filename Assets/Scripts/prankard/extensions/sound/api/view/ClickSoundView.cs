using UnityEngine;
using System.Collections;

using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
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