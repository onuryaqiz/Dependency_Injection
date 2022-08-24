﻿using Dependency_Injection.Services.Interfaces;

namespace Dependency_Injection.Services
{
    public class TextLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("Text dosyasına loglama işlemi gerçekleştirildi. ");
        }
    }
}
