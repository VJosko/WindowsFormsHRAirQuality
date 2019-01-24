using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.Entities;

namespace PresentationLayer
{
    public partial class FormDodaj : Form
    {
        private PollutantRepository _pollutantRepository = new PollutantRepository();
        private StationRepository _stationRepository = new StationRepository();
        private ReadingsRepository _readingsRepository = new ReadingsRepository();
        private BindingSource _dataGridBindingSource = new BindingSource();
        public FormDodaj()
        {
            InitializeComponent();
        }

        private void FormDodaj_Load(object sender, EventArgs e)
        {
            comboBoxDodajStanicu.DataSource = _stationRepository.GetStationNames();
            comboBoxDodajPolutanta.DataSource = _pollutantRepository.GetPollutantNames();
        }

        private void btnDodajNovi_Click(object sender, EventArgs e)
        {
            var stations = new List<Station>();
            stations = _stationRepository.GetStations();
            int stationId = 0;
            for (int i = 0; i < stations.Count(); i++)
            {
                if (comboBoxDodajStanicu.Text == stations[i].name)
                {
                    stationId = stations[i].id;
                }
            }
            var pollutants = new List<Pollutant>();
            pollutants = _pollutantRepository.GetPollutant();
            int pollutantId = 0;
            for (int i = 0; i < pollutants.Count(); i++)
            {
                if (comboBoxDodajPolutanta.Text == pollutants[i].name)
                {
                    pollutantId = pollutants[i].id;
                }
            }
            _readingsRepository.pushToDataBaseMjestoPolutant(stationId, pollutantId);
            this.Close();
        }

        private void comboBoxDodajStanicu_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stations = new List<Station>();
            stations = _stationRepository.GetStations();
            int stationId = 0;
            for (int i = 0; i < stations.Count(); i++)
            {
                if (comboBoxDodajStanicu.Text == stations[i].name)
                {
                    stationId = stations[i].id;
                }
            }
            var pollutants = new List<Pollutant>();
            pollutants = _pollutantRepository.GetPollutant();
            int pollutantId = 0;
            for (int i = 0; i < pollutants.Count(); i++)
            {
                if (comboBoxDodajPolutanta.Text == pollutants[i].name)
                {
                    pollutantId = pollutants[i].id;
                }
            }
            var _readings = _readingsRepository.GetReadings(stationId, pollutantId, "01.01.2019", "05.05.2019");
            bool bMjerenja = false;
            foreach (var mjerenje in _readings)
            {
                if (mjerenje.value != null)
                {
                    bMjerenja = true;
                }
            }
            if (bMjerenja == true)
            {
                textBoxPostoji.Text = "Mjeranja postoje";
            }
            else
            {
                textBoxPostoji.Text = "Nema mjeranja";
            }
        }

        private void comboBoxDodajPolutanta_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stations = new List<Station>();
            stations = _stationRepository.GetStations();
            int stationId = 0;
            for (int i = 0; i < stations.Count(); i++)
            {
                if (comboBoxDodajStanicu.Text == stations[i].name)
                {
                    stationId = stations[i].id;
                }
            }
            var pollutants = new List<Pollutant>();
            pollutants = _pollutantRepository.GetPollutant();
            int pollutantId = 0;
            for (int i = 0; i < pollutants.Count(); i++)
            {
                if (comboBoxDodajPolutanta.Text == pollutants[i].name)
                {
                    pollutantId = pollutants[i].id;
                }
            }
            var _readings = _readingsRepository.GetReadings(stationId, pollutantId, "01.01.2019", "05.05.2019");
            bool bMjerenja = false;
            foreach (var mjerenje in _readings)
            {
                if (mjerenje.value != null)
                {
                    bMjerenja = true;
                }
            }
            if (bMjerenja == true)
            {
                textBoxPostoji.Text = "Mjeranja postoje";
            }
            else
            {
                textBoxPostoji.Text = "Nema mjeranja";
            }
        }
    }
}
