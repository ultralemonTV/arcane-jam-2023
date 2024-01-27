using ArcanepadSDK.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PadManager : MonoBehaviour
{
    public Button _calibrateQuaternionButton;

    async void Awake()
    {
        Arcane.Init(new ArcaneInitParams(deviceType: ArcaneDeviceType.pad, padOrientation: AOrientation.Portrait));
        await Arcane.ArcaneClientInitialized();

        _calibrateQuaternionButton.onClick.AddListener(() => Arcane.Pad.CalibrateQuaternion());
    }
}
