using Microsoft.AspNetCore.Mvc;

namespace Barbearia
{
    public class GoogleCalendarService
    {
        private readonly HttpClient _client;

        public GoogleCalendarService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetCalendarEvents(string accessToken)
        {
            // Exemplo de endpoint para obter eventos de calendário (substitua pelo endpoint de API real)
            string endpoint = "https://www.googleapis.com/calendar/v3/calendars/primary/events";

            // Adicionar cabeçalho de autorização
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Enviar solicitação GET
            HttpResponseMessage response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                // Ler o conteúdo da resposta
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Falha ao recuperar eventos da agenda: {response.StatusCode}");
            }
        }

        public async Task<IActionResult> OnGetCalendarEvents(string accessToken)
        {
            // Substitua pelo seu código para obter eventos do calendário
            string endpoint = "https://www.googleapis.com/calendar/v3/calendars/primary/events";

            // Configurar o cabeçalho de autorização
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Enviar solicitação GET
            HttpResponseMessage response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                // Ler o conteúdo da resposta
                string eventsJson = await response.Content.ReadAsStringAsync();
                return new JsonResult(eventsJson); // Retorna os eventos como JSON
            }
            else
            {

            }
        }
    }
}
