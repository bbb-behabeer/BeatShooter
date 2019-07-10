using System.Collections.Generic;
using _MyAssets.Scripts.Character.Note;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの管理
    /// </summary>
    public class NoteManager: MonoBehaviour
    {
        [SerializeField] private Part part;
        
        // 各パートのノート配列
        private List<AudioClip> _noteList;

        // 各パートの再生フラグ
        private bool _playable = false;
        // 各パートのスキップフラグ
        private bool _skipable = false;

        // 各パートのオーディオソース
        private AudioSource _audioSource;
        
        // ボリュームUI
        [SerializeField] private Animator _volumeUI;
        
        // ボリューム
        [SerializeField] private float _volumeMax = 1f;
        [SerializeField] private float _volumeMin = 0.5f;
        
        // ノート配列のオフセット
        private int _offset;

        [Button("Start")]
        private void Start()
        {
            // オフセットを初期化する
            _offset = 0;
            
            // オーディオクリップを読み込む
            _noteList = new List<AudioClip>(Resources.LoadAll<AudioClip>("Sounds/" + part.ToString()));
            
            // オーディオソースを設定
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
        }

        /// <summary>
        /// オーディオクリップを再生する
        /// </summary>
        [Button("PlayClip")]
        public void PlayClip()
        {
            // 曲が終了していたら処理をしない
            if (_offset >= _noteList.Count) return;
            
            _audioSource.PlayOneShot(_noteList[_offset]);
            
            if (_playable)
            {
                // 再生可能のとき
                // ノートを再生する
                //_audioSource.clip = _noteList[_offset];
                _volumeUI.Play("VolumePlaying");
                
                // ボリュームを最大に
                _audioSource.volume = _volumeMax;
                
                // オフセットを増やす
                _offset++;
                
                // スキップ可能に
                _skipable = true;
                // 再生不可能に
                _playable = false;
            }
            else if (_skipable)
            {
                // オフセットを増やす
                _offset++;
                // スキップ不可能に
                _skipable = false;
                // 再生可能に
                _playable = true;

                // ボリュームを下げる
                _audioSource.volume = _volumeMin;
            }
        }

        /// <summary>
        /// ノートを再生可能に設定する
        /// </summary>
        public void SetPlayable()
        {
            // 再生可能に設定
            _playable = true;
            // 再生可能のときスキップ不可能
            _skipable = false;
        }
        
        /// <summary>
        /// ノートをスキップ可能に設定する
        /// </summary>
        public void SetSkippable()
        {
            // 再生不可能に設定
            _playable = false;
            // 再生不可能のときスキップ可能
            _skipable = true;
        }
    }
}