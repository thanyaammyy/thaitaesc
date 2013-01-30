using System;
using System.Collections;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
namespace Trirand.Web.UI.WebControls
{
	[AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public abstract class BaseItemCollection<OwnerType, ItemType> : StateManagedCollection
	{
		private OwnerType _owner;
		private static readonly Type[] _knownTypes = new Type[]
		{
			typeof(ItemType)
		};
		private int capacity;
		public ItemType this[int i]
		{
			get
			{
				return (ItemType)((object)((IList)this)[i]);
			}
			set
			{
				this[i] = value;
			}
		}
		public int Capacity
		{
			get
			{
				return this.capacity;
			}
			set
			{
				this.capacity = value;
			}
		}
		public BaseItemCollection()
		{
		}
		public BaseItemCollection(OwnerType owner)
		{
			this._owner = owner;
		}
		public int Add(ItemType item)
		{
			return ((IList)this).Add(item);
		}
		public bool Contains(ItemType item)
		{
			return ((IList)this).Contains(item);
		}
		public void CopyTo(ItemType[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}
		protected abstract override object CreateKnownType(int index);
		protected override Type[] GetKnownTypes()
		{
			return BaseItemCollection<OwnerType, ItemType>._knownTypes;
		}
		public int IndexOf(ItemType value)
		{
			return ((IList)this).IndexOf(value);
		}
		public void Insert(int index, ItemType item)
		{
			((IList)this).Insert(index, item);
		}
		protected override void OnClear()
		{
			base.OnClear();
		}
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
		}
		protected override void OnValidate(object value)
		{
			base.OnValidate(value);
		}
		public void Remove(ItemType item)
		{
			this.Remove(item);
		}
		public void RemoveAt(int index)
		{
			this.RemoveAt(index);
		}
		protected override void SetDirtyObject(object o)
		{
			if (o is BaseItem)
			{
				((BaseItem)o).SetDirty();
			}
		}
	}
}
