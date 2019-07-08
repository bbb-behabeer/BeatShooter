using System;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy.HalfRest
{
    /// <summary>
    /// 2分休符の制御
    /// </summary>
    public class HalfRestCtl: MonoBehaviour
    {
        // 全休符の移動速度
        [SerializeField] private int _speed;
        private Transform _player;
        private Rigidbody2D _rb;

        [SerializeField] private int _offsetY = 80;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _player = GameObject.FindWithTag("Player").transform;
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

        /// <summary>
        /// プレイヤーへの接近を始める
        /// </summary>
        public void StartApproach()
        {
            if (_player != null)
            {
                // 移動
                var diff = _player.position - transform.position;
                var v = diff.normalized * _speed;
                _rb.velocity = v;
                
                // 回転
                transform.rotation = Quaternion.FromToRotation(Vector3.down, diff);
            }
        }
    }
}