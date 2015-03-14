using System;
using System.Collections.Generic;
using DomainModel;

namespace XrmTestTask.E1ClientApi
{
    public interface IResumeClient
    {
        List<Resume> Grab();
    }
}
