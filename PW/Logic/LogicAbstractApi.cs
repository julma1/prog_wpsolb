﻿using System.Collections;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public abstract IList CreateBalls(int count);
        public abstract IList DeleteBalls(int count);
        public abstract void Start();
        public abstract void Stop();
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        public static LogicAbstractApi CreateApi(int width, int height)
        {
            return new LogicApi(width, height);
        }
    }
}
