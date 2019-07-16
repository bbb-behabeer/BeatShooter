using System;
using System.Threading.Tasks;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class PodNote: NoteBase
    {
        [SerializeField] Transform _stayPos;
        
        private void Start()
        {
            
        }

        public override void Enter()
        {
            
            transform.position = _stayPos.position;
        }

        public async Task TweenPos()
        {
            
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}