﻿using System;
using System.Windows.Forms;

namespace GameCreator.IDE
{
    class BackgroundGroupResourceView : IResourceView, IDeletable
    {
        string name = "new group";
        public BackgroundGroupResourceView() { }
        #region IResourceView Members

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (NameChanged != null) NameChanged(this, EventArgs.Empty);
            }
        }

        public bool CanRename
        {
            get { return true; }
        }

        public event EventHandler NameChanged;

        public bool HasSpecialAction
        {
            get { return false; }
        }

        public string SpecialActionName
        {
            get { throw new NotImplementedException(); }
        }

        public System.Drawing.Image SpecialActionImage
        {
            get { throw new NotImplementedException(); }
        }

        public void SpecialAction()
        {
            throw new NotImplementedException();
        }

        public string ImageKey
        {
            get { return "FolderClosed"; }
        }

        public string ExpandedImageKey
        {
            get { return "FolderOpen"; }
        }

        public System.Windows.Forms.TreeNode Node
        {
            get;
            set;
        }

        public bool CanEdit
        {
            get { return false; }
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public bool CanDelete
        {
            get { return true; }
        }

        public void Delete()
        {
            if (MessageBox.Show(string.Format("Are you sure you want to permanently delete all of the backgrounds in the group '{0}'?", name), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DoDelete(true);
        }

        public string InsertString
        {
            get { return "Create Background"; }
        }

        public bool CanInsert
        {
            get { return true; }
        }

        public void Insert()
        {
            BackgroundResourceView res = new BackgroundResourceView(Program.BackgroundIncremental);
            Program.Backgrounds.Add(Program.BackgroundIncremental, res);
            Program.IDE.AddResource(Node, res, "background" + Program.BackgroundIncremental++.ToString(), -1, true, false, true);
        }

        public bool CanDuplicate
        {
            get { return false; }
        }

        public void Duplicate()
        {
            throw new NotImplementedException();
        }

        public string InsertGroupString
        {
            get { return "Create Group"; }
        }

        public bool CanInsertGroup
        {
            get { return true; }
        }

        public void InsertGroup()
        {
            Program.IDE.AddResource(Node, new BackgroundGroupResourceView(), null, -1, true, true, false);
        }

        public bool CanSort
        {
            get { return true; }
        }

        public string DragDropFormat { get { return "GameCreatorBackgroundResource"; } }

        public bool AcceptsResource(IDataObject data)
        {
            return data.GetDataPresent("GameCreatorBackgroundResource") && ((IResourceView)data.GetData(typeof(IResourceView))).Node != Node;
        }

        public void DropResource(IDataObject data)
        {
            Program.IDE.MoveResource(Node, (IResourceView)data.GetData(typeof(IResourceView)), -1);
        }

        public int ResourceID { get { throw new InvalidOperationException(); } }

        #endregion

        #region IDeletable Members

        public void DoDelete(bool removenode)
        {
            foreach (TreeNode n in Node.Nodes)
                ((IDeletable)n.Tag).DoDelete(false);
            if (removenode) Node.Remove();
        }

        #endregion
    }
}
