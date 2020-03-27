using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    // private List<Level> levels;
    private LevelObstacles level;
    [SerializeField] private GameObject newFinishPipe;
    [SerializeField] private GameObject branchObstacle;
    [SerializeField] private GameObject obsIPipe;
    [SerializeField] private GameObject obsLPipe;
    [SerializeField] private GameObject funnel;
    private List<Tuple<float, float, float>> targetPipes; 
    private List<Tuple<int, float>> obstacles;
    private List<Tuple<int, float>> funnels;
    private List<Tuple<int, int>> obsIPipes;
    private List<Tuple<int, int>> obsLPipes;
    private GridBlock[] gridBlocks;
    public void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        level = XMLHandler.getObstacleInfo(currentLevel,false);
        targetPipes = level.TargetPipes;
        obstacles = level.Obstacles;
        funnels = level.Funnels;
        obsIPipes = level.ObsIPipes;
        obsLPipes = level.ObsLPipes;
  
        foreach (Tuple<float,float,float> targetPipe in targetPipes)
        {
            Instantiate(newFinishPipe, new Vector3(targetPipe.Item1, targetPipe.Item2, 0),
                Quaternion.Euler(0, 0, targetPipe.Item3));
        }

        gridBlocks = FindObjectsOfType<GridBlock>();
        
        foreach (Tuple<int,float> obstacle in obstacles)
        {
            foreach (GridBlock gridBlock in gridBlocks)
            {
                if (obstacle.Item1 == gridBlock.getID())
                {
                    Vector3 gridBlockPosition = gridBlock.transform.position;
                    Instantiate(branchObstacle, new Vector4(gridBlockPosition.x,
                            gridBlockPosition.y,gridBlockPosition.z),
                    Quaternion.Euler(0,0,obstacle.Item2));
                    gridBlock.deactivate();
                }
            }
        }
        
        foreach (Tuple<int,float> funnelItem in funnels)
        {
            foreach (GridBlock gridBlock in gridBlocks)
            {
                if (funnelItem.Item1 == gridBlock.getID())
                {
                    Vector3 gridBlockPosition = gridBlock.transform.position;
                    Instantiate(funnel, new Vector3(gridBlockPosition.x,
                            gridBlockPosition.y,gridBlockPosition.z),
                        Quaternion.Euler(0,0,funnelItem.Item2));
                     gridBlock.deactivate();
                }
            }
        }

        foreach (Tuple<int,int> obsIPipeItem in obsIPipes)
        {
            foreach (GridBlock gridBlock in gridBlocks)
            {
                if (obsIPipeItem.Item1 == gridBlock.getID())
                {
                    GameObject pipe = Instantiate(obsIPipe);
                    pipe.transform.position = gridBlock.transform.position;
                    IPipeObs pipeScript = pipe.GetComponent<IPipeObs>();
                    for(int i = 0; i < obsIPipeItem.Item2; i+=90) {
                        pipeScript.rotateClockwise();
                    }
                     gridBlock.deactivate();
                }
            }
        }

        foreach (Tuple<int,int> obsLPipeItem in obsLPipes)
        {
            foreach (GridBlock gridBlock in gridBlocks)
            {
                if (obsLPipeItem.Item1 == gridBlock.getID())
                {
                    GameObject pipe = Instantiate(obsLPipe);
                    pipe.transform.position = gridBlock.transform.position;
                    LPipeObs pipeScript = pipe.GetComponent<LPipeObs>();
                    for(int i = 0; i < obsLPipeItem.Item2; i+=90) {
                        pipeScript.rotateClockwise();
                    }
                     gridBlock.deactivate();
                }
            }
        }
    
        if (SceneManager.GetActiveScene().name == "eye 6") {
            foreach (GridBlock gridBlock in gridBlocks)
            {
                gridBlock.deactivate();
            }
        }
        
        
    }
}
