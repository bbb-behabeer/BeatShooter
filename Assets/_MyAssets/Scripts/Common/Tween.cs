using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace _MyAssets.Scripts.Common
{
    /// <summary>
    /// Tweenクラス
    /// </summary>
    public class Tween
    {
        /// <summary>
        /// ワールド座標で移動させる
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration">秒</param>
        /// <returns></returns>
        public static void TweenPositionLiner(Transform transform, Vector3 to, float duration)
        {
            var current = 0f;
            var from = transform.position;

            transform.FixedUpdateAsObservable()
                .TakeWhile(_ => current < duration)
                .Subscribe(
                _ =>
                {
                    var pos = Vector3.Lerp(from, to, current / duration);
                    transform.position = pos;
                    current += Time.deltaTime;
                },
                () => { transform.position = to; })
                .AddTo(transform);
        }
        
        public static void TweenPositionLerp(Transform transform, Vector3 to, float k)
        {
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
                        var pos = Vector3.Lerp(from, to, Time.deltaTime * 5f);
                        transform.position = pos;
                    },
                    () => { transform.position = to; })
                .AddTo(transform);
        }
        
        /// <summary>
        /// 補完しながら移動
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <param name="pTarget"></param>
        /// <param name="duration"></param>
        public static void TweenPositionCurve(Transform transform, Vector3 to, Vector3 pStart, float duration)
        {
            var current = 0f;

            // 対象のスタート地点
            var start = transform.position;

            transform.FixedUpdateAsObservable()
                .TakeWhile(_ => current < duration)
                .Subscribe(
                    _ =>
                    {
                        var p = Vector3.Lerp(pStart, to, current / duration);
                        var pos = Vector3.Lerp(start, p, current / duration);

                        transform.position = pos;
                        current += Time.deltaTime;
                    },
                    () => { transform.position = to; })
                .AddTo(transform);
        }
    }
}