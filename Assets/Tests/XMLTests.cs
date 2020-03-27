using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class XMLTests
    {
        [SetUp]
        public void setUp()
        {
            XMLHandler.resetLevelCompletion("1");
            XMLHandler.resetLevelCompletion("2");
        }
        [Test]
        public void readNumPipesFromXML()
        {
            PlayerPrefs.SetInt("currentLevel", 1);
            Assert.AreEqual(8,XMLHandler.GetNumOfPipes(true)[0]);
            Assert.AreEqual(8,XMLHandler.GetNumOfPipes(true)[1]);
        }
        
        [Test]
        public void readTargetPipesFromXML()
        {
            LevelObstacles levelObstacles = XMLHandler.getObstacleInfo(1, true);
            Tuple<float, float, float> targetPipe = levelObstacles.TargetPipes[0];
            Assert.AreEqual(18,targetPipe.Item1);
            Assert.AreEqual(-6.3f,targetPipe.Item2);
            Assert.AreEqual(0,targetPipe.Item3);
        }

        [Test]
        public void readObstaclesFromXML()
        {
            LevelObstacles levelObstacles = XMLHandler.getObstacleInfo(1, true);
            Tuple<int, float> obstacle1 = levelObstacles.Obstacles[0];
            Assert.AreEqual(10,obstacle1.Item1);
            Assert.AreEqual(45,obstacle1.Item2);
            Tuple<int, float> obstacle2 = levelObstacles.Obstacles[1];
            Assert.AreEqual(18,obstacle2.Item1);
            Assert.AreEqual(45,obstacle2.Item2);
        }
        
        [Test]
        public void readFunnelsFromXML()
        {
            LevelObstacles levelObstacles = XMLHandler.getObstacleInfo(1, true);
            Tuple<int, float> funnel1 = levelObstacles.Funnels[0];
            Assert.AreEqual(12,funnel1.Item1);
            Assert.AreEqual(0,funnel1.Item2);
        }

        [Test]
        public void readStarTimesFromXML()
        {
            List<float> starTimers = XMLHandler.GetStarTimers(true);
            Assert.AreEqual(5,starTimers[0]);
            Assert.AreEqual(10,starTimers[1]);
        }

        [Test]
        public void readMessageFromXML()
        {
            List<string> messages = XMLHandler.GetMessages(0);
            Assert.AreEqual("This is Message 1",messages[0]);
            Assert.AreEqual("This is Message 2",messages[1]);
        }

        [Test]
        public void writeLevelCompletionToXML()
        {
            PlayerPrefs.SetInt("currentLevel", 2);
            XMLHandler.WriteGameCompletion(2,"3","3:45",true);
            Assert.AreEqual("3:45",XMLHandler.GetCurrentBestTimeTaken(true));
            Assert.AreEqual(3,XMLHandler.GetStarsAcheived(2,true));
            Assert.IsTrue(XMLHandler.isLevelCompleted(2,true));
        }
        
        [Test]
        public void findCurrentLevel()
        {
            XMLHandler.resetLevelCompletion("1");
            XMLHandler.resetLevelCompletion("2");
            XMLHandler.WriteGameCompletion(1,"3","3:45",true);
            Assert.AreEqual(2,XMLHandler.findHighestLevelReached(true));
            
        }

    }
}
