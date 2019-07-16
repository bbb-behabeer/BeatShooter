using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _MyAssets.Scripts.Note
{
    /// <summary>
    /// ノートの組
    /// </summary>
    public class NoteUnit : MonoBehaviour
    {
        // ショットモーメント
        [SerializeField] private int _shotMoment;
        public int ShotMoment => _shotMoment;

        // 退出モーメント
        [SerializeField] private int _exitMoment = 4;
        public int ExitMoment => _exitMoment;

        // 入場モーメント
        [SerializeField] private int _enterMoment = 1;
        public int EnterMoment => _enterMoment;
    }
}