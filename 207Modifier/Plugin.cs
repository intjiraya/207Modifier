using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace _207Modifier
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Jiraya";
        public override string Name { get; } = "207Modifier";
        public override string Prefix { get; } = "207Modifier";

        public override System.Version Version { get; } = new System.Version(1, 0, 0);
        public override System.Version RequiredExiledVersion { get; } = new System.Version(8, 9, 11);
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Player.ReceivingEffect += OnReceivingEffect;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.ReceivingEffect -= OnReceivingEffect;
            base.OnDisabled();
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if (ev.DamageHandler.Type != DamageType.Scp207 || !Config.CustomDamage) return;
            var scp207EffectsCount = ev.Player.ActiveEffects.Count(effect => effect.GetEffectType() == EffectType.Scp207);
            if (scp207EffectsCount > 0)
            {
                ev.Amount = Config.Damage * scp207EffectsCount;
            }
        }

        private void OnReceivingEffect(ReceivingEffectEventArgs ev)
        {
            if (ev.Effect.GetEffectType() == EffectType.Scp207 && Config.CustomDuration)
            {
                ev.Duration = Config.Duration;
            }

        }
    }
}
