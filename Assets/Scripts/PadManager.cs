using ArcanepadExample;
using ArcanepadSDK.Models;
using ArcanepadSDK.Types;
using UnityEngine;
using UnityEngine.UI;

public class PadManager : MonoBehaviour
{
    public Button _calibrateQuaternionButton;
    public Button _changeButton;

    async void Awake()
    {
        Arcane.Init(new ArcaneInitParams(deviceType: ArcaneDeviceType.pad, padOrientation: AOrientation.Portrait));
        await Arcane.ArcaneClientInitialized();

        _calibrateQuaternionButton.onClick.AddListener(() => Arcane.Pad.CalibrateQuaternion());
        _changeButton.onClick.AddListener(() => AddArcaneBaseEvent("Change"));
    }

    public void AddArcaneBaseEvent(string name)
    {
        Arcane.Msg.EmitToViews(new ArcaneBaseEvent(name));
    }
}
