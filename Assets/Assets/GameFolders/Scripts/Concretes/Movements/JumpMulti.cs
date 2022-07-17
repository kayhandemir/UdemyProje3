using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class JumpMulti : IJump
    {
        float _jumpForce = 350f;
        Rigidbody2D _rigidbody;
        IOnGround _ground;
        int _currentJumpCount = 0;
        int _maxJumpCount = 2;
        public bool IsJump { get; set; }

        public JumpMulti(IEntityController entity,IOnGround ground)
        {
            _rigidbody = entity.transform.GetComponent<Rigidbody2D>();
            _ground = ground;
        }
        public void TickWithFixedUpdate()
        {
            if (IsJump)
            {
                if (_currentJumpCount < _maxJumpCount)
                {
                    _rigidbody.velocity = Vector2.zero;
                    _rigidbody.AddForce(Vector2.up * _jumpForce);
                    _rigidbody.velocity = Vector2.zero;
                    _currentJumpCount++;
                }
                else if (_ground.IsGround)
                {
                    IsJump = false;
                    _currentJumpCount = 0;
                }
            }   
        }
    }
}

