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
    public partial class Form1 : Form
    {
        private PollutantRepository _pollutantRepository = new PollutantRepository();
        private StationRepository _stationRepository = new StationRepository();
        private ReadingsRepository _readingsRepository = new ReadingsRepository();
        private BindingSource _dataGridBindingSource = new BindingSource();
        //private BindingSource _stationBindingSource = new BindingSource();
        //private BindingSource _pollutantBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            //_stationBindingSource.DataSource = _stationRepository.GetStationNames();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var s1 = _stationRepository.GetStationsBase();
            comboBoxStations.DataSource = s1;
            comboBoxPollutant.DataSource = _pollutantRepository.GetPollutantBase(s1[0]);
            dateTimePickerFrom.CustomFormat = "dd.MM.yyyy";
            dateTimePickerTo.CustomFormat = "dd.MM.yyyy";
        }

        private void search_Click(object sender, EventArgs e)
        {
            var stations = new List<Station>();
            stations = _stationRepository.GetStations();
            int stationId = 0;
            for(int i = 0; i < stations.Count(); i++)
            {
                if (comboBoxStations.Text == stations[i].name)
                {
                    stationId = stations[i].id;
                }
            }
            var pollutants = new List<Pollutant>();
            pollutants = _pollutantRepository.GetPollutant();
            int pollutantId = 0;
            for(int i = 0; i < pollutants.Count(); i++)
            {
                if(comboBoxPollutant.Text == pollutants[i].name)
                {
                    pollutantId = pollutants[i].id;
                }
            }
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime dateTimeFrom = dateTimePickerFrom.Value;
            DateTime dateTimeTo = dateTimePickerTo.Value;
            List<Readings> lReadings = _readingsRepository.ReadReadings(dateTimeFrom, dateTimeTo);
            var _readings1 = new List<Readings>();
            foreach (var station in stations)
            {
                if (station.name == comboBoxStations.Text)
                {
                    foreach (var pollutant in pollutants)
                    {
                        if (pollutant.name == comboBoxPollutant.Text)
                        {
                            foreach (var reading in lReadings)
                            {
                                if (reading.stationId == station.id && reading.pollutantId == pollutant.id)
                                {
                                    _readings1.Add(reading);
                                }
                            }
                        }
                    }
                }
            }
            dataGridViewReadings.DataSource = _readings1.Select(o => new
            { Vrijednost = o.value, Vrijeme = (dateTime.AddMilliseconds(o.time)) }).ToList();

            //graf
            chart1.Series["Vrijednost"].Points.Clear();
            foreach(var x in _readings1)
            {
                chart1.Series["Vrijednost"].Points.AddXY(x.time, x.value);
            }
            labelFrom.Text = dateTimeFrom.ToShortDateString();
            labelTO.Text = dateTimeTo.ToShortDateString();
        }

        private void comboBoxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPollutant.DataSource = _pollutantRepository.GetPollutantBase(comboBoxStations.Text);
            /*var lPollutants = _pollutantRepository.GetPollutant();
            var lStations = _stationRepository.GetStations();
            var lMjerenoId = new List<int>();
            string sStation = comboBoxStations.Text;
            int nStation = 0;
            for(int i = 0; i < lStations.Count(); i++)
            {
                if(lStations[i].name == sStation)
                {
                    nStation = lStations[i].id;
                }
            }
            for (int i = 0; i < lPollutants.Count(); i++)
            {
                var lReadings = _readingsRepository.GetReadings(nStation,lPollutants[i].id, "01.01.2019", "01.01.2019");
                if(lReadings.Count() > 0)
                {
                    lMjerenoId.Add(lReadings[i].pollutantId);
                }
            }
            var lMjereno = new List<string>();
            for(int i = 0; i < lMjerenoId.Count(); i++)
            {
                for(int j = 0; j < lPollutants.Count(); j++)
                {
                    if(lMjerenoId[i] == lPollutants[j].id)
                    {
                        lMjereno.Add(lPollutants[j].name);
                    }
                }
            }
            comboBoxPollutant.DataSource = lMjereno;*/
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FormDodaj m = new FormDodaj();
            m.Show();
        }
    }
}
