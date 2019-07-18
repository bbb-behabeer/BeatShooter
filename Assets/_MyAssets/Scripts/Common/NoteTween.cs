using System.Threading.Tasks;
using _MyAssets.Scripts.Note;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// NoteSetterに合わせたTweenクラス
    /// </summary>
    public static class NoteTween
    {
        /// <summary>
        /// Toまで移動
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        private static void TweenPosition(Transform transform, Vector3 to)
        {
            var k = .1f;
            var t = 5f;
            
            transform.FixedUpdateAsObservable()
                .TakeWhile(_ =>
                {
                    var diff = transform.position - to;
                    return diff.magnitude > k;
                })
                .Subscribe(
                    _ =>
                    {
                        var from = transform.position;
                        var pos = Vector3.Lerp(from, to, Time.deltaTime * t);
                        transform.position = pos;
                    },
                    () => { transform.position = to; })
                .AddTo(transform);
        }
        
        /// <summary>
        /// Axisの位置に移動
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="axis"></param>
        public static void TweenPositionWithAxis(Transform transform, Vector2 origin, Vector2 axis)
        {
            var pos = NoteSetter.Instance.GetPosWithAxis(axis);
            pos += origin;
            TweenPosition(transform, pos);
        }

    }
}