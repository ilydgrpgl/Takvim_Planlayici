using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Media;





namespace Planlayıcı
{
    
  
    public partial class planekranı : Form
    {
        private string kullaniciAdi;
       
        public planekranı(string ad)
        {
            InitializeComponent();

            Controls.Add(rchtxtNot);
            kullaniciAdi = ad;
        }
        DbTakvimProjeEntities db = new DbTakvimProjeEntities();


        public void SetSelectedDate(DateTime date)
        {
            dateTimePickergün.Value = date;
        }
        public void SetExplanation(string explanation)
        {

            rchtxtNot.Text = explanation;
        }

        public void SetEventtype(string eventtype)
        {

            cmbplan.SelectedItem = eventtype;
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Secimekranı scm = new Secimekranı(kullaniciAdi);
            scm.Show();
            this.Hide();
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Secimekranı scm = new Secimekranı(kullaniciAdi);
            scm.Show();
            this.Hide();
        }



        private void btnplanla_Click_1(object sender, EventArgs e)
        {
            Tbl_program tbl = new Tbl_program();
            tbl.Day = DateTime.ParseExact(dateTimePickergün.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            tbl.Starttime = DateTime.ParseExact(dateTimePickersaat.Value.ToString("HH:mm:ss"), "HH:mm:ss", CultureInfo.InvariantCulture);
            tbl.Explanation = rchtxtNot.Text;
            tbl.Eventtype = cmbplan.Text;
            tbl.Userid = Int32.Parse(adi.Text);
            db.Tbl_program.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("YENİ PLAN KAYDI OLUŞTURULDU");
            // user ıd kaydet 
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickergün.Value.Date;
            string eventType = cmbplan.Text;
            string explanation = rchtxtNot.Text;

            Tbl_program existingRecord = db.Tbl_program.FirstOrDefault(tbl => tbl.Day == selectedDate);

            if (existingRecord != null)
            {
                existingRecord.Explanation = explanation;
                existingRecord.Eventtype = eventType;

                db.SaveChanges();
                MessageBox.Show("KAYIT GÜNCELLENDİ");
            }
            else
            {
                MessageBox.Show("Güncellenecek bir kayıt bulunamadı.");
            }

        }

        private void planekranı_Load(object sender, EventArgs e)
        {
            adi.Text = kullaniciAdi;
            
          
        }
    }
}

