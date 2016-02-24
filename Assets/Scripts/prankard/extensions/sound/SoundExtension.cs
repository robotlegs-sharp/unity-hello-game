using System.Collections;
using UnityEngine;
using robotlegs.bender.extensions.mediatorMap.api;
using robotlegs.bender.framework.api;
using prankard.extensions.sound.api.events;
using prankard.extensions.sound.api.model;
using prankard.extensions.sound.api.view;
using prankard.extensions.sound.impl.command;
using prankard.extensions.sound.impl.constant;
using prankard.extensions.sound.impl.model;
using prankard.extensions.sound.impl.view.mediator;
using robotlegs.bender.extensions.eventCommandMap.api;

namespace prankard.extensions.sound
{
	public class SoundExtension : IExtension 
	{
		private GameObject soundFX;
		private GameObject soundMusic;

		public void Extend (IContext context)
		{
			IMediatorMap mediatorMap = context.injector.GetInstance<IMediatorMap> ();
			IEventCommandMap commandMap = context.injector.GetInstance<IEventCommandMap> ();

			// Sound
			context.injector.Map<ISoundModel>().ToSingleton<SoundModel>();
			commandMap.Map(SoundEvent.Type.PLAY_SOUND_EFFECT).ToCommand<PlaySoundCommand>();
			commandMap.Map(SoundEvent.Type.PLAY_MUSIC_TRACK).ToCommand<PlaySoundCommand>();
			commandMap.Map(SoundEvent.Type.STOP_MUSIC_TRACK).ToCommand<PlaySoundCommand>();
			commandMap.Map(SoundEvent.Type.STOP_SOUND_EFFECTS).ToCommand<PlaySoundCommand>();
			commandMap.Map(SoundVolumeEvent.Type.SET_MUSIC_VOLUME).ToCommand<SetSoundVolumeCommand>();
			commandMap.Map(SoundVolumeEvent.Type.SET_SOUND_EFFECTS_VOLUME).ToCommand<SetSoundVolumeCommand>();

			mediatorMap.Map(typeof(SoundLoaderView)).ToMediator(typeof(SoundLoaderMediator));
			mediatorMap.Map(typeof(ISoundSetView)).ToMediator(typeof(SoundSetMediator));
			mediatorMap.Map(typeof(ISoundView)).ToMediator(typeof(SoundMediator));
			soundFX = new GameObject("SoundFX");
			soundMusic = new GameObject("SoundMusic");
			soundFX.hideFlags = soundMusic.hideFlags = HideFlags.HideInHierarchy;
			GameObject.DontDestroyOnLoad(soundFX);
			GameObject.DontDestroyOnLoad(soundMusic);
			context.injector.Map<GameObject>(SoundKeys.GAMEOBJECT_EFFECTS).ToValue(soundFX);
			context.injector.Map<GameObject>(SoundKeys.GAMEOBJECT_MUSIC).ToValue(soundMusic);

			context.AfterDestroying(Cleanup);
		}

		private void Cleanup()
		{
			GameObject.Destroy(soundFX);
			GameObject.Destroy(soundMusic);
		}
	}
}