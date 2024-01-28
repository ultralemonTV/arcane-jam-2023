using ArcanepadEvents;
using ArcanepadSDK;
using ArcanepadSDK.Models;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ArcanePad _pad;

    public Rigidbody _topOfObjectRb;
    public Transform _objectMainBody;
    private Vector3 _initialPos;

    public float _speed = 15.0f;

    private bool _isXAxis = false;

    public void Initialize(ArcanePad pad)
    {
        _pad = pad;
        _initialPos = _topOfObjectRb.transform.position;

        _pad.StartGetQuaternion();
        _pad.OnGetQuaternion(new Action<GetQuaternionEvent>(RotatePad));

        _pad.On("ChangeRotationAxis", new Action<ChangeRotationAxisEvent>(ChangeRotationAxis));
    }

    private void RotatePad(GetQuaternionEvent e)
    {
        if (_isXAxis)
        {
            _topOfObjectRb.velocity = e.x * e.w * _topOfObjectRb.transform.up * _speed;
        }
        else
        {
            _objectMainBody.rotation = new Quaternion(_objectMainBody.rotation.x, _objectMainBody.rotation.y, e.z, e.w);
        }
    }

    private void ChangeRotationAxis(ChangeRotationAxisEvent e)
    {
        _isXAxis = !_isXAxis;
        if (!_isXAxis)
        {
            _topOfObjectRb.velocity = Vector3.zero;
            _topOfObjectRb.transform.position = _initialPos;
        }
    }
}
