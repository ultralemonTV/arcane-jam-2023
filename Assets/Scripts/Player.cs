using ArcanepadEvents;
using ArcanepadSDK;
using ArcanepadSDK.Models;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ArcanePad _pad;

    public Transform _topOfObject;
    public Transform _objectMainBody;

    public float _minPositionThreshold = -0.1f;
    public float _maxPositionThreshold = 0.1f;
    public float _movementMultiplier = 1.0f;

    private bool _isButtonPressed = false;

    public void Initialize(ArcanePad pad)
    {
        _pad = pad;

        _pad.StartGetQuaternion();
        _pad.OnGetQuaternion(new Action<GetQuaternionEvent>(RotatePad));

        _pad.On("Change", new Action<ChangeEvent>(ChangeButtonState));
    }

    private void RotatePad(GetQuaternionEvent e)
    {
        //if (e.x > _minPositionThreshold || e.x < _maxPositionThreshold)
        if (_isButtonPressed)
            _topOfObject.position += _topOfObject.up * e.x * _movementMultiplier;
            //_topOfObject.position = new Vector3(_topOfObject.position.x, e.x * _movementMultiplier, _topOfObject.position.z);

        if (!_isButtonPressed)
        _objectMainBody.rotation = new Quaternion(_objectMainBody.rotation.x, _objectMainBody.rotation.y, e.z, e.w);
    }

    private void ChangeButtonState(ChangeEvent e)
    {
        _isButtonPressed = !_isButtonPressed;
    }
}
