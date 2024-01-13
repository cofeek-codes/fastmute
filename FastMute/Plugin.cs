using BepInEx;

namespace FastMute
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.rune580.LethalCompanyInputUtils", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "FastMute";
        public const string PLUGIN_NAME = "FastMute";
        public const string PLUGIN_VERSION = "1.0.0";


        internal static Binds BindsInstance = new Binds();
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

            SetupKeybindCallbacks();
        }

        public void SetupKeybindCallbacks()
        {
            Plugin.BindsInstance.FastMuteKey.performed += OnFastMuteKeyPressed;

        }

        private void OnFastMuteKeyPressed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
        {
            bool pushToTalk = IngamePlayerSettings.Instance.settings.pushToTalk;

            var settings = IngamePlayerSettings.Instance;

            if (!ctx.performed) return;

            pushToTalk = !pushToTalk;

            settings.SetMicrophoneEnabled();
            settings.UpdateMicPushToTalkButton();
            settings.UpdateGameToMatchSettings();
            settings.SaveChangedSettings();
            settings.SaveSettingsToPrefs();

            if (pushToTalk) Logger.LogInfo("You are muted"); else Logger.LogInfo("You are unmuted");


        }
    }
}