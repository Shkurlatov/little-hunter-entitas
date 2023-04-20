using UnityEngine;
using UnityEngine.UI;

namespace LittleHunter
{
    public class ActorHUDController : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _actorTitleText;
        [SerializeField] private TMPro.TextMeshProUGUI _actorNameText;
        [SerializeField] private TMPro.TextMeshProUGUI _actorDamageText;

        public void SetPlayerTitle(string text)
        {
            _actorTitleText.text = text;
        }
        public void SetPlayerName(string text)
        {
            _actorNameText.text = text;
        }
        public void SetPlayerDamage(string text)
        {
            _actorDamageText.text = text;
        }
    }
}
