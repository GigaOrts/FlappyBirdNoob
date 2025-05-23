using _Scripts.Core.Monobehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core.UpDownMovementLogic
{
    public class UpDownMovementInitialization : MonoBehaviour
    {
        [SerializeField] private UpDownMovementPresentation  _upDownMovementPresentation;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            var rigidbody = _upDownMovementPresentation.GetComponent<Rigidbody2D>();
            var upDownMovement = new UpDownMovement(rigidbody);
            
            _upDownMovementPresentation.Initialize(upDownMovement);
            
            _startButton.onClick.AddListener(_upDownMovementPresentation.StopMoving);
            _restartButton.onClick.AddListener(_upDownMovementPresentation.StartMoving);
        }
    }
}