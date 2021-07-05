/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Server;

import Client.frmClient;
import DES.Khoa;
import DES.MaHoaDES64;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.Base64;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

/**
 *
 * @author PhamTrongTruong
 */
public class Server {
    private static DatagramPacket Client;
    private static DatagramSocket sc;
    private static byte [] mess;
    private static String[] Data;
    public static void main(String[] args) throws SocketException, IOException, InvalidKeyException, NoSuchAlgorithmException, IllegalBlockSizeException, NoSuchPaddingException, BadPaddingException {
      //b1 khoi tao
              KhoiTao();
        while (true) {            
             Receive();           
       if(Check(Data[0])==false){
       break;
       }
       if(Data.length>1){
           //String ma="";
           System.out.println(Data[1].length());
          // Data[1]=ma;        
           System.out.println("Key: "+Data[0]);
          System.out.println("Thong Tin MaHoa: "+Data[1]);
            SendPacket(MaHoa().toUpperCase()); 
    // SendPacket(DESalgorithm().toUpperCase()); 
       }
        }
         SendPacket("Close"); 
        sc.close();  
    }
   private static  String MaHoa()
        {
              Khoa khoa1  = new Khoa(Data[0]);  
           
           MaHoaDES64  maHoaDES64 = new MaHoaDES64();
             String kq1 = maHoaDES64.ThucHienDESText(khoa1, Data[1], -1);
            System.out.println("Server giải mã : "+kq1);
               return  kq1;
                
            }

    private static void KhoiTao() throws SocketException, IOException {
       sc=new DatagramSocket(7777);
        System.out.println("Server đã săn sàn..........");
    
    }

    private static void  Receive() throws IOException {
       mess=new byte[999999999];
       Client=new DatagramPacket(mess, mess.length);
       sc.receive(Client);
       String result=new String(Client.getData(),0,Client.getLength()).trim();
     
        Data=result.split("/");    
             
               }

    private static String DESalgorithm(){
        try {
               SecretKeySpec skeySpec = new SecretKeySpec(Data[0].getBytes(), "DES");
    Cipher cipher = Cipher.getInstance("DES/ECB/PKCS5PADDING");
   cipher.init(Cipher.DECRYPT_MODE, skeySpec);
   byte[] byteDecrypted = new sun.misc.BASE64Decoder().decodeBuffer(Data[1]);
     byte[] utf8 = cipher.doFinal(byteDecrypted);
  return new String(utf8, "UTF8");
    
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return "Lỗi Server";
    }
    private static boolean Check(String mess) {
        if(mess.equals("false")){
            return false;
        }
        return true;
    }
    private static void SendPacket(String decrypted) throws IOException {
        mess=decrypted.getBytes();
        Client=new DatagramPacket(mess, mess.length, Client.getAddress(), Client.getPort());
        sc.send(Client);
    }
}
