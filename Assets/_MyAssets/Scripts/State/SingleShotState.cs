using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 待機ステート
    /// オフセットの位置で次のステートへ
    /// </summary>
    [Serializable]
    public class SingleShotState : StateBase
    {
        // 弾丸
        [SerializeField] private GameObject _bullet;
        
        // ステートマシン
        [SerializeField]
        private SerialStateMachine _stateMachine;

        // 現在の秒数
        private float _shotCurrentSec;
        // 射撃間隔
        [SerializeField]
        private float _duration;

        // 射撃回数
        [SerializeField] private int _shotCnt;

        private bool _shootable;
        
        [SerializeField]
        // 弾丸の速度
        private float _bulletSpeed = 100f;

        private Transform _player;

        void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
        }

        public override void OnStateUpdate()
        {
            if (_shootable)
            {
                // 射撃する
                Shot();
                _shootable = false;
            }
            
            // 現在の秒数を経過させる
            _shotCurrentSec += Time.deltaTime;

            if (_shotCurrentSec > _duration)
            {
                // 射撃間隔を経過したとき
                // 射撃をリセットする
                _shotCurrentSec = 0;
                _shotCnt--;
                _shootable = true;
            }
            
            if (_shotCnt < 0)
            {
                // ステート遷移する
                _stateMachine.Next();
            }
        }

        /// <summary>
        /// 射撃する
        /// </summary>
        private void Shot()
        {
            if (_bullet != null && _player != null)
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
    }
}