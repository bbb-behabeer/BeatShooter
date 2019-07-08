using System;
using _MyAssets.Scripts.Character.Note;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Player
{
    /// <summary>
    /// プレイヤーを制御する
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCtl : MonoBehaviour
    {
        // 弾
        [SerializeField]
        private GameObject _bullet = null;

        // 発射待機時間
        [SerializeField] private float _shotWaitSec;
        // 発射タイマー
        private float _shotCurrentSec = 0f;
        private Vector3 _cacheMousePos;

        // 射撃位置
        [SerializeField] private Transform _bulletPos;
        
        //[SerializeField] private NoteManager _noteManager;

        // 画面枠
        [SerializeField] private Vector2 _maxRange;
        [SerializeField] private Vector2 _minRange;
        
        // マウス感度
        [SerializeField] private float _sencitivity = 1f;

        // 爆発エフェクト
        [SerializeField] private GameObject _explosion;

        void Start()
        {
            _cacheMousePos = Vector3.zero;
        }

        void Update()
        {
            // 入力状態を退避
            var state = PlayerInput.MouseButtonState;
            var buttonDown = PlayerInput.ButtonDown;

            if (state.Equals(MouseButtonState.Press))
            {
                // マウスを押下中
                // 射撃する
                ShotCtl();
                // 移動
                MoveCtl(PlayerInput.MouseWorldPoint);
            } else if (state == MouseButtonState.Void)
            {
                // マウスを操作していないとき
                // 弾を停止
                Idle();
            }
        }

        /// <summary>
        /// 射撃する
        /// </summary>
        public void Shot()
        {
            if (_bullet != null)
            {
                var b = UnityEngine.Object.Instantiate(_bullet);
                b.transform.position = _bulletPos.position;
            }
        }

        /// <summary>
        /// 射撃を制御する
        /// 秒間隔で発射
        /// </summary>
        public void ShotCtl()
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
        }

        
        /// <summary>
        /// posの位置にから、プレイヤーの移動を制御する
        /// </summary>
        /// <param name="pos">マウスのワールド座標</param>
        public void MoveCtl(Vector3 pos)
        {
            // 現在位置を退避
            var x = transform.position.x;
            var y = transform.position.y;

            // キャッシュ位置が初期位置でないとき処理を実行
            if (!_cacheMousePos.Equals(Vector3.zero))
            {
                // 変位を計算
                var dx = pos.x - _cacheMousePos.x;
                var dy = pos.y - _cacheMousePos.y;
                
                // 新しい位置を計算
                var nx = x + dx * _sencitivity;
                var ny = y + dy * _sencitivity;
                
                // 位置を丸める
                if (nx < _minRange.x) nx = _minRange.x;
                if (ny < _minRange.y) ny = _minRange.y;
                if (nx > _maxRange.x) nx = _maxRange.x;
                if (ny > _maxRange.y) ny = _maxRange.y;
                
                // 位置を更新
                transform.position = new Vector3(nx, ny, 0);
            }

            // キャッシュ位置を記憶
            _cacheMousePos = pos;
        }

        /// <summary>
        /// 待機する
        /// </summary>
        public void Idle()
        {
            // タイマーをリセット
            _shotCurrentSec = 0;
            
            // キャッシュ位置をリセット
            _cacheMousePos = Vector3.zero;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Object"))
            {
                // 敵キャラクターと接触したとき
                // オブジェクトと接触したとき
                
                // 爆発する
                var explosion = Instantiate(_explosion);
                explosion.transform.position = transform.position;
                
                // 自身を消去する
                Destroy(this.gameObject);
            }
        }
    }
}