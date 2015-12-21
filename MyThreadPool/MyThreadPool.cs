using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsIfaces {
	public delegate void WaitCallback ();

	/// <summary>
	/// MyThreadPool implements a simple thread pool, that allows for dynamic change of number
	/// of working threads.
	/// </summary>
	public class MyThreadPool : IThreadPool {
		
		private int poolSize;
		private List<Thread> threads = new List<Thread>();
		private Queue<WaitCallback> jobs = new Queue<WaitCallback>();

		public bool QueueUserWorkItem (WaitCallback callBack) {
			if (callBack == null)
				throw new NotSupportedException ("A callback method cannot be null");
			
			lock (jobs) {
				jobs.Enqueue (callBack);
				Monitor.Pulse (jobs);
			}

			return true;
		}

		/* After reducing the number of working threads, currently working threads are allowed
		 * to finish their jobs (they're not interrupted). */
		public bool SetPoolSize (int size) {
			lock (threads) {
				poolSize = size;
				if (poolSize > threads.Count)
					spawnThreads ();
				else if (poolSize < threads.Count) {
					lock(jobs) Monitor.PulseAll (jobs); //wake them up, so some of them might finish
				}
			}

			return true;
		}

		private void spawnThreads() {
			while (threads.Count < poolSize) {
				Thread t = new Thread (ConsumeJobs);
				threads.Add(t);
				t.Start();
			}
		}

		private void ConsumeJobs() {
			WaitCallback job;

			while (true) {
				if (killThreadIfNeeded ()) return;

				lock (jobs) {
					while (jobs.Count == 0 && !(poolSize < threads.Count))
						Monitor.Wait (jobs); //wait, if no more jobs, but should not kill any threads
					if (killThreadIfNeeded ()) return;
					job = jobs.Dequeue ();
				}
				job ();
			}
		}

		/* Returns true if invoking thread should be killed (break his loop), false otherwise */
		private bool killThreadIfNeeded() {
			if (poolSize < threads.Count) {
				lock (threads) {
					if (poolSize < threads.Count) {
						threads.Remove (Thread.CurrentThread);
						return true;
					}
				}
			}

			return false;
		}

		/* Returns most recently set size of the pool. */
		public int PoolSize { get { return poolSize; } }

		/* Gets the actual size of the pool. It might not be equal to PoolSize, when number
		   of threads is stabilizing after pool size change. This value is for information only
		   and should not be relied upon. */
		public int ActualPoolSize { get { return threads.Count; } }
	}
}
