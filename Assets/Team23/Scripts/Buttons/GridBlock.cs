using UnityEngine;

public class GridBlock : Button {
    private Pipe currentPipeOnGrid;
    private DockLevelGameManager gameManager;
    [SerializeField] private int id;
    private BoxCollider2D objectCollider;
    private GazeableObject gazeableObject;
    protected override void Awake() {
        base.Awake();
        gameManager = FindObjectOfType<DockLevelGameManager>();
        objectCollider = GetComponent<BoxCollider2D>();
        gazeableObject = GetComponent<GazeableObject>();
    }
    public override void OnMouseDown() {
        gameManager.gridBlockToggled(this);
    }
    public bool hasPipe() {
        return (currentPipeOnGrid != null);
    }
    public int getID() {
        return id;
    }
    public void setPipe(Pipe pipe) {
        currentPipeOnGrid = pipe;
        if (pipe == null) {
            activate();
        } else {
            deactivate();
        }
    }

    public void deactivate() {
        gazeableObject.enabled = false;
        objectCollider.enabled = false;
        // stoppedGazing needs to be called because the gazeableObject has been disabled so it wont be able
        // to call stoppedGazing() when the user looks away from the gridBlock
        stoppedGazing();
    }

    public void activate() {
        gazeableObject.enabled = true;
        objectCollider.enabled = true;
    }

    public Pipe getPipe() {
        return currentPipeOnGrid;
    }

    public override void currentlyGazing() {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + (0.3f * Time.deltaTime));
    }


}
