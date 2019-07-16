using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの管理
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class NoteManager: SingletonMonoBehaviour<NoteManager>
    {
        // 入力の許容範囲
        [SerializeField] private float _range;
        
        // 一小節の長さ
        public float Duration => 60f / _bpm * _beat;

        private int _beat = 4;

        [SerializeField] private int _bpm = 120;

        // 一拍の時間
        public float DurationPerBeat => Duration / _beat;

        // 時間
        public float CurrentTime => Time.timeSinceLevelLoad % Duration;
        
        // 拍
        public int CurrentMoment => Mathf.FloorToInt(CurrentTime / Duration * _beat);
        private int _cacheMoment = -1;

        private void Update()
        {
            // 拍
            if (_cacheMoment != CurrentMoment)
            {
                Debug.Log(CurrentMoment);
                // 照準
                _cacheMoment = CurrentMoment;
            }
        }

        /// <summary>
        /// 時間を取得する
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
        private float GetTiming(float moment)
        {
            // タイミングを取得
            return DurationPerBeat * moment;
        }

        /// <summary>
        /// ヒットするか
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
        public bool CanHit(int moment)
        {
            /*
            if (moment == _beat)
            {
                var start = 0;
                var end = Duration;
                return (CurrentTime < start + _range || CurrentTime > end -_range);
            }*/
            
            // タイミングを計算
            var just = GetTiming(moment);
            var min = just - _range;
            var max = just + _range;
            
            // 範囲内であればエイム可能
            return (CurrentTime > min && CurrentTime < max);
        }
    }
}