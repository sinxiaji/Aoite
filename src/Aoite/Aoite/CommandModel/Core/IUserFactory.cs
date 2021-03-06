﻿using System;

namespace Aoite.CommandModel
{
    /// <summary>
    /// 定义一个执行命令模型的用户工厂。
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// 获取执行命令模型的用户。
        /// </summary>
        /// <param name="container">服务容器。</param>
        /// <returns>客户端唯一标识，或一个 null 值。</returns>
        object GetUser(IIocContainer container);
    }
}
