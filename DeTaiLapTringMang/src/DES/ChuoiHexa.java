/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DES;

/**
 *
 * @author PhamTrongTruong
 */
public class ChuoiHexa {
      public String Chuoi ; // chuỗi nội dung
        private int _doDai; // độ dài của chuỗi
        public ChuoiNhiPhan chuoiNhiPhan ;// lưu trữ dạng cơ số 2
        public static  String BoHexa = "0123456789ABCDEFabcdef";// bộ chữ trong hệ 16
        public int DoDai()
        {
            return Chuoi.length();            
        }
       /// <summary>
       /// Tạo lập một chuỗi hexa từ 1 chuỗi chữ cái bên ngoài đưa vào
       /// </summary>
       /// <param name="chuoi"></param>
        public ChuoiHexa(String chuoi)
        {
            this.Chuoi = chuoi.toUpperCase(); // đưa về chữ hoa hết cho dễ đọc
            ChuoiNhiPhan chNP;//   
            if (KiemTra())// kiểm tra xem chuỗi này có hợp lệ k
            {
                chuoiNhiPhan = new ChuoiNhiPhan(0);
                for (int i = 0; i < chuoi.length(); i++) {
                    chNP= ChuoiNhiPhan.ChuyenSoSangNhiPhan(ChuoiHexa.ChuyenHexaSangHe10(chuoi.charAt(i)),4); // chuyển từng ký tự 1 về dạng 4bit cơ số 2
                    chuoiNhiPhan = chuoiNhiPhan.Cong(chNP);
                    
                }
               
            }
        }
        /// <summary>
        /// Kiểm tra xem chuỗi này có phải hệ hexa k
        /// 
        /// </summary>
        /// <returns></returns>
        public boolean KiemTra()
        {
            boolean Kt = true;
               for (int i = 0; i < Chuoi.length(); i++) {
                     if (!ChuoiHexa.BoHexa.contains(""+Chuoi.charAt(i)))// nếu có 1 ký tự k nằm trong bộ hexa thì báo lỗi
                {
                    Kt = false;
                    break;

                }
                }
               
          
            return Kt;
        }
        /// <summary>
        /// Chuyển 1 ký tự trong hệ 16 sang hệ 10
        /// </summary>
        /// <param name="K"></param>
        /// <returns></returns>
        public static int ChuyenHexaSangHe10(char K)
        {

            int KQ = 0;
            switch (K)
            {
                case '0':
                    KQ = 0;
                    break;
                case '1':
                    KQ = 1;
                    break;
                case '2':
                    KQ = 2;
                    break;
                case '3':
                    KQ = 3;
                    break;
                case '4':
                    KQ = 4;
                    break;
                case '5':
                    KQ = 5;
                    break;
                case '6':
                    KQ = 6;
                    break;
                case '7':
                    KQ = 7;
                    break;
                case '8':
                    KQ = 8;
                    break;
                case '9':
                    KQ = 9;
                    break;
                case 'A':
                    KQ = 10;
                    break;
                case 'B':
                    KQ = 11;
                    break;
                case 'C':
                    KQ = 12;
                    break;
                case 'D':
                    KQ = 13;
                    break;
                case 'E':
                    KQ = 14;
                    break;
                case 'F':
                    KQ = 15;
                    break;
            }
            return KQ;
        }
}
