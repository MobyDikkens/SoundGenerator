using System;
using System.Text;

namespace Sound
{


/*
****************************************************************************************
            The canonical WAVE format starts with the RIFF header:

            0         4   ChunkID          Contains the letters "RIFF" in ASCII form
                                        (0x52494646 big-endian form).
            4         4   ChunkSize        36 + SubChunk2Size, or more precisely:
                                        4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)
                                        This is the size of the rest of the chunk 
                                        following this number.  This is the size of the 
                                        entire file in bytes minus 8 bytes for the
                                        two fields not included in this count:
                                        ChunkID and ChunkSize.
            8         4   Format           Contains the letters "WAVE"
                                        (0x57415645 big-endian form).
****************************************************************************************           
 */




    class WavHeader
    {

        private string _ChunkID = "RIFF";

        private int _ChunkSize = 0;

        private string _Format = "WAVE";



        public byte[] ChunkID
        {
            get
            {
                return Encoding.ASCII.GetBytes(this._ChunkID);
            }
        }


        public byte[] ChunkSize
        {
            get
            {
                return BitConverter.GetBytes(this._ChunkSize);
            }

        }

        public byte[] Format
        {
            get
            {
                return Encoding.ASCII.GetBytes(this._Format);
            }
        }



        public WavHeader(int soundLenth)
        {
            this._ChunkSize = soundLenth + 36;
        }



    }
}