using System;
using System.Collections.Generic;
using System.Collections;

namespace Microsoft.Xna.Framework.GamerServices
{
	public sealed class PropertyDictionary :
		IDictionary<string, Object>,
		ICollection<KeyValuePair<string, Object>>,
		IEnumerable<KeyValuePair<string, Object>>,
		IEnumerable
	{
		public bool ContainsKey (string key)
		{
			throw new NotImplementedException ();
		}
		public bool TryGetValue (string key, out object value)
		{
			throw new NotImplementedException ();
		}
		public object this [string key] {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public int Count {
			get {
				throw new NotImplementedException ();
			}
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		bool ICollection<KeyValuePair<string, object>>.IsReadOnly {
			get {
				return true;
			}
		}
		ICollection<string> IDictionary<string, object>.Keys {
			get {
				throw new NotImplementedException ();
			}
		}
		ICollection<object> IDictionary<string, object>.Values {
			get {
				throw new NotImplementedException ();
			}
		}

		void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) {
			throw new NotImplementedException();
		}
		void ICollection<KeyValuePair<string, object>>.Clear()
		{
			throw new NotSupportedException();
		}
		bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
		{
			throw new NotImplementedException();
		}
		void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		bool ICollection<KeyValuePair<string, object>>.Remove (KeyValuePair<string, object> item)
		{
			throw new NotImplementedException ();
		}
		void IDictionary<string, object>.Add (string key, object value)
		{
			throw new NotImplementedException ();
		}
		bool IDictionary<string, object>.Remove (string key)
		{
			throw new NotImplementedException ();
		}
		IEnumerator IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}
	}

}

