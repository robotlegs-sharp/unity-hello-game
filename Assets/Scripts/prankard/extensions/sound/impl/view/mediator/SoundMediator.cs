//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using robotlegs.bender.extensions.eventDispatcher.api;
using robotlegs.bender.extensions.mediatorMap.api;
using prankard.extensions.sound.api.events;
using prankard.extensions.sound.api.view;


namespace prankard.extensions.sound.impl.view.mediator
{
	public class SoundMediator : IMediator
	{
		[Inject]
		public ISoundView view {get;set;}
		
		[Inject]
		public IEventDispatcher dispatcher {get;set;}

		public void Initialize ()
		{
			view.dispatcher.AddEventListener(SoundEvent.Type.PLAY_SOUND_EFFECT, dispatcher.Dispatch);
			view.dispatcher.AddEventListener(SoundEvent.Type.PLAY_MUSIC_TRACK, dispatcher.Dispatch);
			view.dispatcher.AddEventListener(SoundEvent.Type.STOP_MUSIC_TRACK, dispatcher.Dispatch);
			view.dispatcher.AddEventListener(SoundEvent.Type.STOP_SOUND_EFFECTS, dispatcher.Dispatch);
		}

		public void Destroy ()
		{
			view.dispatcher.RemoveEventListener(SoundEvent.Type.PLAY_SOUND_EFFECT, dispatcher.Dispatch);
			view.dispatcher.RemoveEventListener(SoundEvent.Type.STOP_MUSIC_TRACK, dispatcher.Dispatch);
			view.dispatcher.RemoveEventListener(SoundEvent.Type.STOP_SOUND_EFFECTS, dispatcher.Dispatch);
			view.dispatcher.RemoveEventListener(SoundEvent.Type.PLAY_MUSIC_TRACK, dispatcher.Dispatch);
		}
	}
}

