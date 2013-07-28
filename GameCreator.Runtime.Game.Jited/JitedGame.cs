﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;
using GameCreator.Framework.Gml.Compiler.Clr;

namespace GameCreator.Runtime.Game.Jited
{
    public static class JitedGame
    {
        static DotNetCompiler compiler;

        public static void Run()
        {
            try
            {
                compiler = new DotNetCompiler(LibraryContext.Current, @"game.exe");

                compiler.InitCompiler();

                compiler.CompileScripts();
                compiler.CompileRooms();

                compiler.Save();

                Game.InitRoom += new Action<Room>(Game_InitRoom);

                //Game.Run();
            }
            catch (ProgramError err)
            {
                int line = 0, col = 0;

                string msg = string.Format("ERROR in code at line {0} pos {1}:\n{2}", line, col, err.Message);
                switch (err.Location)
                {
                    case CodeLocation.Script:
                        msg = string.Format("COMPILAION ERROR in Script:\nError in code at line {0}:\n\n\nat position {1}: {2}", line, col, err.Message);
                        break;
                }
                System.Windows.Forms.MessageBox.Show(msg, Game.Name, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void Initialize()
        {
            LibraryContext.Current = new LibraryContext(new JitedGameLibraryInitializer());

            Game.Init();
        }

        static void Game_InitRoom(Room room)
        {
            var roomInitialization = compiler.Rooms[room.Id];

            roomInitialization();
        }
    }
}
