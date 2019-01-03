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
            { Value = o.value, Time = o.time }).ToList();         
        }
    }
}
