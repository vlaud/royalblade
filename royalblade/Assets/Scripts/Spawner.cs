using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blocks;
    public string blockName;
    public float offset = 1.2f;
    public int blockCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            GenerateBlocks();
        }
    }
    void GenerateBlocks()
    {
        for(int i = 0; i < blockCount; i++)
        {
            var block = ObjectPool.Inst.GetObject<Blocks>(blocks, transform, blockName);
            block.ResetBlock();
            GameObject obj = block.gameObject;
            obj.transform.localPosition = new Vector3(0.0f, i * offset, 0.0f);
            obj.name = $"cube{i}";
        }
    }
}
