using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarizationAnalyzer
{
    static class Utility
    {
        //For testing purposes
        public static string text_S0 = "VAL00  77.204;VAL01  16.427;VAL02   0.295;VAL03  39.486;VAL04   0.371;VAL05   0.121;VAL06  56.222;VAL07   0.000;VAL08  10.609;VAL09  -0.758;VAL10   0.363;VAL11   0.543;VAL12 -75.284;VAL13 -71.248;VAL14 -73.429;1000;E08\n";

        public static string text_SB = "S1  0.849;S2  0.528;S3  0.007;PDB -76.34;1000;E00\n";
        
        //1550.00 nm
        public static string text_J1 = "J[11]  0.870  7.368;J[12]  0.557 -138.518;J[21]  0.646 -39.584;J[22]  0.736 -8.434;1000;E00\n";
        //1551.00 nm
        public static string text_J2 = "J[11]  0.797 -64.374;J[12]  0.605 -66.324;J[21]  0.600 -111.640;J[22]  0.799 63.215;1000;E00\n";

        //Labels for S0 receive data
        public static string[] lables_S0 =
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
        public static string[] lables_SB =
        {
            "S1 normalized Stokes parameter s1",
            "S2 normalized Stokes parameter s2",
            "S3 normalized Stokes parameter s3",
            "PDB polarized optical power in dBm",
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


        public static string[] dataSeparator(string text, int infoS, int valS)
        {
            string[] info = new string[infoS];
            string[] values = new string[valS];

            int j = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ';')
                {
                    j++;
                }
                else
                {
                    info[j] += text[i];
                }
            }

            j = 0;

            for (int i = 0; i < info.Length; i++)
            {
                for (int k = 0; k < info[i].Length; k++)
                {
                    if (info[i][k] == ' ')
                    {
                        while (info[i][k + 1] == ' ')
                        {
                            k++;
                        }
                        j++;
                    }
                    else
                    {
                        values[j] += info[i][k];
                    }
                }
                j++;
            }

            return values;
        }

        public static string[] S0_filter(string[] text)
        {
            string[] S0 = new string[17];

            for (int i = 0; i < 15; i++)
            {
                S0[i] = text[i * 2 + 1];
            }

            S0[15] = text[30];
            S0[16] = ErrorCheck(text[31].Substring(0, 3));

            return S0;
        }

        public static string[] SB_filter(string[] text)
        {
            string[] SB = new string[6];

            for (int i = 0; i < 4; i++)
            {
                SB[i] = text[i * 2 + 1];
            }

            SB[4] = text[8];
            SB[5] = ErrorCheck(text[9].Substring(0, 3));

            return SB;
        }

        public static string[] JM_filter(string[] text)
        {
            string[] JM = new string[10];

            for (int i = 0; i < 4; i++)
            {
                JM[i * 2] = text[i * 3 + 1];
                JM[i * 2 + 1] = text[i * 3 + 2];
            }

            JM[8] = text[12];
            JM[9] = ErrorCheck(text[13].Substring(0, 3));

            return JM;
        }

        public static string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }
        public static string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }
    }
}
