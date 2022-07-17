using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Newtonsoft.Json;

namespace RickAndMortyXamarinForms.Mobile
{
    public class MainPageViewModel : BaseViewModel
    {
        private const string Url = "https://rickandmortyapi.com/api/character";

        private readonly HttpClient _httpClient;

        private ObservableCollection<Result> _list;

        public ObservableCollection<Result> List
        {
            get => _list ?? new ObservableCollection<Result>();
            set => SetProperty(ref _list, value);
        }

        public MainPageViewModel()
        {
            _httpClient = new HttpClient();
            IsBusy = true;
            IsNotBusy = false;
        }

        public async Task LoadCharacters()
        {
            try
            {
                var response = await _httpClient.GetAsync(Url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<Model>(json)?.Results;
                if (list != null)
                {
                    List = new ObservableCollection<Result>(list);
                }
            }
            catch (Exception)
            {
                List = new ObservableCollection<Result>();
            }
            finally
            {
                IsBusy = false;
                IsNotBusy = true;
            }
        }
    }
}
