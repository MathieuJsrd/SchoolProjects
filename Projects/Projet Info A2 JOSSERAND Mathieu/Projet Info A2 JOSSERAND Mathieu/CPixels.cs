using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class CPixels
    {
        // Chaque pixel est codé selon trois octets, et chacun de ces octets codent dans cet ordre,
        // le pixel Rouge, le pixel Vert, et le pixel Bleu
        private byte m_pixelRougeByte;
        private byte m_pixelVertByte;
        private byte m_pixelBleuByte;

        // On crée les acesseurs car on en aura besoin dans la classe CImage
        public byte PixelRougeByte
        {
            get { return m_pixelRougeByte; }
        }
        public byte PixelVertByte
        {
            get { return m_pixelVertByte; }
        }
        public byte PixelBleuByte
        {
            get { return m_pixelBleuByte; }
        }

        // Constructeur
        public CPixels(byte pixelBleuByte, byte pixelVertByte, byte pixelRougeByte)
        {
            m_pixelRougeByte = pixelRougeByte;
            m_pixelVertByte = pixelVertByte;
            m_pixelBleuByte = pixelBleuByte;
        }
        public CPixels()
        {
            m_pixelRougeByte = 0;
            m_pixelVertByte = 0;
            m_pixelBleuByte = 0;
        }
        public string DisplayPixelStr()
        {
            string vide = "";
            return String.Format("{0:000}.{1:000}.{2:000}.{3}", m_pixelRougeByte, m_pixelVertByte, m_pixelBleuByte, vide + "|");
        }

    }
}

