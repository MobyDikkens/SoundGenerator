using System;
using System.Text;

namespace Sound
{

/*
**********************************************************************************************************
                    The "fmt " subchunk describes the sound data's format:

                    12        4   Subchunk1ID      Contains the letters "fmt "
                                                (0x666d7420 big-endian form).
                    16        4   Subchunk1Size    16 for PCM.  This is the size of the
                                                rest of the Subchunk which follows this number.
                    20        2   AudioFormat      PCM = 1 (i.e. Linear quantization)
                                                Values other than 1 indicate some 
                                                form of compression.
                    22        2   NumChannels      Mono = 1, Stereo = 2, etc.
                    24        4   SampleRate       8000, 44100, etc.
                    28        4   ByteRate         == SampleRate * NumChannels * BitsPerSample/8
                    32        2   BlockAlign       == NumChannels * BitsPerSample/8
                                                The number of bytes for one sample including
                                                all channels. I wonder what happens when
                                                this number isn't an integer?
                    34        2   BitsPerSample    8 bits = 8, 16 bits = 16, etc.
                            2   ExtraParamSize   if PCM, then doesn't exist
                            X   ExtraParams      space for extra parameters

**********************************************************************************************************
 */




    class WavFormat
    {

        private string _Subchunk1ID = "fmt ";

        private int _Subchunk1Size = 16;

        private short _AudioFormat = 1;

        private short _NumChannels = 1;

        private int _SampleRate = 44100;

        private int _ByteRate = 0;

        private short _BlockAlign = 0;

        private short _BitsPerSample = 16;


        public byte[] Subchunk1ID
        {
            get
            {
                return Encoding.ASCII.GetBytes(this._Subchunk1ID);
            }
        }

        public byte[] Subchunk1Size
        {
            get
            {
                return BitConverter.GetBytes(this._Subchunk1Size);
            }
        }

        public byte[] AudioFormat
        {
            get
            {
                return BitConverter.GetBytes(this._AudioFormat);
            }
        }

        public byte[] NumChannels
        {
            get
            {
                return BitConverter.GetBytes(this._NumChannels);
            }
        }

        public byte[] SampleRate
        {
            get
            {
                return BitConverter.GetBytes(this._SampleRate);
            }
        }

        public byte[] ByteRate
        {
            get
            {
                return BitConverter.GetBytes(this._ByteRate);
            }
        }

        public byte[] BlockAlign
        {
            get
            {
                return BitConverter.GetBytes(this._BlockAlign);
            }
        }


        public byte[] BitsPerSample
        {
            get
            {
                return BitConverter.GetBytes(this._BitsPerSample);
            }
        }


        public WavFormat()
        {
            this._ByteRate = this._SampleRate * this._NumChannels * this._BitsPerSample/8;

            this._BlockAlign = Convert.ToInt16(this._NumChannels * this._BitsPerSample / 8);
        }

    }
}