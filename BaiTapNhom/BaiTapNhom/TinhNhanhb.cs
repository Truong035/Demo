using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BaiTapNhom
{
    class TinhNhanhb
    {

        static List<string> So1 = new List<string>();
        static int Min = default;
        static int max = default;
        static int Solan = 1;
      

        private static bool KiemTra1(int Sum, string Leng)
        {

            string Chia = "1";
            if (Leng.Equals("0"))
            {
                return true;
            }
            for (int i = (Leng.Length - 1); i > 0; i--)
            {
                Chia += "0";
                double Check = (double)Sum / double.Parse(Chia);
                if (Check==1)
                {
                    return true;
                }

            }
            return false;
        }


        private static bool KiemTra( int Sum ,string Leng)
        {

            string Chia="1";
            if (Leng.Equals("0"))
            {
                return true;
            }
            for (int i = (Leng.Length-1);i>0; i--)
            {
                Chia +="0";
           
                if (Sum % Convert.ToInt16(Chia) == 0)
                {
                    return true;
                }
               
            }
            return false;
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
            string Chuoi = "(88+22+(1988+12+54)-988 +12)+106+46+12";
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
                            Chuoi1+=So[i + 1];
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


            XuatKetQua();
            // Tinh trong Ngoac
         
            /////In ra bieu thuc dau tien 
         //   XuatKetQua();



            //tinh trong khoac xong r thi gan min lai ban ko
            Min = 0;
          
            if (So1.Count > 1)
            {
                Console.WriteLine("Khong the tinh bieu thuc nay vui long kiem tra lai ");
            }
            Console.ReadKey();
        }

        private static void TinhNhanh3()
        {
            for (int i = Min; i < max; i++)
            {
                //lay vi tri dau (
                if (So1[i].Equals("("))
                {
                    Min = i;
                    max = Max(i);
                    if (TinhNhanh())
                    {
                        i = -1;
                    }
                }
            }

        }

        private static bool TinhNhanh()
        {
            for (int i = Min; i < max; i++)
            {
                if (!So1[i].Equals("+") && !So1[i].Equals("-") &&
                    !So1[i].Equals("/") && !So1[i].Equals("*")
                    && !So1[i].Equals("(") && !So1[i].Equals(")"))
                {
                    if (TinhNhanhVeTrai(i))
                    {
                        XuatKetQua();
                        return true;
                    }

                }

            }
            return false;
        }

        private static bool TinhNhanh1()
        {
            for (int i = Min; i < max; i++)
            {
                if (!So1[i].Equals("+") && !So1[i].Equals("-") &&
                    !So1[i].Equals("/") && !So1[i].Equals("*")
                    && !So1[i].Equals("(") && !So1[i].Equals(")"))
                {
                    if (TinhNhanhVeTrai1(i))
                    {
                        XuatKetQua();
                        return true;
                    }

                }

            }
            return false;
        }
        private static bool TinhNhanhVeTrai1(int mix)
        {
            string Lengh;
            int sum;

            int a = Convert.ToInt32(So1[mix]);
            int b;

            for (int i = Min; i < mix - 1; i++)
            {

                if (So1[i].Equals("/"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a / b);
                    sum = (a / b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();

                        return true;
                    }
                }
                if (So1[i].Equals("*"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a * b);
                    sum = (a * b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }



            for (int i = Min; i < mix - 1; i++)
            {

                if (So1[i].Equals("+"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a + b);
                    sum = (a + b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();

                        return true;
                    }
                }
                if (So1[i].Equals("-"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a - b);
                    sum = (a - b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }

            return TinhNhanhVePhai1(mix);
        }


        private static bool  TinhNhanhVeTrai(int mix)
        { 
            string Lengh;
            int sum;
    
            int a = Convert.ToInt32(So1[mix]);
            int b;

            for (int i = Min; i < mix - 1; i++)
            {

                if (So1[i].Equals("/"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a / b);
                    sum = (a / b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();

                        return true;
                    }
                }
                if (So1[i].Equals("*"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a * b);
                    sum = (a * b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }



            for (int i = Min; i < mix-1; i++)
            {

                if (So1[i].Equals("+"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]);}
                    Lengh = "" + (a + b);
                     sum =(a + b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i-1);
                        XoaChuoiRong();
                        
                        return true;
                    }
                }
                if (So1[i].Equals("-"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i - 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i - 2]); }
                    Lengh = "" + (a - b);
                    sum = (a - b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i - 1);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }

            return TinhNhanhVePhai(mix);
        }

        private static bool TinhNhanhVePhai(int mix)
        {  
           // max = So1.Count;
            int a = Convert.ToInt32(So1[mix]);
            int b;
            for (int i = mix + 1; i < max; i++)
            {

                if (So1[i].Equals("/"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a / b);
                    int sum = (a / b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        

                        return true;
                    }
                }
                if (So1[i].Equals("*"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a * b);
                    int sum = (a * b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }

            for (int i = mix+1; i < max; i++)
            {

                if (So1[i].Equals("+"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                  
                    string Lengh = "" + (a + b);
                    int sum = (a + b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i+1);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }
                if (So1[i].Equals("-"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a - b);
                    int sum = (a - b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i+1);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }
            return false;
        }
        private static bool TinhNhanhVePhai1(int mix)
        {
            // max = So1.Count;
            int a = Convert.ToInt32(So1[mix]);
            int b;
            for (int i = mix + 1; i < max; i++)
            {

                if (So1[i].Equals("/"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a / b);
                    int sum = (a / b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i);
                        XoaChuoiRong();

                        return true;
                    }
                }
                if (So1[i].Equals("*"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a * b);
                    int sum = (a * b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }

            for (int i = mix + 1; i < max; i++)
            {

                if (So1[i].Equals("+"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }

                    string Lengh = "" + (a + b);
                    int sum = (a + b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i + 1);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }
                if (So1[i].Equals("-"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a - b);
                    int sum = (a - b);
                    if (KiemTra1(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i+1);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }
            return false;
        }

        private static bool PhepNhanChiaPhai(int mix, int a)
        {
            int b;
            for (int i = mix + 1; i < max; i++)
            {

                if (So1[i].Equals("/"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a / b);
                    int sum = (a / b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i);
                        XoaChuoiRong();

                        return true;
                    }
                }
                if (So1[i].Equals("*"))
                {
                    try
                    {
                        b = Convert.ToInt32(So1[i + 1]);
                    }
                    catch { b = Convert.ToInt32(So1[i + 2]); }
                    string Lengh = "" + (a * b);
                    int sum = (a * b);
                    if (KiemTra(sum, Lengh))
                    {
                        So1[mix] = Lengh;
                        So1.RemoveAt(i);
                        So1.RemoveAt(i);
                        XoaChuoiRong();
                        return true;
                    }
                }

            }
            return false;
        }

        //coi do uu tien cua */+- ()
       
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
            for (int i = 0; i < So1.Count; i++)
            {
                if (So1[i].Equals("(") && So1[i+2].Equals(")"))
                {
                    So1.RemoveAt(i+2);
                    So1.RemoveAt(i);
                    i = -1;
                }
            }
            for (int j = 0; j < So1.Count; j++)
            {
                if (string.IsNullOrEmpty(So1[j]))
                {
                    So1.RemoveAt(j);
                    j = -1;
                }
            }
        //  max =So1.Count;
        }

    }
}
