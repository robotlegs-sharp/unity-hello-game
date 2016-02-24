using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.EventCommand.API;
using Robotlegs.Bender.Extensions.Mediation.API;
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