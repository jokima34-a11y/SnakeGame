using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCS_Project.dataTypes
{
    class Input
    {
        KeyboardKey Horizontal_Bind;
        KeyboardKey Inverse_Horizontal;
        KeyboardKey Vertical_Bind;
        public Input(KeyboardKey Horizontal = KeyboardKey.W, KeyboardKey Vertical = KeyboardKey.Space, KeyboardKey inverse_Horizontal = KeyboardKey.S)
        {
            Horizontal_Bind = Horizontal;
            Vertical_Bind = Vertical;
            Inverse_Horizontal = inverse_Horizontal;
        }

        public int GetAxis(string? Horizontal = null, string? Vertical = null)
        {
            if (Horizontal != null)
            {
                if (Raylib.IsKeyDown(Horizontal_Bind))
                    return 1;

                else if (Raylib.IsKeyDown(Inverse_Horizontal))
                    return -1;

                else
                    return 0;
            }

            if (Vertical != null)
            {
                if (Raylib.IsKeyDown(Vertical_Bind))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        KeyboardKey GetKey(string keyName)
        {
            return keyName switch
            {
                "Horizontal" => Horizontal_Bind,
                "Inverse_Horizontal" => Inverse_Horizontal,
                "Vertical" => Vertical_Bind,
                _ => throw new ArgumentException("Invalid key name"),
            };
        }
    }
}
