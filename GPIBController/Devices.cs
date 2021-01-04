using NationalInstruments.NI4882;
using System;

namespace GPIBController
{
    static class Devices
    {
        public static Device devicePolarizationAnalyzer;
        public static Device deviceLaserSource;
    }

    static class DeviceControl
    {
        public static string MsgWaveLenghtSrc(double waveLenght = 1551.120)
        {
            return ":WAVElength " + waveLenght.ToString() + "nm";
        }

        public static string MsgPowerSrc(double power = 1000)
        {
            return ":POWer " + power.ToString() + "uW";
        }

        public static string MsgWaveLenghtPol(double waveLenght = 1551.12)
        {
            return "L " + waveLenght.ToString() + ";X;";
        }

        public static void InitDGDMesure(double wavelength)
        {
            //Console.WriteLine("Set Source  WL - " + wavelength.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtSrc(wavelength)));//change wavelength source
            //Console.WriteLine("Set PAT9000 WL - " + wavelength.ToString());
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtPol(wavelength)));//change wavelength pol
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("PO;X;"));//Optimizing the polarizer position in the module
        }

        public static void LaserOn(double power)
        {
            //Console.WriteLine("Set Source Power - " + power.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgPowerSrc(power))); // set power to 1000uW
            //Console.WriteLine("Laser is ON !");
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 1")); // turn on the laser
        }

        public static void LaserOff()
        {
            //Console.WriteLine("Laser is Off !");
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(":OUTPut 0")); // turn off the laser
        }

        public static string GetJonesMatrix(double wavelenght, int delay)
        {
            string jString;

            //Console.WriteLine("Set Source  WL - " + wavelenght.ToString());
            Devices.deviceLaserSource.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtSrc(wavelenght)));//change wavelength source

            //Console.WriteLine("Set PAT9000 WL - " + wavelenght.ToString());
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences(MsgWaveLenghtPol(wavelenght)));//change wavelength pol
            System.Threading.Thread.Sleep(delay);

            //Console.WriteLine("Read JM        - " + wavelenght.ToString());
            Devices.devicePolarizationAnalyzer.Write(Utility.ReplaceCommonEscapeSequences("K 0;JM;X"));
            jString = Utility.InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString());//put JM data here
            //Console.WriteLine();
            return jString;
        }

        public static string MsgPolPosition(double theta = 179.82)
        {
            //POS 0;X;
            return "POS " + theta.ToString() + ";X;";
        }
    }
}
