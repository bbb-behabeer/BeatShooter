using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Laser: MonoBehaviour
    {
        // 初期位置
        private Vector3 _initialPos;
        // ターゲット
        [SerializeField] private Transform _target;

        // 時間
        private float _current;
        [SerializeField] private float _period;

        // バネ係数
        [SerializeField] private float _ratio;
        
        // トレイルレンダラー
        private TrailRenderer _trailRenderer;

        private void Start()
        {
            _trailRenderer = GetComponent<TrailRenderer>();
            _initialPos = transform.position;
            Initialize();
        }

        private void FixedUpdate()
        {
            // 0 -> 1に
            var t = Mathf.Min(_current / _ratio, 1f);
            
            // ターゲットまでのベクトルを計算
            var q = Quaternion.Lerp(transform.rotation, Quaternion.identity, t);
            var pos = Vector2.Lerp(_initialPos, q * _target.position, t);
         
            // 位置を更新する
            transform.position = pos;
            
            _current += Time.deltaTime;

            if (_current > _period + _trailRenderer.time)
            {
                gameObject.SetActive(false);
                _trailRenderer.enabled = false;
                transform.position = _initialPos;
            }
        }
        
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            _current = 0;
            gameObject.SetActive(true);
            _trailRenderer.enabled = true;
        }

        /// <summary>
        /// レーザーを撃つ
        /// </summary>
        public void ShotTo(Transform target)
        {
            //_target = target;
            Initialize();
        }
    }
}