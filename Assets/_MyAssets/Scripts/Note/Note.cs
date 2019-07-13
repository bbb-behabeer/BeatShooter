using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの制御
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class Note: MonoBehaviour
    {
        // ノート再生時のエフェクト
        [SerializeField] private GameObject _effect;
        
        // ノートを配置するタイミング
        [SerializeField] private int _moment;

        // 入力した
        private bool _isAimed;
        
        // オーディオソース
        private AudioSource _audioSource;
        
        // 経過時間
        private float _time;
        private float _just;

        [Button("Start")]
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            
            // NoteManagerをシーンから取得
            var noteManager = NoteManager.Instance;
            
            // タイミングを取得
            _just = noteManager.DurationPerBeat * _moment;
            
            // 縦幅を取得
            var h = NoteScreen.Height;
            var hh = NoteScreen.HalfHeight;

            var k = NoteScreen.K;
            
            // 位置を計算
            var mb = (float)_moment /  (float)noteManager.Beat;
            var y = (h * mb - hh) * k;

            // 位置を設定
            var pos = transform.position;
            pos.y = y;
            transform.position = pos;
        }

        private void FixedUpdate()
        {
            _time += Time.deltaTime;

            var noteManager = NoteManager.Instance;
            
            // タイミングを計算
            var min = _just - noteManager.Range;
            var max = _just + noteManager.Range;

            // 範囲内であればエイム可能
            if (_time > min && _time < max)
            {
                // エイムしておらず
                // 入力があればエイムする
                if (!_isAimed && Input.GetButtonDown("Jump"))
                {
                    _isAimed = true;
                    
                    // エイム処理
                    _audioSource.Play();
                    Debug.Log(gameObject);
                }
            }
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