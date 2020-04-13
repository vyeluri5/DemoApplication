using DemoApplication.Interfaces;
using System;

namespace DemoApplication.Application
{
    public class MyInterface : IMyInterface
    {
        public int Add()
        {
            return 2;
        }
    }
}
