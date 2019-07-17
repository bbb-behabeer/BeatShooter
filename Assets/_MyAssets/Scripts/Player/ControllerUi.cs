using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    /// <summary>
    /// コントローラーのUI
    /// </summary>
    public class ControllerUi : MonoBehaviour
    {
        [SerializeField] private GameObject _canShotSprite;
        [SerializeField] private GameObject _canAimSprite;
        [SerializeField] private GameObject _defaultSprite;
        private Shooter _shooter;
        
        private SpriteRenderer _renderer;

        public bool CanShot => _canShotSprite != null;
        public bool CanAim => _canAimSprite != null;
        
        private void Start()
        {
            _shooter = GameObject.Find("Shooter").GetComponent<Shooter>();
        }

        private void FixedUpdate()
        {
            
            if (_canShotSprite != null)
                _canShotSprite.SetActive(false);
            if (_canAimSprite != null)
                _canAimSprite.SetActive(false);
            if (_defaultSprite != null)
                _defaultSprite.SetActive(false);
            
            if (_shooter.CanShot() && _canShotSprite != null)
            {
                _canShotSprite.SetActive(true);;
            }
            else if (_shooter.CanAim() && _canAimSprite != null)
            {
                _canAimSprite.SetActive(true);
            }
            else if (_defaultSprite != null)
            {
                _defaultSprite.SetActive(true);
            }
        }
    }
}