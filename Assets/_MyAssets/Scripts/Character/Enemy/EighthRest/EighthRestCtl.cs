using System;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.EighthRest
{
    /// <summary>
    /// 8分休符の制御
    /// </summary>
    [Serializable]
    public class EighthRestCtl: MonoBehaviour
    {
        private Transform _player;
        private Rigidbody2D _rb;
        
        // 弾丸
        [SerializeField] private GameObject _bullet;
        // 弾丸の速度
        [SerializeField] private float _bulletSpeed;
        
        // 発射待機時間
        [SerializeField] private float _shotWaitSec = 1.5f;
        // 発射タイマー
        private float _shotCurrentSec = 0f;

        // ステート開始のオフセット
        [SerializeField] private int _offsetY = 100;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 射撃する
        /// プレイヤー方向に
        /// </summary>
        public void Shot()
        {
            if (_bullet != null)
            {
                // 弾丸を生成
                var b = UnityEngine.Object.Instantiate(_bullet);
                b.transform.position = transform.position;

                // 弾丸の角度とスピードを変更
                var diff = _player.position - transform.position;
                var v = diff.normalized * _bulletSpeed;

                // 弾丸の速度を設定
                var ctl = b.GetComponent<EnemyBulletCtl>();
                ctl.SetVelocity(v);
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
            }

            return true;
        }

        /// <summary>
        /// 待機状態を制御する
        /// </summary>
        /// <returns>待機中true/待機終了false</returns>
        public bool CanIdle()
        {
            if (transform.position.y < _offsetY)
            {
                // オフセットを通過したとき
                // 待機できない
                return false;
            }

            // 待機できる（待機中）
            return true;
        }
    }
}