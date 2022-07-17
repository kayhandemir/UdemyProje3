using UnityEngine;

namespace UdemyProje3.Animations
{
    public class AnimationImpactWatcher : MonoBehaviour
    {
        public event System.Action OnImpact;
        public void Impact()
        {
            OnImpact?.Invoke();
        }
    }
}