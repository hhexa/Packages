using System;
using UnityEngine;

namespace Kira.Util.InputHandler
{
    public static class InputManager
    {
        private static VirtualInput activeInput;

        // private function handles both types of axis (raw and not raw)
        private static float GetAxis(string name, bool raw)
        {
            return activeInput.GetAxis(name, raw);
        }

    }
}