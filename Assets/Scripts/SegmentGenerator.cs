    using System.Collections.Generic;
    using UnityEngine;

    public class SegmentGenerator : MonoBehaviour
    {
        public List<GameObject> segmentPrefabs;

        public GameObject firstSegment; // starting segment in the scene
        public Transform player; // assign player in Inspector
        [SerializeField] float segmentLength = 150f;
        [SerializeField] float destroyDelay = 20f; // seconds before destroying old segments

        private Vector3 nextSpawnPos;
        private List<GameObject> activeSegments = new List<GameObject>();

        void Start()
        {
            // Set initial next spawn position right after the first segment
            nextSpawnPos = firstSegment.transform.position + new Vector3(0, 0, segmentLength);
            activeSegments.Add(firstSegment);
        }

        void Update()
        {
            // If player is getting close to where the next segment should be
            if (Vector3.Distance(player.position, nextSpawnPos) < segmentLength * 2)
            {
                SpawnSegment();
            }
        }

   void SpawnSegment()
{
    // Pick a random segment
    GameObject prefabToSpawn = segmentPrefabs[Random.Range(0, segmentPrefabs.Count)];

    // Spawn exactly at the calculated position
    GameObject newSeg = Instantiate(prefabToSpawn, nextSpawnPos, Quaternion.identity);

    // Ensure collectibles are active
    foreach (Transform child in newSeg.GetComponentsInChildren<Transform>(true))
    {
        if (child.CompareTag("ColorPalette"))
        {
            child.gameObject.SetActive(true);
        }
    }

    // Track the new segment
    activeSegments.Add(newSeg);
    Destroy(newSeg, destroyDelay); 
    activeSegments.RemoveAll(seg => seg == null);

    // Always move spawn position forward by fixed length
    nextSpawnPos += new Vector3(0, 0, segmentLength);
}



    }
