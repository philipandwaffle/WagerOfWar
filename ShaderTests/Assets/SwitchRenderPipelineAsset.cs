using UnityEngine;
using UnityEngine.Rendering;

public class SwitchRenderPipelineAsset : MonoBehaviour
{
    [SerializeField] private RenderPipelineAsset[] assets;
    private int index;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetIndex(true);
            SetRenderPipeline();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetIndex(false);
            SetRenderPipeline();
        }
    }

    private void SetIndex(bool up)
    {
        int direction = up ? 1 : -1;
        index += direction;
        if (index == -1) { index = assets.Length - 1; }
        else if (index == assets.Length) { index = 0; }
    }

    private void SetRenderPipeline()
    {
        GraphicsSettings.renderPipelineAsset = assets[index];
    }
}