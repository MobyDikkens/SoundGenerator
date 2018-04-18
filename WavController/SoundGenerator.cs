using System;
using System.Text;
using System.IO;

namespace Sound
{
    class SoundGenerator
    {
        private int durability = 0;

        private double frequence = 0;

        private double amplitude = 0;

        private short[] sound = null;

        private WavData data = null;

        private WavFormat format = null;

        private WavHeader header = null;



        private void Generate()
        {
            this.format = new WavFormat();

            int soundLenth = BitConverter.ToInt32(this.format.SampleRate,0) * BitConverter.ToInt16(this.format.NumChannels,0) * this.durability;

            this.sound = new short[soundLenth];

            for(int i=0;i<soundLenth;i++)
            {
                double tmp = Math.Sin(2 * Math.PI * this.frequence * i / BitConverter.ToInt32(format.SampleRate,0));

                this.sound[i] = Convert.ToInt16(this.amplitude * tmp);
            }

            this.data = new WavData(this.sound, BitConverter.ToInt16(format.BitsPerSample,0));

            this.header = new WavHeader(soundLenth * BitConverter.ToInt16(format.BitsPerSample,0)/8);


        }

        public void Save(string filename)
        {
            FileStream fs = new FileStream(filename,FileMode.Create);

            using(BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(header.ChunkID);
                writer.Write(header.ChunkSize);
                writer.Write(header.Format);


                writer.Write(format.Subchunk1ID);
                writer.Write(format.Subchunk1Size);
                writer.Write(format.AudioFormat);
                writer.Write(format.NumChannels);
                writer.Write(format.SampleRate);
                writer.Write(format.ByteRate);
                writer.Write(format.BlockAlign);
                writer.Write(format.BitsPerSample);


                writer.Write(data.Subchunk2ID);
                writer.Write(data.Subchunk2Size);

                foreach(var sample in data.Data)
                {
                    writer.Write(BitConverter.GetBytes(sample));
                }
                
            }



        }






        public SoundGenerator(int durability, double frequence, double amplitude)
        {
            this.durability = durability;
            this.amplitude = amplitude;
            this.frequence = frequence;

            this.Generate();
        }


    }
}