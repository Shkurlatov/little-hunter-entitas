using UnityEngine;
using Photon.Pun;

namespace LittleHunter
{
    public class ActorView : MonoBehaviour
    {
        [SerializeField] private Canvas _actorHUDCanvas;
        [SerializeField] private PhotonView _photonView;

        private void Awake()
        {
            _actorHUDCanvas.gameObject.SetActive(!_photonView.IsMine);
            _actorHUDCanvas.GetComponent<ActorHUDController>().SetPlayerName(_photonView.IsMine ? PhotonNetwork.NickName :
                _photonView.Owner.NickName);
        }
    }
}
