using System;

namespace ProjeOdeviATM
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- DEĞİŞKENLER ---
            string kullaniciSifresi;
            string girilenSifre;
            double bakiye = 5000.0;
            int denemeHakki = 3;
            bool girisBasarili = false;

            // --- 1. ŞİFRE BELİRLEME (Yeni Eklenen Kısım) ---
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== HESAP KURULUMU ===");
            Console.ResetColor();
            Console.Write("Lütfen kullanmak istediğiniz şifreyi belirleyin: ");
            kullaniciSifresi = Console.ReadLine();
            Console.WriteLine("Şifreniz başarıyla oluşturuldu. Giriş ekranına yönlendiriliyorsunuz...");
            System.Threading.Thread.Sleep(1500);

            // --- 2. GİRİŞ SİSTEMİ (Do-While) ---
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== GEMINI BANK ATM GİRİŞİ ===");
                Console.ResetColor();
                Console.Write($"Şifrenizi Giriniz (Kalan Hak: {denemeHakki}): ");
                girilenSifre = Console.ReadLine();

                if (girilenSifre == kullaniciSifresi)
                {
                    girisBasarili = true;
                }
                else
                {
                    denemeHakki--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hatalı şifre!");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                }
            } while (!girisBasarili && denemeHakki > 0);

            // --- 3. ANA MENÜ VE İŞLEMLER ---
            if (girisBasarili)
            {
                bool devam = true;
                while (devam)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("--- ANA MENÜ ---");
                    Console.ResetColor();
                    Console.WriteLine("1- Bakiye Sorgula\n2- Para Yatır\n3- Para Çek\n4- Çıkış");
                    Console.Write("\nSeçiminiz: ");
                    string secim = Console.ReadLine();

                    switch (secim)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nGüncel Bakiyeniz: {bakiye} TL");
                            break;

                        case "2":
                            Console.Write("\nYatırılacak Tutar: ");
                            double yatirilan = Convert.ToDouble(Console.ReadLine());
                            bakiye += yatirilan;
                            Console.WriteLine($"İşlem başarılı. Yeni bakiyeniz: {bakiye} TL");
                            break;

                        case "3":
                            // --- PARA ÇEKME EKRANI (İstediğin Güncelleme) ---
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("=== PARA ÇEKME EKRANI ===");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Mevcut Bakiyeniz: {bakiye} TL"); // Çekmeden önce gösterim
                            Console.WriteLine("-------------------------");
                            
                            Console.Write("Çekmek istediğiniz tutarı girin: ");
                            double cekilen = Convert.ToDouble(Console.ReadLine());

                            if (cekilen <= bakiye)
                            {
                                bakiye -= cekilen;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nİşlem Başarılı. Paranızı alınız.");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Kalan Bakiyeniz: {bakiye} TL"); // Çektikten sonra gösterim
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nYetersiz bakiye! İşlem iptal edildi.");
                            }
                            break;

                        case "4":
                            Console.WriteLine("\nGüvenli çıkış yapıldı. İyi günler!");
                            devam = false;
                            break;

                        default:
                            Console.WriteLine("\nGeçersiz seçim.");
                            break;
                    }

                    Console.ResetColor();
                    if (devam)
                    {
                        Console.WriteLine("\nMenüye dönmek için ENTER...");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n3 Kez hatalı giriş! Güvenlik nedeniyle hesabınız kilitlendi.");
            }

            Console.ResetColor();
            Console.WriteLine("\nKapatmak için bir tuşa basın.");
            Console.ReadKey();
        }
    }
}
