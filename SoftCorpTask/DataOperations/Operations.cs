using Newtonsoft.Json;
using SoftCorpTask.Data;
using SoftCorpTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SoftCorpTask
{
    public static class Operations
    {
        public static async Task<List<Valute>> GetValutes(WebClient client)
        {
            var json = await client.DownloadStringTaskAsync("https://www.cbr-xml-daily.ru/daily_json.js");
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json, new ValutesConverter());
            return rootObject.Valute;
        }
        public static double CalculateCourse(double _convertValue,List<Valute> _valutes, string _valuteCharCodeFrom, string _valuteCharCodeTo)
        {
            double _convertFromValue = _valutes.FirstOrDefault(x => x.CharCode == _valuteCharCodeFrom).Value;
            Valute _convertTo = _valutes.FirstOrDefault(x => x.CharCode == _valuteCharCodeTo);
            if (_convertValue != 0)
            {
                return _convertFromValue * _convertTo.Nominal / _convertTo.Value * _convertValue;
            }
            else return 0;
        }
        public static async Task<List<string>> SearchValuteCourse(WebClient client,string _searchText)
        {
            int res;
            double valToUsd;
            double valToByn;
            Valute val;
            List<Valute> valutes = await GetValutes(client);
            List<string> result = new List<string>();
            bool isInt = int.TryParse(_searchText, out res);
            if (!isInt)
            {
                val = valutes.FirstOrDefault(x => x.CharCode.Contains(_searchText));
            }
            else
            {
                val = valutes.FirstOrDefault(x => x.NumCode == Convert.ToInt32(_searchText));
            }
            if (val != null)
            {
                Valute usd = valutes.FirstOrDefault(x => x.CharCode == "USD");
                Valute byn = valutes.FirstOrDefault(x => x.CharCode == "BYN");
                valToUsd = val.Value * usd.Nominal / usd.Value;
                valToByn = val.Value * byn.Nominal / byn.Value;
                result.Add($"{val.Nominal} {val.CharCode} = {valToUsd} USD");
                result.Add($"{val.Nominal} {val.CharCode} = {valToByn} BYN");
            }
            else
            {
                result.Add($"Нет совпадений");
            }
            return result;
        }
    }
}
