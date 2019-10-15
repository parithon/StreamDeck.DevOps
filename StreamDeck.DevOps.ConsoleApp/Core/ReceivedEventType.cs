using System;
using System.Collections.Generic;
using System.Text;

namespace StreamDeck.DevOps.ConsoleApp.Core
{
    public enum ReceivedEventType
    {
        didReceiveSettings,
        didReceiveGlobalSettings,
        keyDown,
        keyUp,
        willAppear,
        willDisappear,
        titleParametersDidChange,
        deviceDidConnect,
        deviceDidDisconnect,
        applicationDidLaunch,
        applicationDidTerminate,
        systesmDidWakeUp,
        propertyInspectorDidAppear,
        propertyInspectorDidDisappear,
        sendToPlugin,
        sendToPropertyInspector,
        unknown = 9999
    }
}
