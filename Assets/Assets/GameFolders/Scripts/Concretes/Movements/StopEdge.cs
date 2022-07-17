using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{ 
    [RequireComponent(typeof(Collider2D))]
    public class StopEdge : MonoBehaviour,IStopEdge
    {
        [SerializeField] float _distance = 0.1f;
        [SerializeField] LayerMask _layerMask;
        float _direction;
        Collider2D _collider;
      
        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _direction = transform.localScale.x;
        }
        public bool ReachEdge()
        {
            float x = GetXPosition();
            float y = _collider.bounds.min.y;
            Vector2 origin = new Vector2(x, y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, _distance, _layerMask);
            Debug.DrawRay(origin, Vector2.down * _distance, Color.red);
            bool result = hit.collider != null;
            if (result)
            {
                _direction = transform.localScale.x;
                return false;
            }
            return true;
        }
        float GetXPosition()
        {
            return _direction == 1f ? _collider.bounds.max.x : _collider.bounds.min.x;
        }
    }
}