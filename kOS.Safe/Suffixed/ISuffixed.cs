﻿namespace kOS.Safe.Suffixed
{
    public interface ISuffixed
    {
        bool SetSuffix(string suffixName, object value);
        object GetSuffix(string suffixName);
    }
}