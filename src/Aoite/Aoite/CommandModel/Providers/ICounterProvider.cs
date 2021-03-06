﻿using System;

namespace Aoite.CommandModel
{
    /// <summary>
    /// 定义一个计数的提供程序。
    /// </summary>
    public interface ICounterProvider : IContainerProvider
    {
        /// <summary>
        /// 获取指定键的原子递增序列。
        /// </summary>
        /// <param name="key">序列的键。</param>
        /// <param name="increment">递增量。</param>
        /// <returns>递增的序列。</returns>
        long Increment(string key, long increment = 1);
    }
}
