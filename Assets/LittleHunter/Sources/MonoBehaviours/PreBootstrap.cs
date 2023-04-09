using UnityEngine;

namespace LittleHunter
{
    public sealed class PreBootstrap : MonoBehaviour
    {
        [SerializeField]
        private GameObject splashScene;

        private void Awake()
        {
            BootstrapStart();
        }

        private void BootstrapStart()
        {
            splashScene.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
