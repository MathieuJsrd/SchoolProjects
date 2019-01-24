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
        private byte m_pixelRougeInt;
        private byte m_pixelVertInt;
        private byte m_pixelBleuInt;

        // On crée les acesseurs car on en aura besoin dans la classe CImage
        public byte PixelRougeInt
        {
            get { return m_pixelRougeInt; }
        }
        public byte PixelVertInt
        {
            get { return m_pixelVertInt; }
        }
        public byte PixelBleuInt
        {
            get { return m_pixelBleuInt; }
        }

        // Constructeur
        public CPixels(byte pixelRougeInt, byte pixelVertInt, byte pixelBleuInt)
        {
            m_pixelRougeInt = pixelRougeInt;
            m_pixelVertInt = pixelVertInt;
            m_pixelBleuInt = pixelBleuInt;
        }

        public string DisplayPixelStr()
        {
            string vide = "";
            return String.Format("{0:000}.{1:000}.{2:000}.{3}", m_pixelRougeInt, m_pixelVertInt, m_pixelBleuInt, vide + "|");
        }

    }
}
