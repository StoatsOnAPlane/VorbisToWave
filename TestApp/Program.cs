using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream openStream = new FileStream("WinterIntro.ogg", FileMode.Open);
            FileStream outStream = new FileStream("WinterIntro.wav", FileMode.Create);

            VorbisToWave.CreateWave(openStream, outStream);

            openStream.Close();
            outStream.Close();
        }
    }
}
