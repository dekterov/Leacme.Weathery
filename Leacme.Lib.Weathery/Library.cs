// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using LiteDB;
using Newtonsoft.Json;
using RestSharp;

namespace Leacme.Lib.Weathery {

	public class Library {

		public static RestClient wxClient { get; } = new RestClient("https://wxdata.weather.com");
		private LiteDatabase db = new LiteDatabase(typeof(Library).Namespace + ".Settings.db");
		private LiteCollection<BsonDocument> defaultCollection;
		private string name;
		private BsonDocument weatherCodes;

		public Library() {
			defaultCollection = db.GetCollection(nameof(defaultCollection));
		}

		/// <summary>
		/// Load the weather codes and locations from the initialized database.
		/// /// </summary>
		/// <param name="location">Location for the weather forecast</param>
		/// <param name="name">Name of the territory containing the locations</param>
		/// <param name="code">Location-specific code for retrieving the weather data</param>
		/// <returns>Entries for retrieving the forecast data</returns>
		public async Task<IEnumerable<(string location, string name, string code)>> GetWeatherCodesFromDatabaseAsync() {
			return await Task.Run(() => {
				return defaultCollection.FindAll().SelectMany(
					z => (Dictionary<string, BsonValue>)z[(nameof(weatherCodes))], (
						z, zz) => (zz.Value.ToString().Replace("\"", ""), z[(nameof(name))].ToString().Replace("\"", "").Replace("_", " "), zz.Key));
			});
		}

		/// <summary>
		///	Load the location-weather code pairs into the database for retrieval.
		/// /// </summary>
		/// <returns></returns>
		public async Task InitializaDatabaseWithWeatherCodesIfAbsentAsync() {
			if (!db.CollectionExists(nameof(defaultCollection))) {
				var asm = typeof(Library).GetTypeInfo().Assembly;
				var tasks = asm.GetManifestResourceNames().ToList().Select(z => {

					return Task.Run(() => {
						using (Stream rs = asm.GetManifestResourceStream(z)) {
							using (var sr = new StreamReader(rs)) {
								var jo = LiteDB.JsonSerializer.Deserialize(sr);
								weatherCodes = BsonMapper.Global.ToDocument(jo);
								name = z.Split(".").Reverse().Skip(1).Take(1).First();
								var doc = new BsonDocument() { [(nameof(name))] = name, [(nameof(weatherCodes))] = weatherCodes };
								defaultCollection.Insert(doc);
							}
						}
					});
				});
				await Task.WhenAll(tasks);
			}
			return;
		}

		/// <summary>
		/// Retrieve the weather forecast data from the service.
		/// /// </summary>
		/// <param name="locationCode">Location code</param>
		/// <param name="unitsMetric">Metric or Imperial units</param>
		/// <param name="daysForecast">Days of forecast (2-11)</param>
		/// <returns>Response with the weather forecast</returns>
		public async Task<WeatherData> GetWeather(string locationCode = "USDC0001", bool unitsMetric = true, int daysForecast = 5) {
			var searchReq = new RestRequest(new Uri(wxClient.BaseUrl, "wxdata/weather/local/" + locationCode), Method.GET, DataFormat.Xml);
			searchReq.AddQueryParameter("dayf", daysForecast.ToString());
			if (unitsMetric) {
				searchReq.AddQueryParameter("unit", "m");
			} else {
				searchReq.AddQueryParameter("unit", "e");
			}

			return await Task.Run(() => {
				XmlDocument x = new XmlDocument();
				x.LoadXml(wxClient.Execute(searchReq).Content);
				var j = JsonConvert.SerializeXmlNode(x, Newtonsoft.Json.Formatting.None, true).Replace("@", "");
				return JsonConvert.DeserializeObject<WeatherData>(j);
			});
		}

	}
}