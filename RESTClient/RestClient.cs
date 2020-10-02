using Configuracion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TelcomVentures.AR.Logueo;

namespace TelcomVentures.Ar.EnvioComprobantes.Download.RESTClient
{
   
		public class RestClient
		{
			private readonly string baseUrl = string.Empty;

			/// <summary>
			/// Initializes a new instance of the <see cref="RestClient"/> class.
			/// RestSharpClient: constructor.
			/// </summary>
			public RestClient(string key)
			{
				ConfigManager config = new ConfigManager();
				this.baseUrl = config.GetValue(key);
			}

			/// <summary>
			/// GET.
			/// </summary>
			/// <typeparam name="T">type.</typeparam>
			/// <param name="route">url.</param>
			/// <param name="token">JWT token.</param>
			/// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
			public async Task<T> ConsumeAsync<T>(string route, string token)
			{
				try
				{
					string url = $"{this.baseUrl}{route}";
					//LoggerSingleton.Instance.Information($"GET: {url}");

					HttpClient client = new HttpClient();
					if (!string.IsNullOrWhiteSpace(token))
					{
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
					}

					var response = client.GetAsync(url);
					response.Wait();

					if (response.Result.IsSuccessStatusCode)
					{
						string data = await response.Result.Content.ReadAsStringAsync();
						return JsonConvert.DeserializeObject<T>(data);
					}



					return default(T);
				}
				catch (Exception ex)
				{
				string mensaje = "RestSharpClient:ConsumeAsync " + route + " " + ex.Message;
				Logger.Logueo(mensaje, Level.ErrorLog);
				throw ex;
				}
			}

		public async Task<T> ConsumeAsync<T>(string route, HttpMethod httpMethod, string pData, string token)
		{
			try
			{
				string url = $"{this.baseUrl}{route}";
				using (var client3 = new HttpClient())
				{
					var request = new HttpRequestMessage
					{
						RequestUri = new Uri(url),
						Method = httpMethod,
					};
					request.Headers.Authorization =
					new AuthenticationHeaderValue("Bearer", token);
					if ((httpMethod == HttpMethod.Put) || (httpMethod == HttpMethod.Post))
					{
						request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(pData));
						request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
					}

					var result = client3.SendAsync(request).Result;
					result.EnsureSuccessStatusCode();
					string data = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
					if (data != null)
					{
						return JsonConvert.DeserializeObject<T>(data);
					}

				}
				return default(T);
			}
			catch (Exception ex)
			{
				string mensaje = "RestSharpClient:ConsumeAsync " + route + " " + ex.Message;
				Logger.Logueo(mensaje, Level.ErrorLog);
				throw ex;
			}
		}

	}
}
