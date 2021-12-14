using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.Core.Settings
{
    public class SettingsModel
    {
        [YamlProperty("Core.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("Core.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("Core.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
