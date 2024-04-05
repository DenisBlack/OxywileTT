using System;
using UnityEngine;

namespace PlayerComponents
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private string _damageTrigger = "damageTrigger";
        
        private Animator _animator;
        private int _damageTriggerHash;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _damageTriggerHash = Animator.StringToHash(_damageTrigger);
        }

        public void PlayDamageAnimation()
        {
            _animator.SetTrigger(_damageTriggerHash);
        }
    }
}