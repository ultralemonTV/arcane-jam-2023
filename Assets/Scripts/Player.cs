using ArcanepadSDK;
using ArcanepadSDK.Models;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ArcanePad _pad;

    public void Initialize(ArcanePad pad)
    {
        _pad = pad;

        _pad.StartGetQuaternion();
        _pad.OnGetQuaternion(new Action<GetQuaternionEvent>(RotatePad));
    }

    private void RotatePad(GetQuaternionEvent e)
    {
        transform.rotation = new Quaternion(e.x, e.y, e.z, e.w);
    }
}
