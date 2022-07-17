using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Abstracts.Inputs;
using UnityEngine;

namespace UdemyProje3.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool JumpButtonDown => Input.GetButtonDown("Jump");
        public bool AttackButtonDown => Input.GetButtonDown("Fire1");
    }
}