using ArcanepadSDK.Models;

namespace ArcanepadEvents
{
    public class ChangeRotationAxisEvent : ArcaneBaseEvent
    {
        public bool _isXAxis;

        public ChangeRotationAxisEvent(bool isXAxis) : base("ChangeRotationAxis")
        {
            _isXAxis = isXAxis;
        }
    }
}