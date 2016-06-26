﻿using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Contracts;

namespace GameCreator.Projects
{
    public class Gm6ProjectType : IProjectType, IGmFileProjectType
    {
        public string Description
        {
            get
            {
                return "Game Maker 6 Files";
            }
        }

        public string Extension
        {
            get
            {
                return "gm6";
            }
        }

        public bool IsSingleFile
        {
            get
            {
                return true;
            }
        }

        public GmVersion SpecificVersion { get; set; }

        public IEnumerable<GmVersion> Versions
        {
            get
            {
                return new[]
                {
                    GmVersion.Version6_0,
                    GmVersion.Version6_1
                };
            }
        }

        public void LoadProject(IProject project, string location)
        {
            (new GmFileProjectType(SpecificVersion)).LoadProject(project, location);
        }

        public void SaveProject(IProject project, string location)
        {
            (new GmFileProjectType(SpecificVersion)).SaveProject(project, location);
        }
    }
}