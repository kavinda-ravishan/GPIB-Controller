using System;

namespace GPIBController
{
    static class CMath
    {
        public struct ComplexCar
        {
            public double real;
            public double imag;

            public ComplexCar(double Real = 0, double Imag = 0)
            {
                real = Real;
                imag = Imag;
            }

            public static ComplexCar operator +(ComplexCar c1, ComplexCar c2)
            {
                ComplexCar temp;
                temp.real = c1.real + c2.real;
                temp.imag = c1.imag + c2.imag;

                return temp;
            }
            public static ComplexCar operator -(ComplexCar c1, ComplexCar c2)
            {
                ComplexCar temp;
                temp.real = c1.real - c2.real;
                temp.imag = c1.imag - c2.imag;

                return temp;
            }
            public static ComplexCar operator *(double c, ComplexCar c1)
            {
                ComplexCar temp;
                temp.real = c1.real * c;
                temp.imag = c1.imag * c;

                return temp;
            }
            public static ComplexCar operator /(ComplexCar c1, double c)
            {
                ComplexCar temp;
                temp.real = c1.real / c;
                temp.imag = c1.imag / c;

                return temp;
            }
            public static ComplexCar operator *(ComplexCar c1, ComplexCar c2)
            {
                ComplexCar temp;
                temp.real = (c1.real * c2.real) - (c1.imag * c2.imag);
                temp.imag = (c1.real * c2.imag) + (c1.imag * c2.real);

                return temp;
            }
            public static ComplexCar operator /(ComplexCar c1, ComplexCar c2)
            {
                ComplexCar temp;
                double div = (c2.real * c2.real) + (c2.imag * c2.imag);

                temp.real = ((c1.real * c2.real) + (c1.imag * c2.imag)) / div;
                temp.imag = ((c1.imag * c2.real) - (c1.real * c2.imag)) / div;

                return temp;
            }
        }

        public struct ComplexPol
        {
            public double mod;
            public double ang; // in rad

            public ComplexPol(double Mod = 0, double Ang = 0)
            {
                mod = Mod;
                ang = Ang;
            }

            public static ComplexPol operator *(ComplexPol c1, ComplexPol c2)
            {
                ComplexPol temp;
                temp.mod = c1.mod * c2.mod;
                temp.ang = c1.ang + c2.ang;

                return temp;
            }
            public static ComplexPol operator /(ComplexPol c1, ComplexPol c2)
            {
                ComplexPol temp;
                temp.mod = c1.mod / c2.mod;
                temp.ang = c1.ang - c2.ang;

                return temp;
            }
        }

        public struct JonesMatCar
        {
            public ComplexCar J11;
            public ComplexCar J12;
            public ComplexCar J21;
            public ComplexCar J22;

            public static JonesMatCar operator *(JonesMatCar j1, JonesMatCar j2)
            {
                JonesMatCar temp;

                temp.J11 = (j1.J11 * j2.J11) + (j1.J12 * j2.J21);
                temp.J12 = (j1.J11 * j2.J12) + (j1.J12 * j2.J22);
                temp.J21 = (j1.J21 * j2.J11) + (j1.J22 * j2.J21);
                temp.J22 = (j1.J21 * j2.J12) + (j1.J22 * j2.J22);

                return temp;
            }
        }

        public struct JonesMatPol
        {
            public ComplexPol J11;
            public ComplexPol J12;
            public ComplexPol J21;
            public ComplexPol J22;
        }

        #region print
        public static void Print(ComplexCar complexCar)
        {
            if (complexCar.imag >= 0)
            {
                Console.Write(complexCar.real + " +" + complexCar.imag + " i");
            }
            else
            {
                Console.Write(complexCar.real + " " + complexCar.imag + " i");
            }
        }

        public static void Print(ComplexPol complexPol)
        {
            Console.Write(complexPol.mod + " |_" + complexPol.ang);
        }

        public static void Print(JonesMatCar mat)
        {
            Print(mat.J11);
            Console.Write("  ");
            Print(mat.J12);
            Console.WriteLine();
            Print(mat.J21);
            Console.Write("  ");
            Print(mat.J22);
            Console.WriteLine();
        }

        public static void Print(JonesMatPol mat)
        {
            Print(mat.J11);
            Console.Write("  ");
            Print(mat.J12);
            Console.WriteLine();
            Print(mat.J21);
            Console.Write("  ");
            Print(mat.J22);
            Console.WriteLine();
        }
        #endregion

        public static double Deg2Red(double deg)
        {
            return (2 * Math.PI * (deg % 360)) / 360;
        }

        public static double Red2Deg(double red)
        {
            return (360 * (red % (2 * Math.PI))) / (2 * Math.PI);
        }

        public static ComplexCar Pol2Car(ComplexPol complexPol)
        {
            ComplexCar complexCar;

            complexCar.real = complexPol.mod * Math.Cos(complexPol.ang);
            complexCar.imag = complexPol.mod * Math.Sin(complexPol.ang);

            return complexCar;
        }

        public static ComplexPol Car2Pol(ComplexCar complexCar)
        {
            ComplexPol complexPol;

            complexPol.mod = Math.Sqrt(
                (complexCar.real * complexCar.real) +
                (complexCar.imag * complexCar.imag)
                );

            complexPol.ang = Math.Atan2(complexCar.imag, complexCar.real);

            return complexPol;
        }

        public static JonesMatCar Pol2Car(JonesMatPol jonesMatPol)
        {
            JonesMatCar jonesMatCar;

            jonesMatCar.J11 = Pol2Car(jonesMatPol.J11);
            jonesMatCar.J12 = Pol2Car(jonesMatPol.J12);
            jonesMatCar.J21 = Pol2Car(jonesMatPol.J21);
            jonesMatCar.J22 = Pol2Car(jonesMatPol.J22);

            return jonesMatCar;
        }

        public static JonesMatPol Car2Pol(JonesMatCar jonesMatCar)
        {
            JonesMatPol jonesMatPol;

            jonesMatPol.J11 = Car2Pol(jonesMatCar.J11);
            jonesMatPol.J12 = Car2Pol(jonesMatCar.J12);
            jonesMatPol.J21 = Car2Pol(jonesMatCar.J21);
            jonesMatPol.J22 = Car2Pol(jonesMatCar.J22);

            return jonesMatPol;
        }

        public static ComplexCar Det(JonesMatCar jonesMatCar)
        {
            return (jonesMatCar.J11 * jonesMatCar.J22) - (jonesMatCar.J12 * jonesMatCar.J21);
        }

        public static JonesMatCar Inverse(JonesMatCar jonesMatCar)
        {
            JonesMatCar JInv;
            ComplexCar JDet = Det(jonesMatCar);

            JInv.J11 = jonesMatCar.J22 / JDet;
            JInv.J12 = (-1 * jonesMatCar.J12) / JDet;
            JInv.J21 = (-1 * jonesMatCar.J21) / JDet;
            JInv.J22 = jonesMatCar.J11 / JDet;

            return JInv;
        }

        public static double Abs(ComplexCar complexCar)
        {
            return Math.Sqrt((complexCar.real * complexCar.real) + (complexCar.imag * complexCar.imag));
        }

        public static double Abs(double value)
        {
            if (value >= 0)
                return value;
            else
                return -1 * value;
        }

        public static ComplexCar Sqrt(ComplexCar complexCar)
        {
            ComplexPol complexPol = Car2Pol(complexCar);
            ComplexCar complex;

            complex.real = Math.Sqrt(complexPol.mod) * Math.Cos(complexPol.ang / 2);
            complex.imag = Math.Sqrt(complexPol.mod) * Math.Sin(complexPol.ang / 2);

            return complex;
        }

        public static ComplexCar[] Eigenvalues(JonesMatCar jonesMatCar)
        {
            ComplexCar[] complexCar = new ComplexCar[2];

            ComplexCar a = (jonesMatCar.J11 + jonesMatCar.J22);
            ComplexCar b = Sqrt((a * a) + (4 * ((jonesMatCar.J12 * jonesMatCar.J21) - (jonesMatCar.J11 * jonesMatCar.J22))));

            complexCar[0] = (a + b) / 2;
            complexCar[1] = (a - b) / 2;

            return complexCar;
        }

        public static JonesMatCar UnitMatrix()
        {
            JonesMatCar mat = new JonesMatCar();

            ComplexCar one = new ComplexCar(1, 0);
            ComplexCar zero = new ComplexCar(0, 0);

            mat.J11 = one;
            mat.J12 = zero;
            mat.J21 = zero;
            mat.J22 = one;

            return mat;
        }
    }
}
