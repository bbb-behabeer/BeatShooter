using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using Sirenix.OdinInspector;
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
        public float Range => _range;

        // 一小節の長さ
        [SerializeField] private float _duration = 1f;
        public float Duration => _duration;

        [SerializeField]
        private int _beat = 4;
        public float Beat => _beat;

        // 一拍の時間
        public float DurationPerBeat => _duration / _beat;

        // オーディオソース
        private AudioSource _audioSource;

        // 時間
        public float CurrentTime => Time.timeSinceLevelLoad % Duration;
        // 小節
        private int CurrentMeasure => Mathf.FloorToInt(Time.timeSinceLevelLoad / Duration);
        private int _cacheMeasure = -1;
        // 拍
        private int CurrentMoment => Mathf.FloorToInt(Time.timeSinceLevelLoad / DurationPerBeat) % _beat;
        private int _cacheMoment = -1;

        private List<Note> _cacheNotes = new List<Note>();

        // 楽譜
        [SerializeField] private List<int> _moments;

        [SerializeField] private Shooter _shooter;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            // 小節
            if (_cacheMeasure != CurrentMeasure)
            {
                if (CurrentMeasure % 3 == 0)
                {
                    NotesEnter();   
                }
                else if (CurrentMeasure % 3 == 2)
                {
                    NotesExit();
                }
                
                _cacheMeasure = CurrentMeasure;
            }

            // 拍
            if (_cacheMoment != CurrentMoment)
            {
                if (CurrentMeasure % 3 == 0)
                {
                    // ノートに照準をあわせる
                    Aim();
                }
                else
                {
                    // ノートにレーザーを撃つ
                    Shot();
                }
                
                _cacheMoment = CurrentMoment;
            }
        }

        /// <summary>
        /// ノートを入場させる
        /// </summary>
        private void NotesEnter()
        {
            foreach (var moment in _moments)
            {
                // ノートを生成
                var note = NoteSpawn.Instance.Spawn(moment);
                _cacheNotes.Add(note);
            }
        }

        /// <summary>
        /// ノートを退場させる
        /// </summary>
        private void NotesExit()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                note.Explode();
                _cacheNotes.Remove(note);
            }
        }

        /// <summary>
        /// 現在のモーメントをもつノートに照準を合わせる
        /// </summary>
        private void Aim()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // ノートのモーメントが現在のものとき
                if (note.Moment == CurrentMoment)
                {
                    // シューターに命令
                    // ノートに照準をあわせるように
                    _shooter.AimAt(note);
                }
            }
        }
        
        /// <summary>
        /// 現在のモーメントをもつノートにレーザーを撃つ
        /// </summary>
        private void Shot()
        {
            foreach (var note in _cacheNotes.ToArray())
            {
                // ノートのモーメントが現在のものとき
                if (note.Moment == CurrentMoment)
                {
                    // シューターに命令
                    // ノートを射撃するように
                    // ノートにエイムにしているとき
                    _shooter.ShotAt(note);
                }
            }
        }

        /// <summary>
        /// 時間を取得する
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
        public float GetTiming(float moment)
        {
            // タイミングを取得
            return DurationPerBeat * moment;
        }

        /// <summary>
        /// ヒットするか
        /// </summary>
        /// <param name="moment">拍</param>
        /// <returns></returns>
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