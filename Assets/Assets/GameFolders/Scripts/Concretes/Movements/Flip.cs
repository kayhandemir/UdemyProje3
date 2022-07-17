using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProje3.Movements
{
    public class Flip:IFlip
    {
        IEntityController _entity;
        public Flip(IEntityController entity)
        {
            _entity = entity;
        }
        public void FlipCharacter(float direction)
        {
            if (direction == 0) return;
            float mathValue = Mathf.Sign(direction);
            if (mathValue!=_entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}