﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    partial class FontEditor : Form
    {
        public FontEditor()
        {
            InitializeComponent();
        }

        bool modified = false;
        public bool Modified
        {
            get { return modified; }
            set { modified = value; if (value) Program.GameModified = true; }
        }
        public event EventHandler Save;

        private void FontEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified)
                switch (MessageBox.Show("Save changes to the font?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        Save(this, EventArgs.Empty);
                        Modified = false;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
        }
    }
}
