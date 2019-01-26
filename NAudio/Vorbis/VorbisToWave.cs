using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudio.Vorbis
{
    public static class VorbisToWave
    {
        public static void CreateWave(Stream oggStream, Stream wavStream)
        {
            VorbisWaveReader vorbisReader = new VorbisWaveReader(oggStream);
            SampleToWaveProvider16 converter = new SampleToWaveProvider16(vorbisReader);

            using (var writer = new WaveFileWriter(wavStream, converter.WaveFormat))
            {
                int loopCount = 0;
                var buffer = new byte[converter.WaveFormat.AverageBytesPerSecond * 4];
                while (true)
                {
                    loopCount++;
                    Debug.WriteLine("looped: " + loopCount.ToString());

                    int bytesRead = converter.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // end of source provider
                        break;
                    }

                    // Write will throw exception if WAV file becomes too large
                    writer.Write(buffer, 0, bytesRead);
                }
            }

            vorbisReader.Dispose();
        }
    }
}
