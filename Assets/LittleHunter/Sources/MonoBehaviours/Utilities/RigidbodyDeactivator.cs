using UnityEngine;
using Photon.Pun;

namespace LittleHunter
{
    public sealed class RigidbodyDeactivator : MonoBehaviour
    {
        private Rigidbody rigidbody;
        private PhotonView photonView;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            photonView = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (!photonView.IsMine)
            {
                rigidbody.isKinematic = true;
            }
        }
    }
}
