using System;
using System.Security.Cryptography;
using _MyAssets.Scripts.Character;
using _MyAssets.Scripts.Character.Enemy;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /**
     * 全休符の制御
     */
    public class WholeRestCtl: MonoBehaviour
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
        /// 射撃する
        /// </summary>
        public void Shot()
        {
            if (_bullet != null)
            {
                // 弾の数　8方向
                var num = 8;
                for (int i = 0; i < num; i++)
                {
                    // 弾丸を生成
                    var b = UnityEngine.Object.Instantiate(_bullet);
                    b.transform.position = transform.position;

                    // 弾丸の角度とスピードを変更
                    var angle = i * 360f / num;
                    var v = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.down * _bulletSpeed;

                    // 弾丸の速度を設定
                    var ctl = b.GetComponent<EnemyBulletCtl>();
                    ctl.SetVelocity(v);
                }
            }
        }

        /// <summary>
        /// 射撃を制御する
        /// </summary>
        /// <returns></returns>
        public bool ShotCtl()
        {
            if (_shotCurrentSec == 0f)
            {
                // タイマーが0秒のときに弾を発射
                Shot();
            }

            // タイマーを進める
            _shotCurrentSec += Time.deltaTime;

            // タイマーが待機時間を超えたとき、タイマーをリセット
            if (_shotCurrentSec > _shotWaitSec)
            {
                _shotCurrentSec = 0;
                _shotEndCnt++;
            }

            if (_shotEndCnt >= _shotLimit)
            {
                return false;
            }

            return true;
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