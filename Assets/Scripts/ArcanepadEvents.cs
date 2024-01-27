using ArcanepadSDK.Models;

namespace ArcanepadEvents
{
    public class ChangeEvent : ArcaneBaseEvent
    {
        public bool _isButtonPressed;

        public ChangeEvent(bool isButtonPressed) : base("Change")
        {
            _isButtonPressed = isButtonPressed;
        }
    }
}