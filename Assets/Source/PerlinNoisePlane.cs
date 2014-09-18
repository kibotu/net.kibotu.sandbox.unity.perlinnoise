using UnityEngine;

namespace Assets
{
    public class PerlinNoisePlane : MonoBehaviour {

        public float Scale = 1f;
        public float HeightScale = 1f;

        public int PlaneSize = 50;
        public GameObject Geometry;

        public void Start()
        {
            for (var x = 0; x < PlaneSize; ++x)
            {
                for (var z = 0; z < PlaneSize; ++z)
                {
                    var go = Instantiate(Geometry) as GameObject;
                    go.transform.position = new Vector3(x, 0, z);
                    go.transform.parent = transform;
                }
            }
        }

        public void Update()
        {
            var pos = transform.position;
	        pos.y = HeightScale * Mathf.PerlinNoise(Time.time + (transform.position.x * Scale), Time.time + (transform.position.z * Scale));
            transform.position = pos;
	        for(var i = 0; i < transform.childCount; ++i) {
                var childPos = transform.GetChild(i).transform.position;
                childPos.y = HeightScale * Mathf.PerlinNoise(Time.time + (childPos.x * Scale), Time.time + (childPos.z * Scale));
	            transform.GetChild(i).transform.position = childPos;
	        }
         }
    }
}
