using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class Controller: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Shooter _shooter;

        private int _offset = 0;

        private void FixedUpdate()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            
            var dir = new Vector2(h, v);
            
            _player.Move(dir);
            
            if (Input.GetButtonDown("Fire1"))
            {
                if (_shooter.CanShot())
                    Shot();
                else if (_shooter.CanAim())
                    Aim();
            }
        }

        private void Aim()
        {
            // 照準をあわせる
            _shooter.Aim();
        }

        private void Shot()
        {
            if (_shooter.CanShot())
                _shooter.Shot();
        }
    }
}