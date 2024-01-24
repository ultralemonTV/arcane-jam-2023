using ArcanepadSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ArcanePad _pad;

    public void Initialize(ArcanePad pad)
    {
        this._pad = pad;
    }
}
