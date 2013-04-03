using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer.Drivers;
/*
 This printer driver is used to control the Robot Factory 3DLPrinter
 */
namespace UV_DLP_3D_Printer.Device_Interface
{
    public class RobotFactorySRL_3DLPrinter : GenericDriver
    {
        private static int stepspermm = 320;
        public static int PC2MACHINE = 190;
        public static int MACHINE2PC = 180;
        private static int P1 = 2;
        private static int P2 = 3;
        private static int P3 = 4;
        /*
         * this weird format uses a 7 byte data buffer
         * to exchange information to and from the Arduino
         * when sending info from the pc to the machine, use the 190
         * response from the machine are sent back as 180
         * */
        //command table
        public enum eCommand 
        {
            eZeroSteppMotor             = 1, // not used
            eStepperMotorUp             = 2, // move stepper up
            eStepperMotorDown           = 3, // move stepper down
            eRequiresFirmwareVersion    = 4, //P1=Ver1 P2=Ver2 P3=Ver3
            eWriteStepsOffset           = 10, //Steps from the EEPROM
            eReadStepsOffset            = 11, // Steps
            eSendLayerThickness         = 21, // P2 = H P3 = L in 10ths of mm
            eStartPrint                 = 22, // Steps standby P2=H P3=L
            eExposure                   = 23, // Time printing P2=H P3=L = sec /10
            eNextPrint                  = 25, // Steps down P2=H P3=L
            eNumberOfLayerToPrinting    = 29, // P1=H P2=M P3=L
            eBrightness                 = 59, // 0-100
            eContrast                   = 60, //0-100

        };
        public enum eDirection
        {
            eUP,
            eDOWN
        }
        private void CalcChecksum(ref byte[] data) 
        {
            int checksum=0;
            byte checklow=0;
            byte checkhigh=0;
            for (int c = 0; c < 5; c++) 
            {
                checksum += data[c];
            }
            checklow =(byte)( checksum & 0xff);
            checkhigh = (byte)((checksum >> 8) & 0xff);
            data[5] = checkhigh;
            data[6] = checklow;
        }
        public byte[] MakeCommand(eCommand command) 
        {
            byte []ret = new byte[7];

             // zero out the array to start
            for (int c = 0; c < ret.Length; c++) 
            {
                ret[c] = 0;
            }
            ret[0] = (byte)PC2MACHINE; // set the direction from the pc to the machine
            ret[1] = (byte)command; // set the command
            return ret;
        }
        public void SetContrast(int val) 
        {
            byte[] command = MakeCommand(eCommand.eContrast);
            command[P3] = (byte)val;
            CalcChecksum(ref command);
            Write(command, command.Length);
        }
        public void SetBrightness(int val) 
        {
            byte[] command = MakeCommand(eCommand.eBrightness);
            command[P3] = (byte)val;
            CalcChecksum(ref command);
            Write(command, command.Length);        
        }
        public void Move(eDirection dir, float mm)
        {
            byte[] command = null;
            int steps = (int)(mm * stepspermm);
            switch (dir) 
            {
                case eDirection.eUP:
                    command = MakeCommand(eCommand.eStepperMotorUp);
                    break;
                case eDirection.eDOWN:
                    command = MakeCommand(eCommand.eStepperMotorDown);
                    break;
            }
            // I'm assuming p1-p3 are used to hold the steps
            command[P1] = (byte)(0xff & (steps >> 16)); 
            command[P2] = (byte)(0xff & (steps >> 8)); 
            command[P3] = (byte)(0xff & steps);
            CalcChecksum(ref command);
            Write(command, command.Length);   
        }

        public RobotFactorySRL_3DLPrinter() 
        {
            m_drivertype = eDriverType.eRF_3DLPRINTER;
        }

        public override int Write(String line)
        {
            // we need a gcode simple interpreter here that
            //can take the G1 Z commands, and translate them into movement commands
           // m_serialport.Write(line);
            // we should also parse for the layer number and delay commands
           // return line.Length;
            if (line.Trim().ToUpper().StartsWith("G1")) 
            {
                // interpret this as a move command
                string []lines = line.Trim().Split(' ');
                // look for a z on the line
            }
            return -1;
        }
    }
}
