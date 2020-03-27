using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public enum PipeTypes
{
    Straight = 0,
    L = 1
}

public class Dock : MonoBehaviour {
    private Dictionary<PipeTypes,int> noOfPipesOnDock;
    private GameObject LPipe;
    private GameObject StraightPipe;

    [SerializeField] private TextMeshProUGUI textLcount;
    [SerializeField] private TextMeshProUGUI textIcount;
     
    void Awake() {
        noOfPipesOnDock = new Dictionary<PipeTypes, int>();
        LPipe = GameObject.FindGameObjectWithTag("LPipe");
        StraightPipe = GameObject.FindGameObjectWithTag("StraightPipe");
        LPipe.SetActive(false);
        StraightPipe.SetActive(false); 
        List<int> numOfPipes = XMLHandler.GetNumOfPipes(false);
        if (numOfPipes[0] > 0) {
            addPipe(PipeTypes.Straight, numOfPipes[0]);
        }
        if (numOfPipes[1] > 0) {
            addPipe(PipeTypes.L, numOfPipes[1]);
        }
    }

    private void updateLPipeCounter() {
        if (noOfPipesOnDock.ContainsKey(PipeTypes.L)) {
            int Lcount = noOfPipesOnDock[PipeTypes.L];
            textLcount.SetText(Lcount.ToString());
        }
        else {
            textLcount.SetText("0");
        }
    }

    private void updateIPipeCounter() {
        if (noOfPipesOnDock.ContainsKey(PipeTypes.Straight)) {
            int Icount = noOfPipesOnDock[PipeTypes.Straight];
            textIcount.SetText(Icount.ToString());
        }
        else {
            textIcount.SetText("0");
        }
    }

    
    public Pipe removePipe(Pipe pipe) {
        GameObject newPipe = Instantiate(pipe.gameObject, transform);
        PipeTypes pipeType = pipe.getPipeType();
        noOfPipesOnDock[pipeType] -= 1;
        if (noOfPipesOnDock[pipeType] <= 0) {
            noOfPipesOnDock.Remove(pipeType);
            switch (pipeType) {
                case (PipeTypes.Straight) :
                    StraightPipe.SetActive(false);
                    break;
                case (PipeTypes.L) :
                    LPipe.SetActive(false);
                    break;
                default:
                    break;
            }   
        }
        updateLPipeCounter();
        updateIPipeCounter();
        return newPipe.GetComponent<Pipe>();

    }
    public void addPipe(PipeTypes pipeType) {
        addPipe(pipeType, 1);
    }
    
    public void addPipe(PipeTypes pipeType, int amount) {
        if (noOfPipesOnDock.ContainsKey(pipeType)) {
            noOfPipesOnDock[pipeType] += amount;
            updateIPipeCounter();
            updateLPipeCounter();
            return;
        }
        noOfPipesOnDock.Add(pipeType, amount);
        switch (pipeType) {
            case (PipeTypes.Straight) :
                StraightPipe.SetActive(true);
                break;
            case (PipeTypes.L) :
                LPipe.SetActive(true);
                break;
            default:
                break;
        }
        updateIPipeCounter();
        updateLPipeCounter();   
    }
}
