using api.App;
using api.App.FromApi;
using api.Context;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiContextController : ControllerBase
    {

        #region kullan�c� i�lemleri


        #endregion
        [HttpPost]
        public Return kayitOlustur([FromBody] KayitParametre kayitParametre)
        {
            Return _return = new Return();
            using (WebApiContext context = new WebApiContext())
            {
                try
                {
                    kayitParametre.Aktif = false;
                    Kisi _kisi = new Kisi()
                    {
                        Ad = kayitParametre.Ad,
                        Soyad = kayitParametre.Soyad,
                        Tc = kayitParametre.Tc,
                        Tel = kayitParametre.Tel,
                        Mail = kayitParametre.Mail,
                        Aktif = kayitParametre.Aktif,
                        KayitTarihi = DateTime.Now
                    };
                    if (mukerrerKisi(_kisi.Tc, _kisi.Tel) == true)
                    {
                        if (_kisi.Tc.Length == 11 && _kisi.Tel.Length == 11)
                        {
                            context.Kisiler.Add(_kisi);
                            context.SaveChanges();
                            _return.data = _kisi;
                            _return.success = true;
                            _return.message = "Ba�ar�l�";
                            smsGonder(_kisi.Id, 1);
                            return _return;
                        }
                        else
                        {
                            _return.data = _kisi;
                            _return.success = false;
                            _return.message = "Bilgilerinizi tekarar kontrol ediniz";
                            return _return;
                        }


                    }
                    else if (mukerrerKisi(_kisi.Tc, _kisi.Tel) == false && banKontrol(tcKisiCek(_kisi.Tc, _kisi.Tel)) == true)
                    {

                        if (_kisi.Tc.Length == 11 && _kisi.Tel.Length == 11)
                        {
                            context.SaveChanges();
                            _return.data = _kisi;
                            _return.success = true;
                            _return.message = "Ba�ar�l�";
                            smsGonder(tcKisiCek(_kisi.Tc, _kisi.Tel), 1);
                            return _return;
                        }
                        else
                        {
                            _return.data = _kisi;
                            _return.success = false;
                            _return.message = "Bilgilerinizi tekarar kontrol ediniz";
                            return _return;
                        }

                    }
                    else
                    {
                        _return.data = _kisi;
                        _return.success = false;
                        _return.message = "Zaten Kay�tl� (Kaydedilmedi)";
                        return _return;
                    }



                }
                catch (Exception ex)
                {
                    _return.data = null;
                    _return.success = false;
                    _return.message = ex.Message;
                    return _return;

                }

            }


        }

        [HttpPost]
        public Return girisYap([FromBody] GirisParametre girisParametre)
        {
            Return _return = new Return();
            using (WebApiContext context = new WebApiContext())
            {
                int id = kulCek(girisParametre.Tc, girisParametre.Tel);
                try
                {
                    Kullanici kullanici = context.Kullanicilar.Find(id);
                    if (kullanici.Aktif == true && banKontrol(kullanici.KisiId) == true)
                    {
                        Hareket _hareket = new Hareket()
                        {
                            KullaniciId = id,
                            SayfaId = null,
                            IslemId = null,
                            GuncellemeTarihi = DateTime.Now
                        };
                        smsGonder(id, 2);
                        context.SaveChanges();
                        int kisiId = tcKisiCek(girisParametre.Tc, girisParametre.Tel);
                        context.Hareketler.Add(_hareket);
                        context.SaveChanges();


                        _return.data = _hareket;
                        _return.message = "Ba�ar�l�";
                        _return.success = true;
                        return _return;
                    }
                    else
                    {
                        _return.data = null;
                        _return.success = false;
                        _return.message = "Hesab�n�z silinmi�";
                        return _return;
                    }

                }
                catch (Exception ex)
                {
                    _return.data = null;
                    _return.success = false;
                    _return.message = ex.Message;
                    return _return;

                }
            }
        }

        [HttpPost]
        public Return kullaniciSil([FromBody] GirisParametre kullaniciSilParametre)
        {

            int kisiId = tcKisiCek(kullaniciSilParametre.Tc, kullaniciSilParametre.Tel);
            int kulId = kulCek(kullaniciSilParametre.Tc, kullaniciSilParametre.Tel);
            Return _return = new Return();
            using (WebApiContext context = new WebApiContext())
            {
                try
                {
                    Kisi kisi = context.Kisiler.Find(kisiId);
                    Kullanici kullanici = context.Kullanicilar.Find(kulId);
                    kullanici.Aktif = false;
                    context.SaveChanges();
                    smsGonder(kulId, 5);
                    _return.data = kullanici;
                    _return.success = true;
                    _return.message = "Ki�i Silindi";
                    return _return;

                }
                catch
                {
                    _return.data = null;
                    _return.success = false;
                    _return.message = "Ki�i Silinemedi";
                    return _return;

                }
            }
        }

        [HttpPost]
        public Return kullaniciGuncelle([FromBody] KayitParametre kullaniciGuncelleParametre)
        {
            int kulId = kulCek(kullaniciGuncelleParametre.Tc, kullaniciGuncelleParametre.Tel);
            int kisiId = tcKisiCek(kullaniciGuncelleParametre.Tc, kullaniciGuncelleParametre.Tel);
            Return _return = new Return();
            using (WebApiContext context = new WebApiContext())
            {
                try
                {
                    Kisi kisi = context.Kisiler.Find(kisiId);
                    if (kullaniciGuncelleParametre.Mail != null)
                    {
                        kisi.Mail = kullaniciGuncelleParametre.Mail;
                    }
                    if (kullaniciGuncelleParametre.Tel != null && kullaniciGuncelleParametre.Tel.Length == 11)
                    {
                        kisi.Tel = kullaniciGuncelleParametre.Tel;
                    }
                    kisi.GuncellemeTarihi = DateTime.Now;
                    smsGonder(kulId, 4);
                    context.SaveChanges();

                    _return.data = kisi;
                    _return.success = true;
                    _return.message = "Ki�i G�ncellendi";
                    return _return;

                }
                catch
                {
                    _return.data = null;
                    _return.success = false;
                    _return.message = "Ba�ar�s�z";
                    return _return;

                }
            }
        }

        [HttpPost]
        public Return bildiriOlustur([FromBody] BildiriParametre bildiriEkle)
        {

            Return _return = new Return();
            try
            {
                using (WebApiContext context = new WebApiContext())
                {

                    Bildiri bildiri = new Bildiri();
                    bildiri.Aciklama = bildiriEkle.Aciklama;
                    //bildiri.AltKategoriId = bildiriEkle.AltKategoriId;
                    //bildiri.FotografId = bildiriEkle.FotografId;
                    bildiri.KayitTarihi = DateTime.Now;
                    //bildiri.KonumId = bildiriEkle.KonumId;
                    bildiri.Aktif = false;
                    bildiri.KullaniciId = bildiriEkle.KullaniciId;
                    context.Bildiriler.Add(bildiri);
                    context.SaveChanges();

                    if (gikomId(bildiri.Id) != null || gikomId(bildiri.Id) != 0)
                    {
                        Bildiri bildiriGuncel = context.Bildiriler.Find(bildiri.Id);
                        bildiriGuncel.Aktif = true;
                        context.SaveChanges();
                        _return.data = bildiri;
                        _return.success = true;
                        _return.message = "Ba�ar�l�";
                    }
                    else
                    {
                        _return.data = bildiri;
                        _return.success = true;
                        _return.message = "Bildiri Olu�tu Ancak Gikom Taraf�ndan Kabul Edilmedi";
                        return _return;
                    }

                }
                return _return;
            }
            catch (Exception ex)
            {

                _return.data = null;
                _return.success = false;
                _return.message = ex.Message;
                return _return;
            }

        }

        [HttpPost]
        public Return bildiriGuncelle([FromBody] BildiriParametre bildiriDuzenle)
        {
            Return _return = new Return();
            try
            {
                using (WebApiContext context = new WebApiContext())
                {
                    int BildiriId = 8;
                    Bildiri bildiri = context.Bildiriler.Find(BildiriId);

                    bildiri.KullaniciId = bildiriDuzenle.KullaniciId;
                    bildiri.GuncellemeTarihi = DateTime.Now;

                    if (bildiriDuzenle.Aciklama.Length > 1)
                    {
                        bildiri.Aciklama = bildiriDuzenle.Aciklama;
                    }
                    if (bildiriDuzenle.AltKategoriId >= 1)
                    {
                        bildiri.AltKategoriId = bildiriDuzenle.AltKategoriId;
                    }
                    if (bildiriDuzenle.FotografId >= 1)
                    {
                        bildiri.FotografId = bildiriDuzenle.FotografId;
                    }
                    if (bildiriDuzenle.KonumId >= 1)
                    {
                        bildiri.KonumId = bildiriDuzenle.KonumId;
                    }
                    context.SaveChanges();
                    _return.data = bildiri;
                    _return.success = true;
                    _return.message = "Ba�ar�l�";
                }
                return _return;
            }
            catch (Exception ex)
            {

                _return.data = null;
                _return.success = false;
                _return.message = ex.Message;
                return _return;
            }

        }

        [HttpPost]
        public int gikomId(int id)
        {
            int createGikomId = 0;
            using (WebApiContext context = new WebApiContext())
            {
                Gikom gikom = new Gikom();
                gikom.KayitTarihi = DateTime.Now;
                gikom.BildiriId = id;
                context.Gikom.Add(gikom);
                createGikomId = context.SaveChanges();
            }
            return createGikomId;
        }

        [HttpPost]
        public Return smsKontrol(SmsKontrolParametre smsKontrolParametre)
        {
            Return _return = new Return();
            KayitParametre kayit = new KayitParametre();

            using (WebApiContext context = new WebApiContext())
            {
                Sms mesaj = context.Smsler.Where(x => x.KisiId == smsKontrolParametre.KisiId).OrderByDescending(x => x.Id).FirstOrDefault() as Sms;
                if (mesaj.GecerlilikTarih >= DateTime.Now)
                {
                    Kisi kisi = context.Kisiler.Find(smsKontrolParametre.KisiId);

                    if (smsKontrolParametre.SmsKod == mesaj.Kod)
                    {
                        kisi.Aktif = true;
                        kayit.Aktif = true;
                        context.SaveChanges();
                        if (mesaj.SmsTur == 1)
                        {
                            kayit.Ad = kisi.Ad;
                            kayit.Mail = kisi.Mail;
                            kayit.Soyad = kisi.Soyad;
                            kayit.Tc = kisi.Tc;
                            kayit.Tel = kisi.Tel;
                            createUser(kayit, kisi.Id);
                            _return.data = kisi;
                            _return.success = true;
                            _return.message = "Kay�t Ba�ar�l�";
                            return _return;
                        }
                        else if (mesaj.SmsTur == 2)
                        {
                            _return.data = kisi;
                            _return.success = true;
                            _return.message = "Giri� Ba�ar�l�";
                            return _return;
                        }
                        else if (mesaj.SmsTur == 3)
                        {
                            _return.data = kisi;
                            _return.success = true;
                            _return.message = "��k�� Ba�ar�l�";
                            return _return;
                        }
                        else if (mesaj.SmsTur == 4)
                        {
                            _return.data = kisi;
                            _return.success = true;
                            _return.message = "G�ncelleme ��lemi Ba�ar�l�";
                            return _return;
                        }
                        else if (mesaj.SmsTur == 5)
                        {
                            _return.data = kisi;
                            _return.success = true;
                            _return.message = "Silme ��lemi Ba�ar�l�";
                            return _return;
                        }
                        else
                        {
                            _return.data = kisi;
                            _return.success = true;
                            _return.message = "Ba�ar�l� Ancak ��lem Tespit Edilemedi";
                            return _return;
                        }


                    }
                    else
                    {
                        kisi.Aktif = false;
                        kayit.Aktif = false;
                        context.SaveChanges();
                        _return.data = kisi;
                        _return.success = false;
                        _return.message = "Hatal� Bir ��lem Yapt�n�z";
                        return _return;
                    }
                }
                else
                {
                    _return.data = null;
                    _return.success = false;
                    _return.message = "Hata";
                    return _return;
                }
            }

        }

        [HttpPost]
        public Return kisiBan(BanParametre banParam)
        {
            Return _return = new Return();
            using (WebApiContext context = new WebApiContext())
            {
                Kisi kisi = context.Kisiler.Find(banParam.KisiId);
                Kullanici kullanici = context.Kullanicilar.Find(kulCek(kisi.Tc, kisi.Tel));
                Aktiflik ban = new Aktiflik();
                ban.Aktif = true;
                ban.KisiId = banParam.KisiId;
                ban.BitisTarihi = banParam.BitisTarihi;
                ban.PasifTuru = 1;
                kullanici.Aktif = false;
                context.Aktiflikler.Add(ban);
                context.SaveChanges();
                _return.data = ban;
                _return.success = true;
                _return.message = "Kisi Basariyla Banland�";
                return _return;
            }
        }


        //metodlar
        public bool banKontrol(int id)
        {
            using (WebApiContext context = new WebApiContext())
            {
                Aktiflik ban = context.Aktiflikler.Where(x => x.KisiId == id).OrderByDescending(x => x.Id).FirstOrDefault() as Aktiflik;
                Kisi kisi = context.Kisiler.Find(id);
                Kullanici kul = context.Kullanicilar.Where(x => x.KisiId == id).FirstOrDefault() as Kullanici;
                if (ban != null && ban.BitisTarihi > DateTime.Now)
                {
                    ban.Aktif = true;
                    kul.Aktif = false;
                    context.SaveChanges();
                    return false;
                }
                else if (ban == null)
                {
                    return true;
                }
                else if (ban.BitisTarihi <= DateTime.Now)
                {
                    ban.Aktif = false;
                    kisi.Aktif = true;
                    kul.Aktif = true;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string smsGonder(int id, int flag)
        {
            Random rnd = new Random();
            string kod = rnd.Next(100000, 999999).ToString();
            using (WebApiContext context = new WebApiContext())
            {
                string Ad;
                string Soyad;
                string kisiTel;
                try
                {
                    if (flag == 1)
                    {

                        Kisi kisi = context.Kisiler.Find(id);
                        Ad = kisi.Ad;
                        Soyad = kisi.Soyad;
                        kisiTel = kisi.Tel;
                        Sms sms = new Sms();
                        sms.KayitTarihi = DateTime.Now;
                        sms.KisiId = kulCek(kisi.Tc, kisi.Tel);
                        sms.GecerlilikTarih = DateTime.Now.AddMinutes(5);
                        sms.Text = $"Merhaba {Ad} {Soyad} ALO 153 GBB MOBIL UYGULAMASINA KAYIT OLMAK ICIN DOGRULAMA KODUNUZ:{kod}. IYI GUNLER DILERIZ. KODUN SON GECERL�L�K TARIHI {sms.GecerlilikTarih}";
                        sms.Kod = kod;
                        sms.SmsTur = 1;
                        sms.GidenTel = kisiTel;
                        context.Smsler.Add(sms);
                        context.SaveChanges();
                        return kod;
                    }
                    else if (flag == 2)
                    {

                        Ad = kisiBilgi(id).Ad;
                        Soyad = kisiBilgi(id).Soyad;
                        kisiTel = kisiBilgi(id).Tel;
                        Sms sms = new Sms();
                        sms.KayitTarihi = DateTime.Now;
                        sms.KisiId = id;
                        sms.GecerlilikTarih = DateTime.Now.AddMinutes(5);
                        sms.Text = $"Merhaba {Ad} {Soyad} ALO 153 GBB MOBIL UYGULAMASINA GIRIS YAPMAK ICIN DOGRULAMA KODUNUZ:{kod}. IYI GUNLER DILERIZ. KODUN SON GECERL�L�K TARIHI {sms.GecerlilikTarih}";
                        sms.Kod = kod;
                        sms.SmsTur = 2;
                        sms.GidenTel = kisiTel;
                        context.Smsler.Add(sms);
                        context.SaveChanges();
                        return kod;
                    }
                    else if (flag == 3)
                    {
                        Ad = kisiBilgi(id).Ad;
                        Soyad = kisiBilgi(id).Soyad;
                        kisiTel = kisiBilgi(id).Tel;
                        Sms sms = new Sms();
                        sms.KayitTarihi = DateTime.Now;
                        sms.KisiId = id;
                        sms.GecerlilikTarih = DateTime.Now.AddMinutes(5);
                        sms.Text = $"Merhaba {Ad} {Soyad} ALO 153 GBB MOBIL UYGULAMASINA CIKIS YAPMAK ICIN DOGRULAMA KODUNUZ:{kod}. IYI GUNLER DILERIZ. KODUN SON GECERL�L�K TARIHI {sms.GecerlilikTarih}";
                        sms.Kod = kod;
                        sms.SmsTur = 3;
                        sms.GidenTel = kisiTel;
                        context.Smsler.Add(sms);
                        context.SaveChanges();
                        return kod;
                    }
                    else if (flag == 4)
                    {
                        Ad = kisiBilgi(id).Ad;
                        Soyad = kisiBilgi(id).Soyad;
                        kisiTel = kisiBilgi(id).Tel;
                        Sms sms = new Sms();
                        sms.KayitTarihi = DateTime.Now;
                        sms.KisiId = id;
                        sms.GecerlilikTarih = DateTime.Now.AddMinutes(5);
                        sms.Text = $"Merhaba {Ad} {Soyad} ALO 153 GBB MOBIL UYGULAMASINDA HESAP BILGILERINIZI GUNCELLEMEK ICIN DOGRULAMA KODUNUZ:{kod}. IYI GUNLER DILERIZ. KODUN SON GECERL�L�K TARIHI {sms.GecerlilikTarih}";
                        sms.Kod = kod;
                        sms.SmsTur = 4;
                        sms.GidenTel = kisiTel;
                        context.Smsler.Add(sms);
                        context.SaveChanges();
                        return kod;
                    }
                    else if (flag == 5)
                    {
                        Ad = kisiBilgi(id).Ad;
                        Soyad = kisiBilgi(id).Soyad;
                        kisiTel = kisiBilgi(id).Tel;
                        Sms sms = new Sms();
                        sms.KayitTarihi = DateTime.Now;
                        sms.KisiId = id;
                        sms.GecerlilikTarih = DateTime.Now.AddMinutes(5);
                        sms.Text = $"Merhaba {Ad} {Soyad} ALO 153 GBB MOBIL UYGULAMASINDA BULUNAN HESABINIZI SILMEK ICIN DOGRULAMA KODUNUZ:{kod}. IYI GUNLER DILERIZ. KODUN SON GECERL�L�K TARIHI {sms.GecerlilikTarih}";
                        sms.Kod = kod;
                        sms.SmsTur = 5;
                        sms.GidenTel = kisiTel;
                        context.Smsler.Add(sms);
                        context.SaveChanges();
                        return kod;
                    }
                    else
                    {
                        return "HATA";
                    }

                }
                catch (Exception)
                {

                    return "Hatal� Bilgi.";
                }
            }
        }

        public int createUser(KayitParametre kayitParametre, int id)
        {
            int createdUserId = 0;
            if (kayitParametre != null)
            {

                using (WebApiContext context = new WebApiContext())
                {
                    if (true)
                    {
                        Kisi kisi = context.Kisiler.Find(id);
                        Kullanici kullanici = new Kullanici()
                        {
                            KullaniciAdi = kisi.Tc,
                            KullaniciSifre = kisi.Tel,
                            Aktif = true,
                            KayitTarihi = DateTime.Now,
                            KisiId = id
                        };
                        if (mukerrerKullanici(id) == true)
                        {
                            context.Kullanicilar.Add(kullanici);
                            createdUserId = context.SaveChanges();
                            kayitParametre.Aktif = true;
                        }
                    }

                }


            }
            return createdUserId;
        }

        public int kulCek(string Tc, string Tel)
        {

            using (WebApiContext context = new WebApiContext())
            {
                Kisi kisi = context.Kisiler.Where(x => x.Tel == Tel && x.Tc == Tc).FirstOrDefault() as Kisi;

                Kullanici kullanic = context.Kullanicilar.Where(x => x.KisiId == kisi.Id).SingleOrDefault() as Kullanici;
                return kullanic.Id;
            }

        }

        public int tcKisiCek(string tc, string tel)
        {
            using (WebApiContext context = new WebApiContext())
            {
                Kisi kisi = context.Kisiler.Where(x => x.Tel == tel && x.Tc == tc).FirstOrDefault() as Kisi;
                if (kisi.Id != 0 || kisi.Id != null)
                {
                    return kisi.Id;
                }
                else if (kisi == null)
                {
                    return 0;
                }
                else
                {
                    return 0;
                }
            };

        }

        public bool mukerrerKisi(string Tc, string Tel)
        {

            using (WebApiContext context = new WebApiContext())
            {
                Kisi kisi = context.Kisiler.Where(x => x.Tel == Tel || x.Tc == Tc).FirstOrDefault() as Kisi;
                if (kisi != null)
                {
                    if (banKontrol(kisi.Id) == true)
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            };
        }

        public bool mukerrerKullanici(int id)
        {
            using (WebApiContext context = new WebApiContext())
            {
                Kullanici kullanici = context.Kullanicilar.Where(x => x.KisiId == id).FirstOrDefault() as Kullanici;

                if (kullanici != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            };
        }

        public KayitParametre kisiBilgi(int id)
        {
            KayitParametre param = new KayitParametre();
            using (WebApiContext context = new WebApiContext())
            {
                Kullanici kullanici = context.Kullanicilar.Find(id);
                Kisi kisi = context.Kisiler.Find(kullanici.KisiId);
                param.Ad = kisi.Ad;
                param.Soyad = kisi.Soyad;
                param.Mail = kisi.Mail;
                return param;
            }
        }


        #region Deneme Metotu
        public List<Kullanici> getAll()
        {
            using (WebApiContext context = new WebApiContext())
            {

                var results = context.Kullanicilar.Select(x => new Kullanici
                {
                    KullaniciAdi = x.KullaniciAdi
                }).ToList();

                return results;
            }
        }
        #endregion
    }
}