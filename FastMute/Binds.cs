using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace FastMute
{
    internal class Binds : LcInputActions
    {
        [InputAction("<Keyboard>/c", Name = "Fast Mute")]
        public InputAction FastMuteKey { get; set; }
    }
}
