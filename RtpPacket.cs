using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2_mmcken5
{
    class RtpPacket
    {
        private byte[] rtpPacketPayload;
        private byte[] rtpPacketHeader;


        public RtpPacket(byte[] _packet, int _size)
        {
            rtpPacketHeader = new byte[12];
            rtpPacketPayload = new byte[_size - 12];

            // Read in the bytes of the packet header and store them
            for (int i = 0; i < 12; i++)
            {
                rtpPacketHeader[i] = _packet[i];
            }

            // Read in the bytes of the payload (i.e. the frame data)
            for (int i = 12; i < _size; i++)
            {
                rtpPacketPayload[i-12] = _packet[i];
            }
        }


        // Get the header of the packet
        public byte[] GetPacketHeader()
        {
            return rtpPacketHeader;
        }


        // Return the payload (frame) of the packet
        public byte[] GetPacketPayload()
        {
            return rtpPacketPayload;
        }


        // Return the sequence number of the packet
        public int GetPacketSequenceNumber()
        {
            // Get the high-order byte that stores the MSBs of the sequence number
            byte hB = rtpPacketHeader[2];

            // Convert the first byte to an int
            int hI = (int)hB; 

            // Use bitwise AND and the right shift operator to get the bits to the high-order positions
            int seqNo = ((hI & 0x00ff) >> 8);

            // Get the low-order byte of the sequence number
            byte lB = rtpPacketHeader[3];

            // Convert the second byte to an int
            int lI = (int)lB;

            // Use bitware AND to put the bits in the low-order positions
            lI = (lI & 0x00ff);

            // Use bitwise OR to combine the first 8 bits, with the last 8 bits
            seqNo = (seqNo | lI);

            return seqNo;
        }


        // Return the time stamp of the packet
        public long GetPacketTimeStamp()
        {
            // Get the bytes that store the time stamp
            byte b3 = rtpPacketHeader[4];
            byte b2 = rtpPacketHeader[5];
            byte b1 = rtpPacketHeader[6];
            byte b0 = rtpPacketHeader[7];

            // Convert the bytes to ints
            long i3 = (long)b3;
            long i2 = (long)b2;
            long i1 = (long)b1;
            long i0 = (long)b0;

            // Use bitwise AND and the shift operator to get all the bits in the correct position
            i3 = ((i3 & 0x000000ff) << 24);
            i2 = ((i2 & 0x000000ff) << 16);
            i1 = ((i1 & 0x000000ff) << 8);
            i0 = (i0 & 0x000000ff);

            // Use bitwise OR to combine all the bytes into one number
            long timeStamp = (((i3 | i2) | i1) | i0);

            return timeStamp;
        }


        // Return the payload type of the packet
        public int GetPacketPayloadType()
        {
            // Get the byte that stores the marker (1 bit) and the payload type (7 bits)
            byte b = rtpPacketHeader[1];

            // Covert the byte to an int
            int i = (int)b; 

            // Use bitwise AND to get only the payload type (7 bits)
            i = (i & 0x7f);

            return i; 
        }
    }
}
