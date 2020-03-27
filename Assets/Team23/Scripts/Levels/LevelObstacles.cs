using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacles
{
    private List<Tuple<float, float, float>> targetPipes;
    private List<Tuple<int,float>> obstacles;
    private List<Tuple<int,float>> funnels;
    private List<Tuple<int,int>> obsIPipes;
    private List<Tuple<int,int>> obsLPipes;
    public LevelObstacles( List<Tuple<float, float, float>> targetPipes, List<Tuple<int, float>> obstacles, List<Tuple<int, float>> funnels, List<Tuple<int,int>> obsIPipes,
        List<Tuple<int,int>> obsLPipes)
    {
        this.targetPipes = targetPipes;
        this.obstacles = obstacles;
        this.funnels = funnels;
        this.obsIPipes = obsIPipes;
        this.obsLPipes = obsLPipes;
    }
    public List<Tuple<float, float, float>> TargetPipes
    {
        get => targetPipes;
        set => targetPipes = value;
    }

    public List<Tuple<int, float>> Obstacles
    {
        get => obstacles;
        set => obstacles = value;
    }

    public List<Tuple<int, float>> Funnels
    {
        get => funnels;
        set => funnels = value;
    }

    public List<Tuple<int, int>> ObsIPipes
    {
        get => obsIPipes;
        set => obsIPipes = value;
    }

    public List<Tuple<int, int>> ObsLPipes
    {
        get => obsLPipes;
        set => obsLPipes = value;
    }
}
