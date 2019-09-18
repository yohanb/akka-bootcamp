﻿using System;
using Akka.Actor;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for serializing message writes to the console.
    /// (write one message at a time, champ :)
    /// </summary>
    class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case Messages.InputError inputError:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(inputError.Reason);
                    break;
                
                case Messages.InputSuccess inputSuccess:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(inputSuccess.Reason);
                    break;
                
                default:
                    Console.WriteLine(message);
                    break;
            }
            
            Console.ResetColor();
        }
    }
}
