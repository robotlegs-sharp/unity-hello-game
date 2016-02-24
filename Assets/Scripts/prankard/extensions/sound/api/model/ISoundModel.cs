using UnityEngine;
using System.Collections;
using prankard.extensions.sound.api.vo;

namespace prankard.extensions.sound.api.model
{
	public interface ISoundModel
	{
		void AddSoundEffects(SoundVO[] soundVOs);
		
		void AddMusicTracks(SoundVO[] soundVOs);
		
		SoundVO GetSoundEffect(string name);
		
		SoundVO GetMusicTrack(string name);
		
		float SoundVolume {get;set;}
		
		float MusicVolume {get;set;}
	}
}