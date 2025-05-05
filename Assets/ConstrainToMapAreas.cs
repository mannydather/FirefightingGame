using UnityEngine;
using DG.Tweening;

public class ConstrainToMapAreas : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        // if this transform is outside the map area, move it back inside
        if (transform.position.x < 100 || transform.position.x > 800 || transform.position.y < 100 || transform.position.y > 800)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x, 100, 800);
            newPosition.z = Mathf.Clamp(newPosition.y, 100, 800);
            transform.DOMove(newPosition, 0.5f).SetEase(Ease.InOutBack);
           //transform.position = newPosition;
        }

    }
}
