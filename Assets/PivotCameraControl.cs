using UnityEngine;

public class PivotCameraControl : MonoBehaviour
{
	[SerializeField] private Transform source;
	[SerializeField] private Transform target;
	[SerializeField] private float speed;

	void FixedUpdate()
	{
		source.LookAt(target);
		source.Translate(Vector3.right * speed * Time.deltaTime);
	}
}