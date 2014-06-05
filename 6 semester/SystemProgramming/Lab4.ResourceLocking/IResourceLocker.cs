using System;
using System.Threading.Tasks;

namespace Lab4.ResourceLocking
{
    public interface IResourceLocker
    {
        bool TryLockResource(string resourceId);

        void UnlockResource(string resourceId);

        void RegisterCallbackForAccessWaiting(string resourceId, Action callback);

        void RemoveFromQueueForAccess(string resourceId);
    }
}