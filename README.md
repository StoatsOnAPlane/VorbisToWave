# VorbisToWave

This project is just a subset of NAudio and NVorbis, made to run as a Portable Class Library for Monogame

https://github.com/AdamsLair/nvorbis/tree/master/NVorbis/Ogg

https://github.com/naudio/NAudio


Usage example:

```
public SoundEffect SoundEffectFromOgg(Stream oggStream)
        {
            MemoryStream wavStream = new MemoryStream();            
            VorbisToWave.CreateWave(oggStream, wavStream);
            wavStream.Seek(0, SeekOrigin.Begin);
            SoundEffect soundEffect = SoundEffect.FromStream(wavStream);
            wavStream.Dispose();
            oggStream.Dispose();
            
            //You could save the memory stream to a wav file in the app's
            //internal storage or cache so you don't have to do this again.
            
            //Weakness: this seems to load the sound effec into memory
            //TWICE.  Once in the memory stream and then again in the
            //SoundEffect.FromStream method.  Unfortunately, MemoryStream
            //Get buffer method isn't avaialable in PCL

            return soundEffect;
        }
```
