using UnityEngine;

namespace AsFramework.Utils
{
	/// <summary>This component can be added to your prefab GameObject, and it will throw warnings if it is instantiated without the use of <b>LeanPool.Spawn</b>, or despawned without the use of <b>LeanPool.Despawn</b>.</summary>
	public class PoolDebugger : MonoBehaviour
	{
		[SerializeField]
		private GameObjectPool cachedPool;

		[System.NonSerialized]
		private bool skip;

		protected virtual void Start()
		{
			if (Exists() == false)
			{
				Debug.LogWarning("This clone was NOT spawned using LeanPool.Spawn?!\n" + name, this);

				enabled = false;
			}
		}

		protected virtual void Update()
		{
			if (cachedPool == null)
			{
				Debug.LogWarning("This pool this prefab was spawned using has been destroyed.\n" + name, this);

				enabled = false;
			}
			else if (Exists() == false)
			{
				Debug.LogWarning("This clone was despawned using LeanPool.Despawn, but it's still active?!\n" + name, this);

				enabled = false;
			}
		}

		protected virtual void OnApplicationQuit()
		{
			skip = true;
		}

		protected virtual void OnDestroy()
		{
			if (skip == true)
			{
				return;
			}

			if (Exists() == true)
			{
				Debug.LogWarning("This clone has been destroyed, and it was NOT despawned using LeanPool.Despawn?!\n" + name, this);
			}
		}

		private bool Exists()
		{
			if (Pool.Links.TryGetValue(gameObject, out cachedPool) == true)
			{
				return true;
			}

			if (GameObjectPool.TryFindPoolByClone(gameObject, ref cachedPool) == true)
			{
				return true;
			}

			return false;
		}
	}
}

