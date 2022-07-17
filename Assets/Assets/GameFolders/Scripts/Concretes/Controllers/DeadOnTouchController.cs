using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Controllers;
using UnityEngine;

namespace UdemyProje3.Controller
{
    public class DeadOnTouchController : MonoBehaviour
    {
        IAttacker attacker;

        private void Awake()
        {
            attacker = GetComponent<IAttacker>();   
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth health = collision.GetComponent<IHealth>();
            if (health!=null)
            {
                health.TakeHit(attacker);
            }
        }
    }
}