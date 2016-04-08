﻿using System.Threading.Tasks;

namespace MyPegasus.Common.DataAccess.DeutscheBahnApi
{
    public interface IDeutscheBahnApiClient
    {
        Task<T> GetAsync<T>(string uri);
    }
}
