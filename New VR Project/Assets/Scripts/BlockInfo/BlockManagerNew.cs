using UnityEngine;

public class BlockManagerNew : MonoBehaviour
{
    public static BlockManagerNew Instance;

    private BlockInfoRecon currentBlock;

    void Awake()
    {
        Instance = this;
    }

    public void SetActiveBlock(BlockInfoRecon newBlock)
    {
        // If another block is active, hide it
        if (currentBlock != null && currentBlock != newBlock)
        {
            currentBlock.HidePDF();
        }

        // Toggle the clicked block
        if (currentBlock == newBlock)
        {
            newBlock.HidePDF();
            currentBlock = null;
        }
        else
        {
            newBlock.ShowPDF();
            currentBlock = newBlock;
        }
    }
}