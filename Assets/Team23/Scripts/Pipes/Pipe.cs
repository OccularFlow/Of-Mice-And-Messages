using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pipe : MonoBehaviour, IGazeableObject
{
    // spawnLocation is which end of the pipe the water should come out from ('head' or 'tail)
    protected string spawnLocation;
    protected Vector3 waterSource;
    protected bool waterRunning;
    protected PipeTypes pipeType;
    private GameManager gameManager;
    private GridBlock gridBlock;
    // the backgroundSprite is the sprite behind the pipe that glows when a user gazes a pipe.
    private SpriteRenderer backgroundSprite;
    private SpriteChanger spriteChanger;
    private PipeRotator pipeRotator;
    protected bool isFromDock = true;
    private int drops;
    protected int rotationCounter = 0;
    bool droppingBottle = false;
    public int Rotation
    {
        get {return (rotationCounter * -90);}
    }
    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        spriteChanger = GetComponentInChildren<SpriteChanger>();
        pipeRotator = GetComponentInChildren<PipeRotator>();
        backgroundSprite = GetComponent<SpriteRenderer>();
    }
    public PipeTypes getPipeType() {
        return pipeType;
    }

    public void updateGridBlock(GridBlock gridBlock) {
        isFromDock = false;
        this.gridBlock = gridBlock;
    }

    public bool fromDock() {
        return isFromDock;
    }
    public GridBlock getGridBlock() {
        return gridBlock;
    }

    public void rotateClockwise() {
        spriteChanger.rotateClockwise();
        pipeRotator.rotateClockwise();
        rotationCounter = (rotationCounter + 3) % 4;
    }

    public void rotateAntiClockwise(){
        spriteChanger.rotateAnticlockwise();
        pipeRotator.rotateAnticlockwise();
        rotationCounter = (rotationCounter + 1) % 4;
    }

    public virtual void OnMouseDown() {
        gameManager.pipeSelected(this);
    }

    public void currentlyGazing() {
        backgroundSprite.color = new Color(backgroundSprite.color.r,backgroundSprite.color.g,backgroundSprite.color.b, backgroundSprite.color.a + (0.3f * Time.deltaTime));
    }

    public void stoppedGazing() {
        backgroundSprite.color = backgroundSprite.color - new Color(0,0,0,backgroundSprite.color.a);
    }
// returns whether water entering the pipe is going out of the pipe or not. 
// location parameter refers to which end of the pipe that the water entered
    public bool collectWater(GameObject waterDrop, string location)
    {
        if (waterDrop.tag == "message bottle") {
            waterDrop.SetActive(false);
            // droppingBottle = true;
            Invoke("releaseMessageBottle", 0.2f);
            drops++;
            return false;
        }
        Vector2 incomingVel = waterDrop.GetComponent<Rigidbody2D>().velocity;
        if (!correctDirection(incomingVel, location))
            return false;
        if (!waterRunning) {
            resetSpawnLocation(location);
            waterRunning = true;
            InvokeRepeating("dropWater", 0.1f, StartPipe.waterDropRate);
        }
        drops++;
        return true;
    }

    void releaseMessageBottle() {
        GameObject newDrop = DropletPool.instance.getBottleDroplet();

        float randRange = 0.01f;
        float randomx = Random.Range(-randRange,randRange);
        newDrop.transform.position = new Vector2(waterSource.x + randomx, waterSource.y);
        newDrop.SetActive(true);
        newDrop.GetComponent<Rigidbody2D>().velocity = getExitVelocity();
        droppingBottle = false;
    }
    
    protected abstract void resetSpawnLocation(string newLocation);
    protected abstract Vector2 getExitVelocity();
// returns whether water entering the pipe is going out of the pipe or not
// location parameter refers to which end of the pipe that the water entered

    protected abstract bool correctDirection(Vector2 incomingVel, string location);

    private void dropWater()
    {
        GameObject newDrop = DropletPool.instance.getDroplet();

        float randRange = 0.01f;
        float randomx = Random.Range(-randRange,randRange);
        newDrop.transform.position = new Vector2(waterSource.x + randomx, waterSource.y);
        newDrop.SetActive(true);
        newDrop.GetComponent<Rigidbody2D>().velocity = getExitVelocity();

        drops-= 1;
        if (drops <= 0 && !droppingBottle)
        {
            waterRunning = false;
            CancelInvoke();
        }
    }

    public float getGazeTime(){
        return GazeSettings.getDwellTime();
    }

    public void gazeAction() {
        OnMouseDown();
    }

}
