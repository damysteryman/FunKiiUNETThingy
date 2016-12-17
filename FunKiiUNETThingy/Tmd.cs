using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunKiiUNETThingy
{
    class Tmd
    {
        private byte[] tmdData { get; set; }

        public Tmd(byte[] _tmdData)
        {
            tmdData = _tmdData;
        }

        public byte[] ExportTmdData()
        {
            return tmdData;
        }

        public UInt16 GetTitleVersion()
        {
            byte[] version = new byte[2] { tmdData[0x1DC], tmdData[0x1DD] };
            return version.ToUInt16();
        }

        public uint GetContentCount()
        {
            byte[] count = new byte[2] { tmdData[0x1DE], tmdData[0x1DF] };
            return count.ToUInt16();
        }

        public uint GetContentID(uint contentIndex)
        {
            uint contentDataLoc = 0xB04 + (0x30 * contentIndex);

            byte[] id = new byte[4] { tmdData[contentDataLoc], tmdData[contentDataLoc + 1], tmdData[contentDataLoc + 2], tmdData[contentDataLoc + 3], };

            return id.ToUInt32();
        }

        public string GetContentIDString(uint contentIndex)
        {
            uint contentDataLoc = 0xB04 + (0x30 * contentIndex);

            byte[] id = new byte[4] { tmdData[contentDataLoc], tmdData[contentDataLoc + 1], tmdData[contentDataLoc + 2], tmdData[contentDataLoc + 3], };

            string contentString = "";
            foreach (byte idbyte in id)
                contentString += idbyte.ToString("x2");

            return contentString;
        }

        public uint GetContentType(uint contentIndex)
        {
            uint contentDataLoc = 0xB04 + (0x30 * contentIndex);

            byte[] type = new byte[2] { tmdData[contentDataLoc + 0x6], tmdData[contentDataLoc + 0x7] };

            return type.ToUInt16();
        }

        public UInt64 GetContentSize(uint contentIndex)
        {
            uint contentDataLoc = 0xB04 + (0x30 * contentIndex);

            byte[] size = new byte[8]
            {
                tmdData[contentDataLoc + 0x8],
                tmdData[contentDataLoc + 0x9],
                tmdData[contentDataLoc + 0xA],
                tmdData[contentDataLoc + 0xB],
                tmdData[contentDataLoc + 0xC],
                tmdData[contentDataLoc + 0xD],
                tmdData[contentDataLoc + 0xE],
                tmdData[contentDataLoc + 0xF] };

            return size.ToUInt64();
        }
    }
}
