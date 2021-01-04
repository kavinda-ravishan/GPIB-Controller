using System;
using System.Collections.Generic;

namespace GPIBController
{
    static class Utility
    {

        #region test data

        public static string text_S0 = "VAL00  77.204;VAL01  16.427;VAL02   0.295;VAL03  39.486;VAL04   0.371;VAL05   0.121;VAL06  56.222;VAL07   0.000;VAL08  10.609;VAL09  -0.758;VAL10   0.363;VAL11   0.543;VAL12 -75.284;VAL13 -71.248;VAL14 -73.429;1000;E00\n";

        public static string text_SB = "S1  0.849;S2  0.528;S3  0.007;PDB -76.34;1000;E00\n";

        public static string text_J1_1 = "J[11]  0.902 -45.363;J[12]  0.383 -179.843;J[21]  0.420 -4.662;J[22]  0.931 46.226;1000;E00\n";
        //1550.01 nm
        public static string text_J1_2 = "J[11]  0.907 -44.460;J[12]  0.405 -178.349;J[21]  0.416 -3.936;J[22]  0.917 44.923;1000;E00\n";

        //1550.00 nm
        public static string text_J1 = "J[11]  0.870  7.368;J[12]  0.557 -138.518;J[21]  0.646 -39.584;J[22]  0.736 -8.434;1000;E00\n";
        //1551.00 
        public static string text_J2 = "J[11]  0.797 -64.374;J[12]  0.605 -66.324;J[21]  0.600 -111.640;J[22]  0.799 63.215;1000;E00\n";

        #endregion

        public const double C = 299792458;

        public static string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }
        public static string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        //Labels for S0 receive data
        public static string[] Labels_S0 =
        {
            "elevation angle θ",
            "ellipticity angle η",
            "axis ratio tan | η |",
            "degree of polarization DOP",
            "tan ψ",
            "power ratio a",
            "phase difference ∆",
            "polarized power Ppol",
            "extinction ratio ER",
            "normalized Stokes parameter S1",
            "normalized Stokes parameter S2",
            "normalized Stokes parameter S3",
            "polarized power (dBm)",
            "total power",
            "unpolarized power(dBm)",
            "device status code",
            "error code"
        };

        //Labels for SB receive data
        public static string[] Labels_SB =
        {
            "S1 normalized Stokes parameter s1",
            "S2 normalized Stokes parameter s2",
            "S3 normalized Stokes parameter s3",
            "PDB polarized optical power in dBm",
            "device status code",
            "error code"
        };

        //Labels for JM receive data
        public static string[] Labels_JM =
        {
            "J[11] modulus",
            "J[11] phase (degrees)",
            "J[12] modulus",
            "J[12] phase (degrees)",
            "J[21] modulus",
            "J[21] phase (degrees)",
            "J[22] modulus",
            "J[22] phase (degrees)",
            "device status code",
            "error code"
        };

        //Labels for error messages
        public static string[] ErrorList =
            {
                "E00 no error",
                "E01 incorrect command or wrong character",
                "E02 string of characters too long (> 250 characters without terminator)",
                "E03 command buffer overflow(>8 commands without trigger command X; or[GET])",
                "E04 incorrect parameter format",
                "E05 parameter outside the allowed range",
                "E06 parameter has too many digits after the decimal point",
                "E07 optical power too high",
                "E08 incorrect operating wavelength or incorrect optical head calibration (degree of polarization measured >100 %)",
                "E09 no PAN9300 module(in the activated slot)",
                "E10 no POL 9320-Modul(in the activated slot)",
                "E12 no PAN-IR module",
                "E13 no tunable laser",
                "E14 incorrect type of PAN set",
                "E15 type of PMD not set",
                "E16 no reference Jones matrix available",
                "E17 incorrect start wavelength",
                "E18 incorrect stop wavelength",
                "E19 incorrect wavelength step",
                "E20 incorrect wavelength speed",
                "E21 incorrect length of fiber",
                "E22 incorrect K-factor",
                "E23 incorrect value for delta_mm",
                "E24 no PMD data available",
                "E25 no PMD file available",
                "E26 no turbo mode available for PAN9300",
                "E29 no tunable laser for PMD measurements available",
                "E30 No or wrong authorization code",
                "E31 No turbo file existent",
                "E33 Power below limit setting",
                "E34 Insufficient measured points",
                "E35 Unable to calculate ER",
                "E36 Not sufficient fiber stress",
                "E37 No typical PMF behavior(Warning only)",
                "E38 Bad linear eigenmodes(Warning only)",
                "E39 Error loading calibration file*.set",
                "E46 No PAN-NIR",
                "E47 No PAN-FIR",
                "E99 1. Status request after switching the unit on or voltage failure of the unit",
                "EEE"
        };

        //Convert error codes to corresponding error message
        public static string ErrorCheck(string Error)
        {
            string ErrorNo;

            int i;
            for (i = 0; i < ErrorList.Length - 1; i++)
            {
                ErrorNo = ErrorList[i].Substring(0, 3);

                if (ErrorNo == Error) break;
            }
            return ErrorList[i];
        }

        public static List<string> DataSeparator(string text)
        {
            List<string> info = new List<string>();
            string value = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ';' || i == text.Length - 1)
                {
                    info.Add(value);
                    value = "";
                }
                else
                {
                    value += text[i];
                }
            }

            return info;
        }

        public static string[] SB_filter(List<string> text)
        {
            string[] SB = new string[6];

            for (int i = 0; i < 3; i++)
            {
                SB[i] = text[i].Substring(2);
            }

            SB[3] = text[3].Substring(3);
            SB[4] = text[4];
            SB[5] = ErrorCheck(text[5].Substring(0, 3));

            return SB;
        }

        public static string[] S0_filter(List<string> text)
        {
            string[] S0 = new string[17];

            for (int i = 0; i < 15; i++)
            {
                S0[i] = text[i].Substring(5);
            }
            S0[15] = text[15];
            S0[16] = ErrorCheck(text[16].Substring(0, 3));

            return S0;
        }

        public static string[] JM_filter(List<string> text)
        {
            string[] JMat = new string[10];

            for (int i = 0; i < 4; i++)
            {
                JMat[i * 2] = text[i].Substring(5, 7);
                JMat[(i * 2) + 1] = text[i].Substring(12, 7);
            }
            JMat[8] = text[4];
            JMat[9] = ErrorCheck(text[5].Substring(0, 3));

            return JMat;
        }

        public static string[] SC_filter(List<string> text)
        {
            string[] SC = new string[6];

            for (int i = 0; i < 4; i++)
            {
                SC[i] = text[i].Substring(3);
            }

            SC[4] = text[4];
            SC[5] = text[5].Substring(0, 3);

            return SC;
        }

        public static double[] SC_String2Double(string[] values)
        {
            double[] SC = new double[4];

            for (int i = 0; i < 4; i++)
            {

                SC[i] = System.Convert.ToDouble(values[i]);
            }

            return SC;
        }

        public static double[] JonesString2Double(string text)
        {
            List<string> values = DataSeparator(text);

            string[] data = JM_filter(values);

            double[] jonesMat = new double[8];

            for (int i = 0; i < 8; i++)
            {
                jonesMat[i] = Convert.ToDouble(data[i]);
            }

            return jonesMat;
        }

        public static double[] SB_String2Double(string[] values)
        {
            double[] stokes = new double[4];

            for (int i = 0; i < 4; i++)
            {
                stokes[i] = System.Convert.ToDouble(values[i]);
            }

            return stokes;
        }

        public static double[] SB2Stokes(string text)
        {
            return SB_String2Double(SB_filter(DataSeparator(text)));
        }// S1, S2, S3, PDB

        public static double[] SC2EybyExDelta(string text)
        {
            return SC_String2Double(SC_filter(DataSeparator(text)));
        }

        public static CMath.ComplexCar TanPiDelta2K(double delta, double tanPi)//Delta in deg
        {
            CMath.ComplexCar complexCar = new CMath.ComplexCar();

            double r = 1 / tanPi;
            double theta = -1 * CMath.Deg2Red(delta);

            complexCar.real = r * Math.Cos(theta);
            complexCar.imag = r * Math.Sin(theta);

            return complexCar;
        }

        public static CMath.ComplexCar Stokes2K(double s1, double s2, double s3, double s0 = 1)
        {
            CMath.ComplexCar complexCar = new CMath.ComplexCar();

            double r = Math.Sqrt((s0 + s1) / (s0 - s1));
            double theta = -1 * Math.Atan(s3 / s2);

            complexCar.real = r * Math.Cos(theta);
            complexCar.imag = r * Math.Sin(theta);

            return complexCar;
        }

        public static CMath.JonesMatCar K2JonesMat(CMath.ComplexCar k0, CMath.ComplexCar k90, CMath.ComplexCar k45)
        {
            CMath.JonesMatCar jonesMatCar = new CMath.JonesMatCar();

            CMath.ComplexCar k4 = (k90 - k45) / (k45 - k0);

            jonesMatCar.J11 = k0 * k4;
            jonesMatCar.J12 = k90;
            jonesMatCar.J21 = k4;
            jonesMatCar.J22 = new CMath.ComplexCar(1, 0);

            return jonesMatCar;
        }

        //Jones double array comes with angle degries function convert it to red
        public static CMath.JonesMatPol JonesDoubleArray2JonesMat(double[] jonesValues)
        {
            CMath.JonesMatPol mat;

            mat.J11.mod = jonesValues[0];
            mat.J11.ang = CMath.Deg2Red(jonesValues[1]);

            mat.J12.mod = jonesValues[2];
            mat.J12.ang = CMath.Deg2Red(jonesValues[3]);

            mat.J21.mod = jonesValues[4];
            mat.J21.ang = CMath.Deg2Red(jonesValues[5]);

            mat.J22.mod = jonesValues[6];
            mat.J22.ang = CMath.Deg2Red(jonesValues[7]);

            return mat;
        }

        public static double Wavelength2Frequency(double wavelength)//wavelength in nm and frequency in THz
        {
            return C / (wavelength * 1000);
        }

        public static CMath.JonesMatCar JonesMatString2Car(string jonesMat)
        {
            return CMath.Pol2Car(JonesDoubleArray2JonesMat(JonesString2Double(jonesMat)));
        }

        static CMath.ComplexCar Stokes2KMesure(double polPos, int polDelay = 3000)
        {
            //Console.WriteLine("Set Polarizer to - " + polPos.ToString());
            Devices.devicePolarizationAnalyzer.Write(ReplaceCommonEscapeSequences(DeviceControl.MsgPolPosition(polPos)));//change pol position

            System.Threading.Thread.Sleep(polDelay);

            //Console.WriteLine("Read SB at - " + polPos.ToString());
            Devices.devicePolarizationAnalyzer.Write(ReplaceCommonEscapeSequences("SB;"));

            string stokesString = InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString());//read Stokes
            double[] stokes = SB2Stokes(stokesString);

            return Stokes2K(stokes[0], stokes[1], stokes[2]);
        }

        static CMath.ComplexCar TanPiDelta2KMesure(double polPos, int polDelay = 3000)
        {
            Console.WriteLine("Set Polarizer to - " + polPos.ToString());
            Devices.devicePolarizationAnalyzer.Write(ReplaceCommonEscapeSequences(DeviceControl.MsgPolPosition(polPos)));//change pol position

            System.Threading.Thread.Sleep(polDelay);

            Console.WriteLine("Read SC at - " + polPos.ToString());
            Devices.devicePolarizationAnalyzer.Write(ReplaceCommonEscapeSequences("SC;"));

            string TanPiDeltaString = InsertCommonEscapeSequences(Devices.devicePolarizationAnalyzer.ReadString());//read Stokes
            double[] TanPiDelta = Utility.SC2EybyExDelta(TanPiDeltaString);

            return Utility.TanPiDelta2K(TanPiDelta[1], TanPiDelta[2]);
        }

        public static CMath.JonesMatCar MesureStokes2JonesMat(double wavelenght, int delay)
        {
            //Console.WriteLine("Set Source  WL - " + wavelenght.ToString());
            Devices.deviceLaserSource.Write(ReplaceCommonEscapeSequences(DeviceControl.MsgWaveLenghtSrc(wavelenght)));//change wavelength source

            //Console.WriteLine("Set PAT9000 WL - " + wavelenght.ToString());
            Devices.devicePolarizationAnalyzer.Write(ReplaceCommonEscapeSequences(DeviceControl.MsgWaveLenghtPol(wavelenght)));//change wavelength pol
            System.Threading.Thread.Sleep(delay);

            CMath.ComplexCar k0 = Stokes2KMesure(0);
            CMath.ComplexCar k45 = Stokes2KMesure(45);
            CMath.ComplexCar k90 = Stokes2KMesure(90);

            Console.WriteLine();

            return K2JonesMat(k0, k90, k45);
        }

        public static CMath.JonesMatCar MesureTanPiDelta2JonesMat(double wavelenght, int delay)
        {
            //Console.WriteLine("Set Source  WL - " + wavelenght.ToString());
            Devices.deviceLaserSource.Write(ReplaceCommonEscapeSequences(DeviceControl.MsgWaveLenghtSrc(wavelenght)));//change wavelength source

            //Console.WriteLine("Set PAT9000 WL - " + wavelenght.ToString());
            Devices.devicePolarizationAnalyzer.Write(ReplaceCommonEscapeSequences(DeviceControl.MsgWaveLenghtPol(wavelenght)));//change wavelength pol
            System.Threading.Thread.Sleep(delay);

            CMath.ComplexCar k0 = TanPiDelta2KMesure(0);
            CMath.ComplexCar k45 = TanPiDelta2KMesure(45);
            CMath.ComplexCar k90 = TanPiDelta2KMesure(90);

            Console.WriteLine();

            return K2JonesMat(k0, k90, k45);
        }


        public static double[] DGD(CMath.JonesMatCar j1, CMath.JonesMatCar j2, CMath.JonesMatCar refJonesMat,double w1, double w2)
        {
            CMath.JonesMatCar J1 = refJonesMat * j1;
            CMath.JonesMatCar J2 = refJonesMat * j2;

            CMath.JonesMatCar J1Inv = CMath.Inverse(J1);

            CMath.JonesMatCar J2_J1Inv = J2 * J1Inv;

            CMath.ComplexCar[] complexCars = CMath.Eigenvalues(J2_J1Inv);

            CMath.ComplexPol[] complexPols = new CMath.ComplexPol[2];

            complexPols[0] = CMath.Car2Pol(complexCars[0]);
            complexPols[1] = CMath.Car2Pol(complexCars[1]);

            double Ang = complexPols[0].ang - complexPols[1].ang;

            double f1 = Wavelength2Frequency(w1);
            double f2 = Wavelength2Frequency(w2);

            double[] DGD_W = { CMath.Abs(Ang / (f1 - f2)), (w1 + w2) / 2 };

            return DGD_W;
        }
    }
}
