﻿using System;

namespace nothinbutdotnetstore.utility.containers
{
    public class Depends
    {
        public static ContainerResolver container_resolver = delegate
        {
            throw new NotImplementedException("The container resolver needs to be set by a startup process"); 
        };

        public static IFetchDependencies on
        {
            get{ throw new NotImplementedException();}
        }
    }
}