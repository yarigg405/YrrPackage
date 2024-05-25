using UnityEngine;
using Yrr.Audio;


namespace Yrr.Utils
{
    internal sealed class PlaySoundOnObject : MonoBehaviour
    {
        [SerializeField] private string soundName = "fx:scream";

        public void PlaySound()
        {
            AudioManager.Instance.PlaySoundOnObject(soundName, transform);
        }
    }
}
