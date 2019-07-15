using System;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class Shooter: MonoBehaviour
    {
        [SerializeField]
        private Laser _laser;
        [SerializeField]
        private Sight _sight;

        // private bool _aimed;

        private Note _target;

        // 時間
        private float _time;
        
        private void Start()
        {
            _time = 0;
        }

        private void Update()
        {
            var noteManager = NoteManager.Instance;
            
            // 時間経過
            _time += Time.deltaTime;
            _time %= noteManager.Duration;
        }

        /// <summary>
        /// ショットできるか
        /// </summary>
        /// <returns></returns>
        public bool CanShot()
        {
            var noteManager = NoteManager.Instance;
            return noteManager.CanHit(noteManager.Beat);
        }

        /// <summary>
        /// ショットする
        /// </summary>
        public void ShotAt(Note t)
        {
            // Shot内で
            // レーザーを生成する
            _laser.Shot();
        }

        /// <summary>
        /// エイムする
        /// </summary>
        /// <param name="t">ターゲット</param>
        //public void AimAt(Transform t)
        public void AimAt(Note t)
        {
            // SetTarget内で
            // 照準を生成する
            _sight.SetTarget(t);
        }
    }
}