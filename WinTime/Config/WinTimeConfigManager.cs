using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinTime.Config;

public class WinTimeConfigManager
{
    public WinTimeConfig? Config { get; set; }
    
    /// <summary>
    /// Makes Configuration manager instance
    /// for setting up WinTime models and ViewModels
    /// </summary>
    public WinTimeConfigManager()
    {
        Task.Run(DeserializeConfig);
    }

    /// <summary>
    /// Makes Configuration manager instance
    /// for saving new WinTime parameters to file
    /// </summary>
    /// <param name="config"></param>
    public WinTimeConfigManager(WinTimeConfig config)
    {
        Task.Run(() => SerializeConfig(config));
    }

    private Task DeserializeConfig()
    {
        try
        {
            string text = File
                .ReadAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + "WinTime.json")
                .Result;
            WinTimeConfig config = JsonSerializer
                .Deserialize<WinTimeConfig>(text)!;
            
            Config = config;
        }
        finally { }
        
        return Task.CompletedTask;
    }

    private Task SerializeConfig(WinTimeConfig config)
    {
        if (config.ApiUsage == string.Empty)
        {
        }

        string text = JsonSerializer.Serialize(config);
        File.WriteAllTextAsync(text, AppDomain.CurrentDomain.BaseDirectory + "WinTime.json");
        return Task.CompletedTask;
    }
}