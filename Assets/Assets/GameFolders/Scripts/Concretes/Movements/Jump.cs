using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class Jump:IJump
    {
        Rigidbody2D _rigidbody;
        float _jumpForce = 350f;
        IOnGround _onGround;
        public bool IsJump { get; set; }

        public Jump(IEntityController entity,IOnGround ground)
        {
            _rigidbody = entity.transform.GetComponent<Rigidbody2D>();
            _onGround = ground;
        }
        public void TickWithFixedUpdate()
        {
            if (IsJump&&_onGround.IsGround)
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.AddForce(Vector2.up * _jumpForce);
                _rigidbody.velocity = Vector2.zero;          
            }
             IsJump = false;
        }
    }
}