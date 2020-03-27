using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GMTests
    {
        
        DockLevelGameManager gameManager;
        [SetUp]
        public void setup() {
            PlayerPrefs.SetInt("currentLevel", 0);
            GameObject gameObject = new GameObject();
            GameObject IPipe = new GameObject();
            IPipe.AddComponent<IPipe>();
            IPipe.tag = "StraightPipe";
            GameObject LPipe = new GameObject();
            LPipe.AddComponent<IPipe>();
            LPipe.tag = "LPipe";
            gameObject.AddComponent<Dock>();
            gameObject.AddComponent<ButtonManager>();
            gameManager = gameObject.AddComponent<DockLevelGameManager>();
        }
        [Test]
        public void ifWaterRunningGridUnselectable()
        {
            Pipe pipe = new GameObject().AddComponent<IPipe>();
            Assert.True(gameManager.isGridNotSelectable(true,pipe));
        }

        [Test]
        public void ifNoPipeSelectedGridUnselectable()
        {
            Assert.True(gameManager.isGridNotSelectable(false,null));
        }
        
        [Test]
        public void ifWaterNotRunningGridSelectable()
        {
            Pipe pipe = new GameObject().AddComponent<IPipe>();
            Assert.False(gameManager.isGridNotSelectable(false,pipe));
        }

        [Test]
        public void ifWaterRunningPipeSelectedGridSelectable()
        {
            Pipe pipe = new GameObject().AddComponent<IPipe>();
            Assert.True(gameManager.isGridNotSelectable(true,pipe));
        }
        
       
    }
}
