using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// LookAtステート
    /// プレイヤーの方向を向く
    /// </summary>
    [Serializable]
    public class LookAtState : StateBase
    {
        [SerializeField]
        private SerialStateMachine _stateMachine;

        // プレイヤーの方向を向く時間
        [SerializeField] private float _duration = 3f;
        private float _currentSec = 0;

        // プレイヤーの位置
        private Transform _player;

        void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
        }

        public override void OnStateUpdate()
        {
            // 角度を変える
            LookAtPlayer();
            
            _currentSec += Time.deltaTime;

            if (_currentSec > _duration)
            {
                if (_stateMachine != null)
                    _stateMachine.Next();
            }
        }

        /// <summary>
        /// プレイヤーの方向を向く
        /// </summary>
        private void LookAtPlayer()
        {
            if (_player != null)
            {
                var diff = _player.position - transform.position;
                // 回転
                transform.rotation = Quaternion.FromToRotation(Vector3.down, diff);
            }
        }
    }
}