using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    [RequireComponent(typeof(LineRenderer))]
    
    public class AimLine: MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        [SerializeField] private Color _canAim;
        [SerializeField] private Color _canShot;
        [SerializeField] private Color _default;

        [SerializeField] private Shooter _shooter;
        
        // TODO ショットとレーザーが可能なときのみレンダリング
        private void Start()
        {
            _lineRenderer = gameObject.GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            // 色を変更する
            _lineRenderer.startColor = _lineRenderer.endColor = _default;

            var mask = LayerMask.GetMask("Note");
            var hit = Physics2D.Raycast(transform.position, Vector2.up, mask);
            
            if (hit.collider != null)
            {
                // 線を引く
                var from = transform.position;
                var to = hit.point;

                var vs = new Vector3[2];
                vs[0] = from;
                vs[1] = to;

                _lineRenderer.SetPositions(vs);

                // 色を変更する
                var c = hit.collider.gameObject.GetComponent<BeatSprite>();
                if (c.CanAim && _shooter.CanAim())
                {
                    _lineRenderer.startColor = _lineRenderer.endColor = _canAim;
                }
                else if (c.CanShot && _shooter.CanShot())
                {
                    _lineRenderer.startColor = _lineRenderer.endColor = _canShot;
                }
                
            }
            else
            {
                // 線を消す
                /*var vs = new Vector3[2];
                vs[0] = vs[1] = transform.position;
                _lineRenderer.SetPositions(vs);*/
            }
            
            
        }
    }
}