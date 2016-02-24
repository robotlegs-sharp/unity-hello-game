using UnityEngine;
using System.Collections;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine.UI;
using prankard.extensions.sound.api.events;

namespace prankard.extensions.sound.api.view
{
	[RequireComponent(typeof(Slider))]
	public class SoundSliderView : EventView, ISoundSetView
	{
		[SerializeField]
		private bool _isMusic = false;

		private Slider _slider;

		protected override void Start ()
		{
			_slider = GetComponent<Slider> ();
			_slider.onValueChanged.AddListener (OnChangedValue);
			base.Start ();
		}

		protected override void OnDestroy ()
		{
			if (_slider != null)
				_slider.onValueChanged.RemoveListener (OnChangedValue);
			base.OnDestroy ();
		}

		public void UpdateSoundEffectsVolume (float volume)
		{
			if (!_isMusic)
				_slider.value = volume;
		}

		public void UpdateMusicVolume (float volume)
		{
			if (_isMusic)
				_slider.value = volume;
		}
		
		private void OnChangedValue(float value)
		{
			dispatcher.Dispatch (new SoundVolumeEvent (_isMusic ? SoundVolumeEvent.Type.SET_MUSIC_VOLUME : SoundVolumeEvent.Type.SET_SOUND_EFFECTS_VOLUME, value));
		}
	}
}