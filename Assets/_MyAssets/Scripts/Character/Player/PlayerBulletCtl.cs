using System;
using UnityEngine;

namespace _MyAssets.Scripts.Character
{
    /// <summary>
    /// 弾丸を制御する
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBulletCtl : MonoBehaviour
    {
        // 弾丸の速度
        [SerializeField] private Vector3 velocity;

        [SerializeField] private float _upperBound = 200f;

        private Rigidbody2D _rb;

        private Vector3 _cache;

        // 最大距離
        [SerializeField]
        private float _dist;
        
        void Start()
        {
            // 速度を設定
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = velocity;
            
            // 生成位置をキャッシュ
            _cache = transform.position;
        }

        void Update()
        {
            // キャッシュと現在位置の差分を計算
            var diff = transform.position - _cache;
            
            // 差分が最大距離を超えるか
            // 位置が一定の値を超えると
            // 自身を削除する
            if (diff.magnitude > _dist || transform.position.y > _upperBound)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Note") || other.CompareTag("Enemy"))
            {
                // ノートに接触したとき
                // ゲームオブジェクトを削除
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 弾速を設定する
        /// </summary>
        /// <param name="v">弾速</param>
        public void SetVelocity(Vector3 v)
        {
            velocity = v;
            if (_rb = null)
                _rb.velocity = velocity;
        }
    }
}