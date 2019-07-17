using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class LerpNote: MonoBehaviour
    {
        [SerializeField] Transform _enterPos;
        [SerializeField] Transform _exitPos;
        [SerializeField] private float _k = .1f;
        
        public void Enter()
        {
            Tween.TweenPositionLerp(transform, _enterPos.position, _k);
        }
        
        public void Exit()
        {
            Tween.TweenPositionLerp(transform, _exitPos.position, _k);
        }
    }
}