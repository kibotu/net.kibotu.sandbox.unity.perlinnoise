using UnityEngine;

namespace Assets.Source
{
    public class PerlinNoisePlane : MonoBehaviour {

        public float Scale = 1f;
        public float HeightScale = 1f;

        public int PlaneSize = 50;
        public GameObject Geometry;
        public bool UseMaterial = true;
        public Material Gray;

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

            var center = GameObject.Find("Center");
            center.transform.SetParent(transform, false);
            center.transform.position = new Vector3(PlaneSize / 2f, 0, PlaneSize / 2f);
        }

        public void Update()
        {
            var pos = transform.position;
	        pos.y = HeightScale * Mathf.PerlinNoise(Time.time + (transform.position.x * Scale), Time.time + (transform.position.z * Scale));
            transform.position = pos;
	        for(var i = 0; i < transform.childCount; ++i) {
                var child = transform.GetChild(i);
	            if (child.name.Equals("Center")) 
                    continue;
                var childPos = transform.GetChild(i).transform.position;
                childPos.y = HeightScale * Mathf.PerlinNoise(Time.time + (childPos.x * Scale), Time.time + (childPos.z * Scale));
	            child.transform.position = childPos;
	            if (UseMaterial) child.renderer.material.color = new Color(childPos.y, childPos.y, childPos.y, childPos.y);
	            else child.renderer.material = Gray;
	        }
         }

        public void SetPNScale(float Scale)
        {
            this.Scale = Scale;
        }

        public void SetPNHeightScale(float HeightScale)
        {
            this.HeightScale = HeightScale;
        }

        public void ToggleMaterial()
        {
            UseMaterial = !UseMaterial;
        }
    }
}
