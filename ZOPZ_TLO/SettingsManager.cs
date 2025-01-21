using System;
using System.IO;
using Newtonsoft.Json;

namespace ZOPZ_TLO;

public static class SettingsManager
{
	private static string datapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZOPZTLO");

	private static string jsonpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZOPZTLO", "settings.json");

	private static SettingsModel settings = null;

	public static void Save(this SettingsModel model)
	{
		if (!Directory.Exists(datapath))
		{
			Directory.CreateDirectory(datapath);
		}
		settings = model;
		string contents = JsonConvert.SerializeObject(model, Formatting.Indented);
		File.WriteAllText(jsonpath, contents);
	}

	public static SettingsModel Load()
	{
		if (settings != null)
		{
			return settings;
		}
		if (!Directory.Exists(datapath))
		{
			Directory.CreateDirectory(datapath);
		}
		if (!File.Exists(jsonpath))
		{
			SettingsModel model = new SettingsModel();
			model.Save();
		}
		string value = File.ReadAllText(jsonpath);
		return settings = JsonConvert.DeserializeObject<SettingsModel>(value);
	}
}
