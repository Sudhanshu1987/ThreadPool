using System;
using System.Threading;

namespace ThreadsIfaces {
	public class MyThreadPoolExample {

		MyThreadPool pool = new MyThreadPool ();
//		Random random = new Random ();

		public static void Main (String[] args) {
			MyThreadPoolExample example = new MyThreadPoolExample ();
			example.runExample ();
		}

		private void runExample() {
			for (int i = 0; i < 20; ++i) {
				int index = i;
//				int time = random.Next (1000, 3000);
				int time = 1000;
				pool.QueueUserWorkItem (() => {
					Thread.Sleep (time);
					Console.WriteLine (String.Format("Hello from {0}, slept for {1}ms", index, time));
				});
			}

			Console.WriteLine ("Starting the jobs just in a moment...");
			Thread.Sleep (1000); // to show that jobs are queued until SetPoolSize is actualy invoked

			changePoolSize (3);
			changePoolSize (1);
			changePoolSize (0);
			changePoolSize (2);
		}

		private void changePoolSize(int size, int millis = 3500) {
			Console.WriteLine (String.Format(" -> Setting thread pool size to {0}", size));
			pool.SetPoolSize (size);
			Thread.Sleep (millis);
		}
	}
}

