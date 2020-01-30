using System.Collections.Generic;

namespace Service
{
    public interface IServiceResponse<T>
    {
        IList<T> List { get; set; }
        T Entity { get; set; }

        int Count { get; set; }

        bool IsSuccessful { get; set; }
    }
}
