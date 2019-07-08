using System;
using System.Security.Cryptography;
using _MyAssets.Scripts.Character;
using _MyAssets.Scripts.Character.Enemy;
using UnityEngine;

namespace _MyAssets.Scripts.Enemy
{
    /**
     * 全休符の制御
     */
    public class EnemyMover: MonoBehaviour
    {
        // 全休符の移動速度
        [SerializeField] private int _speed;
        private Transform _player;
        private Rigidbody2D _rb;
        
        // 全休符の弾丸
        [SerializeField] private GameObject _bullet;
        // 弾丸の速度
        [SerializeField] private float _bulletSpeed;
        
        // 発射待機時間
        [SerializeField] private float _shotWaitSec = 1.5f;
        // 発射タイマー
        private float _shotCurrentSec = 0f;

        [SerializeField] private int _offsetY = 100;
        
        // 射撃の回数
        [SerializeField] private int _shotLimit = 4;
        // 射撃終了の回数
        private int _shotEndCnt = 0;
        
        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// プレイヤーへの接近を開始する
        /// </summary>
        public void StartApproach()
        {
            if (_player != null)
            {
                var v = Vector3.down * _speed;
                if (_rb != null)
                {
                    _rb.velocity = v;
                }
            }
        }

        

        /// <summary>
        /// 待機状態を制御する
        /// </summary>
        /// <returns>待機中true/待機終了false</returns>
        public bool IdleCtl()
        {
            if (transform.position.y < _offsetY)
            {
                // オフセットを通過したとき
                // 一定時間その場で停止

                var x = transform.position.x;
                var y = _offsetY;
                var z = transform.position.z;
                
                transform.position = new Vector3(x, y, z);
                transform.parent = null;

                return false;
            }

            return true;
        }
    }
}