﻿//Copyright (c) Microsoft Corporation

namespace Microsoft.Azure.BatchExplorer.Messages
{
    public enum RefreshTarget
    {
        Pools,
        Jobs,
        JobSchedules,
        Certificates,
    }

    public class RefreshMessage
    {
        public RefreshTarget ItemToRefresh { get; private set; }

        public RefreshMessage(RefreshTarget itemToRefresh)
        {
            this.ItemToRefresh = itemToRefresh;
        }
    }
}
