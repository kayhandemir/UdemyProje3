using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class Mover : IMover
    {
        IEntityController _playerEntity;
        float _moveSpeed;

        public Mover(IEntityController entityController,float moveSpeed)
        {
            _playerEntity = entityController;
            _moveSpeed = moveSpeed;
        }
        public void Tick(float horizontal)
        {
            if (horizontal == 0f) return;
            _playerEntity.transform.Translate(Vector2.right * horizontal * Time.fixedDeltaTime * _moveSpeed);
        }
    }
}