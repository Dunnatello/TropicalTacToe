namespace Dunnatello.UI {
    using TMPro;
    using UnityEngine;
    using UnityEngine.TextCore.Text;

    public class WavyTextEffect : MonoBehaviour {

        private TextMeshProUGUI text;
        [SerializeField] private float waveSpeed = 2f;
        [SerializeField] private float waveHeight = 5f;

        private Vector3[] vertices;
        private TMP_TextInfo textInfo;

        private void Start() {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
        
            text.ForceMeshUpdate();
            textInfo = text.textInfo;

            int characterCount = textInfo.characterCount;
            if (characterCount == 0)
                return;

            // Get Vertices
            vertices = textInfo.meshInfo[textInfo.characterInfo[0].materialReferenceIndex].vertices;

            foreach (var character in textInfo.characterInfo) {

                // Skip If Character Invisible
                if (!character.isVisible)
                    continue;

                // Get Vertex Index
                int vertexIndex = character.vertexIndex;

                
                
                // Calculate Wave Offset
                Vector3 offset = new(0f, Mathf.Sin(Time.time * waveSpeed + character.index * 0.1f) * waveHeight, 0f);

                // Apply Wave Offset to Each Character Vertice
                for (int i = 0; i < 4; i++) {
                    vertices[vertexIndex + i] += offset;
                }

            }

            int meshIndex = 0;
            // Update Mesh with New Vertices
            foreach (var meshInfo in textInfo.meshInfo) {

                meshInfo.mesh.vertices = meshInfo.vertices;
                meshIndex++;
            }

            text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);

        }

    }

}