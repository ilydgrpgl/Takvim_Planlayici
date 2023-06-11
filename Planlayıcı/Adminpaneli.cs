using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planlayıcı
{
    public partial class Adminpaneli : Form
    {
        private readonly DbTakvimProjeEntities _db = new DbTakvimProjeEntities();
        public Adminpaneli()
        {
            InitializeComponent();
        }


        private void Adminpaneli_Load(object sender, EventArgs e)
        {
            var degerler = _db.Tbl_Users
       .Select(x => new
       {
           x.Name,
           x.Surname,
           x.Password,
           x.TC,
           x.Telephone,
           x.Email,
           x.Adrress,
           x.Usertype
       })
       .ToList();

            dataGridView1.DataSource = degerler;

            var degerler2 = _db.Tbl_program
                .Select(x => new
                {
                    x.Day,
                    x.Starttime,
                    x.Eventtype,
                    x.Explanation,
                    x.Userid
                })
                .ToList();

            dataGridView2.DataSource = degerler2;
        }
    }
}

