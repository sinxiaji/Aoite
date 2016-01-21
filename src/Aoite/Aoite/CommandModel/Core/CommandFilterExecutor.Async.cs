﻿#if !NET40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aoite.Data;

namespace Aoite.CommandModel
{
    partial class CommandFilterExecutor: IFilterExecutorAsync
    {
        public Task<bool> ExistsAsync<TEntity>(ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.Exists<TEntity> { Where = this._where, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);

        public Task<List<TEntity>> FindAllAsync<TEntity>(ICommandTunnel tunnel = null)
            => this.FindAllAsync<TEntity, TEntity>(tunnel);

        public Task<List<TView>> FindAllAsync<TEntity, TView>(ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.FindAll<TEntity, TView> { Where = this._where, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);


        public Task<PageData<TEntity>> FindAllAsync<TEntity>(IPagination page, ICommandTunnel tunnel = null)
            => this.FindAllAsync<TEntity, TEntity>(page, tunnel);

        public Task<PageData<TView>> FindAllAsync<TEntity, TView>(IPagination page, ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.FindAllPage<TEntity, TView> { Where = this._where, Page = page, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);

        public Task<TEntity> FindOneAsync<TEntity>(ICommandTunnel tunnel = null)
            => this.FindOneAsync<TEntity, TEntity>(tunnel);

        public Task<TView> FindOneAsync<TEntity, TView>(ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.FindOne<TEntity, TView> { Where = this._where, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);

        public Task<int> ModifyAsync<TEntity>(object entity, ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.Modify<TEntity> { Where = this._where, Entity = entity, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);

        public Task<int> RemoveAsync<TEntity>(ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.Remove<TEntity> { Where = this._where, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);

        public Task<long> RowCountAsync<TEntity>(ICommandTunnel tunnel = null)
            => this._bus.ExecuteAsync(new CMD.RowCount<TEntity> { Where = this._where, Tunnel = tunnel }).ContinueWith(t => t.Result.Result);
    }
}
#endif