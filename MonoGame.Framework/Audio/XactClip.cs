using System;
using System.IO;
using MiscUtil.IO;

namespace Microsoft.Xna.Framework.Audio
{
	internal class XactClip
	{
		float volume;
		
		abstract class ClipEvent {
			public XactClip clip;
			public abstract void Read(EndianBinaryReader reader, SoundBank soundBank);
			public abstract void Play();
			public abstract void Stop();
			public abstract void Pause();
			public abstract bool Playing { get; }
			public abstract float Volume { get; set; }
		}
		
		class EventPlayWave : ClipEvent {
			public SoundEffectInstance wave;

			public override void Read(EndianBinaryReader reader, SoundBank soundBank) {
				reader.ReadUInt32 (); //unkn
				uint trackIndex = reader.ReadUInt16 ();
				byte waveBankIndex = reader.ReadByte ();
				
				//unkn
				reader.ReadByte ();
				reader.ReadUInt16 ();
				reader.ReadUInt16 ();
				
				this.wave = soundBank.GetWave(waveBankIndex, trackIndex);
			}

			public override void Play() {
				wave.Volume = clip.Volume;
				if (wave.State == SoundState.Playing) wave.Stop ();
				wave.Play ();
			}
			public override void Stop() {
				wave.Stop ();
			}
			public override void Pause() {
				wave.Pause ();
			}
			public override bool Playing {
				get {
					return wave.State == SoundState.Playing;
				}
			}
			public override float Volume {
				get {
					return wave.Volume;
				}
				set {
					wave.Volume = value;
				}
			}
		}

		class EventPlayWavePitchVolumeFilterVariation : EventPlayWave {
			public override void Read (EndianBinaryReader reader, SoundBank soundBank)
			{
				base.Read (reader, soundBank);

				reader.ReadInt16 ();
				reader.ReadInt16 ();
				reader.ReadByte ();
				reader.ReadByte ();
				reader.ReadSingle ();
				reader.ReadSingle ();
				reader.ReadSingle ();
				reader.ReadSingle ();
				uint flags = reader.ReadUInt16 ();
			}
		}
		
		ClipEvent[] events;
		
		public XactClip (SoundBank soundBank, EndianBinaryReader clipReader, uint clipOffset)
		{
			long oldPosition = clipReader.BaseStream.Position;
			clipReader.BaseStream.Seek (clipOffset, SeekOrigin.Begin);
			
			byte numEvents = clipReader.ReadByte();
			events = new ClipEvent[numEvents];
			
			for (int i=0; i<numEvents; i++) {
				uint eventInfo = clipReader.ReadUInt32();
				
				uint eventId = eventInfo & 0x1F;
				switch (eventId) {
				case 1:
					events[i] = new EventPlayWave();
					events[i].Read(clipReader, soundBank);
					break;
				case 4:
					events[i] = new EventPlayWavePitchVolumeFilterVariation();
					events[i].Read (clipReader, soundBank);
					break;
				default:
					throw new NotImplementedException();
				}
				
				events[i].clip = this;
			}
			
			
			clipReader.BaseStream.Seek (oldPosition, SeekOrigin.Begin);
		}
		
		public void Play() {
			//TODO: run events
			events[0].Play ();
		}
		
		public void Stop() {
			events[0].Stop ();
		}
		
		public void Pause() {
			events[0].Pause();
		}
		
		public bool Playing {
			get {
				return events[0].Playing;
			}
		}
		
		public float Volume {
			get {
				return volume;
			}
			set {
				volume = value;
				events[0].Volume = value;
			}
		}
		
	}
}

