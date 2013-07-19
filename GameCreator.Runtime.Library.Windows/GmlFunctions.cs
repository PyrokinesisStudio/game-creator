﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.Runtime.Library.Windows
{
    public static class GmlFunctions
    {
        [GmlFunction]
        public static bool clipboard_has_text()
        {
            return Clipboard.ContainsText();
        }

        [GmlFunction]
        public static string clipboard_get_text()
        {
            return Clipboard.ContainsText() ? Clipboard.GetText() : string.Empty;
        }

        [GmlFunction]
        public static int clipboard_set_text(string str)
        {
            if (!string.IsNullOrEmpty(str))
                Clipboard.SetText(str);
            return 0;
        }
    }
}
