using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 脱出ステート
    /// 画面外へ消える
    /// </summary>
    [Serializable]
    public class ExitState : StateBase
    {
        private SerialStateMachine _stateMachine;

        // 移動速度
        [SerializeField] private float _speed = 100f;
        
        // 遷移までの期間
        [SerializeField] private float _duration = 5f;

        private float _currentSec = 0f;
        
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public override void OnStateEnter()
        {
            _rb.velocity = Vector2.down * _speed;
        }

        public override void OnStateUpdate()
        {
            _currentSec += Time.deltaTime;

            if (_currentSec > _duration)
            {
                _stateMachine.Next();
            }
        }
    }
}