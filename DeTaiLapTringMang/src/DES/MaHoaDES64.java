/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DES;

import java.awt.Component;
import javax.swing.JOptionPane;

/**
 *
 * @author PhamTrongTruong
 */
public class MaHoaDES64 {
       public Khoa KhoaDES ;
        public ChuoiNhiPhan ThucHienDES(Khoa key,ChuoiNhiPhan ChuoiVaoDai, int MaHoaHayGiaiMa)// 1 ma hoa, -1 giai ma
        {
            this.KhoaDES = key;// lấy khóa chính
            if(MaHoaHayGiaiMa==1) // nếu là mã hóa thì cần chỉnh lại độ dài của chúng sao cho chia hết cho 64
                ChuoiVaoDai =ChuoiVaoDai.ChinhDoDai64() ;
            
            KhoaDES.SinhKhoaCon( ); // sinh dẫy các khóa con
            ChuoiNhiPhan[] DSChuoiVao = ChuoiVaoDai.Chia(ChuoiVaoDai.DoDai() / 64);// chia dữ liệu vào thành từng khối 64 bit và xử lý dần dần
            ChuoiNhiPhan ChuoiVao,ChuoiKQ;
            ChuoiKQ = new ChuoiNhiPhan(0);
            ChuoiNhiPhan[] ChuoiSauIP;
            ChuoiNhiPhan ChuoiSauIP_1;
            ChuoiNhiPhan L, R, F, TG;
            for (int k = 0; k < DSChuoiVao.length; k++)  // duyêt qua từng chuỗi được chai
            {
                //ChuoiVao = DSChuoiVao[k];
                
                // b1: tính IP
                ChuoiSauIP = CacThongSo.TinhIP(DSChuoiVao[k]);
                // lấy giá trị L,R
                L = ChuoiSauIP[0];
                R = ChuoiSauIP[1];

                for (int i = 0; i < 16; i++)
                {
                    try {
                         F = HamF(R, KhoaDES.DayKhoaPhu[MaHoaHayGiaiMa==1?i:15-i]);
                    L = L.XOR(F);// tính XOR giữa L và giá trị hàm F
                    TG = L;// đổi L và R cho nhau
                    L = R;
                    R = TG;
                    } catch (Exception e) {
                    }
                    // tính hàm F giữa khóa phụ Right
                   
                }
                // tính IP_1
                ChuoiSauIP_1 = CacThongSo.TinhIP_1( R,L);

                // cộng thêm chuỗi đã ddc mã hóa vào
                ChuoiKQ = ChuoiKQ.Cong(ChuoiSauIP_1);
            }
            if (MaHoaHayGiaiMa == -1) // nếu là giải mã thì cần cắt bớt các bit bù vào ban đầu
                ChuoiKQ = ChuoiKQ.CatDuLieu64();
            return ChuoiKQ;
        }
        

        /// <summary>
        /// Để mã hóa 1 chuỗi string
        /// Đơn giản là chuyển string thành mảng nhị phân và đưa vào hàm mã hóa DES
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ChuoiVao"></param>
        /// <param name="MaHoaHayGiaiMa"></param>
        /// <returns></returns>
        public String ThucHienDESText(Khoa key,String ChuoiVao, int MaHoaHayGiaiMa)// 1 ma hoa, -1 giai ma
        {
            ChuoiNhiPhan chuoiNhiPhan;
            if (MaHoaHayGiaiMa == 1)
            {
                chuoiNhiPhan = ChuoiNhiPhan.ChuyenChuSangNhiPhan(ChuoiVao);
            }
            else
            {
                //chuoiNhiPhan = ChuoiNhiPhan.ChuyenChuSangNhiPhan(ChuoiVao);

                chuoiNhiPhan = ChuoiNhiPhan.ChuyenChuSangChuoiNhiPhan(ChuoiVao);
            }            
            ChuoiNhiPhan KQ = ThucHienDES(key,chuoiNhiPhan, MaHoaHayGiaiMa);
            if (MaHoaHayGiaiMa == 1)
            {
                return KQ.Text();
                //return ChuoiNhiPhan.ChuyenNhiPhanSangChu(KQ);
            }
            if (KQ == null)
            {
                Component rootPane = null;
                 JOptionPane.showMessageDialog(rootPane, "Lỗi giải mã. Vui lòng kiểm tra khóa!");
               
                return "";
            }
            return ChuoiNhiPhan.ChuyenNhiPhanSangChu(KQ);// chuyen sang dạng text để hiện thị kết quả
        }       
        /// <summary>
        /// Hàm tính F 
        /// đầu vào: chuỗi cần tính (C0 hoặc D0) và khóa co thứ k
        /// </summary>
        /// <param name="chuoiVao"></param>
        /// <param name="KhoaCon"></param>
        /// <returns></returns>
        private ChuoiNhiPhan HamF(ChuoiNhiPhan chuoiVao, ChuoiNhiPhan KhoaCon)
        {
            
            ChuoiNhiPhan KQ=CacThongSo.TinhE(chuoiVao); // Tính E trước
            KQ = KQ.XOR(KhoaCon); // tính XOR 
            KQ = CacThongSo.TinhSBox(KQ); // tính hộp s-box
            KQ = CacThongSo.TinhP(KQ); // tính P là ok
            return KQ;
        }

    }

