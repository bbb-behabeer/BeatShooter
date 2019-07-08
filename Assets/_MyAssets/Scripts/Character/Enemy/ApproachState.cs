using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 接近ステート
    /// プレイヤーに接近する
    /// </summary>
    [Serializable]
    public class ApproachState : StateBase
    {
        [SerializeField]
        private SerialStateMachine _stateMachine;
        
        // 接近する回数
        [SerializeField]
        private int _approachCnt = 10;

        // 接近する間隔
        [SerializeField] private float _duration = 2f;
        private float _currentSec = 0;

        // 接近可能か
        private bool _approachable;
        
        // 移動速度
        [SerializeField] private float _speed = 30f;
        
        // プレイヤーの位置
        private Transform _player;

        private Rigidbody2D _rb;

        void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _rb = GetComponent<Rigidbody2D>();
        }

        public override void OnStateUpdate()
        {
            if (_approachable)
            {
                // 角度を変えてプレイヤーに接近する
                LookAtPlayer();
                StartApproach();
            }
            
            _currentSec += Time.deltaTime;

            if (_currentSec > _duration)
            {
                _currentSec = 0;
                _approachCnt--;
                _approachable = true;
            }

            if (_approachCnt < 0)
            {
                // アプローチ回数を超えたら
                // プレイヤーへの接近を終了
                _approachable = false;
                if (_stateMachine != null)
                    _stateMachine.Next();
            }
        }

        /// <summary>
        /// プレイヤーへの接近を始める
        /// </summary>
        private void StartApproach()
        {
            if (_player != null)
            {
                // 移動
                var diff = _player.position - transform.position;
                var v = diff.normalized * _speed;
                _rb.velocity = v;
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