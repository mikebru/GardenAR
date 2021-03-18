using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialCopy : MonoBehaviour
{

    private Renderer self;
    public Renderer main;
    private MaterialPropertyBlock block;

    private void Start()
    {
        self = GetComponent<Renderer>();
        block = new MaterialPropertyBlock();
    }

    private void Update()
    {
        int n = main.materials.Length;
        main.GetPropertyBlock(block);
        for (int i = 0; i < n; i++)
            self.SetPropertyBlock(block);
    }
}