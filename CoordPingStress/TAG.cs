using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordPingStress
{

    class TAG
    {
        private byte[] au8Data;
        private byte DLE = 0x10;
        private byte STX = 0x02;
        private byte u8TxSeq;
        // private byte psCmd = 0x54;
        private byte cType = 0x55;   ///????
        private UInt32 u32SleepMs = 0x54102700;
        private UInt16 u16HwData=0;
        private byte u8Input=0;
        private byte i16DeciCelcius = 20;
        private UInt16 u16MilliVolts = 3300;
        private byte u8PingBadAck;
        private UInt64 u64Node = 0x00158d00002e9f75;
        private UInt64 u64Rx = 0x0123456789abcdef;
        private byte u8Lqi = 0xff;
        private byte u8BdCastSeq = 0;
        private byte u8BdCastAck = 0;

        private UInt16 u16TofCount;
        private byte u8TofTimo;
        private byte u8TofBad;
        private byte u8TofGood;
        private UInt32 i32TofDistance;
        private byte u8TofErrors;
        private UInt64 u64TofNode;
        private byte u8TofRxLqi;
        private byte u8MethUpper;
        private byte u8MethLower;
        private byte u8CoUpper;
        private byte u8CoLower;
        private byte u8O2Upper;
        private byte u8O2Lower;
        private byte u8Co2Upper;
        private byte u8Co2Lower;
        private uint u32Checksum;

        public TAG(UInt64 nodeAdd)
        {
            u64Node = nodeAdd;
            au8Data =new byte[100];
        }

        //public string getTagdata()
        //{
        //    //string " "
        //}


        public void setSequ(byte sequ)
        {
            u8TxSeq = sequ;

        }

        public byte[] formatUartPacket()
        { /* format of UART output, utilises DLE-STX framing     */
            byte u8Data = 0;

            au8Data[u8Data++] = DLE;                                        //< framing character 1 - HEADER
            au8Data[u8Data++] = STX;                                        //< framing character 2 - HEADER
            au8Data[u8Data++] = 0x00;                                       //< Length              - HEADER
            au8Data[u8Data++] = u8TxSeq;                                  //< rolling output sequence
            au8Data[u8Data++] = cType;                                       //< packet type
            au8Data[u8Data++] = (byte)(u32SleepMs & 0xFF);         //< sleep period msec
            au8Data[u8Data++] = (byte)((u32SleepMs >> 8) & 0xFF);
            au8Data[u8Data++] = (byte)((u32SleepMs >> 16) & 0xFF);
            au8Data[u8Data++] = (byte)((u32SleepMs >> 24) & 0xFF);
            au8Data[u8Data++] = (byte)(u16HwData & 0xFF);   //< H/W data flags Lower
            au8Data[u8Data++] = (byte)((u16HwData >> 8) & 0xFF);   //< H/W data flags Upper
            au8Data[u8Data++] = (byte)(u8Input);                   //< input data (i.e. H/W inputs, switches, relays, etc...)
            au8Data[u8Data++] = (byte)(i16DeciCelcius / 10);              //< temperature scaled to deci-celcius
            au8Data[u8Data++] = (byte)(u16MilliVolts & 0xFF);      //< voltage mW
            au8Data[u8Data++] = (byte)((u16MilliVolts >> 8) & 0xFF);
            au8Data[u8Data++] = u8PingBadAck;                        //< rolling count of pings WITH NO APP-ACK RETURNED
            au8Data[u8Data++] = (byte)(u64Node & 0xFF);     //< TAG node MAC-ADDRESS low
            au8Data[u8Data++] = (byte)((u64Node >> 8) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Node >> 16) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Node >> 24) & 0xFF);
            au8Data[u8Data++] = (byte)(u64Node >> 32 & 0xFF);     //< TAG node MAC-ADDRESS high
            au8Data[u8Data++] = (byte)((u64Node >> 40) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Node >> 48) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Node >> 56) & 0xFF);
            au8Data[u8Data++] = (byte)(u64Rx & 0xFF);       //< READER node MAC-ADDRESS low
            au8Data[u8Data++] = (byte)((u64Rx >> 8) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Rx >> 16) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Rx >> 24) & 0xFF);
            au8Data[u8Data++] = (byte)(u64Rx >> 32 & 0xFF);       //< READER node MAC-ADDRESS high
            au8Data[u8Data++] = (byte)((u64Rx >> 40) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Rx >> 48) & 0xFF);
            au8Data[u8Data++] = (byte)((u64Rx >> 56) & 0xFF);

            au8Data[u8Data++] = u8Lqi;                               //< LQI

            au8Data[u8Data++] = u8BdCastSeq;                                 //< returned broadcast sequence number (i.e. confirms that a broadcast has been RX'd by a TAG)
            au8Data[u8Data++] = u8BdCastAck;                                 //< broadcast acknowledge byte returned by the TAG USER
            //  (i.e. can be represented as button mask, or a hex number referencing an acknowledgnment type)

            /**********************************************************************************/
            /************************************ 35 BYTES ************************************/
            /**********************************************************************************/

            //#ifdef DD_ENABLE_TOFF
            au8Data[u8Data++] = (byte)(u16TofCount & 0xFF);         //< TOF : ping count (i.e. rolling count of TOF cycles)
            au8Data[u8Data++] = (byte)((u16TofCount >> 8) & 0xFF);
            au8Data[u8Data++] = (byte)(u8TofTimo);                         //< TOF : timeout count (i.e. time-out before READER has responded to TOF request)
            au8Data[u8Data++] = (byte)(u8TofBad);                          //< TOF : bad TOF count (i.e. READER has refused TOF request)
            au8Data[u8Data++] = (byte)(u8TofGood);                         //< TOF : good TOF count (i.e. READER has responded with "TOF_SUCCESS")
            au8Data[u8Data++] = (byte)(i32TofDistance & 0xFF);      //< TOF : TOF distance (cm) from READER
            au8Data[u8Data++] = (byte)((i32TofDistance >> 8) & 0xFF);
            au8Data[u8Data++] = (byte)((i32TofDistance >> 16) & 0xFF);
            au8Data[u8Data++] = (byte)((i32TofDistance >> 24) & 0xFF);
            au8Data[u8Data++] = (byte)(u8TofErrors);                       //< TOF : error count (i.e. number of errored frames in last TOF reading)
            au8Data[u8Data++] = (byte)(u64TofNode & 0xFF);          //< TOF : MAC-ADDRESS of the TOF ranging node (i.e. the READER last TOF'd with)
            au8Data[u8Data++] = (byte)((u64TofNode >> 8) & 0xFF);
            au8Data[u8Data++] = (byte)((u64TofNode >> 16) & 0xFF);
            au8Data[u8Data++] = (byte)((u64TofNode >> 24) & 0xFF);
            au8Data[u8Data++] = (byte)((u64TofNode >> 32) & 0xFF);
            au8Data[u8Data++] = (byte)((u64TofNode >> 40) & 0xFF);
            au8Data[u8Data++] = (byte)((u64TofNode >> 48) & 0xFF);
            au8Data[u8Data++] = (byte)((u64TofNode >> 56) & 0xFF);

            au8Data[u8Data++] = (byte)(u8TofRxLqi);                        //< TOF : RX LQI value extracted from APP-ACK, used to measure LQI threshold
            //#endif

            //#ifdef AERO_ENABLE_GAS_SENSOR                           // TRUE
            au8Data[u8Data++] = u8MethUpper;
            au8Data[u8Data++] = u8MethLower;
            au8Data[u8Data++] = u8CoUpper;
            au8Data[u8Data++] = u8CoLower;
            au8Data[u8Data++] = u8O2Upper;
            au8Data[u8Data++] = u8O2Lower;
            au8Data[u8Data++] = u8Co2Upper;
            au8Data[u8Data++] = u8Co2Lower;
            //#endif

            /**********************************************************************************/
            /************************************ 62 BYTES ************************************/
            /**********************************************************************************/

            //    memcpy(&au8Data[u8Data], psCmd->acName, 16);                          // Name
            //    u8Data += 16;

            /* update the length byte with the length of the UN-STUFFED data packet, excluding
             * the 3 DLE-STX-LENGTH header bytes
             */
            au8Data[2] = (byte)(u8Data - 3);

            /* Calculate checksum.
             * Uses ADLER-32, which is deemed to be rather weak.
             * May replace with CRC-16 (i.e. as in PC21-FE datagram)
             */
            //u32Checksum = u32Alder(&au8Data[3],
            //                        au8Data[2],
            //                        &a,&b,
            //                        TRUE);

            u32Checksum = calcAdler32(3, au8Data[2]);
            /* add the checksum to the message
             */
            au8Data[u8Data++] = (byte)(u32Checksum & 0xff);
            au8Data[u8Data++] = (byte)((u32Checksum >> 8) & 0xff);
            au8Data[u8Data++] = (byte)((u32Checksum >> 16) & 0xff);
            au8Data[u8Data++] = (byte)((u32Checksum >> 24) & 0xff);

            //return au8Data;

            /* STUFF THE DATA PACKET WITH <DLE>  !!
     */
            byte[] pu8Data = new byte[100];
            byte u8Len = 0;
            for (int u8Pos = 0; u8Pos < u8Data; u8Pos++)
            {
                /* ...byte is DLE and not the first ?
                 */
                if (au8Data[u8Pos] == DLE && u8Pos != 0)
                {
                    /* ...then output a DLE stuff byte
                     */
                    pu8Data[u8Len++] = au8Data[u8Pos];
                }
                /* ...output original byte
                 */
                pu8Data[u8Len++] = au8Data[u8Pos];
            }

            /* for conformity we could terminate the packet with DLE-ETX,
             * but on this regard we shall align with the PC21 datagram
             * format where DLE-ETX is NOT used
             */
            /**
             *   pu8Data[u8Len++] = DLE;
             *   pu8Data[u8Len++] = ETX;
             */


            /**********************************************************************************/
            /****** pu8Data[2] = STUFFED-PACKET-DATA-LENGTH <i.e. DATA + CHECKSUM >   *********/
            /**********************************************************************************/

            /*######################################################################*/
            /*                  THERE IS A POTENTIAL BUG HERE !!!                   */
            /*                                                                      */
            /* IF THE INSERTED LENGTH IS 0X10 (i.e. DLE) THEN THIS BYTE WILL NOT    */
            /*                      HAVE BEEN STUFFED !!                            */
            /*                                                                      */
            /* THEREFORE THE WHOLE FRAME WILL NEED TO BE RE-STUFFED,                */
            /* AND THE LENGTH BYTE UPDATING AGAIN.                                  */
            /*######################################################################*/

            /* update the length byte with the length of the STUFFED data packet, excluding
             * the 3 DLE-STX-LENGTH header bytes
             */
            pu8Data[2] = (byte)(u8Len - 3);

            //return u8Len;
            return pu8Data;





        }


        private uint calcAdler32(int startPoint, uint length)
        {
            uint ckSumCalc;
            //adler32 check sum
            {
                uint a = 1, b = 0;
                int index;
                const uint MOD_ADLER = 65521;

                /* Process each byte of the data in order */
                for (index = startPoint; index < (startPoint + length); ++index)
                {
                    a = (a + (uint)au8Data[index]) % MOD_ADLER;
                    b = (b + a) % MOD_ADLER;
                }

                ckSumCalc = (b << 16) | a;   // needs work !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            return ckSumCalc;
        }


    }
}
