// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Threading;
using Leacme.Lib.Weathery;

namespace Leacme.App.Weathery {

	public class AppUI {

		private StackPanel rootPan = (StackPanel)Application.Current.MainWindow.Content;
		private Library lib = new Library();

		public AppUI() {

			var acLoc = App.AutoCompleteWithLabel;
			acLoc.holder.HorizontalAlignment = HorizontalAlignment.Center;
			acLoc.acBox.IsEnabled = false;
			acLoc.acBox.Watermark = "Loading locations...";

			Dispatcher.UIThread.InvokeAsync(async () => {
				((App)Application.Current).LoadingBar.IsIndeterminate = true;
				await lib.InitializaDatabaseWithWeatherCodesIfAbsentAsync();

				var wRes = lib.GetWeatherCodesFromDatabaseAsync();

				// req for the async
				await wRes.ContinueWith(zzz => {
					Console.WriteLine(wRes.Result.Count());
				});

				acLoc.acBox.Items = wRes.Result.Select(zzz => zzz.location + ", " + zzz.name + " (" + zzz.code + ")");
				acLoc.label.Text = "Enter Location:";
				acLoc.acBox.IsEnabled = true;
				acLoc.acBox.Watermark = "";
				((App)Application.Current).LoadingBar.IsIndeterminate = false;
			});

			acLoc.acBox.MinimumPopulateDelay = new TimeSpan(0, 0, 2);

			var daysLab = App.TextBlock;
			daysLab.Text = "Days:";

			var daysBox = App.TextBox;
			daysBox.Text = 5.ToString();

			var unitLab = App.TextBlock;
			unitLab.Text = "Units:";

			var metricBt = new RadioButton();
			metricBt.Content = "Metric ";
			metricBt.GroupName = "Units";
			metricBt.IsChecked = true;

			var imperialBt = new RadioButton();
			imperialBt.Content = "Imperial ";
			imperialBt.GroupName = "Units";
			imperialBt.IsChecked = false;

			var wBt = App.Button;
			wBt.Content = "Get Weather";

			var wOutp = App.TextBox;
			wOutp.IsReadOnly = true;
			wOutp.Width = 900;
			wOutp.Height = 400;

			wBt.Click += async (z, zz) => {
				if (!string.IsNullOrWhiteSpace(acLoc.acBox.Text) && !string.IsNullOrWhiteSpace(acLoc.acBox.Text.Split('(', ')')[1]) &&
				int.TryParse(daysBox.Text, out var daysW) && daysW < 12 && daysW > 1) {
					var wResp = await lib.GetWeather(acLoc.acBox.Text.Split('(', ')')[1], metricBt.IsChecked == true, daysW);

					var days = wResp.Dayf.Day.Select(zzz => zzz.T + " " + zzz.Dt + "\n" + "High: " + zzz.Hi + " Low: " + zzz.Low + "\n" + zzz.Part.First().T + "\n");

					wOutp.Text =
					"Location: " + wResp.Loc.Dnam + "\n" +
					"Current time: " + wResp.Loc.Tm + "\n" +
					"Sunrise: " + wResp.Loc.Sunr + "\n" +
					"Sunset: " + wResp.Loc.Suns + "\n\n" +
					string.Join("\n", days);
				}
			};

			acLoc.holder.Children.AddRange(new List<IControl> { daysLab, daysBox, unitLab, metricBt, imperialBt, wBt });
			rootPan.Children.AddRange(new List<IControl> { acLoc.holder, wOutp });
		}
	}
}