using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using RavingDev.Common;

namespace Lab4.ResourceLocking
{
    public sealed class ResourceLocker : IResourceLocker
    {
        private static readonly Lazy<ResourceAccessArbiter> ResourceAccessArbiterLazy;

        static ResourceLocker()
        {
            ResourceAccessArbiterLazy = new Lazy<ResourceAccessArbiter>(() => new ResourceAccessArbiter());
        }

        public ResourceLocker()
        {
        }

        private ResourceAccessArbiter ResourceAccessArbiter
        {
            get { return ResourceAccessArbiterLazy.Value; }
        }

        public bool TryLockResource(string resourceId)
        {
            return ResourceAccessArbiter.TryGetAccess(resourceId);
        }

        public void UnlockResource(string resourceId)
        {
            ResourceAccessArbiter.ReleaseAccess(resourceId);
        }

        public void RegisterCallbackForAccessWaiting(string resourceId, Action callback)
        {
            ResourceAccessArbiter.RegisterCallbackOnResourceAccessGranted(resourceId, callback);
        }

        public void RemoveFromQueueForAccess(string resourceId)
        {
            ResourceAccessArbiter.LeaveQueue(resourceId);
        }
    }
}