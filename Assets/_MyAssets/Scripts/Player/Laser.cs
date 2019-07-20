using _MyAssets.Scripts.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    /// <summary>
    /// レーザー
    /// </summary>
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
        private TrailRenderer _trailRenderer => GetComponent<TrailRenderer>();

        private void FixedUpdate()
        {
            // 0 -> 1に
            var t = Mathf.Min(_current / _period, 1f);
            
            // ターゲットまでのベクトルを計算
            if (_target != null)
            {
                var q = Quaternion.Slerp(transform.rotation, Quaternion.identity, t);
                var pos = Vector2.Lerp(_initialPos, q * _target.Position, t);

                // 位置を更新する
                transform.position = pos;
            }

            _current += Time.deltaTime;

            if (_current > _period)
            {
                _target = null;
            }
            
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
            transform.position = pos;
            _current = 0;
        }

        /// <summary>
        /// ターゲットを設定
        /// </summary>
        //public void AimAt(Transform t)
        public void SetTarget(NoteBase t)
        {
            _target = t;
            var diff = t.Position - transform.position;
            if (diff.x > 0)
                transform.rotation = Quaternion.AngleAxis(-170f, Vector3.forward);
            else
                transform.rotation = Quaternion.AngleAxis(170f, Vector3.forward);
        }
    }
}