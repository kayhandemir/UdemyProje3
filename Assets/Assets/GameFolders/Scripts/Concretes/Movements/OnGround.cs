using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class OnGround : MonoBehaviour,IOnGround
    {
        [SerializeField] Transform[] transforms;
        [SerializeField] float maxDistance = 0.3f;
        [SerializeField] LayerMask layerMask;
        bool _isGorund;
        public bool IsGround => _isGorund;
        private void Update()
        {
            foreach (Transform footTransform in transforms)
            {
                CheckedIfFootsOnGround(footTransform);
                if (_isGorund) break;
            }
        }

        private void CheckedIfFootsOnGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, layerMask);
            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);
            if (hit.collider!=null)
            {
                _isGorund = true;
            }
            else
            {
                _isGorund = false;
            }
        }
    }
}