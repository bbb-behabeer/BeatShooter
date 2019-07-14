using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの制御
    /// </summary>
    [RequireComponent(typeof(AudioClip))]
    public class Note: MonoBehaviour
    {
        // ノート再生時のエフェクト
        [SerializeField] private GameObject _effect;
        
        // ノートを配置するタイミング
        [SerializeField] private int _moment;

        // 入力した
        private bool _isAimed;
        
        // オーディオクリップ
        [SerializeField] private AudioClip _se;
        
        // 経過時間
        private float _time;
        private float _just;

        public Transform Transform => transform;

        public void Start()
        {
            Initialize(_moment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moment">タイミングを設定する</param>
        public void Initialize(int moment)
        {
            // NoteManagerをシーンから取得
            var noteManager = NoteManager.Instance;

            // タイミングを取得
            _moment = moment;
            _just = noteManager.DurationPerBeat * _moment;
            
            // 縦幅を取得
            var h = NoteScreen.Height;
            var k = NoteScreen.K;
            
            // 位置を計算
            var mb = (float)_moment /  (float)noteManager.Beat;
            var y = h * mb * k;

            // 位置を設定
            var pos = transform.position;
            pos.y = y;
            transform.position = pos;

            _isAimed = false;
        }

        private void FixedUpdate()
        {
            var noteManager = NoteManager.Instance;

            // 時間経過
            _time += Time.deltaTime;
            _time %= noteManager.Duration * noteManager.BBeatPerBeat;

            // 最終ラインで入力
            var end = noteManager.Duration * noteManager.BBeatPerBeat;
            if (_time > end - noteManager.Range * 2)
                if (_isAimed && Input.GetButtonDown("Jump"))
                {
                    // 消去
                    DestroyThis();
                }
        }

        public bool CanAim()
        {
            var noteManager = NoteManager.Instance;
            
            // タイミングを計算
            var min = _just - noteManager.Range;
            var max = _just + noteManager.Range;
            
            // 範囲内であればエイム可能
            return (_time > min && _time < max);
        }
        
        /// <summary>
        /// 削除する
        /// </summary>
        public void DestroyThis()
        {
            // エフェクトを生成
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            
            // 自身を削除
            Destroy(this.gameObject);
        }
    }
}