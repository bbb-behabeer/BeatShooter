using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class CurveNote: MonoBehaviour
    {
        [SerializeField] Transform _enterPos;
        [SerializeField] Transform _exitPos;
        [SerializeField] private float _pDuration;
        [SerializeField] private float _duration;
        
        public void Enter()
        {
            Tween.TweenPositionCurve(
                transform,
                _exitPos.position,
                _enterPos.position,
                _pDuration,
                _duration);
        }
        
        public void Exit()
        {
        }
    }
}