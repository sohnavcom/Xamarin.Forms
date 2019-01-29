﻿using System;
using Foundation;
using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	public class UICollectionViewDelegator : UICollectionViewDelegateFlowLayout
	{
		public ItemsViewLayout ItemsViewLayout { get; private set; }
		public ItemsViewController ItemsViewController { get; private set; }
		public SelectableItemsViewController SelectableItemsViewController
		{
			get => ItemsViewController as SelectableItemsViewController;
		}
		public CarouselViewController CarouselViewController { get; set; }

		public UICollectionViewDelegator(ItemsViewLayout itemsViewLayout, ItemsViewController itemsViewController)
		{
			ItemsViewLayout = itemsViewLayout;
			ItemsViewController = itemsViewController;
		}

		public override void WillDisplayCell(UICollectionView collectionView, UICollectionViewCell cell, NSIndexPath path)
		{
			ItemsViewLayout?.WillDisplayCell(collectionView, cell, path);
		}

		public override UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout,
			nint section)
		{
			if (ItemsViewLayout == null)
			{
				return default(UIEdgeInsets);
			}

			return ItemsViewLayout.GetInsetForSection(collectionView, layout, section);
		}

		public override nfloat GetMinimumInteritemSpacingForSection(UICollectionView collectionView,
			UICollectionViewLayout layout, nint section)
		{
			if (ItemsViewLayout == null)
			{
				return default(nfloat);
			}

			return ItemsViewLayout.GetMinimumInteritemSpacingForSection(collectionView, layout, section);
		}

		public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView,
			UICollectionViewLayout layout, nint section)
		{
			if (ItemsViewLayout == null)
			{
				return default(nfloat);
			}

			return ItemsViewLayout.GetMinimumLineSpacingForSection(collectionView, layout, section);
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			SelectableItemsViewController?.ItemSelected(collectionView, indexPath);
		}

		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			SelectableItemsViewController?.ItemDeselected(collectionView, indexPath);
		}

		public override void CellDisplayingEnded(UICollectionView collectionView, UICollectionViewCell cell, NSIndexPath indexPath)
		{
			ItemsViewController.RemoveLogicalChild(cell);
		}

		//Should this be moved to ItemsViewController ?
		public override void Scrolled(UIScrollView scrollView)
		{
			CarouselViewController?.Scrolled(scrollView);
		}

		public override void DecelerationEnded(UIScrollView scrollView)
		{
			CarouselViewController?.DecelerationEnded(scrollView);
		}

		public override void DecelerationStarted(UIScrollView scrollView)
		{
			CarouselViewController?.DecelerationStarted(scrollView);
		}

		public override void DraggingStarted(UIScrollView scrollView)
		{
			CarouselViewController?.DraggingStarted(scrollView);
		}

		public override void DraggingEnded(UIScrollView scrollView, bool willDecelerate)
		{
			CarouselViewController?.DraggingEnded(scrollView, willDecelerate);
		}

		public override void ScrollAnimationEnded(UIScrollView scrollView)
		{
			CarouselViewController?.ScrollAnimationEnded(scrollView);
		}
	}
}