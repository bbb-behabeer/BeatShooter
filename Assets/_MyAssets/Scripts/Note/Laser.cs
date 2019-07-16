using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Laser: MonoBehaviour
    {
        // 初期位置
        private Vector3 _initialPos;
        // ターゲット
        //[SerializeField] private Transform _target;
        private NoteBase _target;
        
        // 時間
        private float _current;
        [SerializeField] private float _period;
        public float Period => _period;

        // バネ係数
//        [SerializeField] private float _ratio;
        
        // トレイルレンダラー
        private TrailRenderer _trailRenderer;

        private void Start()
        {
            _trailRenderer = GetComponent<TrailRenderer>();
            //_initialPos = transform.position;
            //Initialize();
        }

        private void FixedUpdate()
        {
            // 0 -> 1に
            var t = Mathf.Min(_current / _period, 1f);
            
            // ターゲットまでのベクトルを計算
            if (_target != null)
            {
                var q = Quaternion.Lerp(transform.rotation, Quaternion.identity, t);
                var pos = Vector2.Lerp(_initialPos, q * _target.Position, t);
                //var pos = Vector2.Lerp(_initialPos, q * _target.position, t);

                // 位置を更新する
                transform.position = pos;
            }

            _current += Time.deltaTime;

            if (_current > _period + _trailRenderer.time)
            {
                Destroy(gameObject);
            }
        }
        
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize(Vector3 pos)
        {
            _initialPos = pos;
            _current = 0;
        }

        /// <summary>
        /// レーザーを撃つ
        /// </summary>
        /*public void Shot()
        {
            Initialize();
        }*/

        /// <summary>
        /// ターゲットを設定
        /// </summary>
        //public void AimAt(Transform t)
        public void SetTarget(NoteBase t)
        {
            _target = t;
        }
    }
}