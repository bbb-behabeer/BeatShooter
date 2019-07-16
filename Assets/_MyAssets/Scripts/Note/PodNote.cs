using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class PodNote: NoteBase
    {
        [SerializeField] Transform _enterPos;
        [SerializeField] Transform _exitPos;
        
        public override async void Enter()
        {
            Tween.TweenPositionLerp(transform, _enterPos.position, .1f);
        }
        
        public override async void Exit()
        {
            Tween.TweenPositionLerp(transform, _exitPos.position, .1f);
        }
    }
}