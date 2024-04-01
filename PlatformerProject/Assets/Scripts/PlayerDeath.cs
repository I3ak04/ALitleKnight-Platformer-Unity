using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _diedCanvas;
    [SerializeField] private string _ignoreLayerName;
    private PlayerInput _playerInput;
    private Transform[] _gameObjectsInPlayer;
    private bool _isPlayerAlive = true;

    private void Start()
    {
        _gameObjectsInPlayer = gameObject.GetComponentsInChildren<Transform>();
    }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void SpawnDieCanvas()
    {
        if(_isPlayerAlive)
        {
            _playerInput.enabled = false;
            gameObject.layer = LayerMask.NameToLayer(_ignoreLayerName);

            foreach(Transform gameObj in _gameObjectsInPlayer)
            {
                gameObj.gameObject.layer = LayerMask.NameToLayer(_ignoreLayerName);
            }

            Instantiate(_diedCanvas);
            _isPlayerAlive = false;
        }
    }
}
