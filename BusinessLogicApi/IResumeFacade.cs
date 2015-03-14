using System.Collections.Generic;
using DomainModel;

namespace XrmTestTask.BusinessLogicApi
{
    public interface IResumeFacade
    {
        void Grab();
        Page<Resume> Search(ResumeSearch search);
    }
}
