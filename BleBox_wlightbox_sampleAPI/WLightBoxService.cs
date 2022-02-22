using System.Net.Http.Json;


namespace BleBox_wlightbox_sampleAPI
{

    public class WLightBoxService
    {
        private readonly string _endpoint;
        private readonly HttpClient _client;

        public WLightBoxService(string endpoint)
        {
            _endpoint = endpoint;
            _client = new HttpClient();
        }
        public Task SetColor(string desiredColor, double colorFade = 1000)
        {
            var content = new
            {
                rgbw = new
                {
                    desiredColor,
                    durationsMs = new
                    {
                        colorFade
                    }
                }
            };

            return _client.PostAsJsonAsync(_endpoint + "/api/rgbw/set", content);
        }

        public Task SetEffect(int effectID, int effectFade = 1000, int effectStep = 2000)
        {
            var content = new
            {
                rgbw = new
                {
                    effectID,
                    durationsMs = new
                    {
                        effectFade,
                        effectStep
                    }
                }
            };

            return _client.PostAsJsonAsync(_endpoint + "/api/rgbw/set", content);
        }

        public async Task<string> GetColor()
        {
            var result = await _client.GetAsync(_endpoint + "/api/rgbw/state");
            var currentState = result.Content.ReadFromJsonAsync<RgbwState>().Result;
            return currentState.rgbw.currentColor;
        }

        public async Task<int> GetEffect()
        {
            var result = await _client.GetAsync(_endpoint + "/api/rgbw/state");
            var currentState = result.Content.ReadFromJsonAsync<RgbwState>().Result;
            return currentState.rgbw.effectID;
        }
    }
}