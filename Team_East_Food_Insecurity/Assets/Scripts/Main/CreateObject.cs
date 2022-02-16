using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] ObjectPool objectToSpawn;
    [SerializeField] bool randomizeRotation;

    public void CreateNewObject(GameObject objLoc)
    {
        GameObject o = objectToSpawn.GetObject();
        if (o != null)
        {
            Vector3 rot = objectToSpawn.transform.eulerAngles;
            if (randomizeRotation)
                rot = new Vector3(0, 0, Random.Range(-180f, 180f));
            GameObject newObject = Instantiate(o, transform.position, Quaternion.Euler(rot), objectToSpawn.transform);
            newObject.transform.position = objLoc.transform.position;
            newObject.SetActive(true);
        }
    }
}