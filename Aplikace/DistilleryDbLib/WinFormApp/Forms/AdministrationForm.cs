using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.Forms.DialogForms;

namespace WinFormApp.Forms
{
    public partial class AdministrationForm : Form
    {
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            RefreshNames();
        }

        private void RefreshNames()
        {
            //actualPeriodTBox.Text = PeriodTable.ActivePeriodName();
            //actualSeasonTBox.Text = SeasonTable.ActiveSeasonName();
        }

        private void CloseMonthPeriod(object sender, EventArgs e)
        {
            //if (PeriodTable.Select().Where(p => p.finished == false).Count() < 1)
            //{
            //    MessageBox.Show("Žádne období k ukončení", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //Collection<MonthReport> report;
            //try
            //{
            //    report = PeriodTable.ClosePeriod();
            //}
            //catch (DatabaseException)
            //{
            //    MessageBox.Show("Ukončení měsíčního období neproběhlo správně", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //using (StreamWriter writer = new StreamWriter("report.txt"))
            //{
            //    foreach (MonthReport r in report)
            //    {
            //        string payed;
            //        if (r.payed)
            //        {
            //            payed = "ano";
            //        }
            //        else
            //        {
            //            payed = "ne";
            //        }
            //        string row = string.Format("{0} Zakaznik: {1}; Adresou {2}; Material: {3}; Mnozstvi aboslutniho alkoholu: {4}; Cena: {5}; Zaplaceno: {6}", r.date.ToShortDateString(), r.surename, r.adress, r.materialName, r.absVolume, r.price, payed);
            //        writer.WriteLine(row);
            //    }
            //}
            //RefreshNames();
        }

        private void NewMonthPeriod(object sender, EventArgs e)
        {
            //if (PeriodTable.Select().Where(p => p.finished == false).Count() > 0)
            //{
            //    MessageBox.Show("Před vytvořením nového období je třeba ukončit poslední období.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //NewPeriodForm npf = new NewPeriodForm();
            //if (npf.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show("Nové období bylo vytvořeno.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    RefreshNames();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (PeriodTable.Select().Where(p => p.finished == false).Count() > 0)
            //{
            //    if(MessageBox.Show("Aktuální sezóna obsahuje neukončené období, chcete jej ukončit?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        CloseMonthPeriod(null, null);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //try
            //{
            //    SeasonTable.StartNewSeason();
            //    RefreshNames();
            //}
            //catch (DatabaseException)
            //{
            //}
        }
    }
}
