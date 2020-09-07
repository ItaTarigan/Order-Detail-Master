using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalitTanahPelayanan.Helpers
{
    public class Status
    {
        public static string[] OrderStatus =
        {
            "Pesanan Baru",//0
            "Barcode Sample",//1
            "Pilih Penyelia",//2
            "Proses Lab",//3
            "Evaluasi Hasil",//4
            "Verifikasi Penyelia",//5
            "Menunggu Approval",//6
            "LHP Keluar",//7
            "LHP Sudah Diambil"//8
        };

        public static string[] PaymentStatus =
        {
            "Belum dibayar",
            "Verifikasi",
            "Sudah dibayar"
        };

        public static string[] SampleStatus =
        {
            "Menunggu",
            "Diproses"
        };
    }
}