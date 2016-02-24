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
using Robotlegs.Bender.Extensions.EventManagement.Impl;


namespace prankard.extensions.sound.api.events
{
	public class SoundEvent : Event
	{
		public enum Type
		{
			PLAY_SOUND_EFFECT,
			PLAY_MUSIC_TRACK,
			STOP_MUSIC_TRACK,
			STOP_SOUND_EFFECTS
		}
		
		private string _name;
		
		public string Name
		{
			get
			{
				return _name;
			}
		}
		
		private float _pitch = 1f;
		
		public float Pitch
		{
			get
			{
				return _pitch;
			}
		}
		
		public SoundEvent (Type type) : base (type)
		{
		}
		
		public SoundEvent (Type type, string name) : base (type)
		{
			_name = name;
		}
		
		public SoundEvent (Type type, string name, float pitch) : base (type)
		{
			_name = name;
			_pitch = pitch;
		}
	}
}

