using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCutScene : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private MenuInput _menuInput;
    [SerializeField] private float _setOrthographicSizeC;
    [SerializeField] private Transform[] _cameraFollowTransform;
    [SerializeField] private string[] _dialogue;
    [SerializeField] private float[] _timeOfSkipDialogue;
    private Animator _animator;
    private float _startOrthographicSize;
    private int _changeTextMaxCount;
    private int _currentIndex = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _changeTextMaxCount = _dialogue.Length - 1;
    }

    public void ChangeText()
    {
        if (_currentIndex <= _changeTextMaxCount)
        {
            _text.text = _dialogue[_currentIndex];
            _virtualCamera.Follow = _cameraFollowTransform[_currentIndex];
            StartCoroutine(TimeOfChangeText());
        }
    }

    public void BlackLinesOn()
    {
        _playerInput.enabled = false;
        _menuInput.enabled = false;
        _playerInput.ResetHorizontalDirection();
        gameObject.SetActive(true);
        _startOrthographicSize = _virtualCamera.m_Lens.OrthographicSize;
        _virtualCamera.m_Lens.OrthographicSize = _setOrthographicSizeC;
    }

    public void BlackLinesOff()
    {
        _virtualCamera.Follow = _playerTransform.transform;
        _text.text = string.Empty;
        _animator.SetTrigger("IsEnd");
        _virtualCamera.m_Lens.OrthographicSize = _startOrthographicSize;
    }

    public void OffCutScenecanvas()
    {
        gameObject.SetActive(false);
        _playerInput.enabled = true;
        _menuInput.enabled = true;
    }

    private IEnumerator TimeOfChangeText()
    {
        yield return new WaitForSeconds(_timeOfSkipDialogue[_currentIndex]);
        
        if(_currentIndex == _changeTextMaxCount)
        {
            BlackLinesOff();
        }
        else
        {
            _currentIndex++;
            ChangeText();
        }
    }
}
