using _MyAssets.Scripts.Character.Player;
using UnityEngine;

namespace _MyAssets.Scripts.Manager
{
    /// <summary>
    /// コントローラーのUI
    /// </summary>
    public class ControllerUi : MonoBehaviour
    {
        [SerializeField] private GameObject _canShotSprite;
        [SerializeField] private GameObject _canAimSprite;
        private Shooter _shooter;
        
        private SpriteRenderer _renderer;

        private void Start()
        {
            _shooter = GameObject.Find("Shooter").GetComponent<Shooter>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            if (_shooter.CanShot())
            {
                _canShotSprite.SetActive(true);
                _canAimSprite.SetActive(false);
            }
            else if (_shooter.CanAim())
            {
                _canShotSprite.SetActive(false);
                _canAimSprite.SetActive(true);
            }
            else
            {
                _canShotSprite.SetActive(false);
                _canAimSprite.SetActive(false);
            }
        }
    }
}