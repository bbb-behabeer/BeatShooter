using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Pod: MonoBehaviour
    {
        [SerializeField]
        private Laser _laser;
        [SerializeField]
        private Sight _sight;

        private bool _aimed;

        // 時間
        private float _time;
        
        private void Start()
        {
            //_laser = GetComponentInChildren<Laser>();
            //_sight = GetComponentInChildren<Sight>();
            _time = 0;
        }

        private void Update()
        {
            var noteManager = NoteManager.Instance;
            
            // 時間経過
            _time += Time.deltaTime;
            _time %= noteManager.Duration * noteManager.BBeatPerBeat;
        }

        /// <summary>
        /// ショットできるか
        /// </summary>
        /// <returns></returns>
        public bool CanShot()
        {
            var noteManager = NoteManager.Instance;
            // 最終ラインで入力
            var just = noteManager.Duration * noteManager.BBeatPerBeat;

            // 範囲
            var start = just - noteManager.Range * 2;
            var end = just + noteManager.Range * 2;
            
            return (_time > start && _time < end);
        }

        /// <summary>
        /// ショットする
        /// </summary>
        public void Shot()
        {
            _laser.Shot();
        }

        /// <summary>
        /// エイムする
        /// </summary>
        /// <param name="t">ターゲット</param>
        public void AimAt(Transform t)
        {
            _sight.AimAt(t);
            _laser.AimAt(t);
            _aimed = true;
        }
    }
}