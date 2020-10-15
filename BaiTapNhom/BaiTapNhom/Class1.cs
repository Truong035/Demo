using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace BaiTapNhom
{
    
    class Class1
    {  
        static List<string> So1 = new List<string>();
        static int Min = default;
        static int max = default;
        static int Solan = 1;
        static bool QuyTacDoiNhau()
        {
            for (int i = Min; i < max; i++)
            {
                int cout = 0;
                try
                {
                        int a = Convert.ToInt32(So1[i]);
                        if (i > Min)
                        {
                            if (So1[i - 1].Equals("-"))
                            {
                                a = -a;
                                cout++;
                            }
                        }
                        int b = i + 1;
                        do
                        {
                            if (b == LaySoB(a, b))
                            {
                                break;
                            }
                            else
                            {
                                b = LaySoB(a, b);
                                if (TinhBieuThua(a, b, So1[b - 1]))
                                {
                                    So1.RemoveAt(i);
                                    if (cout > 0)
                                    {
                                        So1.RemoveAt(i - 1);
                                        max -= 1;
                                    }
                                    max -= 1;
                                    XoaChuoiRong();
                                    XuatKetQua();
                                    return true;
                                }
                            }

                        } while (true);
                    }
                
                catch { }
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
        private static void XoaChuoiRong()
        {
                for (int j = Min; j < max; j++)
                {
                // Xoa cac kí tu () vd (8)
                if (So1[j].Equals("(")&& So1[j+2].Equals(")"))
                {
                    So1.RemoveAt(j+2);
                    So1.RemoveAt(j);
                    max -= 2;
                    j = 0;
                }
                // Xoa Các chuôi rỗng
                  else   if (string.IsNullOrEmpty(So1[j]))
                    {
                        So1.RemoveAt(j);
                        max -= 1;
                        j = 0;
                    }
                }
            for (int j = Min; j < max; j++)
            {
                int a;
                try {
                    a = Convert.ToInt32(So1[j]) ;
                }
                catch
                {
                    if (So1[j + 1].Equals("+"))
                    {
                        So1.RemoveAt(j + 1);
                        max -= 1;
                    }

                }
            }

        }
        // Tinh cộng Trừ Bình Thươg
        private static bool TinhBieuThua(int a, int v1, string v2)
        {
            int sum = 0;
            int b = Convert.ToInt32(So1[v1]);
            if (v2.Equals("+"))
            {
                sum = a + b;
                if (sum == 0)
                {    
                    So1[v1] = ""+sum;
                    return true;
                }
                else return false;
                
            }
            if (v2.Equals("-"))
            {
                sum = a - b;
                if (sum == 0)
                {
                    So1[v1 - 1] = "+";
                    So1[v1] = "" + sum;
                    return true;
                }
                else return false;

            }
            return false;
        }
         
        private static int LaySoB(int a,int i)
        {  
            for (int j = i ; j < max; j++)
            {
                try
                {
                    Convert.ToInt32(So1[j]);
                    return j;
                }
                catch { }
            }
            return i;
        }

        //kiểm Tra có trong 10,20,30,40 
        private static bool KiemTra(int Sum, string Leng)
        {
            string Chia = "1";
            for (int i = (Leng.Length - 1); i > 0; i--)
            {
                Chia += "0";
            }
            for (int i = (Leng.Length-1); i>1; i--)
            {

                if (Sum % Convert.ToInt16(Chia.Substring(0,i)) == 0)
                {
                    return true;
                }
            
            }
            return false;
        }
        //kiêm tra co tròn truc tron tram
        private static bool DoUuTien1(int mix , int n)
        {
            string Lengh;
            int sum;
            int a = Convert.ToInt32(So1[mix]);
            if (mix > Min)
            {
                if (So1[mix - 1].Equals("-"))
                {
                    a = -a;

                }
            }
            int b;
            for (int i = mix+1; i < max; i++)
            {
                try
                {
                    b = Convert.ToInt32(So1[i]);
                    if (i > -1)
                    {
                        if (So1[i - 1].Equals("+"))
                        {
                            Lengh = "" + (a + b);
                            sum = (a + b);
                            if (n == 1)
                            {
                                if (KiemTra1(sum, Lengh))
                                {
                                    So1[mix] = Lengh;
                                    So1.RemoveAt(i);
                                    So1.RemoveAt(i - 1);
                                    max -= 2;
                                    XoaChuoiRong();
                                    return true;
                                }
                            }
                            else
                            {
                                if (KiemTra1(sum, Lengh))
                                {
                                    So1[mix] = Lengh;
                                    So1.RemoveAt(i);
                                    So1.RemoveAt(i - 1);
                                    max -= 2;
                                    XoaChuoiRong();

                                    return true;
                                }
                            }
                        }

                    } 
                }
                catch { }
                try
                {
                    b = Convert.ToInt32(So1[i]);
                    if (i > -1)
                    {
                        if (So1[i - 1].Equals("-"))
                        {
                            Lengh = "" + (a - b);
                            if (a >= b)
                            {
                                sum = (a - b);
                                if (n == 1)
                                {
                                    if (KiemTra1(sum, Lengh))
                                    {
                                        So1[mix] = Lengh;
                                        So1.RemoveAt(i);
                                        So1.RemoveAt(i - 1);
                                        max -= 2;
                                        XoaChuoiRong();
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (KiemTra(sum, Lengh))
                                    {
                                        So1[mix] = Lengh;
                                        So1.RemoveAt(i);
                                        So1.RemoveAt(i - 1);
                                        max -= 2;
                                        XoaChuoiRong();
                                        return true;
                                    }
                                }
                            }
                          
                        }

                    }
                }
                catch {}
            }

            return false;
        }
        //kiểm TRa 10,1000,10000..........
        private static bool KiemTra1(int Sum, string Leng )
        {
            string Chia = "10";
            
            for (int i = (Leng.Length-1); i > 1; i--)
            {
                Chia += "0";
          
            }
            double Check1 = (double)Sum % double.Parse(Chia);
            if (Check1==0)
            {
              
                return true;
            }
            return false;
        }
         private static bool QuyTacNhan( int mix ,int n)
        {
            string Lengh;
            int sum;
            int a;
           try{
                 a = Convert.ToInt32(So1[mix]);
            }
            catch { return false; }
            if (mix > Min)
            {
                if (So1[mix - 1].Equals("-"))
                {
                    a = -a;

                }
            }
            int b;
            for (int i = mix + 1; i < max; i++)
            {
                try
                {
                    b = Convert.ToInt32(So1[i]);
                    if (i > -1)
                    {
                        if (So1[i - 1].Equals("*"))
                        {
                            Lengh = "" + (a * b);
                            sum = (a * b);
                            if (n == 1)
                            {
                                if (KiemTra1(sum, Lengh))
                                {
                                    So1[mix] = Lengh;
                                    So1.RemoveAt(i);
                                    So1.RemoveAt(i - 1);
                                    max -= 2;
                                    XoaChuoiRong();
                                    return true;
                                }
                            }
                            else
                            {
                                if (KiemTra(sum, Lengh))
                                {
                                    So1[mix] = Lengh;
                                    So1.RemoveAt(i);
                                    So1.RemoveAt(i - 1);
                                    max -= 2;
                                    XoaChuoiRong();
                                    return true;
                                }

                            }

                        }

                    }

                }
                catch { }
            }
            return false;
        }

        private static bool QuyTacNhan(int n)
        {
            for (int i = Min; i < max; i++)
            {
                if (!So1[i].Equals("*")&& !So1[i].Equals("(") && !So1[i].Equals(")"))
                {
                    if (QuyTacNhan(i,n))
                    {
                        XuatKetQua();
                        return true;
                    }

                }

            }
            return false;
        }

        private static bool QuyTacTong1( int n)
        {
            for (int i = Min; i < max; i++)
            {
                if (!So1[i].Equals("+") && !So1[i].Equals("-") &&
                    !So1[i].Equals("/") && !So1[i].Equals("*")
                    && !So1[i].Equals("(") && !So1[i].Equals(")"))
                {
                    if (DoUuTien1(i ,n))
                    {
                        XuatKetQua();
                        return true;
                    }

                }

            }
            return false;
        }
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
                            max -= 2;
                            XuatKetQua();
                            return max;
                        }
                        else if (So1[i].Equals("*"))
                        {
                            int a = Convert.ToInt16(So1[i - 1]);
                            int b = Convert.ToInt16(So1[i + 1]);
                            sum = (a * b);
                            So1[i - 1] = "" + sum;
                            So1.RemoveAt(i + 1);
                            So1.RemoveAt(i);
                            max -= 2;
                            XuatKetQua();
                            return max;
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
                            max -= 2;
                            XuatKetQua();
                            return max;
                        }
                        else if (So1[i].Equals("-"))
                        {
                            int a = Convert.ToInt16(So1[i - 1]);
                            int b = Convert.ToInt16(So1[i + 1]);
                            sum = (a - b);
                            So1[i - 1] = "" + sum;
                            So1.RemoveAt(i + 1);
                            So1.RemoveAt(i);
                            max -= 2;
                            XuatKetQua();
                            return max;
                        }
                    }
                    catch { }
                }
            }

            return 0;
        }
        static void Main(string[] args)
        {
            string Chuoi = " 3*5*5*8*3*5";

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
            TinhTrongKhoac();
            TinhNgoaiKhoac();
          
           

            XuatKetQua();
            if (So1.Count > 1)
            {
                Console.WriteLine("Khong the tinh bieu thuc nay vui long kiem tra lai ");
            }
            Console.ReadKey();
        }

        private static void TinhNgoaiKhoac()
        {
            Min = 0;
            max = So1.Count;
            for (int i = Min; i < max; i++)
            {
                if (KienTrachuoi())
                {
                    if (QuyTacNhan(1)) { i = -1; }
                    else if (QuyTacNhan(2)) { i = -1; }
                }
                KhuchiaNhan();
                if (QuyTacDoiNhau()) { i = -1; }
                if (QuyTacTong1(1))
                {
                    i = -1;
                }
                else if (QuyTacTong1(2))
                {
                    i = -1;
                }
                else
                {
                    if ((BieuThuc("*", max) > 0)) { i = Min - 1; }
                    else if ((BieuThuc("+", max) > 0))
                    {
                        i = Min - 1;
                    }
                    else if ((BieuThuc("-", max) > 0))
                    {
                        i = Min - 1;
                    }

                }

                max = So1.Count;
            }
        }

        //Tinh Hàm Trong  khoạc
        private static void TinhTrongKhoac()
        {
            Min = 0;
            max = So1.Count;
            XuatKetQua();
            for (int i = Min; i < max; i++)
            {
                if (So1[i].Equals("("))
                {
                    Min = i;
                    max = Max(i); // Tim Dấu )
                    if (KienTrachuoi())
                    {
                        if (QuyTacNhan(1)) { i = -1; } // kiêm tra tron 10,1000,10000,10000000.....
                        else if (QuyTacNhan(2)) { i = -1; } //kiêm tra tron 10,20,30,40.....
                    }
                    KhuchiaNhan(); // Tính các dấu nhân chia con sót lại 
                    if (QuyTacDoiNhau()) { i = -1; } // Kiểm tra tông = 0
                    if (QuyTacTong1(1)) // kiêm tra tron 10,1000,10000,10000000.....
                    {
                        i = -1;
                    }
                    else if (QuyTacTong1(2))//kiêm tra tron 10,20,30,40.....
                    {
                        i = -1;
                    }
                    else
                    {
                        // Tính Bình Thường Như cau a 
                        if ((BieuThuc("*", max) > 0)) { i = Min - 1; }
                        else if ((BieuThuc("+", max) > 0))
                        {
                            i = Min - 1;
                        }
                        else if ((BieuThuc("-", max) > 0))
                        {
                            i = Min - 1;
                        }

                    }
                }
                max = So1.Count; //Gan Lai Max
            }
        }
        // Kieemt tra trong chuoi có phải là chuổi nhân hay không vd 3*2*7*5
        private static bool KienTrachuoi()
        {
           
            for (int i = Min+1; i < max; i++)
            {
                if (So1[i].Equals("+") || So1[i].Equals("-") || So1[i].Equals("/") || So1[i].Equals("(") || So1[i].Equals(")"))
                {
                    return false;
                } 
                
            }
            return true;
        }

        // Tim dau )
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
         //Tinh các dau nhan chia cong tru còn xót lai trong chuổi
        private static void KhuchiaNhan()
        {
            int sum = 0;
                XoaChuoiRong();
                for (int i = Min; i < max; i++)
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
                            max -= 2;
                            XuatKetQua();
                            i = Min;
                        }
                    if (So1[i].Equals("*"))
                    {
                        int a = Convert.ToInt16(So1[i - 1]);
                        int b = Convert.ToInt16(So1[i + 1]);
                        sum = (a * b);
                        So1[i - 1] = "" + sum;
                        So1.RemoveAt(i + 1);
                        So1.RemoveAt(i);
                        max -= 2;
                        XuatKetQua();
                        i = Min;
                    }

                }
                    catch { }
            }
        }
    }
}
