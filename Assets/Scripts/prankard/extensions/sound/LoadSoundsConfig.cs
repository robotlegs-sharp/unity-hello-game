using robotlegs.bender.framework.api;
using robotlegs.bender.extensions.eventCommandMap.api;
using robotlegs.bender.extensions.mediatorMap.api;
using prankard.extensions.sound.api.model;
using prankard.extensions.sound.api.vo;

namespace prankard.extensions.sound
{
	public class LoadSoundsConfig : IConfig 
	{
		[Inject] public ISoundModel soundModel;

		private SoundConfigVO _soundData;

		public LoadSoundsConfig(SoundConfigVO soundData)
		{
			_soundData = soundData;
		}
	
		public void Configure ()
		{
			soundModel.AddSoundEffects(_soundData.sounds);
			soundModel.AddMusicTracks(_soundData.music);
		}
	}
}