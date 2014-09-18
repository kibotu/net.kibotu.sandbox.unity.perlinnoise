using UnityEngine;

namespace Assets.Source
{
    public class PerlinNoisePlane : MonoBehaviour
    {
        public float Power = 3.0f;
        public float Scale = 1.0f;
        public float HeightScale = 1f;
        private Vector2 _v2SampleStart = new Vector2(0f, 0f);

        void Start()
        {
            _v2SampleStart = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f));
            MakeSomeNoise();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _v2SampleStart = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f));
            }
            MakeSomeNoise();
        }

        void MakeSomeNoise()
        {
            var mf = GetComponent<MeshFilter>();
            var vertices = mf.mesh.vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var xCoord = _v2SampleStart.x + vertices[i].x * Scale;
                var yCoord = _v2SampleStart.y + vertices[i].z * Scale;
//                vertices[i].y = (Mathf.PerlinNoise(xCoord, yCoord) - 0.5f) * Power;
                vertices[i].y = HeightScale * Mathf.PerlinNoise(Time.time + (xCoord * Scale), Time.time + (yCoord * Scale));
            }
            mf.mesh.vertices = vertices;
            mf.mesh.RecalculateBounds();
            mf.mesh.RecalculateNormals();
        }
    }
}