using Caliburn.Micro;
using SoftCorpTask.Data;
using SoftCorpTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoftCorpTask.ViewModels
{
    public class ValuteViewModel : PropertyChangedBase
    {
        private List<Valute> valutes;
        private WebClient client;
        private string _searchText; 
        private double _convertValue;
        private double _convertResult;
        private string _selectedValueCB1;
        private string _selectedValueCB2;
        private ObservableCollection<ValuteCourse> _valuteCourses;
        private ObservableCollection<ValuteCodes> _valuteCodes;
        private ObservableCollection<string> _searchResults;
        private ObservableCollection<string> _charCodes;

        public  ValuteViewModel()
        {
            client = new WebClient();
            valutes = new List<Valute>();
            LoadData();
        }
        private async void LoadData()
        {
            valutes = await Operations.GetValutes(client);
            ComboBoxFrom = new ObservableCollection<string>();
            foreach (var val in valutes)
            {
                ComboBoxFrom.Add(val.CharCode);
            }
        }
        public ObservableCollection<ValuteCourse> ValuteCourses
        {
            get=>_valuteCourses;
            set { _valuteCourses = value; NotifyOfPropertyChange(() => ValuteCourses); } 
        }
        public ObservableCollection<ValuteCodes> ValuteCodes { 
            get=>_valuteCodes; 
            set { _valuteCodes = value; NotifyOfPropertyChange(() => ValuteCodes); }
        }
        public ObservableCollection<string> SearchResults {
            get=>_searchResults; 
            set { _searchResults = value; NotifyOfPropertyChange(() => SearchResults); }
        }
        public ObservableCollection<string> ComboBoxFrom { 
            get=>_charCodes;
            set { _charCodes = value; NotifyOfPropertyChange(() =>ComboBoxFrom);NotifyOfPropertyChange(() => ComboBoxTo); }
        }
        public ObservableCollection<string> ComboBoxTo
        {
            get => _charCodes;
        }
        public string SearchText { get => _searchText; set { _searchText = value; } }
        public string SelectedValueCB1
        {
            get => _selectedValueCB1;
            set { _selectedValueCB1 = value; NotifyOfPropertyChange(() => SelectedValueCB1); }
        }
        public string SelectedValueCB2
        {
            get => _selectedValueCB2;
            set { _selectedValueCB2 = value; NotifyOfPropertyChange(() => SelectedValueCB2); }
        }
        public string ConvertValue
        {
            get => _convertValue.ToString();
            set 
            { 
                _convertValue = GetValue(value);
                _convertResult= Operations.CalculateCourse(_convertValue, valutes, _selectedValueCB1, _selectedValueCB2);
                NotifyOfPropertyChange(() => ConvertValue); NotifyOfPropertyChange(() => ConvertResult);
            }
        }
        public string ConvertResult
        {
            get => _convertResult.ToString();
            set => Operations.CalculateCourse(_convertValue,valutes,_selectedValueCB1,_selectedValueCB2);
        }
       
        public async void UpdateCourses()
        {
            valutes = await Operations.GetValutes(client);
            ValuteCourses = new ObservableCollection<ValuteCourse>();
            foreach (var val in valutes)
            {
                ValuteCourses.Add(new ValuteCourse(val.NumCode, val.Value));
            }
        }
        public async void UploadCodes()
        {
            valutes = await Operations.GetValutes(client);
            ValuteCodes = new ObservableCollection<ValuteCodes>();
            foreach (var val in valutes)
            {
               ValuteCodes.Add(new ValuteCodes(val.NumCode,val.CharCode));
            }    
        }
        public async void Search()
        {
            SearchResults = new ObservableCollection<string>();
            List<string> result=new List<string>();
            if (_searchText != null) { result = await Operations.SearchValuteCourse(client, _searchText); }
            else { SearchResults.Add("Нет совпадений"); }
            foreach(var res in result)
            {
                SearchResults.Add(res);
            }
        }
        private double GetValue(string value)
        {
            double res;
            bool isNumber = double.TryParse(value, out res);
            if (isNumber) return res;
            else return 0;

        }

    }
}
