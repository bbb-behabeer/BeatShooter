using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using _MyAssets.Scripts.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの管理
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class NoteManager: MonoBehaviour
    {
        private static NoteManager _instance = null;

        public static NoteManager Instance => _instance;
        
        // 入力の許容範囲
        [SerializeField] private float _range;
        public float Range => _range;

        // 一小節の長さ
        [SerializeField] private float _duration = 1f;
        public float Duration => _duration;

        [SerializeField]
        private float _beat = 4;
        public float Beat => _beat;

        // 一拍の時間
        public float DurationPerBeat => _duration / _beat;

        // オーディオソース
        private AudioSource _audioSource;

        public float CurrentTime => Time.timeSinceLevelLoad % (Duration * 2);

        public float StartMoment => _beat / 2f;
        public float EndMoment => _beat + StartMoment;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySE(AudioClip clip)
        {
            //_audioSource.PlayOneShot(clip);
        }

        public float GetPosWithMoment(float moment)
        {
            // 縦幅を取得
            var h = NoteScreen.Height;
            var k = NoteScreen.K;
            
            // 位置を計算
            var m = StartMoment + moment;
            var ny = GetPosWithTime(m * DurationPerBeat);

            return ny;
        }
        
        public float GetPosWithTime(float time)
        {
            // 縦幅を取得
            var h = NoteScreen.Height;
            var k = NoteScreen.K;
            
            var t = time / Duration;
            
            // 位置を計算
            var ny = h * t * k;

            return ny;
        }

        public float GetPos()
        {
            return GetPosWithTime(CurrentTime);
        }

        public float GetTiming(float moment)
        {
            // タイミングを取得
            return DurationPerBeat * (moment + StartMoment);
        }

        public bool CanHit(float moment)
        {
            // タイミングを計算
            var just = GetTiming(moment);
            var min = just - Range;
            var max = just + Range;
            
            // 範囲内であればエイム可能
            return (CurrentTime > min && CurrentTime < max);
        }
    }
}