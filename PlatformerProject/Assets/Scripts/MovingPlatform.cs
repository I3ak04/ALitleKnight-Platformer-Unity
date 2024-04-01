using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _timeOfPlatformWait;
    private SliderJoint2D _sliderJoint;
    private JointMotor2D _motorJoint;
    private bool _isChangeSpeed = true;

    private void Start()
    {
        _sliderJoint = GetComponent<SliderJoint2D>();
    }

    private void FixedUpdate()
    {
        bool isUpper = _sliderJoint.limitState == JointLimitState2D.UpperLimit;
        bool isLower = _sliderJoint.limitState == JointLimitState2D.LowerLimit;

        if ((isLower || isUpper) && _isChangeSpeed)
        {
            _isChangeSpeed = false;
            StartCoroutine(TimeOfPlatformWait());
        }
    }

    private IEnumerator TimeOfPlatformWait()
    {
        yield return new WaitForSeconds(_timeOfPlatformWait);
        ChangeSpeed();
        yield return new WaitForSeconds(1);
        _isChangeSpeed = true;
    }

    private void ChangeSpeed()
    {
        _motorJoint = _sliderJoint.motor;
        _motorJoint.motorSpeed *= -1;
        _sliderJoint.motor = _motorJoint;
    }
}
