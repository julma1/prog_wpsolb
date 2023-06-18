using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;

namespace Data
{
    public abstract class DataAbstractApi
    {

        public abstract IBall GetBall(int count);
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract void StopLoggingTask();

        public abstract Task CreateLoggingTask(ConcurrentQueue<IBall> logQueue);

        public abstract void AppendObjectToJSONFile(string filename, string newJsonObject);
        
        public static DataAbstractApi CreateApi(int width, int height)
        {
            return new DataApi(width, height);
        }
    }


}
