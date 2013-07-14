﻿using GameCreator.Framework;
using GameCreator.Runtime.Game;
using GameCreator.Framework.Gml.Interpreter;

namespace GameCreator.RuntimeTest
{
    static class Program
    {
        static void Main()
        {
            // Initialize the runtime engine
            Game.Init();

            var lib = new LibraryContext();
            

            // Define action libraries
            lib.GetActionLibrary(1).DefineAction(100, ActionKind.Normal, ActionExecutionType.Function, false, "action_create_object", string.Empty, new ActionArgumentType[] { ActionArgumentType.Object, ActionArgumentType.Expression, ActionArgumentType.Expression });
            lib.GetActionLibrary(1).DefineAction(101, ActionKind.Code, ActionExecutionType.Function, false, "execute_string", string.Empty, new ActionArgumentType[] { ActionArgumentType.String });
            lib.GetActionLibrary(1).DefineAction(102, ActionKind.Normal, ActionExecutionType.Function, false, "show_message", string.Empty, new ActionArgumentType[] { ActionArgumentType.String });
            lib.GetActionLibrary(1).DefineAction(103, ActionKind.Normal, ActionExecutionType.Function, false, "action_move", string.Empty, new ActionArgumentType[] { ActionArgumentType.String, ActionArgumentType.Expression });
            // Define scripts
            lib.Resources.Scripts.Define("scr_main", "instance_create(0,0,0)");
            // Define objects
            lib.Resources.Objects.Define().DefineEvent((int)EventType.Create, 0).DefineAction(1, 100, new string[] { "1", "0", "0" }, -1, false, false);
            Event ev = lib.Resources.Objects.Define().DefineEvent((int)EventType.Create, 0);
            ev.DefineAction(1, 103, new string[] { "000000001", "4" }, -1, false, false);
            ev.DefineAction(1, 101, new string[] { "show_message(string(hspeed))" }, -1, false, false);
            // Define rooms
            lib.Resources.Rooms.Define().CreationCode = "scr_main()";
            // Run the game
            Game.Run();
        }
    }
}
