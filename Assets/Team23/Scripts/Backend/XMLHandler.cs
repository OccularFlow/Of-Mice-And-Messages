﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
public static class XMLHandler
{
  public static LevelObstacles getObstacleInfo(int levelRequired, bool testMode)
  {
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
      
    }
    catch (System.IO.FileNotFoundException)
    {
      List<Tuple<float, float, float>> targetPipesList = new List<Tuple<float, float, float>>();
      Tuple<float, float, float> targetPipeDet = new Tuple<float, float, float>(18f, -6.3f, 0f);
      targetPipesList.Add(targetPipeDet);
      
      List<Tuple<int,float>> obstaclesList = new List<Tuple<int, float>>();
      Tuple<int, float> obstacleDet = new Tuple<int, float>(10, 45);
      obstaclesList.Add(obstacleDet);
      
      List<Tuple<int,float>> funnelsList = new List<Tuple<int, float>>();
      Tuple<int, float> funnelDet = new Tuple<int, float>(5, 0);
      funnelsList.Add(funnelDet);
      
      List<Tuple<int,int>> obsIPipesList = new List<Tuple<int, int>>();
      Tuple<int, int> obsIDet = new Tuple<int, int>(18, 0);
      obsIPipesList.Add(obsIDet);
      
      List<Tuple<int,int>> obsLPipesList = new List<Tuple<int, int>>();
      Tuple<int, int> obsLDet = new Tuple<int, int>(19, 0);
      obsLPipesList.Add(obsLDet);
      
      return new LevelObstacles(targetPipesList, obstaclesList,funnelsList, obsIPipesList, obsLPipesList);
      
    }

    XmlNode root = xmlDocument.LastChild;
    List<LevelObstacles> levels = new List<LevelObstacles>();
    
    foreach (XmlNode childNode in root.ChildNodes)
    {
      int levelName = Int32.Parse(childNode.Attributes["name"].Value);
      if (levelName != levelRequired) {
        continue;
      }
      
      List<Tuple<float, float, float>> targetPipes = new List<Tuple<float, float, float>>();
      foreach (XmlNode targetPipe in childNode["targetPipes"].ChildNodes)
      {
        Tuple<float, float, float> targetPipeDetails = new Tuple<float, float, float>(
          float.Parse(targetPipe["targetXPosition"].InnerText),
          float.Parse(targetPipe["targetYPosition"].InnerText),
          float.Parse(targetPipe["targetRotation"].InnerText));
        targetPipes.Add(targetPipeDetails);
      }

      List<Tuple<int,float>> obstacles = new List<Tuple<int, float>>();
      foreach (XmlNode obstacle in childNode["obstacles"].ChildNodes)
      {
        Tuple<int,float> obstacleDetails = new Tuple<int, float>(
          Int32.Parse(obstacle["gridBlockID"].InnerText),
          float.Parse(obstacle["obstacleRotation"].InnerText));
        obstacles.Add(obstacleDetails);
      }
      
      List<Tuple<int,float>> funnels = new List<Tuple<int, float>>();
      foreach (XmlNode funnel in childNode["funnels"].ChildNodes)
      {
        Tuple<int,float> funnelDetails = new Tuple<int, float>(
          Int32.Parse(funnel["gridBlockID"].InnerText),
          float.Parse(funnel["funnelRotation"].InnerText));
        funnels.Add(funnelDetails);
      }

      List<Tuple<int,int>> obsIPipes = new List<Tuple<int, int>>();
      foreach (XmlNode obsIPipe in childNode["obsIPipes"].ChildNodes)
      {
        Tuple<int,int> obsDetails = new Tuple<int, int>(
          Int32.Parse(obsIPipe["gridBlockID"].InnerText),
          Int32.Parse(obsIPipe["obstacleRotation"].InnerText));
        obsIPipes.Add(obsDetails);
      }

      List<Tuple<int,int>> obsLPipes = new List<Tuple<int, int>>();
      foreach (XmlNode obsIPipe in childNode["obsLPipes"].ChildNodes)
      {
        Tuple<int,int> obsDetails = new Tuple<int, int>(
          Int32.Parse(obsIPipe["gridBlockID"].InnerText),
          Int32.Parse(obsIPipe["obstacleRotation"].InnerText));
        obsLPipes.Add(obsDetails);
      }
      return new LevelObstacles(targetPipes, obstacles,funnels, obsIPipes, obsLPipes);
    }
    return null;
  }

  public static List<string> GetMessages() {
    return GetMessages(PlayerPrefs.GetInt("currentLevel"));
  }
  public static List<string> GetMessages(int requestedLevelint) {
    string requestedLevel = requestedLevelint.ToString();
    XmlDocument xmlDocument = new XmlDocument();
    List<string> messages = new List<string>();
    try
    {
      xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "messages.xml"));
    }
    catch
    {
      messages.Add("Error: Message not Found");
      messages.Add("None");
      return messages;
    }
    messages.Add(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/message", requestedLevel)).InnerText);
    messages.Add(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/message2", requestedLevel)).InnerText);
    
    return messages;
  }

  public static List<int> GetNumOfPipes(bool testMode)
  {
    string currentLevel = PlayerPrefs.GetInt("currentLevel").ToString();
    return GetNumOfPipes(currentLevel, testMode);
  }
  public static List<int> GetNumOfPipes(string requestedLevel, bool testMode) {
    XmlDocument xmlDocument = new XmlDocument();
    List<int> numOfPipes = new List<int>();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      numOfPipes.Add(8);
      numOfPipes.Add(8);
      return numOfPipes;
    }
    numOfPipes.Add(Int32.Parse(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/numberOfIPipes", requestedLevel)).InnerText));
    numOfPipes.Add(Int32.Parse(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/numberOfLPipes", requestedLevel)).InnerText));
    
    return numOfPipes;
  }

  public static string GetCurrentBestTimeTaken(bool testMode)
  {
    int currentLevel = PlayerPrefs.GetInt("currentLevel");
    return GetCurrentBestTimeTaken(currentLevel, testMode);
  }
  public static string GetCurrentBestTimeTaken(int currentLevelInt, bool testMode) {
    string currentLevel = currentLevelInt.ToString();
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      return "00:00";
    }
    return xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/timeTaken", currentLevel)).InnerText;
  }

  public static int GetStarsAcheived(int currentLevelInt, bool testMode) {
    string currentLevel = currentLevelInt.ToString();
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      return 3;
    }
    return Int32.Parse(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/stars", currentLevel)).InnerText);
  }

  public static List<float> GetStarTimers(bool testMode)
  {
    int currentLevel = PlayerPrefs.GetInt("currentLevel");
    return GetStarTimers(currentLevel, testMode);
  }
  
  public static List<float> GetStarTimers(int currentLevelInt, bool testMode)
  {
    string currentLevel = currentLevelInt.ToString();
    XmlDocument xmlDocument = new XmlDocument();
    List<float> starTimers = new List<float>();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      starTimers.Add(90f);
      starTimers.Add(180f);
      return starTimers;
    }
    starTimers.Add(float.Parse(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/threeStarTime", currentLevel)).InnerText));
    starTimers.Add(float.Parse(xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/twoStarTime", currentLevel)).InnerText));
    
    return starTimers;
  }

  public static bool isLevelCompleted(int currentLevelInt, bool testMode)
  {
    string currentLevel = currentLevelInt.ToString();
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      return false;
    }

    if (xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/complete", currentLevel)).InnerText ==
        "Yes")
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public static void WriteGameCompletion(int currentLevelInt, string starsAchieved, string timeTaken, bool testMode)
  {
    string currentLevel = currentLevelInt.ToString();
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      return;
    }

    xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/complete", currentLevel)).InnerText = "Yes";
    xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/stars", currentLevel)).InnerText =
      starsAchieved;
    xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/timeTaken", currentLevel)).InnerText =
      timeTaken;
    if (!testMode)
    {
      xmlDocument.Save(Path.Combine(Application.streamingAssetsPath, "level.xml"));
    }
    else
    {
      xmlDocument.Save(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
    }
  }

  public static int findHighestLevelReached(bool testMode)
  {
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      if (!testMode)
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "level.xml"));
      }
      else
      {
        xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
      }
    }
    catch
    {
      return 0;
    }

    if (xmlDocument.SelectSingleNode("//levels/level[complete[contains(text(), 'No')]]") != null)
    {
      string levelName = xmlDocument.SelectSingleNode("//levels/level[complete[contains(text(), 'No')]]").Attributes["name"].Value;
      return Int32.Parse(levelName);
    }
    else
    {
      return 31;
    }
  }
  
  // for testing purposes so will only write to testLevel.xml
  public static void resetLevelCompletion(string currentLevel)
  {
    XmlDocument xmlDocument = new XmlDocument();
    try
    {
      xmlDocument.Load(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
    }
    catch
    {
      return;
    }
    xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/complete", currentLevel)).InnerText = "No";
    xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/timeTaken", currentLevel)).InnerText = "0:00";
    xmlDocument.SelectSingleNode(String.Format("levels/level[@name='{0}']/stars", currentLevel)).InnerText = "0";
    xmlDocument.Save(Path.Combine(Application.streamingAssetsPath, "testLevel.xml"));
  }
}
