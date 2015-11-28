﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Aoite.CommandModel
{
    /// <summary>
    /// 定义一个提供锁功能的提供程序。
    /// </summary>
    public interface ILockProvider : IContainerProvider
    {
        /// <summary>
        /// 提供锁的功能。
        /// </summary>
        /// <param name="key">锁的键名。</param>
        /// <param name="timeout">锁的超时设定。</param>
        /// <returns>返回一个锁。</returns>
        IDisposable Lock(string key, TimeSpan? timeout = null);
    }
}
