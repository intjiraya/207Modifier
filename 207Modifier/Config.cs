using System.ComponentModel;
using Exiled.API.Interfaces;

namespace _207Modifier
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enable debug mode?")]
        public bool Debug { get; set; } = false;

        [Description("Enable custom damage?")]
        public bool CustomDamage { get; set; } = false;

        [Description("Custom damage value (set to 0 to disable damage)")]
        public float Damage { get; set; } = 0f;
    }
}