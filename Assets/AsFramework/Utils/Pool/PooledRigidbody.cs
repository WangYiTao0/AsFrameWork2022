using UnityEngine;

namespace RobotGame.Utils
{
	/// <summary>This component allows you to reset a Rigidbody's velocity via Messages or via Poolable.</summary>
	[RequireComponent(typeof(Rigidbody))]
	public class PooledRigidbody : MonoBehaviour, IPoolable
	{
		public void OnSpawn()
		{
			Debug.Log("LeanPooledRigidbody OnSpawn");
		}

		public void OnDespawn()
		{
			Debug.Log("LeanPooledRigidbody OnDespawn");

			var rigidbody = GetComponent<Rigidbody>();

			rigidbody.velocity        = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}