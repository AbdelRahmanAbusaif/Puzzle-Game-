using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WobbyText : MonoBehaviour
{
    public TMP_Text Text;

    private void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        Text.ForceMeshUpdate();
        var textInfo = Text.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 4f + orig.x * 0.01f) * 5f, 0);
            }
        }
        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;

            Text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
