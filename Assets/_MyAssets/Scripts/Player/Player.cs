using _MyAssets.Scripts.Manager;
using _MyAssets.Scripts.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    /// <summary>
    /// プレイヤーを制御する
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        // 射撃位置
        [SerializeField] private Transform _bulletPos;

        // 画面枠
        [SerializeField] private Vector2 _maxRange;
        [SerializeField] private Vector2 _minRange;

        // 爆発エフェクト
        [SerializeField] private GameObject _explosion;

        // ゲームマネージャー
        [SerializeField] private GameManager _gameManager;

        // 速度
        [SerializeField] private float _velocity = 1f;

        private Rigidbody2D _rigidbody;

        private Vector2 _offset;
        
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _offset = transform.position;
        }

        /// <summary>
        /// posの位置にから、プレイヤーの移動を制御する
        /// </summary>
        /// <param name="pos">マウスのワールド座標</param>
        public void Move(Vector2 dir)
        {
            var pos = transform.position;
            var npos = NoteSetter.Instance.GetPosWithAxis(dir) + _offset;
            
            transform.position = Vector2.Lerp(pos, npos, Time.deltaTime * 10f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                // 敵キャラクターと接触したとき
                
                // 爆発する
                var explosion = Instantiate(_explosion);
                explosion.transform.position = transform.position;
                
                // 自身を消去する
                Destroy(this.gameObject);
                
                // ゲームオーバー
                //if (_gameManager != null)
                    //_gameManager.ShowResult();
            }
        }
    }
}