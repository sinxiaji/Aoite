﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace System.Core
{
    public class LockeableTests
    {
        [Fact]
        public void LockingTest()
        {
            List<Task> tasks = new List<Task>();
            var x = 0;
            for(int i = 0; i < 100; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(100 - i);
                    using("x".Locking())
                    {
                        if(x < 10) x++;
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Assert.Equal(10, x);

            var lockable = "x".Locking();

            var t = Task.Factory.StartNew(() =>
            {
                Assert.Throws<TimeoutException>(() => "x".Locking(TimeSpan.FromMilliseconds(300)));
            });
            t.Wait();
            lockable.Dispose();
        }

        [Fact]
        public void TryLockingTest()
        {
            var lockable = "x".Locking();

            var t = Task.Factory.StartNew(() =>
            {
                Assert.Null("x".TryLocking(TimeSpan.FromMilliseconds(300)));
            });
            t.Wait();
            lockable.Dispose();
        }
    }
}
