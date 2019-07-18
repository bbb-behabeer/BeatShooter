using System;
using System.Threading.Tasks;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Note
{
    public class PodNote: MonoBehaviour
    {
        [SerializeField] private Vector2 _enter;
        [SerializeField] private Vector2 _exit;

        Vector2 _origin = new Vector2(0, 100);
        //[SerializeField] private Transform _origin;
        
        public void Enter()
        {
            Tween(_enter);
        }
        
        public void Exit()
        {
            Tween(_exit);
        }
        
        private void Tween(Vector2 axis)
        {
            NoteTween.TweenPositionWithAxis(transform, _origin, axis);
        }
    }
}