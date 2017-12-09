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
using DataLayerNetCore.Entities;
using DistilleryLogic;

namespace WinFormApp.Forms
{
    public partial class AdministrationForm : Form
    {
        private Period _activePeriod;
        private Season _activeSeason;

        public AdministrationForm()
        {
            InitializeComponent();
            _activeSeason = AdministrationLogic.GetActiveSeason();
            _activePeriod = AdministrationLogic.GetActivePeriod();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            //period exist
            if (_activePeriod != null)
            {
                actualPeriodTBox.Text = _activePeriod.Name;
                btnEndPeriod.Enabled = true;
                btnStartPeriod.Enabled = false;
            }
            else
            {
                actualPeriodTBox.Text = string.Empty;
                btnEndPeriod.Enabled = false;
                btnStartPeriod.Enabled = _activeSeason != null;
            }

            if (_activeSeason != null)
                actualSeasonTBox.Text = _activeSeason.Name;
            else
                actualSeasonTBox.Text = string.Empty;
            
        }

        private void CloseMonthPeriod(object sender, EventArgs e)
        {
            if (_activePeriod == null)
            {
                MessageBox.Show("Žádne období k ukončení", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ICollection<MonthReport> report = AdministrationLogic.GetPeriodReport(_activePeriod);
            AdministrationLogic.EndPeriod(_activePeriod);
            _activePeriod = null;

            using (StreamWriter writer = new StreamWriter("report.txt"))
            {
                foreach (MonthReport r in report)
                {
                    string payed;
                    if (r.Payed)
                    {
                        payed = "ano";
                    }
                    else
                    {
                        payed = "ne";
                    }
                    string row = string.Format("{0} Zakaznik: {1}; Adresou {2}; Material: {3}; Mnozstvi aboslutniho alkoholu: {4}; Cena: {5}; Zaplaceno: {6}", r.Date.ToShortDateString(), r.Surename, r.Adress, r.MaterialName, r.AbsVolume, r.Price, payed);
                    writer.WriteLine(row);
                }
            }

            Reload();
        }

        private void NewMonthPeriod(object sender, EventArgs e)
        {
            if (_activePeriod != null)
            {
                MessageBox.Show("Před vytvořením nového období je třeba ukončit poslední období.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewPeriodForm npf = new NewPeriodForm();
            if (npf.ShowDialog() == DialogResult.OK)
            {
                _activePeriod = AdministrationLogic.StartPeriod(npf.NewPeriod);
                MessageBox.Show("Nové období bylo vytvořeno.", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }
        }

        private void NewSeason(object sender, EventArgs e)
        {
            if (_activePeriod != null)
            {
                if (MessageBox.Show("Aktuální sezóna obsahuje neukončené období, chcete jej ukončit?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CloseMonthPeriod(null, null);
                }
                else
                {
                    return;
                }
            }
            _activeSeason = AdministrationLogic.StartSeason(_activeSeason);

            Reload();
        }
    }
}
