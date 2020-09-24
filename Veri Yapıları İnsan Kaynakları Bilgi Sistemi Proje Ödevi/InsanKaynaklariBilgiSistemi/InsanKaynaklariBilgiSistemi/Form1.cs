using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsanKaynaklariBilgiSistemi
{

    public partial class FrmAnaSayfa : Form
    {
        HashChainTable hashChainTable = new HashChainTable();
        HashChainTableSirket HashChainTableSirket = new HashChainTableSirket();
        IkiliAramaAgaci IkiliAramaAgaci = new IkiliAramaAgaci();
        Kisi kisi = new Kisi();
        IkiliAramaAgacDugumu IkiliAramaAgacDugumu = new IkiliAramaAgacDugumu();
        LinkedListEgitimDurumuBilgileri linkedListEgitimDurumuBilgileri = new LinkedListEgitimDurumuBilgileri();
        EgitimDurumuBilgileri egitimDurumuBilgileri = new EgitimDurumuBilgileri();
        LinkedListIsDeneyimiBilgileri linkedListIsDeneyimiBilgileri = new LinkedListIsDeneyimiBilgileri();
        IsDeneyimi isDeneyimi = new IsDeneyimi();
        Sirket sirket = new Sirket();
        int ilanNumarasi=0, SirketNumarasi = 0;
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void txtArananSirketAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdayKaydet_Click(object sender, EventArgs e)
        {
            kisi = new Kisi();
            kisi.Ad = txtAd.Text;
            kisi.Soyad = txtSoyad.Text;
            kisi.TCKimlikNo = Convert.ToInt32(AdayTCKimlik.Text);
            kisi.TelNo = txtTelno.Text;
            kisi.Eposta = txtEposta.Text;
            kisi.YabanciDil = txtYabanciDil.Text;
            kisi.Uyruk = txtUyruk.Text;
            kisi.DogumYeri = txtDogumYeri.Text;
            kisi.DogumTarihi = Convert.ToDateTime(dateTimeDogumTarihi.Value);
            kisi.ReferansKisiler = txtReferansKisi.Text;
            kisi.MedeniDurum = txtMedeniDurum.Text;
            kisi.Adres = txtAdresBilgisi.Text;
            kisi.IlgiAlanlari = txtIlgiAlanlari.Text;
            egitimDurumuBilgileri.MezunOlunanOkulAdi = txtOkulAdi.Text;
            egitimDurumuBilgileri.MezunOlunanBolum = txtOkulBolumu.Text;
            egitimDurumuBilgileri.BaslangicYili = Convert.ToInt32(txtOkulBaslangicTarihi.Text);
            egitimDurumuBilgileri.BitisYili = Convert.ToInt32(txtOkulBitisTarihi.Text);
            linkedListEgitimDurumuBilgileri.InsertFirst(egitimDurumuBilgileri);            
            if (Convert.ToDouble(txtOkulNotOrtalamasi.Text) <= 100 && Convert.ToDouble(txtOkulNotOrtalamasi.Text) >= 0)
            {
                egitimDurumuBilgileri.MezunOlunanNotOrtalamasi = Convert.ToDouble(txtOkulNotOrtalamasi.Text);
            }
            else
            {
                MessageBox.Show("Not ortalaması 0 ile 100 arasında olmalıdır.");
            }
            isDeneyimi.Adi = txtCalisilanIsyeriAdi.Text;
            isDeneyimi.Adres = txtCalisilanIsyeriAdresi.Text;
            isDeneyimi.Pozisyon = txtCalisilanPozisyon.Text;
            isDeneyimi.Yil = Convert.ToInt32(txtCalisilanYil.Text);
            linkedListIsDeneyimiBilgileri.InsertFirst(isDeneyimi);
            kisi.IsTecrubeleri = linkedListIsDeneyimiBilgileri;
            kisi.EgitimDurumu = linkedListEgitimDurumuBilgileri;
            IkiliAramaAgaci.Ekle(kisi);           
            isDeneyimi = new IsDeneyimi();
            egitimDurumuBilgileri = new EgitimDurumuBilgileri();
            linkedListIsDeneyimiBilgileri = new LinkedListIsDeneyimiBilgileri();
            linkedListEgitimDurumuBilgileri = new LinkedListEgitimDurumuBilgileri();
            MessageBox.Show("Aday Kaydetme İşlemi Başarılı!");
        }

        private void btnAdayAra_Click(object sender, EventArgs e)
        {
            IkiliAramaAgacDugumu = IkiliAramaAgaci.Ara(Convert.ToInt32(txtTCKimlikNo.Text));
            if (IkiliAramaAgacDugumu == null)
            {
                MessageBox.Show("Böyle biri bulunamadı!!!");
            }          
            else
            {
                Node egitimBilgisi = new Node();               
                kisi = ((Kisi)IkiliAramaAgacDugumu.veri);
                txtGuncelleAd.Text = kisi.Ad;
                txtGuncelleSoyad.Text = kisi.Soyad;
                txtGuncelleTelNo.Text = kisi.TelNo;
                txtGuncelleEposta.Text = kisi.Eposta;
                txtGuncelleYabanciDil.Text = kisi.YabanciDil;
                txtGuncelleUyruk.Text = kisi.Uyruk;
                txtGuncelleDogumYeri.Text = kisi.DogumYeri;
                txtGuncelleMedeniDurum.Text = kisi.MedeniDurum;
                txtGuncelleAdresBilgisi.Text =kisi.Adres;
                txtGuncelleReferans.Text = kisi.ReferansKisiler;
                Node nodeEgitim = new Node();
                nodeEgitim = kisi.EgitimDurumu.Head;
                while (nodeEgitim != null)
                {
                    listEgitimBilgileri.Items.Add(((EgitimDurumuBilgileri)nodeEgitim.Data).MezunOlunanOkulAdi.ToString());
                    nodeEgitim = nodeEgitim.Next;
                }
                Node nodeDeneyim = new Node();
                nodeDeneyim = kisi.IsTecrubeleri.Head;
                while (nodeDeneyim != null)
                {
                    listIsBilgileri.Items.Add(((IsDeneyimi)nodeDeneyim.Data).Adi.ToString());
                    nodeDeneyim = nodeDeneyim.Next;
                }
            }
        }

        private void btnAdayiSil_Click(object sender, EventArgs e)
        {
            bool kontrol = IkiliAramaAgaci.Sil(kisi.TCKimlikNo);
            if (kontrol == true)
            {
                MessageBox.Show("Silme Başarılı");
            }
            else
            {
                MessageBox.Show("Aday Bulunamadı");
            }
        }
        private void btnBasvuruYap_Click(object sender, EventArgs e)
        {
            if (ListIsIlanlari.SelectedItem == null)
                MessageBox.Show("Lütfen işyeri seçiniz!!!");
            else
            {

                if (txtBasvuranTCK.Text == "")
                    MessageBox.Show("Başvuracak kişinin TC kimlik numarasını giriniz.");
                else
                {
                    IkiliAramaAgacDugumu bul = new IkiliAramaAgacDugumu();
                    bul = IkiliAramaAgaci.Ara(Convert.ToInt32(txtBasvuranTCK.Text));
                    if (bul == null)
                        MessageBox.Show("Kişi Bilgisi Bulunamadı!");
                    else
                    {
                        IlanBilgileri ilan = new IlanBilgileri();
                        ilan= hashChainTable.GetIlan(ListIsIlanlari.SelectedIndex+1);
                        Kisi kisi1 = ((Kisi)bul.veri);
                        if (((IlanBilgileri)ilan).heapIlanBasvurusu.Search(((IlanBilgileri)ilan).heapIlanBasvurusu, kisi1) == true)
                            MessageBox.Show("Önceden başvurduğunuz ilana tekrar başvuramazsınız!!!.");
                        else
                        {
                            Random random = new Random();
                            kisi1.IsUygunluk = random.Next(0, 10);
                            txtIseUygunlukPuani.Text = Convert.ToString(kisi1.IsUygunluk);
                            ((IlanBilgileri)ilan).heapIlanBasvurusu.Insert(kisi1);
                            MessageBox.Show("Başvurunuz Alınmıştır.");
                        }
                    }
                }
            }
        }

        private void btnIlanSec_Click(object sender, EventArgs e)
        {
            if (ListIsIlanlari.SelectedItem != null)
            {
                IlanBilgileri ilan = hashChainTable.GetIlan(ListIsIlanlari.SelectedIndex+1);
                txtIsIlanıBilgileri.Text = "İş İlanı Bilgisi Tanımı :" + Environment.NewLine + ((IlanBilgileri)ilan).IsTanimi + Environment.NewLine + "Aranan Eleman Özellikleri :" + ((IlanBilgileri)ilan).ArananElemanOzellikleri + Environment.NewLine + "Aranan Dil Bilgisi Özellikleri:" + ((IlanBilgileri)ilan).İstenenDilBilgisi;
                HeapIlanBasvurusu tekHeapBasvurusu = ((IlanBilgileri)ilan).heapIlanBasvurusu;
                txtIseBasvuranlar.Text = tekHeapBasvurusu.IsIlaniBasvurulariListele(tekHeapBasvurusu);
            }
            else
                MessageBox.Show("İlanı seçiniz");
        }

        private void btnIsyeriAdinaGoreAra_Click(object sender, EventArgs e)
        {
            listIsyeriAdinaGore.Items.Clear();
            Sirket sirket = new Sirket();
            for (int i = 1; i < SirketNumarasi+1; i++)
            {               
                sirket=HashChainTableSirket.GetSirket(i);
                if (sirket.IsyeriAdi == txtArananIsyeri.Text)
                {
                    for (int j = 1; j < ilanNumarasi+1; j++)
                    {
                        IlanBilgileri ilanBilgisi = sirket.ilanlar.GetIlan(j);
                        if (ilanBilgisi != null)
                        {
                            listIsyeriAdinaGore.Items.Add(ilanBilgisi.IlanNumarasi + "İş Tanımı:" + ilanBilgisi.IsTanimi+"Aranan Dil:"+ilanBilgisi.İstenenDilBilgisi+"Aranan Pozisyon"+ilanBilgisi.ArananPozisyon);
                        }
                    }    
                }
            } 
        }

        private void btnPozisyonaGoreAra_Click(object sender, EventArgs e)
        {
            listPozisyonaGore.Items.Clear();
            IlanBilgileri ilanbilgisi = new IlanBilgileri();
            for (int i = 0; i < ilanNumarasi+1; i++)
            {
                ilanbilgisi = hashChainTable.GetIlan(i);
                if (ilanbilgisi != null)
                {
                    if (ilanbilgisi.ArananPozisyon == txtPozisyonaGoreAra.Text)
                    {
                        listPozisyonaGore.Items.Add(ilanbilgisi.IlanNumarasi+"İş Tanımı:" +ilanbilgisi.IsTanimi + "Aranan Dil:" + ilanbilgisi.İstenenDilBilgisi + "Aranan Pozisyon" + ilanbilgisi.ArananPozisyon);
                    }
                }
            }
        }
        private void btnYeniIlanEkle_Click(object sender, EventArgs e)
        {
            Sirket sirket = new Sirket();
            txtIlanSirketAdi.Text = sirket.IsyeriAdi;
            sirket = HashChainTableSirket.GetSirket(Convert.ToInt32(txtSirketNumarasi.Text));
            if (sirket == null)
                MessageBox.Show("Şirket bilgisi bulunamadı!");
            else
            {
                if (txtIlanIsTanimi.Text == "")
                    MessageBox.Show("İlan verebilmek için ilan bilgilerini doldurun.");
                else
                {
                    IlanBilgileri ilan = new IlanBilgileri();
                    ilan.IlanNumarasi = ilanNumarasi++;
                    ilan.IsTanimi = txtIlanIsTanimi.Text;
                    ilan.ArananPozisyon = txtIlanArananPozisyon.Text;
                    ilan.ArananElemanOzellikleri = txtIlanElemanOzellikleri.Text;
                    ilan.İstenenDilBilgisi = txtArananDilBilgisi.Text;
                    ilan.Sirket = sirket;
                    sirket.ilanlar.AddIlan(ilanNumarasi, ilan);
                    HashChainTableSirket.AddSirket(SirketNumarasi,ilan.Sirket);
                    MessageBox.Show("İlan ekleme işleminiz başarıyla gerçekleştirildi.");                
                    lbIlanlar.Items.Add(ilanNumarasi + ". " + ilan.IsTanimi);
                    ListIsIlanlari.Items.Add(ilanNumarasi + ". " + ilan.IsTanimi);
                    hashChainTable.AddIlan(ilanNumarasi, ilan);
                    MessageBox.Show("İlan Numarasi :" + ilanNumarasi);
                }
            }
        }

        private void btnIlanSil_Click(object sender, EventArgs e)
        {
            hashChainTable.RemoveIlan(Convert.ToInt32(txtIlanNumarasi.Text));
            MessageBox.Show("İlan Silme İşlemi Başarılı!");
        }

        private void btnSirketKaydet_Click(object sender, EventArgs e)
        {           
                sirket = new Sirket();
                sirket.IsyeriAdi = txtSirketAd.Text;
                sirket.Adres = txtSirketAdres.Text;
                sirket.TelefonNumarasi = txtSirketTelefon.Text;
                sirket.Eposta = txtSirketEposta.Text;
                sirket.Faks = txtSirketFaks.Text;
                sirket.IsyeriNumarasi = SirketNumarasi++;
                HashChainTableSirket.AddSirket(SirketNumarasi, sirket);
                MessageBox.Show("Şirket Numaranız :" + SirketNumarasi);
                MessageBox.Show("Şirket ekleme başarılı.");            
        }
        private void btnSirketAra_Click(object sender, EventArgs e)
        {
            sirket = HashChainTableSirket.GetSirket(Convert.ToInt32(txtGunSirketNumarasiAra.Text));
                if (sirket == null)
                    MessageBox.Show("Aradığınız şirket bulunamadı!");
                else
                {
                    txtArananSirketAdi.Text = sirket.IsyeriAdi;
                    txtArananSirketAdresi.Text = sirket.Adres;
                    txtArananSirketEposta.Text = sirket.Eposta;
                    txtArananSirketTelefonu.Text = sirket.TelefonNumarasi;
                    txtArananSirketFaksi.Text = sirket.Faks;
                }            
        }
        private void btnSirketBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            sirket = HashChainTableSirket.GetSirket(Convert.ToInt32(txtGunSirketNumarasiAra.Text));
            if (sirket == null)
                MessageBox.Show("Aradığınız şirket bulunamadı!");
            else
            {
                sirket.IsyeriAdi = txtArananSirketAdi.Text;
                sirket.Adres= txtArananSirketAdresi.Text;
                sirket.Eposta= txtArananSirketEposta.Text;
                sirket.TelefonNumarasi= txtArananSirketTelefonu.Text;
                sirket.Faks = txtArananSirketFaksi.Text;
                MessageBox.Show("Şirket Güncelleme Başarılı!");
            }
        }

        private void btnIlanGuncelle_Click(object sender, EventArgs e)
        {
            IlanBilgileri ilan = new IlanBilgileri();
            ilan = hashChainTable.GetIlan(Convert.ToInt32(txtIlanNumarasi.Text));
            if (ilan == null)
                MessageBox.Show("Aradığınız ilan bulunamadı!");
            else
            {
                ilan.İstenenDilBilgisi = txtArananDilBilgisi.Text;
                ilan.ArananPozisyon = txtIlanArananPozisyon.Text;
                ilan.ArananElemanOzellikleri = txtIlanElemanOzellikleri.Text;
                ilan.Sirket.IsyeriAdi = txtIlanSirketAdi.Text;
                ilan.IsTanimi = txtIlanIsTanimi.Text;
                MessageBox.Show("İlan Güncelleme Başarılı!");
            }
        }

        private void btnIlaniBul_Click(object sender, EventArgs e)
        {
            IlanBilgileri ilan = new IlanBilgileri();
            ilan = hashChainTable.GetIlan(Convert.ToInt32(txtIlanNumarasi.Text));
            if (ilan == null)
                MessageBox.Show("Aradığınız ilan bulunamadı!");
            else
            {
                txtArananDilBilgisi.Text = ilan.İstenenDilBilgisi;
                txtIlanElemanOzellikleri.Text = ilan.ArananElemanOzellikleri;
                txtIlanArananPozisyon.Text = ilan.ArananPozisyon;
                txtIlanIsTanimi.Text = ilan.IsTanimi;
                txtIlanSirketAdi.Text = ilan.Sirket.IsyeriAdi;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            IkiliAramaAgacDugumu = IkiliAramaAgaci.Ara(Convert.ToInt32(AdayTCKimlik.Text));
            if (IkiliAramaAgacDugumu == null)
            {
                MessageBox.Show("Böyle biri bulunamadı!!!");
            }
            else
            {                
                kisi = ((Kisi)IkiliAramaAgacDugumu.veri);
                kisi.Ad = txtGuncelleAd.Text;
                kisi.Soyad=txtGuncelleSoyad.Text;
                kisi.TelNo = txtGuncelleTelNo.Text;
                kisi.Eposta = txtGuncelleEposta.Text;
                kisi.Uyruk=txtGuncelleUyruk.Text;
                kisi.DogumYeri = txtGuncelleDogumYeri.Text;
                kisi.MedeniDurum = txtGuncelleMedeniDurum.Text;
                kisi.Adres=txtGuncelleAdresBilgisi.Text ;
                kisi.ReferansKisiler= txtGuncelleReferans.Text;
                kisi = new Kisi();
                MessageBox.Show("Başarıyla Aday Güncellendi.");
            }
        }

        private void btnEgitimBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGuncelleOkulAdi.Text=="")
                MessageBox.Show("Güncellenecek Eğitim Bilgisini İçin Okul Adınızı Yazınız.");
            else
            {        
                Node egitimBilgisi = new Node();
                egitimBilgisi = ((Kisi)IkiliAramaAgacDugumu.veri).EgitimDurumu.Head;

                while (true)
                {
                    if (((EgitimDurumuBilgileri)egitimBilgisi.Data).MezunOlunanOkulAdi == txtGuncelleOkulAdi.Text)
                    {                       
                        ((EgitimDurumuBilgileri)egitimBilgisi.Data).MezunOlunanOkulAdi = txtGuncelleOkulAdi.Text;
                        ((EgitimDurumuBilgileri)egitimBilgisi.Data).MezunOlunanBolum = txtGuncelleOkulBolumu.Text;
                        ((EgitimDurumuBilgileri)egitimBilgisi.Data).BaslangicYili = Convert.ToInt32(txtGuncelleOkulBaslangicTarihi.Text);
                        ((EgitimDurumuBilgileri)egitimBilgisi.Data).BitisYili = Convert.ToInt32(txtGuncelleOkulBitisTarihi.Text);
                        ((EgitimDurumuBilgileri)egitimBilgisi.Data).MezunOlunanNotOrtalamasi = Convert.ToDouble(txtGuncelleNotOrtalamasi.Text);
                        MessageBox.Show("Eğitim Bilgileriniz Güncellendi");
                        break;
                    }
                    else
                        egitimBilgisi = egitimBilgisi.Next;
                }
            }
        }

        private void btnIsBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGuncelleIsyeriAdi.Text == "")
                MessageBox.Show("Güncellenecek İş Deneyimi Bilgisini İş Yeri Adına Yazınız.");
            else
            {
                Node istecrubesi = new Node();
                istecrubesi = ((Kisi)IkiliAramaAgacDugumu.veri).IsTecrubeleri.Head;
                while (true)
                {
                    if (((IsDeneyimi)istecrubesi.Data).Adi == txtGuncelleIsyeriAdi.Text)
                    {
                        ((IsDeneyimi)istecrubesi.Data).Adi = txtGuncelleIsyeriAdi.Text;
                        ((IsDeneyimi)istecrubesi.Data).Pozisyon = txtGuncelleCalisilanPozisyonu.Text;
                        ((IsDeneyimi)istecrubesi.Data).Yil = Convert.ToInt32(txtGuncelleYil.Text);
                        ((IsDeneyimi)istecrubesi.Data).Adres = txtGuncelleAdresBilgisi.Text;                      
                        MessageBox.Show("İş Deneyimi Bilgileriniz Güncellendi");
                        break;
                    }
                    else
                        istecrubesi = istecrubesi.Next;
                }
            }

        }

        private void btnPreOrder_Click(object sender, EventArgs e)
        {
            IkiliAramaAgaci.PreOrder();
            txtPreOrderListe.Text = IkiliAramaAgaci.DugumleriYazdir();
        }

        private void btnPostOrder_Click(object sender, EventArgs e)
        {
            IkiliAramaAgaci.PostOrder();
            txtPostOrderListe.Text = IkiliAramaAgaci.DugumleriYazdir();
        }

        private void btnInOrder_Click(object sender, EventArgs e)
        {
            IkiliAramaAgaci.InOrder();
            txtInOrderListe.Text = IkiliAramaAgaci.DugumleriYazdir();
        }

        private void btnEnAzIkıYılTecrube_Click(object sender, EventArgs e)
        {
            IkiliAramaAgaci.YılKontrolAra();
            txtElemanListele.Text = IkiliAramaAgaci.DugumleriYazdir();
        }

        private void btnAgacDerinlikBul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IkiliAramaAgaci.DerinlikBul().ToString());
            
        }

        private void btnAgacElemanSayisiBul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IkiliAramaAgaci.DugumSayisi().ToString());            
        }

        private void btnIseal_Click(object sender, EventArgs e)
        {
            if (lbIlanlar.SelectedItem == null)
                MessageBox.Show("Bir ilan seçiniz");
            else
            {
                IlanBilgileri ilan = new IlanBilgileri();
                ilanNumarasi=lbIlanlar.SelectedIndex+1;
                ilan=hashChainTable.GetIlan(ilanNumarasi);              
                HeapDugumu uygunAday = ((IlanBilgileri)ilan).heapIlanBasvurusu.UygunAdayBul();
                if (uygunAday == null)
                    MessageBox.Show("İşe Uygun Aday Yok");
                else
                    txtIseAlinanEleman.Text = ((Kisi)uygunAday.Deger).Ad;
            }
        }

        private void btnIsIlaniniİncele_Click(object sender, EventArgs e)
        {
            if (lbIlanlar.SelectedItem != null)
            {
                IlanBilgileri ilan = new IlanBilgileri();
                ilanNumarasi = lbIlanlar.SelectedIndex+1;
                ilan = hashChainTable.GetIlan(ilanNumarasi);
                HeapIlanBasvurusu tekHeapBasvurusu = ((IlanBilgileri)ilan).heapIlanBasvurusu;
                txtIseBasvuranlar.Text = "İş tanımı :" + Environment.NewLine + ((IlanBilgileri)ilan).IsTanimi + Environment.NewLine + "Aranan Eleman özellikleri :" + ((IlanBilgileri)ilan).ArananElemanOzellikleri + Environment.NewLine + "Başvuran Kişi Sayısı :" + tekHeapBasvurusu.IsIlaniBasvurulariListele(tekHeapBasvurusu);
            }
            else
                MessageBox.Show("Lütfen önce başvurmak istediğiniz ilanı seçin!");
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
           
        }

        private void btnYabanciDilBilenler_Click(object sender, EventArgs e)
        {
            IkiliAramaAgaci.DilKontrolAra();
            txtElemanListele.Text = IkiliAramaAgaci.DugumleriYazdir();       
        }

        private void btnSirketSil_Click(object sender, EventArgs e)
        {
           HashChainTableSirket.RemoveSirket(Convert.ToInt32(txtGunSirketNumarasiAra.Text));
           MessageBox.Show("Şirket silme işlemi başarılı");
         
        }
    }
}
