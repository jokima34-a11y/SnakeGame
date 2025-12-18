using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCS_Project.dataTypes
{
    class Input
    {
        KeyboardKey BindRight;
        KeyboardKey BindLeft;
        KeyboardKey BindUp;
        KeyboardKey BindDown;
        public Input(KeyboardKey BindRight = KeyboardKey.Right, KeyboardKey BindUp = KeyboardKey.Down, KeyboardKey BindLeft = KeyboardKey.Left, KeyboardKey BindDown = KeyboardKey.Up)
        {
            this.BindRight = BindRight;
            this.BindDown = BindDown;
            this.BindLeft = BindLeft;
            this.BindUp = BindUp;
        }

        public int GetHorizontal(string? Horizontal = null)
        {
            if (Horizontal != null)
            {
                if (Raylib.IsKeyDown(BindRight))
                    return 1;

                else if (Raylib.IsKeyDown(BindLeft))
                    return -1;

                else
                    return 0;
            }
            return 0;
        }

        public int GetVertical(string? Vertical = null)
        {
            if (Vertical != null)
            {
                if (Raylib.IsKeyDown(BindUp))
                    return 1;

                else if (Raylib.IsKeyDown(BindDown))
                    return -1;

                else
                    return 0;
            }
            return 0;
        }

        KeyboardKey GetKey(string keyName)
        {
            return keyName switch
            {
                "Horizontal" => BindRight,
                "Inverse_Horizontal" => BindLeft,
                "VerticalUp" => BindUp,
                "VerticalDown" => BindDown,
                _ => throw new ArgumentException("Invalid key name"),
            };
        }
    }
}
