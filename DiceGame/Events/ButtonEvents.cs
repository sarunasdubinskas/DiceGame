using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame.Events
{
    public delegate void OnButtonEvent(int v);

    //bandau suprast iš kurios klasės kaip sukurt buttoną, kad galėčiau kaip delegatą panaudot OnButtonPick... 
    class ButtonEvents
    {
    }
}
