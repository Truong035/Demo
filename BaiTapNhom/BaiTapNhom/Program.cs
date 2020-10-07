using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BaiTapNhom
{
    class Program
    {
        static List<string> So1 = new List<string>();
        static int BieuThuc(string PhepTinh, int Min, int Max)
        {
            int sum = 0;
            if (PhepTinh.Equals("/") || PhepTinh.Equals("*"))
            {
                XoaChuoiRong();
                for (int i = Min; i < Max; i++)
                {
                    try
                    {
                        if (So1[i].Equals("/"))
                        {
                            int a = Convert.ToInt16(So1[i - 1]);
                            int b = Convert.ToInt16(So1[i + 1]);
                            sum = (a / b);
                            So1[i - 1] = "" + sum;
                            So1.RemoveAt(i + 1);
                            So1.RemoveAt(i);
                            Max -= 2;
                            foreach (var item in So1)
                            {
                                Console.Write(item);
                            }
                            Console.WriteLine();
                            i = 0;
                        }
                        else if (So1[i].Equals("*"))
                        {
                            int a = Convert.ToInt16(So1[i - 1]);
                            int b = Convert.ToInt16(So1[i + 1]);
                            sum = (a * b);
                            So1[i - 1] = "" + sum;
                            So1.RemoveAt(i + 1);
                            So1.RemoveAt(i);
                            Max -= 2;
                            foreach (var item in So1)
                            {
                                Console.Write(item);
                            }
                            Console.WriteLine();
                            i = 0;

                        }
                    }
                    catch { }
                }

            }
            if (PhepTinh.Equals("+") || PhepTinh.Equals("-"))
            {
                XoaChuoiRong();
                for (int i = Min; i < Max; i++)
                {
                    try
                    {
                        if (So1[i].Equals("+"))
                        {
                            int a = Convert.ToInt16(So1[i - 1]);
                            int b = Convert.ToInt16(So1[i + 1]);
                            sum = (a + b);
                            So1[i - 1] = "" + sum;
                            So1.RemoveAt(i + 1);
                            So1.RemoveAt(i);
                            foreach (var item in So1)
                            {
                                Console.Write(item);
                            }
                            i = 0;
                            Console.WriteLine();
                        }
                        else if (So1[i].Equals("-"))
                        {
                            int a = Convert.ToInt16(So1[i - 1]);
                            int b = Convert.ToInt16(So1[i + 1]);
                            sum = (a - b);
                            So1[i - 1] = "" + sum;
                            So1.RemoveAt(i + 1);
                            So1.RemoveAt(i);
                            Max -= 2;
                            foreach (var item in So1)
                            {
                                Console.Write(item);
                            }
                            i = 0;
                            Console.WriteLine();

                        }
                    }
                    catch { }
                }

            }


            return Max;
        }


        static void Main(string[] args)
        {
            string Chuoi = "(3*3)-(4/5*5)+-6";

            string Chuoi1 = Chuoi;
            Chuoi = Chuoi.Replace(" ", "");
            Console.WriteLine(Chuoi);
            List<string> So = new List<string>();
            for (int i = 0; i < Chuoi.Length; i++)
            {
                So.Add(Chuoi.Substring((i), 1));
            }
            Chuoi1 = "";
            Chuoi = "";
            for (int i = 0; i < So.Count; i++)
            {
                if (So[i].Equals("+") || So[i].Equals("-") || So[i].Equals("*") || So[i].Equals("/"))
                {
                    So1.Add(Chuoi1);//luu so
                    So1.Add(So[i]);//luu +-*/
                    Chuoi += So[i];//luu do u tien cac dau ()+-*/
                    Chuoi1 = "";
                        if (So[i + 1].Equals("-"))
                        {
                            Chuoi1 += So[i + 1];
                            i++;
                        }
                 
                }
                else if (So[i].Equals("(") || So[i].Equals(")"))
                {
                    So1.Add(Chuoi1);//luu so 
                    So1.Add(So[i]);//luu ()
                    Chuoi += So[i];//luu do u tien cac dau ()+-*/
                    Chuoi1 = "";
                }
                else
                {
                    Chuoi1 += So[i];
                }
            }
            //Kiem tra con so cuoi cung trong mang hay ko
            if (Chuoi1.Length > 0)
            {
                So1.Add(Chuoi1);
            }

            // Tinh trong Ngoac
            for (int i = 0; i < So1.Count; i++)
            {
                //lay vi tri dau (
                if (So1[i].Equals("("))
                {
                    TinHeBieuThuc(Chuoi, i, Max(i));
                }
            }

           // xoa het cac dau () da tinh xong
            for (int i = 0; i < So1.Count; i++)
            {
                if (So1[i].Equals("(")|| So1[i].Equals(")"))
                {
                    So1.RemoveAt(i);
                    XoaChuoiRong();
                }
            }

            // tinh binh thuong
            TinHeBieuThuc(Chuoi, 0, So1.Count);


            Console.ReadKey();

        }

     //coi do uu tien cua */+- ()
        private static void TinHeBieuThuc(string Chuoi, int min, int Max)
        {
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (Chuoi.Substring(i, 1).Equals("/"))
                {
                    if (Max - min > 1)
                    {
                        Max = BieuThuc("/", min, Max);
                    }

                }
                if (Chuoi.Substring(i, 1).Equals("*"))
                {
                    if (Max - min > 1)
                    {
                        Max = BieuThuc("*", min, Max);
                    }
                }
            }

            for (int i = 0; i < Chuoi.Length; i++)
            {

                if (Chuoi.Substring(i, 1).Equals("-"))
                {
                    if (Max - min > 1)
                    {
                        Max = BieuThuc("-", min, Max);
                    }
                }
                else if (Chuoi.Substring(i, 1).Equals("+"))
                {
                    if (Max - min > 1)
                    {
                        Max = BieuThuc("+", min, Max);
                    }
                }
            }
        }

        //Lay ra vi tri ket thuc )
        private static int Max(int min)
        {
            for (int i = min + 1; i < So1.Count; i++)
            {
                if (So1[i].Equals(")"))
                {
                    return i;
                }
            }
            return min;
        }

        //xoa cac chuoi rong con ton tai trong Mang
        private static void XoaChuoiRong()
        {

            for (int j = 0; j < So1.Count; j++)
            {
                if (string.IsNullOrEmpty(So1[j]))
                {
                    So1.RemoveAt(j);
                    j = 0;
                }
            }

        }
    }
}
