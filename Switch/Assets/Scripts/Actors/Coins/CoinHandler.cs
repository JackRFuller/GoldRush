using UnityEngine;

public class CoinHandler : MonoBehaviour
{
	[SerializeField] private Collider coinCollider;
	[SerializeField] private MeshRenderer coinMesh;

	private void Start()
	{
		Initiatlise();
	}

	private void Initiatlise()
	{
		coinCollider.enabled = true;
		coinCollider.isTrigger = true;
		coinMesh.enabled = true;

	}

	private void HideCoin()
	{
		coinCollider.enabled = false;
		coinCollider.isTrigger = false;
		coinMesh.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			HideCoin();
		}
	}

	
}
