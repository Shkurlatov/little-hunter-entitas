using UnityEngine;

namespace LittleHunter
{
    public class BillboardView : MonoBehaviour
    {
        private Transform _cameraTransform = default;

        void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        void LateUpdate()
        {
            if ( _cameraTransform == null )
            {
                return;
            }

            transform.LookAt( _cameraTransform );
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
