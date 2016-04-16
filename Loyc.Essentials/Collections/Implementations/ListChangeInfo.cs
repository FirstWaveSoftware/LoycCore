
using System.Diagnostics;

namespace Loyc.Collections {

	/// <summary>Contains information about how a collection is about to change.</summary>
	/// <typeparam name="T">Type of element in the collection</typeparam>
	/// <remarks>
	/// In contrast to <see cref="NotifyCollectionChangedEventArgs"/>, this object
	/// represents changes that are about to happen, not changes that have happened
	/// already.
	/// </remarks>
	/// <seealso cref="INotifyListChanging{T}"/>
	public struct ListChangeInfo<T>
	{
		/// <summary>Initializes the members of <see cref="ListChangeInfo{T}"/>.</summary>
		public ListChangeInfo(NotifyCollectionChanged action, int index, int sizeChange, IListSource<T> newItems)
		{
			Action = action;
			Index = index;
			SizeChange = sizeChange;
			NewItems = newItems;
			Debug.Assert(
				(action == NotifyCollectionChanged.Add && newItems != null && NewItems.Count == sizeChange) ||
				(action == NotifyCollectionChanged.Remove && (newItems == null || newItems.Count == 0) && sizeChange < 0) ||
				(action == NotifyCollectionChanged.Replace && newItems != null && sizeChange == 0) ||
				(action == NotifyCollectionChanged.Move && sizeChange == 0) ||
				(action == NotifyCollectionChanged.Reset));
		}

		/// <summary>Gets a value that indicates the type of change being made to
		/// the collection.</summary>
		public readonly NotifyCollectionChanged Action;

		/// <summary>Gets the index at which the add, remove, or change operation starts.</summary>
		public readonly int Index;

		/// <summary>Gets the amount by which the collection size changes. When
		/// items are being added, this is positive, and when items are being
		/// removed, this is negative. This is 0 when existing items are only being
		/// replaced.</summary>
		public readonly int SizeChange;

		/// <summary>Represents either new items that are being added to the
		/// collection, or items that are about to replace existing items in
		/// the collection. This member is null or empty when items are being
		/// removed.</summary>
		public readonly IListSource<T> NewItems;

	}

}
