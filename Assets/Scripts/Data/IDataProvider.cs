﻿namespace Data
{
    public interface IDataProvider
    {
        public void Save();
        public bool TryLoad();
    }
}
