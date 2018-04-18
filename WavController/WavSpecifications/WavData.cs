using System;
using System.Text;


namespace Sound
{


/*
***************************************************************************************************
                    The "data" subchunk contains the size of the data and the actual sound:

                    36        4   Subchunk2ID      Contains the letters "data"
                                                (0x64617461 big-endian form).
                    40        4   Subchunk2Size    == NumSamples * NumChannels * BitsPerSample/8
                                                This is the number of bytes in the data.
                                                You can also think of this as the size
                                                of the read of the subchunk following this 
                                                number.
                    44        *   Data             The actual sound data.
***************************************************************************************************
 */




    class WavData
    {
        public byte[] Subchunk2ID { get ; private set ; }

        public byte[] Subchunk2Size { get ; private set ; }

        public short[] Data { get ; private set ; }


        public WavData(short[] sound, short BitsPerSample)
        {
            if(sound != null)
            {
                this.Subchunk2ID = Encoding.ASCII.GetBytes("data");

                this.Subchunk2Size = BitConverter.GetBytes(sound.Length * BitsPerSample/8);

                this.Data = sound;
            }
        }

    }
}