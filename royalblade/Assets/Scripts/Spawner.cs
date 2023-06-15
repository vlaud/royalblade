using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blocks;
    public float offset = 1.2f;
    public int blockCount = 1;
    [SerializeField] float limitVelocity = 5.0f;
    [SerializeField] string blockName;
    // Start is called before the first frame update
    void Start()
    {
        blockName = blocks.GetComponent<Blocks>().destructable.blockName;
        GenerateBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            blockCount++;
            GenerateBlocks();
        }
    }
    void GenerateBlocks()
    {
        for(int i = 0; i < blockCount; i++)
        {
            var block = ObjectPool.Inst.GetObject<Blocks>(blocks, transform, blockName);
            block.GetLimit(limitVelocity);
            block.ResetBlock();
            GameObject obj = block.gameObject;
            obj.transform.localPosition = new Vector3(0.0f, i * offset, 0.0f);
            obj.name = $"cube{i}";
        }
    }
}
