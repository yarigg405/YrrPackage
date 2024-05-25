using UnityEngine;
using Yrr.Audio;



namespace Yrr.Utils
{
    internal sealed class PlayUiSound : MonoBehaviour
    {
        [SerializeField] private string soundName = "ui:click";

        public void PlaySound()
        {
            AudioManager.Instance.PlayUiSound(soundName);
        }
    }
}
