using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTapNhom
{
    class TinhNhanh
    {
        static List<string> So1 = new List<string>();
        static int Min = default;
        static int Solan = 1;
        static int BieuThuc(string PhepTinh, int Max)
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
                            XuatKetQua();
                            i = Min;
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
                            XuatKetQua();
                            i = Min;
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
                            i = Min;
                            XuatKetQua();
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
                            i = Min;
                            XuatKetQua();
                        }
                    }
                    catch { }
                }
            }

            return Max;
        }

        private static void XuatKetQua()
        {
            Console.Write("\n Lan tinh thư {0} : ", (Solan++));
            foreach (var item in So1)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string Chuoi = "(5+((5+-6))-(218)*((2/2+5)-(-89*9)";
            string Chuoi1 = Chuoi;
            // cat chuoi rong 
            Chuoi = Chuoi.Replace(" ", "");
            List<string> So = new List<string>();
            for (int i = 0; i < Chuoi.Length; i++)
            {
                // gan tung ki tu vao mot mang
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
                    if (So[i].Equals("("))
                    {
                        if (So[i + 1].Equals("-"))
                        {
                            Chuoi1 += So[i + 1];
                            i++;
                        }

                    }
                }
                else
                {
                    Chuoi1 += So[i];// lay so 
                }
            }
            //Kiem tra con so cuoi cung trong mang hay ko
            if (Chuoi1.Length > 0)
            {
                So1.Add(Chuoi1);
            }
            // In ra bieu thuc dau tien 
            XuatKetQua();
            // Tinh trong Ngoac
            for (int i = 0; i < So1.Count; i++)
            {
                //lay vi tri dau (
                if (So1[i].Equals("("))
                {
                    Min = i;
  
                    TinHeBieuThuc(Chuoi,Max(i));
                }
            }
            // xoa het cac dau () da tinh xong
            for (int i = 0; i < So1.Count; i++)
            {
                if (So1[i].Equals("(") || So1[i].Equals(")"))
                {
                    So1.RemoveAt(i);
                    XoaChuoiRong();
                    i = 0; // gan chay lai for 
                }
            }
            // tinh trong khoac xong r thi gan min lai ban ko
            Min = 0;
            TinHeBieuThuc(Chuoi, So1.Count);
            if (So1.Count > 1)
            {
                Console.WriteLine("Khong the tinh bieu thuc nay vui long kiem tra lai ");
            }
            Console.ReadKey();
        }

        //coi do uu tien cua */+- ()
        private static void TinHeBieuThuc(string Chuoi, int Max)
        {
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (Chuoi.Substring(i, 1).Equals("/"))
                {
                    Max = BieuThuc("/", Max);

                }
                if (Chuoi.Substring(i, 1).Equals("*"))
                {
                    Max = BieuThuc("*", Max);
                }
            }
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (Chuoi.Substring(i, 1).Equals("-"))
                {
                    Max = BieuThuc("-", Max);
                }
                else if (Chuoi.Substring(i, 1).Equals("+"))
                {
                    Max = BieuThuc("+", Max);
                }
            }
        }
        //Lay ra vi tri ket thuc )
        private static int Max(int min)
        {
            for (int i = min + 1; i < So1.Count; i++)
            {
                // tim kiem xem trong ( con ton tai ( nưa hay ko 
                if (So1[i].Equals(")"))
                {
                    return i;// tra ve max 
                }
                if (So1[i].Equals("("))
                {
                    Min = i;// GAN Min = i
                    Max(Min); //Tiep tuc tim max
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
