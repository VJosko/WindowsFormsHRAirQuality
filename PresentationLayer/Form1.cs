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
            comboBoxStations.DataSource = _stationRepository.GetStationNames();
            comboBoxPollutant.DataSource = _pollutantRepository.GetPollutantNames();
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
            List<Readings> lReadings = _readingsRepository.GetReadings(stationId, pollutantId, dateTimePickerFrom.Text, dateTimePickerTo.Text);
            dataGridViewReadings.DataSource = lReadings.Select(o => new
            { Vrijednost = o.value, Vrijeme = o.time }).ToList();         
        }

        private void comboBoxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
