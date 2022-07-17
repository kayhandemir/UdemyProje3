using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Controllers;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class MoverRigidBody : IMover
    {
        Rigidbody2D _rigidbody2D;
        float _moveSpeed = 80f;

        public MoverRigidBody(PlayerController playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }
        public void Tick(float horizontal)
        {
            Vector2 direction = Vector2.right * horizontal;
            Vector2 movement = direction.normalized * Time.fixedDeltaTime * _moveSpeed;
            _rigidbody2D.velocity = movement;
        }
    }
}