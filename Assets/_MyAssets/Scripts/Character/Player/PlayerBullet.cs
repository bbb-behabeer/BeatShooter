using UnityEngine;

namespace _MyAssets.Scripts.Character.Player
{
    /// <summary>
    /// 弾丸を制御する
    /// </summary>
    public class PlayerBullet : MonoBehaviour
    {
        // 画面外に出ないように上限を設ける
        [SerializeField] private float _upperBound = 200f;

        private Vector3 _cache;

        // 最大距離
        [SerializeField]
        private float _dist;
        
        void Start()
        {
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
    }
}