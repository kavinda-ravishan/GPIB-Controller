using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolarizationAnalyzer
{
    static class Utility
    {
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

        //Convert the S0 data string to values string array
        public static string[] S0(string data)
        {
            int x = 0;
            string[] values = new string[17];

            for (int i = 0; i < 15; i++)
            {
                values[i] = data.Substring(x + 5, 8);
                x = x + 14;
            }

            values[15] = data.Substring(x, 4);
            x = x + 5;
            values[16] = ErrorCheck(data.Substring(x, 3));

            return values;
        }

        //Convert the SB data string to values string array
        public static string[] SB(string data)
        {
            int x = 0;
            string[] values = new string[6];

            for (int i = 0; i < 3; i++)
            {
                values[i] = data.Substring(x + 3, 6);
                x = x + 10;
            }
            x = x + 3;
            values[3] = data.Substring(x, 7);
            x = x + 8;
            values[4] = data.Substring(x, 4);
            x = x + 5;
            values[5] = ErrorCheck(data.Substring(x, 3));

            return values;
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
